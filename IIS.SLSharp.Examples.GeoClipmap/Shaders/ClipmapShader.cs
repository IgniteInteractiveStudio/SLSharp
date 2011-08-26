using System.Drawing;
using System.Reflection;
using System.Resources;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Bindings.OpenTK;
using IIS.SLSharp.Bindings.OpenTK.Textures;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Examples.GeoClipmap.Shaders
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
        public abstract vec2 Origin { set; get; }

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

            var zfZd = texel.x * 512.0f;
            var zd = (Floor(zfZd) + 1.0f) * 0.001953125f;
            var zf = Fraction(zfZd);

            var uvs = new vec2(0.125f*0.5f) / FineBlockOrigin.zw;
            var uvx = (Vertex.xy + Origin.xy) * FineBlockOrigin.zw;
            var a = Clamp(uvx * uvs, new vec2(0.0f), new vec2(1.0f));
            var b = Clamp((new vec2(1.0f) - uvx) * uvs, new vec2(0.0f), new vec2(1.0f));
            
            var c = Min(a, b);
            var d = Min(c.x, c.y);

            // zd = coarse
            // zf = detail
            _z = Lerp(zd, zf, d);

            // planar map
            var worldPosFinal = new vec4(worldPos, _z * 0.3f, 1.0f);

            _finalPos = ModelViewProjectionMatrix * worldPosFinal;
            gl_Position = _finalPos;


            // just for testing, derive normal using interpolation over heights
            var dfdx = (textureLod(Heightmap, _uv + new vec2(FineBlockOrigin.z, 0.0f), 1.0f).r - texel.r);
            var dfdy = (textureLod(Heightmap, _uv + new vec2(0.0f, FineBlockOrigin.w), 1.0f).r - texel.r);
            var dz = 2.0f*ScaleFactor.z - dfdx * dfdx - dfdy * dfdy;
            Normal = new vec3(dfdx, dfdy, dz);

            //normal = normalize(vec3(texel.yz, 1.0));
        }

        [FragmentShader(true)]
        public void ClipmapFragmentMain()
        {
            var light = Normalize(new vec3(0.0f, 1.0f, 0.6f));
            var n = Normalize(Normal);

            
            var n2 = Normalize(Cross(dFdx(_finalPos.xyz),dFdy(_finalPos.xyz)));
            n2.xy = -n2.xy;
            var light2 = new mat3(NormalMatrix) * (light);
            
            var i = Max(Dot(light2, n2), 0.0f) * 0.8f + 0.2f; // Dot(light2, n2);

            FragColor = Color * i;
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
