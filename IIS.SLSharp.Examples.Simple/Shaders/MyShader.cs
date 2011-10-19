using IIS.SLSharp.Annotations;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Examples.Simple.Shaders
{
    public abstract class MyShader : Shader
    {
        // expose a simple uniform (this can be directly accessed from client code)
        [Uniform]
        public abstract float Blue { set; get; }

        [Varying]
        private vec2 _uv;

        [VertexIn(UsageSemantic.Position0)]
        public vec4 Vertex;

        [FragmentOut(UsageSemantic.Color0)]
        public vec4 Color;

        [Varying(UsageSemantic.Position0)]
        public vec4 Position;

        // demonstrate using a shared library
        public InvertShader Invert { get; private set; }

        [FragmentShader(true)]
        protected void FragmentMain()
        {
            //Invert.Channels = new vec4(1.0f); // invalid testcode
            Color = Invert.Invert(new vec4(_uv, Blue, 1.0f));
        }

        [VertexShader(true)]
        public void VertexMain()
        {
            _uv = (Vertex.xy + new vec2(1.0f)) * 0.5f;
            Position = Vertex;
        }

        // resource setup code
        protected MyShader()
        {
            Invert = CreateSharedShader<InvertShader>();
            Link(new[] { Invert });
        }

        public override void Dispose()
        {
            Invert.Dispose();
            base.Dispose();
        }

        public override void Begin()
        {
            Invert.BeginLibrary(this);
            base.Begin();
        }

        public void RenderQuad()
        {
            RenderQuad(this, () => Vertex);
        }
    }
}
