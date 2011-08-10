using System;
using System.Collections.Generic;
using System.Drawing;
using IIS.SLSharp.Bindings.MOGRE;
using IIS.SLSharp.Examples.MOGRE.GeoClipmap.Shaders;
using IIS.SLSharp.Shaders;
using Mogre;
using Image = System.Drawing.Image;
using Math = System.Math;

namespace IIS.SLSharp.Examples.MOGRE.GeoClipmap.GeoClipmap
{
    public sealed class Clipmap : IDisposable
    {
        private const int K = 8;

        private const int D = 1 << K;

        private const int N = D - 1;

        private const int M = D / 4;

        private const int H = -M - M + 1;

        private const int Hx = -D / 2;

        private readonly Bitmap _testMap;

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
            x %= _testMap.Width;
            if (x < 0)
                x += _testMap.Width;
            y %= _testMap.Height;
            if (y < 0)
                y += _testMap.Height;

            return _testMap.GetPixel(x, y).R / 255.0f;
             
             

            //if (x < 0 || y < 0)
            //    return 0.2f + 0.8f * (float)rng.NextDouble(); ;
            //return 0.0f;

            /*
            const float scale = 1.0f/D * 1.340f;
            return (float)(Math.Sin(y * Math.PI * scale) * Math.Sin(x * Math.PI * scale) * 0.5 + 0.5);
             */
             
            /*
            if (y < 0)
                return 0.0f;
            return Math.Min(y/255.0f, 1.0f);
             */
             
        }

        public Clipmap(SceneManager scene)
        {
            //_testMap = (Bitmap)Image.FromFile("height.png");
            _scene = scene;
            _scene.RenderQueueStarted += (byte groupId, string invocation, out bool skipThisInvocation) =>
            {
                if (groupId == _scene.RenderQueue.DefaultQueueGroup)
                    QueuePatches(_scene.RenderQueue);
                skipThisInvocation = false;
            };
            _testMap = (Bitmap)Image.FromFile(@"height.jpg");


            var mat = _shader.ToMaterial();
            var pass = mat.GetTechnique(0).GetPass(0);
            //pass.CullingMode = CullingMode.CULL_NONE;
            //pass.PolygonMode = PolygonMode.PM_POINTS;
            
            var tu = _shader.Sampler(() => _shader.Heightmap);
            tu.DesiredFormat = PixelFormat.PF_FLOAT32_RGB;
            tu.SetTextureFiltering(FilterOptions.FO_POINT, FilterOptions.FO_POINT, FilterOptions.FO_NONE);
            tu.SetTextureAddressingMode(TextureUnitState.TextureAddressingMode.TAM_WRAP);
            tu.SetBindingType(TextureUnitState.BindingType.BT_VERTEX);

            _shader.SetAuto(() => _shader.ModelViewProjectionMatrix, GpuProgramParameters.AutoConstantType.ACT_WORLDVIEWPROJ_MATRIX);
            _shader.SetAuto(() => _shader.NormalMatrix, GpuProgramParameters.AutoConstantType.ACT_INVERSE_TRANSPOSE_WORLDVIEW_MATRIX);
            _shader.SetAuto(() => _shader.ScaleFactor, GpuProgramParameters.AutoConstantType.ACT_CUSTOM, 0);
            _shader.SetAuto(() => _shader.FineBlockOrigin, GpuProgramParameters.AutoConstantType.ACT_CUSTOM, 1);

            Position = new IntFloatVector2(new IntFloat(-_testMap.Width / 4), new IntFloat(-_testMap.Height / 4));

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

        private static void BeginDraw()
        {
        }

        private void BeginLevel(int i)
        {
            //_shader.HeightmapTex = _levels[i].Heightmap;
        }

        private static void EndDraw()
        {
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

        public void Render(Matrix4 modelviewProjection, Matrix4 normalMatrix, bool debugColors)
        {
            _shader.Begin();
            _shader.alpha = 0.5f + 0.5f * (float)Math.Sin((DateTime.Now.Millisecond + DateTime.Now.Second * 1000) * 0.01f);

            _shader.ModelViewProjectionMatrix = modelviewProjection.ToMatrix4F();

            BeginDraw();

            _shader.DebugValue = (DebugIndex & 1) == 1 ? 1.0f : 0.0f;
            _shader.ScaleFactor = new Vector4(0.1f, 0.1f, 0.0f, 0.0f).ToVector4F();
            _shader.FineBlockOrigin = (new Vector4(0.01f, 0.01f, 0.0f, 0.0f)).ToVector4F();
            _shader.ViewerPosition = new Vector2(0.0f, 0.0f).ToVector2F();
            _shader.AlphaOffset = new Vector2(0.0f, 0.0f).ToVector2F();
            _shader.OneOverWidth = new Vector2(1.0f / M, 1.0f / M).ToVector2F();
            _shader.NormalMatrix = normalMatrix.ToMatrix4F();
 
            var vloc = Shader.AttributeLocation(_shader, () => _shader.Vertex);

            for (var i = 0; i < Levels; i++)
            {
                var level = _levels[i];

                BeginLevel(i);
                _shader.Color = debugColors ? SelectColor(i).ToVector4F() : new Vector4(1.0f, 1.0f, 1.0f, 1.0f).ToVector4F();

                var mask = i == 0 ? PatchLocations.PatchSelection.Everything : PatchLocations.PatchSelection.Outer;

                // test line
                //mask = PatchLocations.PatchSelection.OuterDegenerated | PatchLocations.PatchSelection.BaseBottomLeft;

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
                    var pp = p.Patch;
                    _shader.ScaleFactor = new Vector4(p.X + subX, p.Y + subY, level.Scale, level.Scale).ToVector4F();
                    _shader.FineBlockOrigin = new Vector4(p.X - Hx - texX, p.Y - Hx - texY, (float)InverseD, (float)InverseD).ToVector4F();
                    //pp.Draw(vloc);
                }
            }

            EndDraw();
            _shader.End();
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

                // test line
                //mask = PatchLocations.PatchSelection.OuterDegenerated | PatchLocations.PatchSelection.BaseBottomLeft;

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