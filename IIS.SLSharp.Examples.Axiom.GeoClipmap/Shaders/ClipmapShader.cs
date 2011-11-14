using IIS.SLSharp.Annotations;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Examples.Axiom.GeoClipmap.Shaders
{
    public abstract class ClipmapShader : Shader
    {
        [Uniform]
        public abstract vec4 Color { set; get; }

        [Uniform]
        public abstract mat4 ModelViewProjectionMatrix { set; get; }

        [Uniform]
        public abstract mat4 NormalMatrix { set; get; }

        [Uniform]
        public abstract vec4 ScaleFactor { set; get; }

        [Uniform]
        public abstract vec4 FineBlockOrigin { set; get; }

        [Uniform]
        public abstract vec2 ViewerPosition { set; get; }

        [Uniform]
        public abstract vec2 AlphaOffset { set; get; }

        [Uniform]
        public abstract vec2 OneOverWidth { set; get; }

        [Uniform]
        public abstract float ZTexScaleFactor { set; get; }

        [Uniform]
        public abstract float DebugValue { set; get; }

        [Uniform]
        public abstract float alpha { set; get; }

        [Uniform]
        public abstract sampler2D Heightmap { set; get; }

        [Varying]
        public vec2 _uv;

        [Varying(UsageSemantic.Position0)]
        private vec4 _position;

        [Varying]
        public float _z;

        [Varying]
        public vec4 _finalPos;

        [Varying]
        public vec3 Normal;

        [VertexIn(UsageSemantic.Position0)]
        public vec4 Vertex;

        [FragmentOut(UsageSemantic.Color0)]
        public vec4 FragColor;

        [VertexShader(true)]
        public void ClipmapVertexMain()
        {
            var worldPos = (Vertex.xy + ScaleFactor.xy) * ScaleFactor.zw;
            _uv = (Vertex.xy + FineBlockOrigin.xy) * FineBlockOrigin.zw;


            var texel = new vec3(TextureLod(Heightmap, _uv, 1.0f).r);

            var zfZd = texel.x * 512.0f;
            var zf = Floor(zfZd) * 0.001953125f;
            var zd = Fraction(zfZd) * 2.0f - 1.0f;

            //var alpha = Clamp((Abs(worldPos - ViewerPosition) - AlphaOffset) * OneOverWidth, 0.0f, 1.0f);
            //alpha.x = Max(alpha.x, alpha.y);


            _z = zf + /* alpha * */ zd;

            //_z = zfZd; // alpha blend not implemented, yet

            // planar map
            var worldPosFinal = new vec4(worldPos, _z * 0.3f, 1.0f);

            _finalPos = ModelViewProjectionMatrix * worldPosFinal;
            _position = _finalPos;


            // just for testing, derive normal using interpolation over heights
            var dfdx = (TextureLod(Heightmap, _uv + new vec2(FineBlockOrigin.z, 0.0f), 1.0f).r - texel.r);
            var dfdy = (TextureLod(Heightmap, _uv + new vec2(0.0f, FineBlockOrigin.w), 1.0f).r - texel.r);
            var dz = 2.0f * ScaleFactor.z - dfdx * dfdx - dfdy * dfdy;
            Normal = new vec3(dfdx, dfdy, dz);

            //normal = normalize(vec3(texel.yz, 1.0));
        }

        [FragmentShader(true)]
        public void ClipmapFragmentMain()
        {
            var light = Normalize(new vec3(0.0f, 1.0f, 0.6f));
            var n = Normalize(Normal);

            /*
            var n2 = Normalize(Cross(dFdx(_finalPos.xyz),dFdy(_finalPos.xyz)));
            n2.xy = -n2.xy;
            var light2 = new mat3(NormalMatrix) * (light);
            */
            var i = Max(Dot(light, n), 0.0f) * 0.8f + 0.2f; // Dot(light2, n2);


            FragColor = /*Color **/ new vec4(i);
        }

        protected ClipmapShader()
        {
            Link();
        }


        public override void Dispose()
        {
            base.Dispose();
        }
         
    }
}
