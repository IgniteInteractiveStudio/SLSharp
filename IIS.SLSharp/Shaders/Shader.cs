using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Core;
using IIS.SLSharp.Diagnostics;
using IIS.SLSharp.Reflection;
using IIS.SLSharp.Runtime;
using IIS.SLSharp.Textures;
using IIS.SLSharp.Translation;
using Mono.Cecil;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using FieldAttributes = System.Reflection.FieldAttributes;
using MethodAttributes = System.Reflection.MethodAttributes;
using TypeAttributes = System.Reflection.TypeAttributes;

namespace IIS.SLSharp.Shaders
{
    /// <summary>
    /// Base class of which all typed GLSL shaders derive of
    /// </summary>
    public abstract class Shader : ShaderDefinition, IDisposable
    {
        private const BindingFlags BindingFlagsAny =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        [ReflectionMarker(ReflectionToken.ShaderName)]
        public int Name { get; private set; }

        public static bool DebugMode { get; set; }

        private readonly string _uniforms;

        private readonly string _varyings;

        private readonly string _ins;

        private readonly string _outs;

        private readonly string _ffuns;

        private readonly string _vfuns;

        private readonly string _fentry;

        private readonly string _ventry;

        private bool _vsCompiled;

        private bool _fsCompiled;

        private static int _quadVbo;

        private static int _refCount;

        private static readonly ShaderDebugger _debugger = new ShaderDebugger();

        private readonly List<int> _objects = new List<int>();

#if DEBUG

        /// <summary>
        /// Dumps the GLSL shader to a file for debugging purposes
        /// </summary>
        /// <param name="type">The shader type that is to be dumped</param>
        /// <param name="s">The shader source to be dumped</param>
        private void Dump(ShaderType type, string s)
        {
            var fn = GetType().Name + "." + type;

            using (var f = new StreamWriter(fn, false))
                f.Write(s);
        }

#endif

        private Type GetImplementingType()
        {
            var t = GetType();
            var bt = GetShaderType();

            // ReSharper disable PossibleNullReferenceException
            while (t.BaseType != bt)
            // ReSharper restore PossibleNullReferenceException
                t = t.BaseType;

            return t;
        }

        private Type GetShaderType()
        {
            var t = GetType();

            // ReSharper disable PossibleNullReferenceException
            while (t.BaseType != typeof(Shader))
            // ReSharper restore PossibleNullReferenceException
                t = t.BaseType;

            return t;
        }

        public string VertexShader
        {
            get
            {
                var src = _uniforms;
                src += _varyings.Replace("varying ", "out ");
                src += _ins;
                //src += _outs;
                src += _vfuns;
                src += _ventry;
                return src;
            }
        }

        public string FragmentShader
        {
            get
            {
                var src = _uniforms;
                src += _varyings.Replace("varying ", "in ");
                //src += _ins;
                src += _outs;
                src += _ffuns;
                src += _fentry;
                return src;
            }
        }

        /// <summary>
        /// Compiles the shader as GLSL shader.
        /// </summary>
        /// <param name="type">The shader type to construct and compile.</param>
        /// <param name="version">The GLSL version to use</param>
        private void CompileShader(ShaderType type, int version)
        {
            if (version < 130)
                throw new Exception("Versions < 130 are deprecated");

            var src = "#version " + version + Environment.NewLine;

            if (version >= 130)
            {
                if (type == ShaderType.FragmentShader)
                    src += "precision highp float;" + Environment.NewLine;

                if (type == ShaderType.VertexShader)
                    src += "in vec4 gl_Vertex;" + Environment.NewLine; // should we disallow this?
            }

            switch (type)
            {
                case ShaderType.VertexShader:
                    if (_vsCompiled)
                        return;

                    _vsCompiled = true;
                    src += VertexShader;
                    break;
                case ShaderType.FragmentShader:
                    if (_fsCompiled)
                        return;

                    _fsCompiled = true;
                    src += FragmentShader;
                    break;
                default:
                    throw new NotImplementedException();
            }

            var shader = GL.CreateShader(type);
            Utilities.CheckGL();

            GL.ShaderSource(shader, src);
            GL.CompileShader(shader);
            int compileResult;
            GL.GetShader(shader, ShaderParameter.CompileStatus, out compileResult);
            string info;
            GL.GetShaderInfoLog(shader, out info);

#if DEBUG

            Dump(type, src);

#endif

            if (compileResult != 1)
            {
                // TODO: Throw a proper informative exception
                //Dump(type, src);
                throw new Exception(info);
            }

            if (info != string.Empty)
                Console.WriteLine(info);

            _objects.Add(shader);
        }

