using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using IIS.SLSharp.Bindings.OpenTK.Textures;
using IIS.SLSharp.Descriptions;
using IIS.SLSharp.Reflection;
using IIS.SLSharp.Shaders;
using IIS.SLSharp.Translation;
using IIS.SLSharp.Translation.GLSL;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace IIS.SLSharp.Bindings.OpenTK
{
    sealed class SLSharpBinding: ISLSharpBinding
    {
        private Quad _quad;

        public Dictionary<ReflectionToken, MethodInfo> PassiveMethods
        {
            get { return SLSharp.Handlers; }
        }

        private readonly ITransform _transform = new GlslTransform();

        public ITransform Transform
        {
            get { return _transform; }
        }

        #region Active Methods

        public void TexActivate(int textureUnit, object tex)
        {
            GL.ActiveTexture(TextureUnit.Texture0 + textureUnit);
            ((ITexture)tex).Activate();
        }

        public void TexFinish(int textureUnit, object tex)
        {
            GL.ActiveTexture(TextureUnit.Texture0 + textureUnit);
            ((ITexture)tex).Finish();
        }

        public void TexReset()
        {
            GL.ActiveTexture(TextureUnit.Texture0);
        }

        public object Compile(Shader s, ShaderType type, SourceDescription source)
        {
            var src = source.ToGlsl(type);

            int shader;
            switch (type)
            {
                case ShaderType.FragmentShader:
                    shader = GL.CreateShader(global::OpenTK.Graphics.OpenGL.ShaderType.FragmentShader);
                    break;
                case ShaderType.VertexShader:
                    shader = GL.CreateShader(global::OpenTK.Graphics.OpenGL.ShaderType.VertexShader);
                    break;
                default:
                    throw new SLSharpException("Binding does not support " + type);
            }

            Utilities.CheckGL();

            GL.ShaderSource(shader, src);
            GL.CompileShader(shader);
            int compileResult;
            GL.GetShader(shader, ShaderParameter.CompileStatus, out compileResult);
            string info;
            GL.GetShaderInfoLog(shader, out info);

            if (compileResult != 1)
            {
                //Dump(type, src);
                throw new SLSharpException("Shader compilation failed: " + info);
            }

            if (info != string.Empty)
                Console.WriteLine(info);

            return new Tuple<int, SourceDescription>(shader, source);
        }

        public IProgram Link(Shader shader, IEnumerable<object> units)
        {
            return new Program(units.Cast<Tuple<int, SourceDescription>>());
        }

        public void Initialize()
        {
            _quad = new Quad();
        }

        public void Cleanup()
        {
            _quad.Dispose();
            _quad = null;
        }

        public void FullscreenQuad(int vertexLocation, bool positive)
        {
            _quad.Render(vertexLocation, positive);
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
            public Vector2d D2;
            public Vector3d D3;
            public Vector4d D4;
            public Matrix4 F4X4;
            public Matrix4d D4X4;
            public int Sampler;
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

        public static ShaderDefinition.dvec2 ToVector2D(this Vector2d v)
        { _storage.D2 = v; return null; }

        public static ShaderDefinition.dvec3 ToVector3D(this Vector3d v)
        { _storage.D3 = v; return null; }

        public static ShaderDefinition.dvec4 ToVector4D(this Vector4d v)
        { _storage.D4 = v; return null; }

        public static ShaderDefinition.mat4 ToMatrix4F(this Matrix4 v)
        { _storage.F4X4 = v; return null; }

        public static ShaderDefinition.dmat4 ToMatrix4D(this Matrix4d v)
        { _storage.D4X4 = v; return null; }

        public static ShaderDefinition.SamplerTmp ToSampler(this int v)
        { _storage.Sampler = v; return null; }

        #endregion


        public static int GetLocation(int program, string name)
        {
            return GL.GetUniformLocation(program, name);
        }

        public static void Uniform1F(int location, float value)
        {
            GL.Uniform1(location, value);
        }

        public static void Uniform2F(int location)
        {
            GL.Uniform2(location, ref _storage.F2);
        }

        public static void Uniform3F(int location)
        {
            GL.Uniform3(location, ref _storage.F3);
        }

        public static void Uniform4F(int location)
        {
            GL.Uniform4(location, ref _storage.F4);
        }

        public static void Uniform1D(int location, double value)
        {
            GL.Uniform1(location, value);
        }

        public static void Uniform2D(int location)
        {
            var d2L = _storage.D2;
            GL.Uniform2(location, d2L.X, d2L.Y);
        }

        public static void Uniform3D(int location)
        {
            var d3L = _storage.D3;
            GL.Uniform3(location, d3L.X, d3L.Y, d3L.Z);
        }

        public static void Uniform4D(int location)
        {
            var d4L = _storage.D4;
            GL.Uniform4(location, d4L.X, d4L.Y, d4L.Z, d4L.W);
        }

        public static void UniformMatrix4X4(int location)
        {
            GL.UniformMatrix4(location, false, ref _storage.F4X4);
        }

        public static unsafe void UniformDMatrix4X4(int location)
        {
            fixed (Matrix4d* v = &_storage.D4X4)
                GL.UniformMatrix4(location, 1, false, (double*) v);
        }

        public static void UniformSampler(int location)
        {
            GL.Uniform1(location, _storage.Sampler);
        }
        #endregion
    }

    
}
