using System;
using System.Collections.Generic;
using System.Drawing;
using Axiom.Core;
using Axiom.Graphics;
using Axiom.Math;
using Axiom.Media;
using IIS.SLSharp.Bindings.Axiom;
using IIS.SLSharp.Examples.Axiom.GeoClipmap.Shaders;
using IIS.SLSharp.Shaders;
using Image = System.Drawing.Image;
using Math = System.Math;

namespace IIS.SLSharp.Examples.Axiom.GeoClipmap.GeoClipmap
{
    public sealed class Clipmap : IDisposable
    {
        private const int K = 8;

        private const int D = 1 << K;

        private const int N = D - 1;

        private const int M = D / 4;

        private const int H = -M - M + 1;

        private const int Hx = -D / 2;

        private readonly int _testMapWidth;

        private readonly int _testMapHeight;

        private readonly float []_testMap;

        private readonly SceneManager _scene;

        private readonly List<PatchRenderable> _queueCache = new List<PatchRenderable>();

        public int DValue
        {
            get { return D; }
        }

        // TODO: remove this and derive H in util classes once the value has proven to be corect
        public int HValue
        {
            get { return H; }
        }

        private const double InverseD = 1.0 / D;

        private const int Levels = 4;

        public const float Scale = 2.0f / D;

        private bool _initialized;

        private readonly ClipmapShader _shader = Shader.CreateSharedShader<ClipmapShader>();

        private readonly ClipmapLevel[] _levels = new ClipmapLevel[Levels];

        public IntFloatVector2 Position;

        public int DebugIndex { get; set; }

        public PatchLocations Locations { get; private set; }

        public float GeneratePixelAt(int x, int y)
        {
            // wrap to positive values
            x %= _testMapWidth;
            if (x < 0)
                x += _testMapWidth;
            y %= _testMapHeight;
            if (y < 0)
                y += _testMapHeight;

            return _testMap[x + y * _testMapWidth];  
        }

        public Clipmap(SceneManager scene)
        {
            _scene = scene;
            _scene.QueueStarted += (sender, args) =>
            {
                if (args.RenderQueueId == _scene.GetRenderQueue().DefaultRenderGroup)
                    QueuePatches(_scene.GetRenderQueue());
                args.SkipInvocation = false;
            };

            using (var testMap = (Bitmap)Image.FromFile(@"height.jpg"))
            {
                _testMapWidth = testMap.Width;
                _testMapHeight = testMap.Height;
                _testMap = new float[_testMapWidth * _testMapHeight];
                var i = 0;
                for (var y = 0; y < testMap.Height; y++)
                    for (var x = 0; x < testMap.Width; x++)
                        _testMap[i++] = testMap.GetPixel(x, y).R / 255.0f;
            }

        
            var tu = _shader.Sampler(() => _shader.Heightmap);
            tu.DesiredFormat = PixelFormat.FLOAT32_RGB;
            tu.SetTextureFiltering(FilterOptions.Point, FilterOptions.Point, FilterOptions.None);
            tu.SetTextureAddressingMode(TextureAddressing.Wrap);
            tu.BindingType = TextureBindingType.Vertex;

            _shader.SetAuto(() => _shader.ModelViewProjectionMatrix, GpuProgramParameters.AutoConstantType.WorldViewProjMatrix);
            //_shader.SetAuto(() => _shader.NormalMatrix, GpuProgramParameters.AutoConstantType.ACT_INVERSE_TRANSPOSE_WORLDVIEW_MATRIX);
            _shader.SetAuto(() => _shader.ScaleFactor, GpuProgramParameters.AutoConstantType.Custom, 0);
            _shader.SetAuto(() => _shader.FineBlockOrigin, GpuProgramParameters.AutoConstantType.Custom, 1);

            Position = new IntFloatVector2(new IntFloat(-_testMapWidth / 4), new IntFloat(-_testMapHeight / 4));

            Locations = new PatchLocations(H, M);

            var scale = Scale;
            var scaleInt = 1;

            for (var i = 0; i < Levels; i++)
            {
                _levels[i] = new ClipmapLevel(scale, scaleInt, this);
                var level = _levels[i];
                tu.SetTextureName(level.Heightmap.Name);
                var m = _shader.CloneMaterial("ClipmapLevel" + i);
                _levels[i].Material = m;
                
                scale *= 2.0f;
                scaleInt *= 2;
            }

            UpdatePosition();
            Reset();

            _initialized = true;
        }


        private void UpdatePosition()
        {
            var pos = Position;
            foreach (var lvl in _levels)
            {
                lvl.SetPosition2(pos);
                pos = pos.Div2();
            }
        }

        public void MoveBy(float dx, float dy)
        {
            if (Math.Abs(dx) < 0.0000001f && Math.Abs(dy) < 0.0000001f)
                return;

            Position = Position.MoveBy(dx, dy);
            UpdatePosition();
        }

        public void Dispose()
        {
            if (!_initialized)
                return;

            _initialized = false;
            Locations.Dispose();
            foreach (var l in _levels)
                l.Dispose();

            _shader.Dispose();
        }

        ~Clipmap()
        {
            Dispose();
        }

        public void ReselectOptimalCache()
        {
            //
        }

        public void Reset()
        {
            foreach (var level in _levels)
                level.Recalculate();
        }

        private readonly Vector4[] _colors = new[] 
        { 
            new Vector4(1.0f, 0.0f, 0.0f, 1.0f), 
            new Vector4(0.0f, 1.0f, 0.0f, 1.0f), 
            new Vector4(0.0f, 0.0f, 1.0f, 1.0f), 
            new Vector4(1.0f, 1.0f, 0.0f, 1.0f), 
            new Vector4(1.0f, 0.0f, 1.0f, 1.0f), 
            new Vector4(0.0f, 1.0f, 1.0f, 1.0f)
        };

        public Vector4 SelectColor(int index)
        {
            return _colors[index % _colors.Length];
        }

        public void QueuePatches(RenderQueue queue)
        {
            var idx = 0;

            for (var i = 0; i < Levels; i++)
            {
                var level = _levels[i];

                var mask = i == 0 ? PatchLocations.PatchSelection.Everything :PatchLocations.PatchSelection.Outer;

                if (i != 0)
                    mask |= PatchLocations.PatchSelection.OuterDegenerated;

                mask |= level.Bottom ? PatchLocations.PatchSelection.InteriorBottom : PatchLocations.PatchSelection.InteriorTop;
                mask |= level.Left ? PatchLocations.PatchSelection.InteriorLeft : PatchLocations.PatchSelection.InteriorRight;

                var subX = level.Position.X.Fraction * 2.0f - 1.0f;
                var intX = level.Position.X.Integer;
                var subY = level.Position.Y.Fraction * 2.0f - 1.0f;
                var intY = level.Position.Y.Integer;
                var texX = (intX * 2) & N;
                var texY = (intY * 2) & N;

                foreach (var p in Locations.Select(mask))
                {
                    PatchRenderable pp;
                    if (_queueCache.Count <= idx)
                    {
                        pp = new PatchRenderable(p.Patch, _shader);
                        _queueCache.Add(pp);
                    } else
                        pp = _queueCache[idx];
                    idx++;


                    // queue the patch for rendering
                    pp.ScaleFactor = new Vector4(p.X + subX, p.Y + subY, level.Scale, level.Scale);
                    pp.FineBlockOrigin = new Vector4(p.X - Hx - texX, p.Y - Hx - texY, (float)InverseD, (float)InverseD);
                    pp.Level = level;
                    queue.AddRenderable(pp);
                }
            }
        }

    }

}