        private bool HasType(Type t)
        {
            return GetType().GetMethods(BindingFlagsAny).Any(m => m.GetCustomAttributes(t, false).Length != 0);
        }

        /// <summary>
        /// Compiles Fragment as well as Vertex shader any exists.
        /// </summary>
        /// <param name="version">The GLSL version to use</param>
        public void Compile(int version = 130)
        {
            if (HasType(typeof(FragmentShaderAttribute)))
                CompileShader(ShaderType.FragmentShader, version);

            if (HasType(typeof(VertexShaderAttribute)))
                CompileShader(ShaderType.VertexShader, version);
        }

        /// <summary>
        /// Links other shaders against this shader.
        /// A derived shader that uses other shaders must call
        /// Link within its constructor and pass all shaders it will access.
        /// </summary>
        /// <param name="libaries">The external shaders to be linked</param>
        /// <param name="version">The GLSL version to use to compile this shader</param>
        protected void Link(Shader[] libaries = null, int version = 130)
        {
            Compile(version);
            Name = GL.CreateProgram();

            if (libaries != null)
            {
                foreach (var lib in libaries)
                    lib.Compile();

                foreach (var obj in libaries.SelectMany(lib => lib._objects))
                    GL.AttachShader(Name, obj);
            }           

            foreach (var obj in _objects)
                GL.AttachShader(Name, obj);

            GL.LinkProgram(Name);

            // now we can pull and cache uniform locations
            CacheUniforms();
        }

        private static readonly Dictionary<string, string> _globalNames = new Dictionary<string, string>();

        private static readonly ITexture[] _textures = new ITexture[32];

        private static int _currentTextureUnit;

        /// <summary>
        /// Utility function that binds a texture to the next free texture unit.
        /// </summary>
        /// <param name="tex">The texture to bind</param>
        /// <returns>The texture unit reserved. Pass this to a sampler uniform.</returns>
        protected static int BindTexture(ITexture tex)
        {
            var idx = _currentTextureUnit++;
            BindTexture(tex, idx);
            return idx;
        }

        /// <summary>
        /// Binds a texture to an explicit given texture unit.
        /// This will not reserve a unit.
        /// </summary>
        /// <param name="tex">The texture to bind</param>
        /// <param name="slot">The unit to use</param>
        protected static void BindTexture(ITexture tex, int slot)
        {
            GL.ActiveTexture(TextureUnit.Texture0 + slot);
            _textures[slot] = tex;
            tex.Activate();
        }

        /// <summary>
        /// Reserves a texture unit without binding a texture to it yet.
        /// A texture can later be bound with the explicit BindTexture version.
        /// </summary>
        /// <returns></returns>
        protected static int AllocateSamplerSlot()
        {
            return _currentTextureUnit++;
        }

        /// <summary>
        /// Unbinds all textures from all units
        /// </summary>
        protected static void UnbindTextures()
        {
            for (var i = 0; i < _textures.Length; i++ )
            {
                if (_textures[i] != null)
                {
                    GL.ActiveTexture(TextureUnit.Texture0 + i);
                    _textures[i].Finish();
                }

                _textures[i] = null;
            }

            _currentTextureUnit = 0;
            GL.ActiveTexture(TextureUnit.Texture0);
        }

        private sealed class PropInfo
        {
            public string Name { get; private set; }

            public MethodInfo Delegate { get; private set; }

            public PropInfo(string name, MethodInfo dele)
            {
                Name = name;
                Delegate = dele;
            }
        }

        private static MethodInfo GetHandler(ReflectionToken token)
        {
            return ReflectionMarkerAttribute.FindMethod(typeof(ShaderHelpers), token);
        }

