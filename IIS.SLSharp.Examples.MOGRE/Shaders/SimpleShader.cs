using IIS.SLSharp.Annotations;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Examples.MOGRE.Shaders
{
    public abstract class SimpleShader : Shader
    {
        // expose a simple uniform (this can be directly accessed from client code)
        [Uniform]
        public abstract float Blue { set; get; }

        [Uniform]
        public abstract mat4 ModelviewProjection { set; get; }

        [Uniform]
        public abstract sampler2D Texture { set; get; }

        [Varying]
        private vec2 _uv;

        [VertexIn(UsageSemantic.Position0)]
        public vec4 Vertex;

        [VertexIn(UsageSemantic.Texcoord0)]
        public vec2 Texcoord;

        [FragmentOut(UsageSemantic.Color0)]
        public vec4 Color;

        [FragmentShader(true)]
        protected void FragmentMain()
        {
            var c = texture(Texture, _uv);
            Color = new vec4(c.rg, Blue, 1.0f);
        }

        [VertexShader(true)]
        public void VertexMain()
        {
            _uv = Texcoord;
            gl_Position = ModelviewProjection * Vertex;
        }

        // resource setup code
        protected SimpleShader()
        {
            Link();
        }
    }
}
