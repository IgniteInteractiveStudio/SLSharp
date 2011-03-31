using System.Reflection;
using GeoClip.Shaders.Annotations;

namespace GeoClip.Shaders.Examples.Shaders
{
    public abstract class MyShader : Shader
    {
        // expose a simple uniform (this can be directly accessed from client code)
        [Obfuscation(Exclude = true)]
        [Uniform]
        public abstract float Blue { set; get; }

        [Varying]
        private vec2 _uv;

        // demonstrate using a shared library
        public InvertShader Invert { get; private set; }

        [FragmentShader(true)]
        protected void FragmentMain()
        {
            gl_FragColor = Invert.Invert(new vec4(_uv, Blue, 1.0f));
        }

        [VertexShader(true)]
        public void VertexMain()
        {
            _uv = (gl_Vertex.xy + new vec2(1.0f)) * 0.5f;
            gl_Position = gl_Vertex;
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
    }
}
