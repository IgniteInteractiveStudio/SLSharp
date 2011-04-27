using IIS.SLSharp.Annotations;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Examples.Axiom.Shaders
{
    public abstract class SimpleShader : Shader
    {
        // expose a simple uniform (this can be directly accessed from client code)
        [Uniform]
        public abstract float Blue { set; get; }

        [Uniform]
        public abstract mat4 ModelviewProjection { set; get; }

        [Varying]
        private vec2 _uv;

        [VertexIn(UsageSemantic.Position0)]
        public vec4 Vertex;

        [FragmentOut(UsageSemantic.Color0)]
        public vec4 Color;

        [FragmentShader(true)]
        protected void FragmentMain()
        {
            //Invert.Channels = new vec4(1.0f); // invalid testcode
            Color = new vec4(_uv, Blue, 1.0f);
        }

        [VertexShader(true)]
        public void VertexMain()
        {
            _uv = (Vertex.xy + new vec2(1.0f)) * 0.5f;
            gl_Position = ModelviewProjection * Vertex;
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
