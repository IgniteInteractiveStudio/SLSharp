using IIS.SLSharp.Annotations;
using IIS.SLSharp.Textures;

namespace IIS.SLSharp.Examples.Complex.Shaders
{
    public abstract class WangShader: Shader
    {
        [Uniform]
        public abstract sampler2D WangTiles { set; get; }

        [Uniform]
        public abstract sampler2D WangMap { set; get; }

        public Texture2D Tiles { get; set; }

        public Texture2D WangTable { get; set; }

        [FragmentShader]
        public vec4 WangAt(vec2 tex)
        {
            var address = tex - mod(tex, 1.0f / 256.0f);
            var subPos = fract(tex * 256.0f) / 4.0f;
            var offset = texture(WangMap, fract(address)).xw;
            var tc = offset + subPos;
            var tileScaledTex = tex * new vec2(32.0f / 1.0f);

            return textureGrad(WangTiles, tc, dFdx(tileScaledTex), dFdy(tileScaledTex));
        }

        public override void Begin()
        {
            base.Begin();
            WangTiles = BindTexture(Tiles);
            WangMap = BindTexture(WangTable);
        }
    }
}
