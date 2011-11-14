using Axiom.Core;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Examples.Axiom.Textures;
using IIS.SLSharp.Shaders;
using IIS.SLSharp.Bindings.Axiom;

namespace IIS.SLSharp.Examples.Axiom.Shaders
{
    public abstract class SimpleShader : Shader
    {
        // demonstrate using a shared library
        public WangShader Wang { get; private set; }

        // expose a simple uniform (this can be directly accessed from client code)
        [Uniform]
        public abstract float Blue { set; get; }

        [Uniform]
        public abstract mat4 ModelviewProjection { set; get; }

        [Varying]
        private vec2 _uv;

        [Varying(UsageSemantic.Position0)]
        private vec4 _position;

        [VertexIn(UsageSemantic.Position0)]
        public vec4 Vertex;

        [VertexIn(UsageSemantic.Texcoord0)]
        public vec2 Texcoord;

        [FragmentOut(UsageSemantic.Color0)]
        public vec4 Color;

        [FragmentShader(true)]
        protected void FragmentMain()
        {
            var c = Wang.WangAt(_uv);
            Color = new vec4(c.rg, Blue, c.a);
        }

        [VertexShader(true)]
        public void VertexMain()
        {
            _uv = Texcoord;
            _position = ModelviewProjection * Vertex;
        }

        // resource setup code
        protected SimpleShader()
        {
            Wang = CreateSharedShader<WangShader>();


            var tiles = TextureManager.Instance.Load("tiles.png", ResourceGroupManager.DefaultResourceGroupName);
            tiles.MipmapCount = 5;

            Wang.WangTable = new WangMap(64, 64).AsTexture;
            Wang.Tiles = tiles;

            Link(new[] { Wang });
        }


        public override void Dispose()
        {
            Wang.WangTable.Dispose();
            Wang.Tiles.Dispose();
            Wang.Dispose();
            base.Dispose();
        }

        public override void Begin()
        {
            Wang.BeginLibrary(this);
            base.Begin();
        }

    }
}
