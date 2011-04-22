using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Axiom.Graphics;
using Axiom.RenderSystems.OpenGL.GLSL;
using IIS.SLSharp.Descriptions;
using IIS.SLSharp.Reflection;
using Axiom.Math;
using IIS.SLSharp.Shaders;
using IIS.SLSharp.Translation;
using IIS.SLSharp.Translation.GLSL;

namespace IIS.SLSharp.Bindings.Axiom
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
            throw new NotImplementedException();
            //GL.ActiveTexture(TextureUnit.Texture0 + textureUnit);
            //((ITexture)tex).Activate();
        }

        public void TexFinish(int textureUnit, object tex)
        {
            throw new NotImplementedException();
            //GL.ActiveTexture(TextureUnit.Texture0 + textureUnit);
            //((ITexture)tex).Finish();
        }

        public void TexReset()
        {
            throw new NotImplementedException();
            //GL.ActiveTexture(TextureUnit.Texture0);
        }

        public object Compile(ShaderType type, SourceDescription source)
        {            
            var glsl = new GLSLProgram(null, "", 0, "", false, null);
            var prog = new GLSLGpuProgram(glsl);
            prog.GLSLProgram.Source = source.ToGlsl(type);

            switch (type)
            {
                case ShaderType.FragmentShader:
                    prog.GLSLProgram.Type = GpuProgramType.Fragment;
                    break;
                case ShaderType.VertexShader:
                    prog.GLSLProgram.Type = GpuProgramType.Vertex;
                    break;
                default:
                    throw new SLSharpException("Binding does not support " + type);
            }
            
            prog.GLSLProgram.Load();
            return prog;
        }

        internal class Program : GLSLLinkProgram, IProgram
        {
            public static Program CurrentProgram;

            public Program(IEnumerable<object> units)
            {
                foreach (var u in units.Cast<GLSLGpuProgram>())
                    u.GLSLProgram.AttachToProgramObject(GLHandle);
                Activate(); // compiles the program
            }

            public new void Activate()
            {
                base.Activate();
                CurrentProgram = this;
            }

            public void Finish()
            {
                CurrentProgram = null;
            }

            public int GetUniformIndex(string name)
            {
                return uniformReferences.First(u => u.name == name).location;
            }

            public string GetUniformName(int idx)
            {
                return uniformReferences.First(u => u.location == idx).name;
            }

            [Obsolete("This has to be moved inside Axiom")]
            private int AttributeIndexHack(string name)
            {
                // This is a temporary hack we have to move this functionality into Axiom!!!
                return Tao.OpenGl.Gl.glGetAttribLocationARB(GLHandle, name);
            }

            public int GetAttributeIndex(string name)
            {                
                return AttributeIndexHack(name);
            }
        }

        public IProgram Link(IEnumerable<object> units)
        {
            return new Program(units);
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
            throw new NotImplementedException();
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
                Tao.OpenGl.Gl.glUniformMatrix4fv(location, 1, 0, new IntPtr(v));
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