        /// <summary>
        /// This map holds handlers to be called as uniform setters by the runtime derived
        /// shaders.
        /// </summary>
        private static readonly Dictionary<Type, PropInfo> _typeMap = new Dictionary<Type, PropInfo>
        {
            // TODO: what do we do for double? ...
            { typeof(float), new PropInfo("float", typeof(GL).GetMethod("Uniform1", new[] { typeof(int), typeof(float) })) },
            { typeof(vec2), new PropInfo("vec2", GetHandler(ReflectionToken.ShaderVec2Helper)) },
            { typeof(vec3), new PropInfo("vec3", GetHandler(ReflectionToken.ShaderVec3Helper)) },
            { typeof(vec4), new PropInfo("vec4", GetHandler(ReflectionToken.ShaderVec4Helper)) },
            { typeof(mat2), new PropInfo("mat2", GetHandler(ReflectionToken.ShaderUniformMatrix2X2Helper)) },
            { typeof(mat2x3), new PropInfo("mat2x3", GetHandler(ReflectionToken.ShaderUniformMatrix2X3Helper)) },
            { typeof(mat2x4), new PropInfo("mat2x4", GetHandler(ReflectionToken.ShaderUniformMatrix2X4Helper)) },
            { typeof(mat3x2), new PropInfo("mat3x2", GetHandler(ReflectionToken.ShaderUniformMatrix3X2Helper)) },
            { typeof(mat3), new PropInfo("mat3", GetHandler(ReflectionToken.ShaderUniformMatrix3X3Helper)) },
            { typeof(mat3x4), new PropInfo("mat3x4", GetHandler(ReflectionToken.ShaderUniformMatrix3X4Helper)) },
            { typeof(mat4x2), new PropInfo("mat4x2", GetHandler(ReflectionToken.ShaderUniformMatrix4X2Helper)) },
            { typeof(mat4x3), new PropInfo("mat4x3", GetHandler(ReflectionToken.ShaderUniformMatrix4X3Helper)) },
            { typeof(mat4), new PropInfo("mat4", GetHandler(ReflectionToken.ShaderUniformMatrix4X4Helper)) },
            { typeof(sampler1D), new PropInfo("sampler1D", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(sampler2D), new PropInfo("sampler2D", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(sampler3D), new PropInfo("sampler3D", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(samplerCube), new PropInfo("samplerCube", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(sampler1DShadow), new PropInfo("sampler1DShadow", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(sampler2DShadow), new PropInfo("sampler2DShadow", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(isampler1D), new PropInfo("isampler1D", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(isampler2D), new PropInfo("isampler2D", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(isampler3D), new PropInfo("isampler3D", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(isamplerCube), new PropInfo("isamplerCube", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(usampler1D), new PropInfo("usampler1D", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(usampler2D), new PropInfo("usampler2D", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(usampler3D), new PropInfo("usampler3D", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(usamplerCube), new PropInfo("usamplerCube", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(sampler2DRect), new PropInfo("sampler2DRect", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(sampler2DRectShadow), new PropInfo("sampler2DRectShadow", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(isampler2DRect), new PropInfo("isampler2DRect", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(usampler2DRect), new PropInfo("usampler2DRect", GetHandler(ReflectionToken.ShaderSamplerHelper)) },
            { typeof(int), new PropInfo("int", typeof(GL).GetMethod("Uniform1", new[] { typeof(int), typeof(int) })) },
            { typeof(ivec2), new PropInfo("ivec2", GetHandler(ReflectionToken.ShaderIvec2Helper)) },
            { typeof(ivec3), new PropInfo("ivec3", GetHandler(ReflectionToken.ShaderIvec3Helper)) },
            { typeof(ivec4), new PropInfo("ivec4", GetHandler(ReflectionToken.ShaderIvec4Helper)) },
            { typeof(uint), new PropInfo("uint", typeof(GL).GetMethod("Uniform1", new[] { typeof(int), typeof(uint) })) },
            { typeof(uvec2), new PropInfo("uvec2", GetHandler(ReflectionToken.ShaderUvec2Helper)) },
            { typeof(uvec3), new PropInfo("uvec3", GetHandler(ReflectionToken.ShaderUvec3Helper)) },
            { typeof(uvec4), new PropInfo("uvec4", GetHandler(ReflectionToken.ShaderUvec4Helper)) },
            { typeof(double), new PropInfo("double", typeof(GL).GetMethod("Uniform1", new[] { typeof(int), typeof(double) })) },
            { typeof(dvec2), new PropInfo("dvec2", GetHandler(ReflectionToken.ShaderDvec2Helper)) },
            { typeof(dvec3), new PropInfo("dvec3", GetHandler(ReflectionToken.ShaderDvec3Helper)) },
            { typeof(dvec4), new PropInfo("dvec4", GetHandler(ReflectionToken.ShaderDvec4Helper)) },
        };

        /// <summary>
        /// Generates a string that forward declarates all functions used within a shader.
        /// </summary>
        /// <param name="functions"></param>
        /// <returns></returns>
        private static string ForwardDeclare(IEnumerable<string> functions)
        {
            return functions.Aggregate(string.Empty, (a, b) => a + b + ";" + Environment.NewLine) + Environment.NewLine;
        }

        /// <summary>
        /// Collects the sources of all functions within this shader
        /// </summary>
        /// <typeparam name="T">Specifies which shader type to collect for</typeparam>
        /// <param name="entryPoint">Returns the name of the function flagged as entrypoint</param>
        /// <returns>A string containing the GLSL code for all collected functions</returns>
        private string CollectFuncs<T>(out string entryPoint)
            where T : IShaderAttribute
        {
            entryPoint = string.Empty;
            var body = string.Empty;
            var hasEntry = false;

            var trans = new GlslTransform();
            foreach (var m in GetType().GetMethods(BindingFlagsAny))
            {
                var attrs = m.GetCustomAttributes(typeof(T), false);
                if (attrs.Length == 0)
                    continue;

                var attr = (T)attrs[0];
                if (attr.EntryPoint)
                {
                    if (hasEntry)
                        throw new Exception("Shader cannot have two entry points.");

                    if (m.GetParameters().Length != 0)
                        throw new Exception("Entry point must not have parameters.");

                    hasEntry = true;
                }

                body += trans.Transform(m, attr) + Environment.NewLine;
            }

            //var body = (from m in GetType().GetMethods(BindingFlagsAny)
            //            let attrs = m.GetCustomAttributes(typeof(T), false)
            //            where attrs.Length != 0
            //            select m).Aggregate(string.Empty, (current, m) => current + trans.Transform(m));
            return ForwardDeclare(trans.Functions) + body;
        }

        /// <summary>
        /// Looks up a unique shared name to be used in GLSL
        /// </summary>
        /// <param name="key">The native name to look up</param>
        /// <returns>The (obfuscated) shared GLSL name</returns>
        private static string GetGlobalName(string key)
        {
            string name;
            if (!_globalNames.TryGetValue(key, out name))
            {
                name = key.Split('.').Last();
                if (_globalNames.Values.Contains(name))
                {
                    var ctr = 1;
                    while (_globalNames.Values.Contains(name + ctr))
                        ctr++;
                    name = name + ctr;
                }
#if DEBUG
                //name = key.Replace("@", "_").Replace(".", "_").Replace("__", "_s_");
                _globalNames[key] = name;
#else
                name = "_v" + _globalNames.Count;
                _globalNames[key] = name;            
#endif
            }
            return name;
        }


        public static string GetUniformName(PropertyInfo prop)
        {
            var fullName = "U@" + prop.DeclaringType.FullName + "." + prop.Name;
            return GetGlobalName(fullName);
        }

        public static string GetUniformName(IMemberDefinition prop)
        {
            var fullName = "U@" + prop.DeclaringType.FullName + "." + prop.Name;
            return GetGlobalName(fullName);
        }

        public static string GetVaryingName(FieldInfo prop)
        {
            var fullName = "P@" + prop.DeclaringType.FullName + "." + prop.Name;
            return GetGlobalName(fullName);
        }

        public static string GetVaryingName(IMemberDefinition prop)
        {
            var fullName = "P@" + prop.DeclaringType.FullName + "." + prop.Name;
            return GetGlobalName(fullName);
        }

        public static string GetMethodName(IMemberDefinition prop)
        {
            var fullName = "M@" + prop.DeclaringType.FullName + "." + prop.Name;
            return GetGlobalName(fullName);
        }

        public static string GetMethodName(MethodInfo prop)
        {
            var fullName = "M@" + prop.DeclaringType.FullName + "." + prop.Name;
            return GetGlobalName(fullName);
        }


        /// <summary>
        /// Builds a string containing all uniform declarations.
        /// </summary>
        /// <returns>A string containing all uniform declarations.</returns>
        private string CollectUniforms()
        {
            return (from prop in GetShaderType().GetProperties(BindingFlagsAny)
                    let attrs = prop.GetCustomAttributes(typeof(UniformAttribute), false)
                    where attrs.Length != 0
                    let attr = (UniformAttribute)attrs[0]
                    let glslType = attr.ExplicitName ?? _typeMap[prop.PropertyType].Name
                    let name = GetUniformName(prop)
#if DEBUG
                    let comment = " // " + prop.DeclaringType.FullName + "." + prop.Name
#else
                    let comment = "";
#endif
                    select "uniform " + glslType + " " + name + ";" + comment).Aggregate(string.Empty, (current, glslVar) =>
                        current + (glslVar + Environment.NewLine));
        }

        /// <summary>
        /// Builds a string containing all varying declarations.
        /// </summary>
        /// <returns>A string containing all varying declarations.</returns>
        private string CollectVaryings()
        {
            return (from field in GetShaderType().GetFields(BindingFlagsAny)
                    let attrs = field.GetCustomAttributes(typeof(VaryingAttribute), false)
                    where attrs.Length != 0
                    let attr = (VaryingAttribute)attrs[0]
                    let glslType = GlslVisitor.ToGlslType((field).FieldType)
                    let name = GetVaryingName(field)
#if DEBUG
                    let comment = " // " + field.DeclaringType.FullName + "." + field.Name
#else
                    let comment = "";
#endif
                    select "varying " + glslType + " " + name + ";" + comment).Aggregate(string.Empty, (current, glslVar) =>
                        current + (glslVar + Environment.NewLine));
        }

        /// <summary>
        /// Builds a string containing all in declarations.
        /// </summary>
        /// <returns>A string containing all in declarations.</returns>
        private string CollectIns()
        {
            var s1 = (from field in GetShaderType().GetFields(BindingFlagsAny)
                      let attrs = field.GetCustomAttributes(typeof(VertexInAttribute), false)
                      where attrs.Length != 0
                      let attr = (VertexInAttribute)attrs[0]
                      let glslType = GlslVisitor.ToGlslType((field).FieldType)
                      let name = GetVaryingName(field)
#if DEBUG
                      let comment = " // " + field.DeclaringType.FullName + "." + field.Name
#else
                      let comment = "";
#endif

                      select "in " + glslType + " " + name + ";" + comment).Aggregate(string.Empty, (current, glslVar) =>
                          current + (glslVar + Environment.NewLine));

            // TODO: what was this supposed to be good for?
            // should have documented might be bugged?
            var s2 = (from prop in GetShaderType().GetProperties(BindingFlagsAny)
                      let attrs = prop.GetCustomAttributes(typeof(VertexInAttribute), false)
                      where attrs.Length != 0
                      let attr = (VertexInAttribute)attrs[0]
                      let glslType = _typeMap[prop.PropertyType].Name
                      let name = GetUniformName(prop)
#if DEBUG
                      let comment = " // " + prop.DeclaringType.FullName + "." + prop.Name
#else
                      let comment = "";
#endif
                      select "uniform " + glslType + " " + name + ";" + comment).Aggregate(string.Empty, (current, glslVar) =>
                          current + (glslVar + Environment.NewLine));

            return s1 + s2;
        }

        /// <summary>
        /// Builds a string containing all out declarations.
        /// </summary>
        /// <returns>A string containing all out declarations.</returns>
        private string CollectOuts()
        {
            return (from field in GetShaderType().GetFields(BindingFlagsAny)
                    let attrs = field.GetCustomAttributes(typeof(FragmentOutAttribute), false)
                    where attrs.Length != 0
                    let attr = (FragmentOutAttribute)attrs[0]
                    let glslType = GlslVisitor.ToGlslType((field).FieldType)
                    let name = GetVaryingName(field)
#if DEBUG
                    let comment = " // " + field.DeclaringType.FullName + "." + field.Name
#else
                    let comment = "";
#endif
                    select "out " + glslType + " " + name + ";").Aggregate(string.Empty, (current, glslVar) =>
                        current + (glslVar + Environment.NewLine));
        }

        protected Shader()
        {
            RefShaders();
            _ffuns = CollectFuncs<FragmentShaderAttribute>(out _fentry);
            _vfuns = CollectFuncs<VertexShaderAttribute>(out _ventry);
            _varyings = CollectVaryings();
            _uniforms = CollectUniforms();
            _ins = CollectIns();
            _outs = CollectOuts();
        }

        /// <summary>
        /// Overload this for derived shaders that need setup code.
        /// </summary>
        [ReflectionMarker(ReflectionToken.ShaderActivate)]
        protected void Activate()
        {
            if (Name == 0)
                return; // it's a lib

            GL.UseProgram(Name); 
            Utilities.CheckGL();
        }

        /// <summary>
        /// Call this in derived shaders .Activate for any external
        /// shader that is going to be accessed.
        /// </summary>
        /// <param name="main"></param>
        public void BeginLibrary(Shader main)
        {
            Name = main.Name;
            CacheUniforms();
            Begin();
        }

        /// <summary>
        /// Binds the shader
        /// </summary>
        [ReflectionMarker(ReflectionToken.ShaderBegin)]
        public virtual void Begin()
        {
            if (DebugMode)
                _debugger.BeginDebug(this);
        }

        /// <summary>
        /// Unbinds the shader
        /// </summary>
        public virtual void End()
        {
            // render all texture units to debug output here
            // depending on DebugMode

            UnbindTextures();
            GL.UseProgram(0);

            if (DebugMode)
                _debugger.EndDebug();
        }

        public virtual void Dispose()
        {
            if (Name == 0) 
                return;

            DerefShaders();
            GL.DeleteProgram(Name);
            Name = 0;
        }

        private static readonly Dictionary<Type, ConstructorInfo> _ctors = new Dictionary<Type, ConstructorInfo>();

        private void CacheUniforms()
        {
            var typ = GetShaderType();
            var impl = GetImplementingType();

            foreach (var prop in typ.GetProperties(BindingFlagsAny))
            {
                var attr = prop.GetCustomAttributes(typeof (UniformAttribute), false);
                if (attr.Length == 0)
                    continue;

                var f = impl.GetField("m_" + prop.Name, BindingFlagsAny);
                if (f == null)
                    throw new Exception("Could not retrieve uniform implementation!");

                var name = GetUniformName(prop);
                var loc = GL.GetUniformLocation(Name, name);
                f.SetValue(this, loc);

                //var f = typeBuilder.DefineField("m_" + prop.Name, typeof(int), FieldAttributes.Private);
            }
        }

        /// <summary>
        /// Reflection utility that implements a shader around any user defined shader.
        /// Creating code for any uniform defined.
        /// </summary>
        /// <typeparam name="T">The shader type to derive from</typeparam>
        /// <returns>A constructor to the derived type</returns>
        private static ConstructorInfo GetConstructor<T>()
        {
            var baseBegin = ReflectionMarkerAttribute.FindMethod(
                 typeof(Shader), ReflectionToken.ShaderBegin);

            var typ = typeof(T);
            if (typ.IsNotPublic)
                throw new Exception("Type " + typ.Name + " must be public");

            ConstructorInfo ctor;
            if (_ctors.TryGetValue(typ, out ctor))
            {
                try
                {
                    return ctor;
                }
                catch (Exception e)
                {
                    throw e.InnerException;
                }
            }

            var assemblyName = new AssemblyName { Name = "tmp_" + typ.Name };
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var module = assemblyBuilder.DefineDynamicModule("tmpModule");
            var typeBuilder = module.DefineType(typ.Name + "_impl", TypeAttributes.Public | TypeAttributes.Class, typ);

            var beginFun = typeBuilder.DefineMethod(baseBegin.Name, MethodAttributes.Virtual | MethodAttributes.Public, typeof(void), Type.EmptyTypes);
            var ilBeg = beginFun.GetILGenerator();

            var getName = ReflectionMarkerAttribute.FindProperty(
                typeof(Shader), ReflectionToken.ShaderName).GetGetMethod();

            var nameIndex = ilBeg.DeclareLocal(typeof(int)).LocalIndex;

            var shaderActivate = ReflectionMarkerAttribute.FindMethod(
                typeof(Shader), ReflectionToken.ShaderActivate);

            ilBeg.Emit(OpCodes.Ldarg, 0);
            ilBeg.Emit(OpCodes.Call, shaderActivate);
            ilBeg.Emit(OpCodes.Ldarg, 0);
            ilBeg.Emit(OpCodes.Call, getName);
            ilBeg.Emit(OpCodes.Stloc, nameIndex);

            foreach (var prop in typ.GetProperties(BindingFlagsAny))
            {
                var attr = prop.GetCustomAttributes(typeof(UniformAttribute), false);
                if (attr.Length == 0)
                    continue;

                var uniformCall = _typeMap[prop.PropertyType].Delegate;
                var f = typeBuilder.DefineField("m_" + prop.Name, typeof(int), FieldAttributes.Private);
                //var visibility = prop.PropertyType.IsPublic ? MethodAttributes.Public : MethodAttributes.Family;
                const MethodAttributes visibility = MethodAttributes.Public;

                var getter = prop.GetSetMethod() != null ? prop.GetGetMethod().Name : "get_" + prop.Name;
                var setter = prop.GetSetMethod() != null ? prop.GetSetMethod().Name : "set_" + prop.Name;

                var m = typeBuilder.DefineMethod(setter, MethodAttributes.Virtual | visibility, typeof(void), new[] { prop.PropertyType });
                var ilg = m.GetILGenerator();

                ilg.Emit(OpCodes.Ldarg, 0);
                ilg.Emit(OpCodes.Ldfld, f);

                if (uniformCall.GetParameters().Length == 2)
                    ilg.Emit(OpCodes.Ldarg, 1);

                ilg.Emit(OpCodes.Call, uniformCall);
                ilg.Emit(OpCodes.Ret);

                m = typeBuilder.DefineMethod(getter, MethodAttributes.Virtual | visibility, prop.PropertyType, Type.EmptyTypes);
                ilg = m.GetILGenerator();

                ilg.Emit(OpCodes.Newobj, typeof(NotImplementedException));
                ilg.Emit(OpCodes.Throw);
            }

            ilBeg.Emit(OpCodes.Ldarg, 0);
            ilBeg.Emit(OpCodes.Call, typ.GetMethod(baseBegin.Name, Type.EmptyTypes));
            ilBeg.Emit(OpCodes.Ret);

            // implement in accessors
            foreach (var prop in typ.GetProperties(BindingFlagsAny))
            {
                var attr = prop.GetCustomAttributes(typeof(VertexInAttribute), false);
                if (attr.Length == 0)
                    continue;

                var getter = prop.GetSetMethod() != null ? prop.GetGetMethod().Name : "get_" + prop.Name;
                var setter = prop.GetSetMethod() != null ? prop.GetSetMethod().Name : "set_" + prop.Name;
                //var visibility = prop.PropertyType.IsPublic ? MethodAttributes.Public : MethodAttributes.Family;
                const MethodAttributes visibility = MethodAttributes.Public;

                var m = typeBuilder.DefineMethod(setter, MethodAttributes.Virtual | visibility, typeof(void), new[] { prop.PropertyType });
                var ilg = m.GetILGenerator();
                ilg.Emit(OpCodes.Newobj, typeof(NotImplementedException));
                ilg.Emit(OpCodes.Throw);

                m = typeBuilder.DefineMethod(getter, MethodAttributes.Virtual | visibility, prop.PropertyType, Type.EmptyTypes);
                ilg = m.GetILGenerator();
                ilg.Emit(OpCodes.Newobj, typeof(NotImplementedException));
                ilg.Emit(OpCodes.Throw);
            }

            var timpl = typeBuilder.CreateType();
            ctor = timpl.GetConstructor(Type.EmptyTypes);
            _ctors[typ] = ctor;
            return ctor;
        }

        /// <summary>
        /// Creates a shared instance of a shader.
        /// The instance will only be freed when Dispose() is called as often as
        /// this same shadertype has been constructed via this helper.
        /// </summary>
        /// <typeparam name="T">The shadertype to create</typeparam>
        /// <returns>The shader instance</returns>
        public static T CreateSharedShader<T>() where T: Shader
        {
            var ctor = GetConstructor<T>();
            return (T)ResourceManager.Instance(ctor.DeclaringType, null, null);
        }

        /// <summary>
        /// Creates a non shared instance of a shader
        /// </summary>
        /// <typeparam name="T">The shadertype to create</typeparam>
        /// <returns>The shader instance</returns>
        public static T CreateInstance<T>() where T: Shader
        {
            var ctor = GetConstructor<T>();

            try
            {
                return (T)ctor.Invoke(new object[0]);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        [Obsolete]
        public static string ResolveName(Type t, string name)
        {
            var prop = t.GetProperty(name, BindingFlagsAny);
            var field = t.GetField(name, BindingFlagsAny);

            if (prop != null &&
                (prop.GetCustomAttributes(typeof(UniformAttribute), false).Length != 0 ||
                prop.GetCustomAttributes(typeof(VertexInAttribute), false).Length != 0))
                return GetUniformName(prop);

            if (field != null &&
                (field.GetCustomAttributes(typeof(VaryingAttribute), false).Length != 0 ||
                field.GetCustomAttributes(typeof(VertexInAttribute), false).Length != 0 ||
                field.GetCustomAttributes(typeof(FragmentOutAttribute), false).Length != 0))
                return GetVaryingName(field);

            return name;
        }

        private static readonly string[] _attribStrings = new[]
        {
            typeof(VaryingAttribute).FullName,
            typeof(VertexInAttribute).FullName,
            typeof(FragmentOutAttribute).FullName,
        };

        private static readonly string _uniformString = typeof (UniformAttribute).FullName;

        [Obsolete]
        public static string ResolveName(FieldDefinition member)
        {
            return member.CustomAttributes.Any(x => _attribStrings.Contains(x.AttributeType.FullName)) ?
                GetVaryingName(member) : member.Name;
        }

        [Obsolete]
        public static string ResolveName(PropertyDefinition member)
        {
            return member.CustomAttributes.Any(x => _attribStrings.Contains(x.AttributeType.FullName)) ?
                GetUniformName(member) : member.Name;
        }

        public static string ResolveName(IMemberDefinition member)
        {
            if (member is MethodDefinition)
                return GetMethodName(member);

            if (member.CustomAttributes.Any(x => _attribStrings.Contains(x.AttributeType.FullName)))
                return GetVaryingName(member);

            if (member.CustomAttributes.Any(x => x.AttributeType.FullName == _uniformString))
                return GetUniformName(member);

            return member.Name;
        }

        [Obsolete]
        public static string ResolveName(MemberInfo member)
        {
            if (member.MemberType == MemberTypes.Method)
                return GetMethodName(member as MethodInfo);
            
            if (member.GetCustomAttributes(typeof(VaryingAttribute), false).Length != 0 ||
                member.GetCustomAttributes(typeof(VertexInAttribute), false).Length != 0 ||
                member.GetCustomAttributes(typeof(FragmentOutAttribute), false).Length != 0)
                return GetVaryingName(member as FieldInfo);

            return member.Name;
        }

        public static int AttributeLocation<T>(Shader shader, Expression<Func<T>> expr)
        {
            var body = ((MemberExpression)expr.Body);
            var globalName = GetVaryingName(body.Member as FieldInfo);
            var loc = GL.GetAttribLocation(shader.Name, globalName);
            Utilities.CheckGL();
            return loc;
        }

        // TODO: should move this static stuff to seperate file!
        private static void RefShaders()
        {
            if (_refCount == 0)
                StaticInit();

            _refCount++;
        }

        private static void DerefShaders()
        {
            _refCount--;
            if (_refCount == 0)
                StaticDispose();
        }

        private static void StaticInit()
        {
            var data = new[]
            {
                new Vector2(-1.0f, -1.0f),
                new Vector2(1.0f, -1.0f),
                new Vector2(1.0f, 1.0f),
                new Vector2(-1.0f, 1.0f),
                new Vector2(0.0f, 0.0f),
                new Vector2(1.0f, 0.0f),
                new Vector2(1.0f, 1.0f),
                new Vector2(0.0f, 1.0f),
            };

            GL.GenBuffers(1, out _quadVbo);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _quadVbo);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(Marshal.SizeOf(typeof(Vector2)) * data.Length), 
                data, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        private static void StaticDispose()
        {
            GL.DeleteBuffers(1, ref _quadVbo);
        }

        private static void RenderQuad(int loca, int startIdx)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, _quadVbo);
            GL.VertexAttribPointer(loca, 2, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(loca);
            GL.DrawArrays(BeginMode.Quads, startIdx, 4);
            GL.DisableVertexAttribArray(loca);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public static void RenderQuad(Shader shader, int location)
        {
            RenderQuad(location, 0);
        }

        public static void RenderQuad<T>(Shader shader, Expression<Func<T>> vertexLocation)
        {
            var loca = AttributeLocation(shader, vertexLocation);
            RenderQuad(loca, 0);
        }

        public static void RenderPositiveQuad(Shader shader, int location)
        {
            RenderQuad(location, 4);
        }

        public static void RenderPositiveQuad<T>(Shader shader, Expression<Func<T>> vertexLocation)
        {
            var loca = AttributeLocation(shader, vertexLocation);
            RenderQuad(loca, 4);
        }
    }
}
