using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Bindings;
using IIS.SLSharp.Descriptions;
using IIS.SLSharp.Reflection;
using IIS.SLSharp.Runtime;
using Mono.Cecil;
using System.Collections.Generic;
using FieldAttributes = System.Reflection.FieldAttributes;
using MethodAttributes = System.Reflection.MethodAttributes;
using TypeAttributes = System.Reflection.TypeAttributes;

namespace IIS.SLSharp.Shaders
{
    /// <summary>
    /// Base class of which all typed GLSL shaders derive of
    /// </summary>
    public abstract partial class Shader : ShaderDefinition, IDisposable
    {
        private const BindingFlags BindingFlagsAny =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        [ReflectionMarker(ReflectionToken.ShaderName)]
        public IProgram Program { get; private set; }

        public static bool DebugMode { get; set; }

        private readonly ShaderContext _context;

        private bool _vsCompiled;

        private bool _fsCompiled;

        private static int _refCount;

        private readonly List<object> _objects = new List<object>();

        private Shader _parentLogic;

        private List<Type> _dependencies = new List<Type>(); // SL# shaders, this shader depends on

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
            while (t.Assembly.IsDynamic)
            // ReSharper restore PossibleNullReferenceException
                t = t.BaseType;

            return t;
        }

        /// <summary>
        /// Compiles the shader as GLSL shader.
        /// </summary>
        /// <param name="type">The shader type to construct and compile.</param>
        private void CompileShader(ShaderType type)
        {
            ShaderContext.UnitContext unit;
            switch (type)
            {
                case ShaderType.VertexShader:
                    if (_vsCompiled)
                        return;

                    _vsCompiled = true;
                    unit = _context.VertexUnit;
                    break;
                case ShaderType.FragmentShader:
                    if (_fsCompiled)
                        return;

                    _fsCompiled = true;
                    unit = _context.FragmentUnit;
                    break;
                default:
                    throw new NotImplementedException();
            }

            var desc = new SourceDescription(unit.Functions, _context.Uniforms, _context.Attribs, _context.Varyings, _context.Ins, _context.Outs, 
                unit.ForwardDeclarations);

            var shader = Binding.Active.Compile(this, type, desc);

            _dependencies = _dependencies.Union(unit.Dependencies).ToList();
            _objects.Add(shader);
        }

        private bool HasType(Type t)
        {
            return GetType().GetMethods(BindingFlagsAny).Any(m => m.GetCustomAttributes(t, false).Length != 0);
        }

        /// <summary>
        /// Compiles Fragment as well as Vertex shader any exists.
        /// </summary>
        protected void Compile()
        {
            if (HasType(typeof(FragmentShaderAttribute)))
                CompileShader(ShaderType.FragmentShader);

            if (HasType(typeof(VertexShaderAttribute)))
                CompileShader(ShaderType.VertexShader);
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
            var compiled = new HashSet<Type>();

            // compile main unit
            var e = Enumerable.Empty<object>();
            Compile();
            e = e.Concat(_objects);

            foreach (var dep in _dependencies)
            {
                if (!compiled.Add(dep))
                    continue;

                using (var tmp = CreateSharedShader(dep))
                {
                    tmp.Compile();
                    e = e.Concat(tmp._objects);
                }
            }

            Program = Binding.Active.Link(this, e);
            CacheUniforms();
        }

        private static readonly Dictionary<string, string> _globalNames = new Dictionary<string, string>();

        private static readonly object[] _textures = new object[32];

        private static int _currentTextureUnit;

        /// <summary>
        /// Utility function that binds a texture to the next free texture unit.
        /// </summary>
        /// <param name="tex">The texture to bind</param>
        /// <returns>The texture unit reserved. Pass this to a sampler uniform.</returns>
        protected static int BindTexture(object tex)
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
        protected static void BindTexture(object tex, int slot)
        {
            _textures[slot] = tex;
            Binding.Active.TexActivate(slot, tex);
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
                    Binding.Active.TexFinish(i, _textures[i]);

                _textures[i] = null;
            }

