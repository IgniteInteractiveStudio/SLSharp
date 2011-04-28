using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Axiom.Core;
using Axiom.Graphics;
using Axiom.RenderSystems.OpenGL.GLSL;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Descriptions;
using IIS.SLSharp.Reflection;
using Axiom.Math;
using IIS.SLSharp.Shaders;
using IIS.SLSharp.Translation;
using IIS.SLSharp.Translation.GLSL;
using Tao.OpenGl;

namespace IIS.SLSharp.Bindings.Axiom.GLSL
{
    sealed class SLSharpBinding: ISLSharpBinding
    {
        public Dictionary<ReflectionToken, MethodInfo> PassiveMethods
        {
            get { return SLSharp.Handlers; }
        }

        public ITransform Transform
        {
            // TODO: chose target dynamically on current axiom operation mode
            get { return new GlslTransform(); }
        }

        #region Active Methods

        public void TexActivate(int textureUnit, object tex)
        {
            //throw new NotImplementedException();
            //GL.ActiveTexture(TextureUnit.Texture0 + textureUnit);
            //((ITexture)tex).Activate();
        }

        public void TexFinish(int textureUnit, object tex)
        {
            //throw new NotImplementedException();
            //GL.ActiveTexture(TextureUnit.Texture0 + textureUnit);
            //((ITexture)tex).Finish();
        }

        public void TexReset()
        {
            //throw new NotImplementedException();
            //GL.ActiveTexture(TextureUnit.Texture0);
        }

        public object Compile(Shader shader, ShaderType type, SourceDescription source)
        {
            var name = shader.GetType().FullName + "_" + type;
            var m = HighLevelGpuProgramManager.Instance;
            const string group = ResourceGroupManager.DefaultResourceGroupName;
            var unit = m.CreateProgram(name, group, "glsl", type.ToAxiom());

            unit.Source = source.ToGlsl(type);

            return new System.Tuple<ShaderType, GLSLProgram, SourceDescription>(
                type, (GLSLProgram)unit, source);
        }


        public IProgram Link(Shader shader, IEnumerable<object> u)
        {
            GLSLProgram vs;
            GLSLProgram ps;

            var units = u.Cast<System.Tuple<ShaderType, GLSLProgram, SourceDescription>>();
            var name = shader.GetType().FullName;

            const string group = ResourceGroupManager.DefaultResourceGroupName;

            var vertexIns = units.Where(v => v.Item1 == ShaderType.VertexShader).Aggregate(
                SourceDescription.Empty, (current, vu) => current.Merge(vu.Item3)).VertexIns;

            var verts = units.Where(v => v.Item1 == ShaderType.VertexShader).Select(v => v.Item2);
            if (verts.Count() > 1)
            {
                vs =
                    (GLSLProgram)
                    HighLevelGpuProgramManager.Instance.CreateProgram(name + "_" + "Vertex", group, "glsl",
                                                                      GpuProgramType.Vertex);
                foreach (var unit in verts)
                    vs.AttachChildShader(unit.Name);
            }
            else
                vs = verts.FirstOrDefault();


            var frags = units.Where(v => v.Item1 == ShaderType.FragmentShader).Select(v => v.Item2);
            if (frags.Count() > 1)
            {
                ps =
                    (GLSLProgram)
                    HighLevelGpuProgramManager.Instance.CreateProgram(name + "_" + "Fragment", group, "glsl",
                                                                      GpuProgramType.Fragment);
                foreach (var unit in frags)
                    ps.AttachChildShader(unit.Name);
            }
            else
                ps = frags.FirstOrDefault(); 

            return new Program(vs, ps, vertexIns);
        }

        public void Initialize()
        {
            //_quad = new Quad();
        }

        public void Cleanup()
        {
            //_quad.Dispose();
            //_quad = null;
        }

        public void FullscreenQuad(int vertexLocation, bool positive)
        {
            throw new NotImplementedException();
            //_quad.Render(vertexLocation, positive);
        }

        #endregion
    }

    public class Program : IProgram
    {
        public static Program CurrentProgram;

        public readonly GLSLProgram VertexShader;

        public readonly GLSLProgram PixelShader;

        public readonly GLSLLinkProgram Prog;

        private readonly GLSLLinkProgram.UniformReferenceList _uniforms;

        private readonly List<VariableDescription> _vertexIns;

