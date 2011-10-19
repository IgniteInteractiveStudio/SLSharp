using System.Drawing;
using System.Reflection;
using System.Resources;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Bindings.OpenTK;
using IIS.SLSharp.Bindings.OpenTK.Textures;
using IIS.SLSharp.Examples.Complex.Textures;
using IIS.SLSharp.Shaders;
using OpenTK;

namespace IIS.SLSharp.Examples.Complex.Shaders
{
    public abstract class BackdropShader : Shader
    {
        [Uniform]
        public abstract float MaxScale { get; set; }

        [Uniform]
        public abstract vec2 Scale { get; set; }

        [Varying]
        private vec2 _uv;

        [Varying(UsageSemantic.Position0)]
        private vec4 _position;

        [FragmentOut(UsageSemantic.Color0)]
        protected vec4 Color;

        [VertexIn(UsageSemantic.Position0)]
        public vec4 GlVertex;

        // demonstrate using a shared library
        public WangShader Wang { get; private set; }

        [FragmentShader(true)]
        protected void FragmentMain()
        {
            Color = Wang.WangAt(_uv);
        }

        [VertexShader(true)]
        public void VertexMain()
        {
            _uv = GlVertex.xy * 0.5f * Scale * MaxScale;
            _position = GlVertex;
        }

        // resource setup code
        protected BackdropShader()
        {
            Wang = CreateSharedShader<WangShader>();
            var wang = new WangMap(64, 64);
            Wang.WangTable = wang;
            var asm = Assembly.GetExecutingAssembly();
            var resourceManager = new ResourceManager(asm.EntryPoint.DeclaringType.Namespace + ".Resources", asm);
            var bmp = (Bitmap)resourceManager.GetObject("tiles");
            Wang.Tiles = Texture2D.FromBitmap(bmp);
            Wang.Tiles.GenerateMipMaps(5);
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

        public void Render(float time, float aspect)
        {
            MaxScale = 2.0f;
            var s = (float)(System.Math.Cos(time * MathHelper.TwoPi) + 1.0f) * 0.5f + 0.05f;
            Scale = (new Vector2(s * aspect, s).ToVector2F());
            RenderQuad(this, () => GlVertex);
        }
    }
}