            _currentTextureUnit = 0;
            Binding.Active.TexReset();
        }

        internal sealed class PropInfo
        {
            public Type Type { get; private set; }

            public ReflectionToken Token { get; private set; }

            public PropInfo(Type type, ReflectionToken token)
            {
                Type = type;
                Token = token;
            }
        }

        /// <summary>
        /// This map holds handlers to be called as uniform setters by the runtime derived
        /// shaders.
        /// </summary>
        // TODO: could need some simplifications ...
        internal static readonly Dictionary<int, PropInfo> TypeMap = new Dictionary<int, PropInfo>
        {
            { typeof(void).MetadataToken, new PropInfo(typeof(void), ReflectionToken.NullToken) },
            { typeof(float).MetadataToken, new PropInfo(typeof(float), ReflectionToken.ShaderVec1Helper) },
            { typeof(vec2).MetadataToken, new PropInfo(typeof(vec2), ReflectionToken.ShaderVec2Helper) },
            { typeof(vec3).MetadataToken, new PropInfo(typeof(vec3), ReflectionToken.ShaderVec3Helper) },
            { typeof(vec4).MetadataToken, new PropInfo(typeof(vec4), ReflectionToken.ShaderVec4Helper) },
            { typeof(mat2).MetadataToken, new PropInfo(typeof(mat2), ReflectionToken.ShaderUniformMatrix2X2Helper) },
            { typeof(mat2x3).MetadataToken, new PropInfo(typeof(mat2x3), ReflectionToken.ShaderUniformMatrix2X3Helper) },
            { typeof(mat2x4).MetadataToken, new PropInfo(typeof(mat2x4), ReflectionToken.ShaderUniformMatrix2X4Helper) },
            { typeof(mat3x2).MetadataToken, new PropInfo(typeof(mat3x2), ReflectionToken.ShaderUniformMatrix3X2Helper) },
            { typeof(mat3).MetadataToken, new PropInfo(typeof(mat3), ReflectionToken.ShaderUniformMatrix3X3Helper) },
            { typeof(mat3x4).MetadataToken, new PropInfo(typeof(mat3x4), ReflectionToken.ShaderUniformMatrix3X4Helper) },
            { typeof(mat4x2).MetadataToken, new PropInfo(typeof(mat4x2), ReflectionToken.ShaderUniformMatrix4X2Helper) },
            { typeof(mat4x3).MetadataToken, new PropInfo(typeof(mat4x3), ReflectionToken.ShaderUniformMatrix4X3Helper) },
            { typeof(mat4).MetadataToken, new PropInfo(typeof(mat4), ReflectionToken.ShaderUniformMatrix4X4Helper) },
            { typeof(sampler1D).MetadataToken, new PropInfo(typeof(sampler1D), ReflectionToken.ShaderSamplerHelper) },
            { typeof(sampler2D).MetadataToken, new PropInfo(typeof(sampler2D), ReflectionToken.ShaderSamplerHelper) },
            { typeof(sampler3D).MetadataToken, new PropInfo(typeof(sampler3D), ReflectionToken.ShaderSamplerHelper) },
            { typeof(samplerCube).MetadataToken, new PropInfo(typeof(samplerCube), ReflectionToken.ShaderSamplerHelper) },
            { typeof(sampler1DShadow).MetadataToken, new PropInfo(typeof(sampler1DShadow), ReflectionToken.ShaderSamplerHelper) },
            { typeof(sampler2DShadow).MetadataToken, new PropInfo(typeof(sampler2DShadow), ReflectionToken.ShaderSamplerHelper) },
            { typeof(isampler1D).MetadataToken, new PropInfo(typeof(isampler1D), ReflectionToken.ShaderSamplerHelper) },
            { typeof(isampler2D).MetadataToken, new PropInfo(typeof(isampler2D), ReflectionToken.ShaderSamplerHelper) },
            { typeof(isampler3D).MetadataToken, new PropInfo(typeof(isampler3D), ReflectionToken.ShaderSamplerHelper) },
            { typeof(isamplerCube).MetadataToken, new PropInfo(typeof(isamplerCube), ReflectionToken.ShaderSamplerHelper) },
            { typeof(usampler1D).MetadataToken, new PropInfo(typeof(usampler1D), ReflectionToken.ShaderSamplerHelper) },
            { typeof(usampler2D).MetadataToken, new PropInfo(typeof(usampler2D), ReflectionToken.ShaderSamplerHelper) },
            { typeof(usampler3D).MetadataToken, new PropInfo(typeof(usampler3D), ReflectionToken.ShaderSamplerHelper) },
            { typeof(usamplerCube).MetadataToken, new PropInfo(typeof(usamplerCube), ReflectionToken.ShaderSamplerHelper) },
            { typeof(sampler2DRect).MetadataToken, new PropInfo(typeof(sampler2DRect), ReflectionToken.ShaderSamplerHelper) },
            { typeof(sampler2DRectShadow).MetadataToken, new PropInfo(typeof(sampler2DRectShadow), ReflectionToken.ShaderSamplerHelper) },
            { typeof(isampler2DRect).MetadataToken, new PropInfo(typeof(isampler2DRect), ReflectionToken.ShaderSamplerHelper) },
            { typeof(usampler2DRect).MetadataToken, new PropInfo(typeof(usampler2DRect), ReflectionToken.ShaderSamplerHelper) },
            { typeof(int).MetadataToken, new PropInfo(typeof(int), ReflectionToken.ShaderIvec1Helper) },
            { typeof(ivec2).MetadataToken, new PropInfo(typeof(ivec2), ReflectionToken.ShaderIvec2Helper) },
            { typeof(ivec3).MetadataToken, new PropInfo(typeof(ivec3), ReflectionToken.ShaderIvec3Helper) },
            { typeof(ivec4).MetadataToken, new PropInfo(typeof(ivec4), ReflectionToken.ShaderIvec4Helper) },
            { typeof(uint).MetadataToken, new PropInfo(typeof(uint), ReflectionToken.ShaderUvec1Helper) },
            { typeof(uvec2).MetadataToken, new PropInfo(typeof(uvec2), ReflectionToken.ShaderUvec2Helper) },
            { typeof(uvec3).MetadataToken, new PropInfo(typeof(uvec3), ReflectionToken.ShaderUvec3Helper) },
            { typeof(uvec4).MetadataToken, new PropInfo(typeof(uvec4), ReflectionToken.ShaderUvec4Helper) },
            { typeof(double).MetadataToken, new PropInfo(typeof(double), ReflectionToken.ShaderDvec1Helper) },
            { typeof(dvec2).MetadataToken, new PropInfo(typeof(dvec2), ReflectionToken.ShaderDvec2Helper) },
            { typeof(dvec3).MetadataToken, new PropInfo(typeof(dvec3), ReflectionToken.ShaderDvec3Helper) },
            { typeof(dvec4).MetadataToken, new PropInfo(typeof(dvec4), ReflectionToken.ShaderDvec4Helper) },
            { typeof(dmat2).MetadataToken, new PropInfo(typeof(dmat2), ReflectionToken.ShaderUniformDMatrix2X2Helper) },
            { typeof(dmat2x3).MetadataToken, new PropInfo(typeof(dmat2x3), ReflectionToken.ShaderUniformDMatrix2X3Helper) },
            { typeof(dmat2x4).MetadataToken, new PropInfo(typeof(dmat2x4), ReflectionToken.ShaderUniformDMatrix2X4Helper) },
            { typeof(dmat3x2).MetadataToken, new PropInfo(typeof(dmat3x2), ReflectionToken.ShaderUniformDMatrix3X2Helper) },
            { typeof(dmat3).MetadataToken, new PropInfo(typeof(dmat3), ReflectionToken.ShaderUniformDMatrix3X3Helper) },
            { typeof(dmat3x4).MetadataToken, new PropInfo(typeof(dmat3x4), ReflectionToken.ShaderUniformDMatrix3X4Helper) },
            { typeof(dmat4x2).MetadataToken, new PropInfo(typeof(dmat4x2), ReflectionToken.ShaderUniformDMatrix4X2Helper) },
            { typeof(dmat4x3).MetadataToken, new PropInfo(typeof(dmat4x3), ReflectionToken.ShaderUniformDMatrix4X3Helper) },
            { typeof(dmat4).MetadataToken, new PropInfo(typeof(dmat4), ReflectionToken.ShaderUniformDMatrix4X4Helper) },
            { typeof(bool).MetadataToken, new PropInfo(typeof(bool),  ReflectionToken.ShaderBvec1Helper) },
            { typeof(bvec2).MetadataToken, new PropInfo(typeof(bvec2), ReflectionToken.ShaderBvec2Helper) },
            { typeof(bvec3).MetadataToken, new PropInfo(typeof(bvec3), ReflectionToken.ShaderBvec3Helper) },
            { typeof(bvec4).MetadataToken, new PropInfo(typeof(bvec4), ReflectionToken.ShaderBvec4Helper) },
        };

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

                if (DebugMode)
                {
                    //name = key.Replace("@", "_").Replace(".", "_").Replace("__", "_s_");
                    _globalNames[key] = name;
                }
                else
                {
                    name = "_v" + _globalNames.Count;
                    _globalNames[key] = name;
                }
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

        protected Shader()
        {
            RefShaders();
            _context = new ShaderContext(GetShaderType());
        }

        /// <summary>
        /// Overload this for derived shaders that need setup code.
        /// </summary>
        [ReflectionMarker(ReflectionToken.ShaderActivate)]
        protected void Activate()
        {
            if (Program == null)
                return; // it's a lib
            Program.Activate();
        }

        /// <summary>
        /// Call this in derived shaders .Activate for any external
        /// shader that is going to be accessed.
        /// </summary>
        /// <param name="main"></param>
        public void BeginLibrary(Shader main)
        {
            Program = main.Program;
            CacheUniforms();
            Begin();
        }

        /// <summary>
        /// Binds the shader
        /// </summary>
        [ReflectionMarker(ReflectionToken.ShaderBegin)]
        public virtual void Begin()
        {
            // intentionally virtual (not abstract) in case we want to add
            // code here later on
        }

        /// <summary>
        /// Unbinds the shader
        /// </summary>
        public virtual void End()
        {
            // render all texture units to debug output here
            // depending on DebugMode

            UnbindTextures();
            Program.Finish();
        }

        public virtual void Dispose()
        {
            DisposeParent();
            if (Program == null) 
                return;

            DerefShaders();
            Program.Dispose();
            Program = null;
        }

        private void CompileParent()
        {
            var myType = GetShaderType();
            var parentType = myType.BaseType;
            if (parentType == typeof(Shader))
                return; // no parent logic defined

            _parentLogic = CreateSharedShader(parentType);
            _parentLogic.Compile();
        }

        private void DisposeParent()
        {
            if (_parentLogic != null)
                _parentLogic.Dispose();
            _parentLogic = null;
        }

        private static readonly Dictionary<Type, ConstructorInfo> _ctors = new Dictionary<Type, ConstructorInfo>();

        /// <summary>
        /// Caches uniform indices associated to a uniform with each
        /// [uniform] attributed property. The data is stored in a field
        /// named m_PropertyName which is defined within the runtime
        /// derived shader class
        /// </summary>
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
                var loc = Program.GetUniformIndex(name);
                f.SetValue(this, loc);

                //var f = typeBuilder.DefineField("m_" + prop.Name, typeof(int), FieldAttributes.Private);
            }
        }



        /// <summary>
        /// Reflection utility that implements a shader around any user defined shader.
        /// Creating code for any uniform defined.
        /// </summary>
        /// <param name="type">The shader type to derive from</param>
        /// <returns>A constructor to the derived type</returns>
        private static ConstructorInfo GetConstructor(Type type)
        {
            var baseBegin = ReflectionMarkerAttribute.FindMethod(
                 typeof(Shader), ReflectionToken.ShaderBegin);

            if (type.IsNotPublic)
                throw new Exception("Type " + type.Name + " must be public");

            ConstructorInfo ctor;
            if (_ctors.TryGetValue(type, out ctor))
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

            var assemblyName = new AssemblyName { Name = "tmp_" + type.Name };
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var module = assemblyBuilder.DefineDynamicModule("tmpModule");
            var typeBuilder = module.DefineType(type.Name + "_impl", TypeAttributes.Public | TypeAttributes.Class, type);

            var beginFun = typeBuilder.DefineMethod(baseBegin.Name, MethodAttributes.Virtual | MethodAttributes.Public, typeof(void), Type.EmptyTypes);
            var ilBeg = beginFun.GetILGenerator();

            var getName = ReflectionMarkerAttribute.FindProperty(
                typeof(Shader), ReflectionToken.ShaderName).GetGetMethod();

            var nameIndex = ilBeg.DeclareLocal(typeof(IProgram)).LocalIndex;

            var shaderActivate = ReflectionMarkerAttribute.FindMethod(
                typeof(Shader), ReflectionToken.ShaderActivate);

            ilBeg.Emit(OpCodes.Ldarg, 0);
            ilBeg.Emit(OpCodes.Call, shaderActivate);
            ilBeg.Emit(OpCodes.Ldarg, 0);
            ilBeg.Emit(OpCodes.Call, getName);
            ilBeg.Emit(OpCodes.Stloc, nameIndex);

            foreach (var prop in type.GetProperties(BindingFlagsAny))
            {
                var attr = prop.GetCustomAttributes(typeof(UniformAttribute), false);
                if (attr.Length == 0)
                    continue;

                var info = TypeMap[prop.PropertyType.MetadataToken];
                
                var uniformCall = Binding.Resolve(info.Token);
                

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
            ilBeg.Emit(OpCodes.Call, type.GetMethod(baseBegin.Name, Type.EmptyTypes));
            ilBeg.Emit(OpCodes.Ret);

            // implement in accessors
            foreach (var prop in type.GetProperties(BindingFlagsAny))
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
            _ctors[type] = ctor;

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
            return (T)CreateSharedShader(typeof(T));
        }

        public static Shader CreateSharedShader(Type type)
        {
            var ctor = GetConstructor(type);
            return (Shader)ResourceManager.Instance(ctor.DeclaringType, null, null);
        }

        /// <summary>
        /// Creates a non shared instance of a shader
        /// </summary>
        /// <typeparam name="T">The shadertype to create</typeparam>
        /// <returns>The shader instance</returns>
        public static T CreateInstance<T>() where T: Shader
        {
            return (T)CreateInstance(typeof(T));
        }

        public static Shader CreateInstance(Type type) 
        {
            var ctor = GetConstructor(type);

            try
            {
                return (Shader)ctor.Invoke(new object[0]);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }


        public static string ResolveName(IMemberDefinition member)
        {
            if (member is MethodDefinition)
                return GetMethodName(member);

            if (member.CustomAttributes.Any(x => x.AttributeType.IsAttribute()))
                return GetVaryingName(member);

            if (member.CustomAttributes.Any(x => x.AttributeType.IsUniform()))
                return GetUniformName(member);

            return member.Name;
        }

        public static string AttributeName<T>(Expression<Func<T>> expr)
        {
            var body = ((MemberExpression)expr.Body);
            return GetVaryingName(body.Member as FieldInfo);
        }

        public static int AttributeLocation<T>(Shader shader, Expression<Func<T>> expr)
        {
            var loc = shader.Program.GetAttributeIndex(AttributeName(expr));
            return loc;
        }

        public static string UniformName<T>(Expression<Func<T>> expr)
        {
            var body = ((MemberExpression)expr.Body);
            return GetUniformName(body.Member as PropertyInfo);
        }

        public static int UniformLocation<T>(Shader shader, Expression<Func<T>> expr)
        {
            var loc = shader.Program.GetUniformIndex(UniformName(expr));
            return loc;
        }

        private static void RefShaders()
        {
            if (_refCount == 0)
                Binding.Active.Initialize();
            _refCount++;
        }

        private static void DerefShaders()
        {
            _refCount--;
            if (_refCount == 0)
                Binding.Active.Cleanup();
        }

        public static void RenderQuad(Shader shader, int location)
        {
            Binding.Active.FullscreenQuad(location, false);
        }

        public static void RenderQuad<T>(Shader shader, Expression<Func<T>> vertexLocation)
        {
            var loca = AttributeLocation(shader, vertexLocation);
            Binding.Active.FullscreenQuad(loca, false);
        }

        public static void RenderPositiveQuad(Shader shader, int location)
        {
            Binding.Active.FullscreenQuad(location, true);
        }

        public static void RenderPositiveQuad<T>(Shader shader, Expression<Func<T>> vertexLocation)
        {
            var loca = AttributeLocation(shader, vertexLocation);
            Binding.Active.FullscreenQuad(loca, true);
        }
    }
}
