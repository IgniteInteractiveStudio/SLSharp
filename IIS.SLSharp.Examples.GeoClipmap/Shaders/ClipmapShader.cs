using IIS.SLSharp.Annotations;
using IIS.SLSharp.Bindings.OpenTK;
using IIS.SLSharp.Bindings.OpenTK.Textures;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Examples.GeoClipmap.Shaders
{
    public abstract class ClipmapShader : Shader
    {
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
        public abstract sampler2D Heightmap { set; get; }

        [Varying]
        public vec2 _uv;

        [Varying]
        public float _z;

        [Varying]
        public vec4 _finalPos;

        [VertexIn(UsageSemantic.Position0)]
        public vec4 Vertex;

        [FragmentOut(UsageSemantic.Color0)]
        public vec4 FragColor;

        [VertexShader(true)]
        public void ClipmapVertexMain()
        {
            var worldPos = (Vertex.xy + ScaleFactor.xy) * ScaleFactor.zw;
            _uv = (Vertex.xy + FineBlockOrigin.xy) * FineBlockOrigin.zw;


            var texel = new vec3(texture(Heightmap, _uv, 1.0f).r);
    
            var zfZd = texel.x;
            var zf = Floor(zfZd);
            var zd = Fraction(zfZd) * 512.0f - 256.0f;

            var alpha = Clamp((Abs(worldPos - ViewerPosition) - AlphaOffset) * OneOverWidth, 0.0f, 1.0f);
            alpha.x = Max(alpha.x, alpha.y);
            _z = zf + alpha.x * zd;
    
            _z = zfZd; // alpha blend not implemented, yet

            // planar map
            var worldPosFinal = new vec4(worldPos, _z * 0.1f, 1.0f);

            _finalPos = ModelViewProjectionMatrix * worldPosFinal;
            gl_Position = _finalPos;

            //normal = normalize(vec3(texel.yz, 1.0));
        }

        [FragmentShader(true)]
        public void ClipmapFragmentMain()
        {
            var n = Normalize(Cross(dFdx(_finalPos.xyz),dFdy(_finalPos.xyz)));
            n.xy = -n.xy;
            var light = Normalize(new vec3(1.0f, 0.0f, 1.0f));
            light = new mat3(NormalMatrix) * (light);
            var i = Dot(light, n);
            FragColor = new vec4(_uv.xy, i, 1.0f);
        }

        private int _heightmap;

        protected ClipmapShader()
        {
            Link();
        }

        
        public Texture2D HeightmapTex
        {
            set { BindTexture(value, _heightmap); }
        }

        public override void Begin()
        {
            base.Begin();

            _heightmap = AllocateSamplerSlot();
            Heightmap = _heightmap.ToSampler();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
         
    }
}
