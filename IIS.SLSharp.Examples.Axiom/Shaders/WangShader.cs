using Axiom.Core;
using Axiom.Graphics;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Shaders;
using IIS.SLSharp.Bindings.Axiom;

namespace IIS.SLSharp.Examples.Axiom.Shaders
{
    public abstract class WangShader : Shader
    {
        public Texture Tiles { get; set; }

        public Texture WangTable { get; set; }

        [Uniform]
        public abstract sampler2D WangTiles { set; get; }

        [Uniform]
        public abstract sampler2D WangMap { set; get; }

        [FragmentShader]
        public vec4 WangAt(vec2 tex)
        {
            
            var address = tex - tex % (1.0f / 256.0f);
            var subPos = Fraction(tex * 256.0f) / 4.0f;
            var offset = Texture(WangMap, Fraction(address)).xw;
            var tc = offset + subPos;
            var tileScaledTex = tex * new vec2(32.0f / 1.0f);

            return TextureGrad(WangTiles, tc, DeriveTowardsX(tileScaledTex), DeriveTowardsY(tileScaledTex));
        }

        public override void Begin()
        {
            base.Begin();
            var smp = this.Sampler(() => WangTiles);
            smp.SetTextureName(Tiles.Name);
            smp.SetTextureFiltering(FilterOptions.Linear, FilterOptions.Linear, FilterOptions.Linear);

            smp = this.Sampler(() => WangMap);
            smp.SetTextureName(WangTable.Name);
            smp.SetTextureFiltering(FilterOptions.Point, FilterOptions.Point, FilterOptions.None);
        }
    }
}
