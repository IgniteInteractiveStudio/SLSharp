using IIS.SLSharp.Annotations;
using IIS.SLSharp.Bindings.OpenTK;
using IIS.SLSharp.Bindings.OpenTK.Textures;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Examples.GeoClipmap.Shaders
{
    public abstract class ClipmapShaderLevel0 : Shader
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
        public abstract vec2 Block { set; get; }

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
        public abstract vec4 AtlasScale { set; get; }

        [Uniform]
        public abstract sampler2D Heightmap { set; get; }

        [Uniform]
        public abstract sampler2D Normalmap { set; get; }

        [Uniform]
        public abstract sampler2D Colormap { set; get; }

        [Uniform]
        public abstract sampler2D Atlas { set; get; }

        [Uniform]
        public abstract sampler2D Indexmap { set; get; }

        [Uniform]
        public abstract sampler2D Indexmap2 { set; get; }

        [Uniform]
        public abstract sampler2D AlphaIndexMap { set; get; }

        [Uniform]
        public abstract sampler2D AlphaLayer { set; get; }

        [Varying]
        public vec2 _uv;

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


            var texel = new vec3(texture(Heightmap, _uv, 1.0f).r);

            _z = texel.x;
    
            var worldPosFinal = new vec4(worldPos, _z * 8.0f, 1.0f);

            _finalPos = ModelViewProjectionMatrix * worldPosFinal;
            gl_Position = _finalPos;


            // just for testing, derive normal using interpolation over heights
            var dfdx = (textureLod(Heightmap, _uv + new vec2(FineBlockOrigin.z, 0.0f), 1.0f).r - texel.r);
            var dfdy = (textureLod(Heightmap, _uv + new vec2(0.0f, FineBlockOrigin.w), 1.0f).r - texel.r);
            var dz = 0.1f*ScaleFactor.z - dfdx * dfdx - dfdy * dfdy;
            Normal = new vec3(dfdx, dfdy, dz);

            //normal = normalize(vec3(texel.yz, 1.0));
        }

        [FragmentShader(true)]
        public void ClipmapFragmentMain()
        {
            var light = Normalize(new vec3(-1.0f, 0.0f, 0.6f));
            var normT = texture(Normalmap, _uv);
            var texId = normT.w;
            var n = Normalize(normT.xyz * 2.0f - 1.0f);
            var color = texture(Colormap, _uv) * 2.0f;
            //var color = new vec4(1.0f);
            var dl = Dot(light, n);
            var i = Max(dl, 0.0f) * 0.8f + 0.2f;

            // 256 is correct scaler here!

            var uv01 = mod(_uv, 1.0f);

            var uvs = (uv01 * 256.0f - Block + new vec2(DebugValue) + new vec2(8.0f)) / 17.0f;
            uvs = mod(uvs, 1.0f);

            var uvz = uvs * AtlasScale.xy;
            var uva = uvs * (64.0f / 2048.0f); //*AtlasScale.zw;

            var index0 = texture(Indexmap, _uv);
            var index1 = texture(Indexmap2, _uv);
            var alphaIndex = texture(AlphaIndexMap, _uv);
            // 0.0 -> 0, 1.0 -> 255

            // * 255 -> idx as integer
            // * 64 -> in pixels
            // / atlassize -> normalized
            // -> *255*64/2048 = *7.96875

            alphaIndex *= 7.96875f;
            
            var layer0Tex = texture(Atlas, uvz + index0.rg);
            var layer1Tex = texture(Atlas, uvz + index0.ba);
            var layer2Tex = texture(Atlas, uvz + index1.rg);
            var layer3Tex = texture(Atlas, uvz + index1.ba);

            var alphaTex = texture(AlphaLayer, uva + alphaIndex.rg);

             
             
            //FragColor = combinedColor * color * i;


            
            var combinedColor =
                layer0Tex * (1.0f - (alphaTex.r + alphaTex.g + alphaTex.b)) +
                layer1Tex * alphaTex.r +
                layer2Tex * alphaTex.g +
                layer3Tex * alphaTex.b
                //alphaTex
                ;

            FragColor = combinedColor * i; // new vec4(uvs, 0.0f, 0.0f);


            
        }

        private int _heightmap;

        private int _normalmap;

        private int _colormap;

        private int _atlas;

        private int _indexmap;

        private int _indexmap2;

        private int _alphaindexmap;

        private int _alphalayer;

        protected ClipmapShaderLevel0()
        {
            Link();
        }

        
        public Texture2D HeightmapTex
        {
            set { BindTexture(value, _heightmap); }
        }

        public Texture2D NormalTex
        {
            set { BindTexture(value, _normalmap); }
        }

        public Texture2D ColorTex
        {
            set { BindTexture(value, _colormap); }
        }

        public Texture2D AtlasTex
        {
            set { BindTexture(value, _atlas); }
        }

        public Texture2D IndexTex
        {
            set { BindTexture(value, _indexmap); }
        }

        public Texture2D IndexTex2
        {
            set { BindTexture(value, _indexmap2); }
        }

        public Texture2D AlphaIndexTex
        {
            set { BindTexture(value, _alphaindexmap); }
        }

        public Texture2D AlphaLayerTex
        {
            set { BindTexture(value, _alphalayer); }
        }

        public override void Begin()
        {
            base.Begin();

            _heightmap = AllocateSamplerSlot();
            _normalmap = AllocateSamplerSlot();
            _colormap = AllocateSamplerSlot();
            _atlas = AllocateSamplerSlot();
            _indexmap = AllocateSamplerSlot();
            _indexmap2 = AllocateSamplerSlot();
            _alphaindexmap = AllocateSamplerSlot();
            _alphalayer = AllocateSamplerSlot();
            Heightmap = _heightmap.ToSampler();
            Normalmap = _normalmap.ToSampler();
            Colormap = _colormap.ToSampler();
            Atlas = _atlas.ToSampler();
            Indexmap = _indexmap.ToSampler();
            Indexmap2 = _indexmap2.ToSampler();
            AlphaIndexMap = _alphaindexmap.ToSampler();
            AlphaLayer = _alphalayer.ToSampler();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
         
    }
}
