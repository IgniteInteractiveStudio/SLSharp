using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Bindings.OpenTK;
using IIS.SLSharp.Bindings.OpenTK.Textures;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Examples.GeoClipmap.Shaders
{
    public abstract class DebugShader: Shader
    {
        private readonly Texture2D _debugTex;

        private int _heightmap;

        public Texture2D HeightmapTex
        {
            set { BindTexture(value, _heightmap); }
        }

        [Uniform]
        public abstract sampler2D DebugTex { set; get; }

        [Uniform]
        public abstract sampler2D Heightmap { set; get; }

        [Uniform]
        public abstract vec4 HeightSize { set; get; }

        [VertexIn(UsageSemantic.Position0)]
        public vec4 Vertex;

        [FragmentOut(UsageSemantic.Color0)]
        public vec4 FragColor;

        [Varying]
        public vec2 _uv;

        [Varying(UsageSemantic.Position0)]
        private vec4 _position;

        [FragmentShader(true)]
        public void DebugFragmentMain()
        {
            var uvs = _uv * HeightSize.xy;
            var subUv = Fraction(uvs);
            var val = (uvs - subUv + new vec2(0.5f)) / HeightSize.xy;
            var height = Texture(Heightmap, val);
            //var height = new vec4(1.0f);

            var idx = height.r * 255.0f;
            idx -= Fraction(idx); // idx = [0..255] now
            idx /= 16.0f;
            var xidx = Fraction(idx);
            idx -= xidx;
            var yidx = idx / 16.0f;
                        
            var tileUv = new vec2(subUv.x/16.0f + xidx, (1.0f-subUv.y)/16.0f + yidx);

            FragColor = Texture(DebugTex, tileUv);


            //FragColor = height;

            //FragColor = texture(Heightmap, _uv); //new vec4(_uv, 0.0f, 1.0f);
        }

        [VertexShader(true)]
        public void FragmentMain()
        {
            _position = Vertex;
            _uv = Vertex.xy * 0.5f + new vec2(0.5f);
        }

        protected DebugShader()
        {
            _debugTex = Texture2D.FromFile(@"E:\SLSharp\IIS.SLSharp.Examples.GeoClipmap\debug.png");
            Link();
        }

        public override void Begin()
        {
            base.Begin();
            _heightmap = AllocateSamplerSlot();
            Heightmap = _heightmap.ToSampler();
            DebugTex = BindTexture(_debugTex).ToSampler();
        }

        public override void Dispose()
        {
            _debugTex.Dispose();
            base.Dispose();
        }
    }
}