        public Program(GLSLProgram vs, GLSLProgram ps, List<VariableDescription> vertexIns)
        {
            _vertexIns = vertexIns;

            VertexShader = vs;
            PixelShader = ps;

            vs.Load();
            ps.Load();

            var link = GLSLLinkProgramManager.Instance;
            link.SetActiveFragmentShader((GLSLGpuProgram) ps.BindingDelegate);
            link.SetActiveVertexShader((GLSLGpuProgram)vs.BindingDelegate);
            Prog = link.ActiveLinkProgram;

            var field = Prog.GetType().GetField("uniformReferences", BindingFlags.Instance | BindingFlags.NonPublic);
            if (field == null)
                throw new SLSharpException("could not resolve uniformReferences");

            _uniforms = (GLSLLinkProgram.UniformReferenceList) field.GetValue(Prog);
        }

        public void Activate()
        {
            // HACK: assign attribute semantics
            // axiom doesnt know about attributes yet :(

            foreach (var v in _vertexIns)
            {
                //var id = Gl.glGetAttribLocationARB(Prog.GLHandle, v.Name);
                int id;
                switch (v.Semantic)
                {
                    case UsageSemantic.Position0: id = 0; break;
                    case UsageSemantic.Normal0: id = 2; break;
                    case UsageSemantic.Color0: id = 3; break;
                    case UsageSemantic.Color1: id = 4; break;
                    case UsageSemantic.Texcoord0: id = 8; break;
                    case UsageSemantic.Texcoord1: id = 9; break;
                    case UsageSemantic.Texcoord2: id = 10; break;
                    case UsageSemantic.Texcoord3: id = 11; break;
                    case UsageSemantic.Texcoord4: id = 12; break;
                    case UsageSemantic.Texcoord5: id = 13; break;
                    case UsageSemantic.Texcoord6: id = 14; break;
                    case UsageSemantic.Texcoord7: id = 15; break;
                    default:
                        throw new SLSharpException("Axiom does not support " + v.Semantic + " yet for OpenGL.");
                }
                Gl.glBindAttribLocation(Prog.GLHandle, id, v.Name);
            }
            CurrentProgram = this;
        }

        public void Finish()
        {
            CurrentProgram = null;
        }

        public int GetUniformIndex(string name)
        {
            return _uniforms.First(u => u.name == name).location;
        }

        public string GetUniformName(int idx)
        {
            return _uniforms.First(u => u.location == idx).name;
        }

        [Obsolete("This has to be moved inside Axiom")]
        private int AttributeIndexHack(string name)
        {
            // This is a temporary hack we have to move this functionality into Axiom!!!
            return Gl.glGetAttribLocationARB(Prog.GLHandle, name);
            //throw new NotImplementedException();
        }

