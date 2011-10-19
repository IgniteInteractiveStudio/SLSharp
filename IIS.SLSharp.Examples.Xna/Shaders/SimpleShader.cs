using IIS.SLSharp.Annotations;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Examples.XNA.Shaders
{
    public abstract class SimpleShader : Shader
    {
        // expose a simple uniform (this can be directly accessed from client code)
        [Uniform]
        public abstract float Blue { set; get; }

        [Uniform]
        public abstract mat4 ModelviewProjection { set; get; }

        [Varying]
        private vec2 _fragNormal;

        [Varying(UsageSemantic.Position0)]
        private vec4 _position;

        [VertexIn(UsageSemantic.Position0)]
        public vec4 Vertex;

        [VertexIn(UsageSemantic.Normal0)]
        public vec2 Normal;

        [FragmentOut(UsageSemantic.Color0)]
        public vec4 Color;

        [FragmentShader(true)]
        protected void FragmentMain()
        {
            Color = new vec4(_fragNormal.xy, Blue, 1.0f);
        }

        [VertexShader(true)]
        public void VertexMain()
        {
            _fragNormal = Normal;
            _position = ModelviewProjection * Vertex;
        }

        // resource setup code
        protected SimpleShader()
        {
            Link();
        }

        public void RenderQuad()
        {
            RenderQuad(this, () => Vertex);
        }
    }
}
