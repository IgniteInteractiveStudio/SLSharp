using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using IIS.SLSharp.Descriptions;
using IIS.SLSharp.Reflection;
using IIS.SLSharp.Shaders;
using IIS.SLSharp.Translation;
using IIS.SLSharp.Translation.HLSL;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Graphics;

namespace IIS.SLSharp.Bindings.XNA
{
    sealed class SLContentBuildLogger : ContentBuildLogger
    {
        public override void LogMessage(string message, params object[] messageArgs) { }
        public override void LogImportantMessage(string message, params object[] messageArgs) { }
        public override void LogWarning(string helpLink, ContentIdentity contentIdentity, string message, params object[] messageArgs) { }
    }

    sealed class SLContentProcessorContext: ContentProcessorContext
    {
        public override TargetPlatform TargetPlatform { get { return TargetPlatform.Windows; } }
        public override GraphicsProfile TargetProfile { get { return GraphicsProfile.Reach; } }
        public override string BuildConfiguration { get { return string.Empty; } }
        public override string IntermediateDirectory { get { return string.Empty; } }
        public override string OutputDirectory { get { return string.Empty; } }
        public override string OutputFilename { get { return string.Empty; } }

        public override OpaqueDataDictionary Parameters { get { return _parameters; } }
        readonly OpaqueDataDictionary _parameters = new OpaqueDataDictionary();

        public override ContentBuildLogger Logger { get { return _logger; } }
        readonly ContentBuildLogger _logger = new SLContentBuildLogger();

        public override void AddDependency(string filename) { }
        public override void AddOutputFile(string filename) { }

        public override TOutput Convert<TInput, TOutput>(TInput input, string processorName, OpaqueDataDictionary processorParameters) { throw new NotImplementedException(); }
        public override TOutput BuildAndLoadAsset<TInput, TOutput>(ExternalReference<TInput> sourceAsset, string processorName, OpaqueDataDictionary processorParameters, string importerName) { throw new NotImplementedException(); }
        public override ExternalReference<TOutput> BuildAsset<TInput, TOutput>(ExternalReference<TInput> sourceAsset, string processorName, OpaqueDataDictionary processorParameters, string importerName, string assetName) { throw new NotImplementedException(); }
    }

    sealed class SLSharpBinding: ISLSharpBinding
    {
        public Dictionary<ReflectionToken, MethodInfo> PassiveMethods
        {
            get { return SLSharp.Handlers; }
        }

        private readonly ITransform _transform = new HlslTransform();

        public ITransform Transform
        {
            get { return _transform; }
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
            // HLSL design is kinda screwed up, it only allows us to use one
            // shared source, so we pass through the source and build a
            // merged sourcecode at linktime
            return source;
        }

        internal class Program : IProgram
        {
            public Program(IEnumerable<object> units)
            {
                throw new NotImplementedException();
                /*
                foreach (var u in units.Cast<GLSLGpuProgram>())
                    u.GLSLProgram.AttachToProgramObject(GLHandle);
                Activate(); // compiles the program
                 */
            }

            public void Activate()
            {
                throw new NotImplementedException();
            }

            public void Finish()
            {
                throw new NotImplementedException();
            }

            public int GetUniformIndex(string name)
            {
                throw new NotImplementedException();
            }

            public string GetUniformName(int idx)
            {
                throw new NotImplementedException();
            }

            public int GetAttributeIndex(string name)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

        public IProgram Link(IEnumerable<object> units)
        {
            var sources = units.Cast<SourceDescription>();
            var merged = sources.Skip(1).Aggregate(sources.First(), (current, d) => current.Merge(d));
            var s = new StringBuilder();


            // XNA doesnt support shader compilation so we have to generate a .fx file
            s.AppendLine(merged.ToHlsl());
            
            var src = s;
            Console.WriteLine(src);

            var cp = new SLContentProcessorContext();
            var ep = new EffectProcessor();
            var ec = new EffectContent();

            ec.EffectCode =
@"
float4 MakeItPink() : COLOR0
{
    return float4(1, 0, 1, 1);
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 MakeItPink();
    }
}
        ";
            return new Program(units);
        }

        public void Initialize()
        {
        }

        public void Cleanup()
        {
        }

        public void FullscreenQuad(int vertexLocation, bool positive)
        {
            throw new NotImplementedException();
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
            public Matrix F4X4;
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
        
        public static ShaderDefinition.mat4 ToMatrix4F(this Matrix v)
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

        public static void UniformMatrix4X4(int location)
        {
            throw new NotImplementedException();

            // HACK: Axiom doesnt know about glUniformMatrix* -_-

            //fixed (Matrix* v = &_storage.F4X4)
            //    Tao.OpenGl.Gl.glUniformMatrix4fv(location, 1, 0, new IntPtr(v));
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