        public int GetAttributeIndex(string name)
        {                
            return AttributeIndexHack(name);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public static class SLSharp
    {
        public static void Init()
        {
            Binding.Register(new SLSharpBinding());
        }

        #region Passive Methods
        private static MethodInfo GetMethod(Action<int> a)
        {
            return a.Method;
        }

        private static MethodInfo GetMethod<T>(Action<int, T> a)
        {
            return a.Method;
        }

        internal static Dictionary<ReflectionToken, MethodInfo> Handlers = new Dictionary<ReflectionToken, MethodInfo>
                                                                               {
            {ReflectionToken.ShaderVec1Helper, GetMethod<float>(Uniform1F) },
            {ReflectionToken.ShaderVec2Helper, GetMethod(Uniform2F) },
            {ReflectionToken.ShaderVec3Helper, GetMethod(Uniform3F) },
            {ReflectionToken.ShaderVec4Helper, GetMethod(Uniform4F) },
            {ReflectionToken.ShaderDvec1Helper, GetMethod<double>(Uniform1D) },
            {ReflectionToken.ShaderDvec2Helper, GetMethod(Uniform2D) },
            {ReflectionToken.ShaderDvec3Helper, GetMethod(Uniform3D) },
            {ReflectionToken.ShaderDvec4Helper, GetMethod(Uniform4D) },
            {ReflectionToken.ShaderSamplerHelper, GetMethod(UniformSampler) },
            {ReflectionToken.ShaderUniformMatrix4X4Helper, GetMethod(UniformMatrix4X4) },
        };

        public static GpuProgramType ToAxiom(this ShaderType type)
        {
            switch (type)
            {
                case ShaderType.FragmentShader:
                    return GpuProgramType.Fragment;
                case ShaderType.VertexShader:
                    return GpuProgramType.Vertex;
            }
            throw new SLSharpException("Unhandled shader type: " + type);
        }
        

        #region Uniform Local Storage

        internal struct UniformStorage
        {
            public Vector2 F2;
            public Vector3 F3;
            public Vector4 F4;
            public Matrix3 F3X3;
            public Matrix4 F4X4;
           
        }

        // use ThreadStatic when multiple render contexts are planned
        // if speed is a concern cache with UniformStorage[64] or so
        // and access as UniformStorage[CurrentThreadID] as long the tid 
        // is < 64, otherwise fallback to TLS var
        //[ThreadStatic]
        private static UniformStorage _storage;

        public static ShaderDefinition.vec2 ToVector2F(this Vector2 v)
        { _storage.F2 = v; return null; }

        public static ShaderDefinition.vec3 ToVector3F(this Vector3 v)
        { _storage.F3 = v; return null; }

        public static ShaderDefinition.vec4 ToVector4F(this Vector4 v)
        { _storage.F4 = v; return null; }

        public static ShaderDefinition.mat4 ToMatrix3F(this Matrix3 v)
        { _storage.F3X3 = v; return null; }
        
        public static ShaderDefinition.mat4 ToMatrix4F(this Matrix4 v)
        { _storage.F4X4 = v; return null; }

        #endregion


        public static int GetLocation(int program, string name)
        {
            throw new NotImplementedException();
            //return GL.GetUniformLocation(program, name);
        }

        public static void Uniform1F(int location, float value)
        {
            Tao.OpenGl.Gl.glUniform1f(location, value);
            //GL.Uniform1(location, value);
        }

        public static void Uniform2F(int location)
        {
            throw new NotImplementedException();
            //GL.Uniform2(location, ref _storage.F2);
        }

        public static void Uniform3F(int location)
        {
            throw new NotImplementedException();
            //GL.Uniform3(location, ref _storage.F3);
        }

        public static void Uniform4F(int location)
        {
            throw new NotImplementedException();
            //GL.Uniform4(location, ref _storage.F4);
        }

        public static void Uniform1D(int location, double value)
        {
            throw new NotImplementedException();
            //GL.Uniform1(location, value);
        }

        public static void Uniform2D(int location)
        {
            throw new NotImplementedException();
            //var d2L = _storage.D2;
            //GL.Uniform2(location, d2L.X, d2L.Y);
        }

        public static void Uniform3D(int location)
        {
            throw new NotImplementedException();
            //var d3L = _storage.D3;
            //GL.Uniform3(location, d3L.X, d3L.Y, d3L.Z);
        }

        public static void Uniform4D(int location)
        {
            throw new NotImplementedException();
            //var d4L = _storage.D4;
            //GL.Uniform4(location, d4L.X, d4L.Y, d4L.Z, d4L.W);
        }

        public unsafe static void UniformMatrix4X4(int location)
        {
            /*
            var loc = new GpuProgramParameters();
            //loc.SetConstant(location, _storage.F4X4);
            loc.SetNamedConstant(SLSharpBinding.Program.CurrentProgram.GetUniformName(location), _storage.F4X4);
            SLSharpBinding.Program.CurrentProgram.UpdateUniforms(loc);
            //GL.UniformMatrix4(location, false, ref _storage.F4X4);
             */

            // HACK: Axiom doesnt know about glUniformMatrix* -_-

            fixed (Matrix4* v = &_storage.F4X4)
                Tao.OpenGl.Gl.glUniformMatrix4fv(location, 1, 1, new IntPtr(v));
            //Tao.OpenGl.Gl.glUniformMatrix4fv(location, 1, false, storage.F4X4);
        }

        public static void UniformDMatrix4X4(int location)
        {
            throw new NotImplementedException();
            //fixed (Matrix4d* v = &_storage.D4X4)
            //    GL.UniformMatrix4(location, 1, false, (double*) v);
        }

        public static void UniformSampler(int location)
        {
            throw new NotImplementedException();
            //GL.Uniform1(location, ShaderDefinition.Sampler.value);
        }
        #endregion
    }

    
}
