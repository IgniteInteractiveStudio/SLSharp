using System;
using System.Drawing;
using IIS.SLSharp.Bindings.OpenTK;
using IIS.SLSharp.Examples.GeoClipmap.Shaders;
using IIS.SLSharp.Shaders;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Examples.GeoClipmap.Clipmap
{
    public sealed class Clipmap : IDisposable
    {
        private const int Levels = 8;

        private int _activeMin;

        public int ActiveMin
        {
            get { return _activeMin; }
            set
            {
                _activeMin = value;
                UpdatePosition();
            }
        }

        private int _activeMax;

        public int ActiveMax
        {
            get { return _activeMax; }
            set
            {
                _activeMax = Math.Min(value, Levels);
                UpdatePosition();
            }
        }

        private const int K = 8;

        private const int D = 1 << K;

        private const int N = D - 1;

        private const int M = D / 4;

        private const int H = -M - M + 1;

        private const int Hx = -D / 2;

        private readonly Bitmap _testMap;

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

        private void GenerateTestTexture()
        {
            foreach (var lvl in _levels)
                lvl.Recalculate();
        }

        public Clipmap()
        {
            //_testMap = (Bitmap)Image.FromFile("height.png");
            _testMap = (Bitmap)Image.FromFile(@"height.jpg");
            

            //Position = new IntFloatVector2(new IntFloat(-_testMap.Width / 4), new IntFloat(-_testMap.Height / 4));

            Locations = new PatchLocations(H, M);

            ClipmapLevel parent = null;
            for (var i = Levels - 1; i >= 0; i--)
            {
                _levels[i] = new ClipmapLevel(i, Scale, this, parent);
                parent = _levels[i];
            }

            GenerateTestTexture();
            ActiveMin = 0;
            ActiveMax = Levels;
            UpdatePosition();
            Reset();

            _initialized = true;
        }

        private static void BeginDraw()
        {
        }

        private void BeginLevel(int i)
        {
            _shader.HeightmapTex = _levels[i].Heightmap;
        }

        private static void EndDraw()
        {
        }


        private void UpdatePosition()
        {
            var pos = Position;
            var p = new IntFloatVector2[Levels]; // TODO: could make this a member var

            for (var i = 0; i < ActiveMax; i++)
            {
                p[i] = pos;
                pos = pos.Div2();
            }

            // we need to update from coarse to detail levels
            // as detail levels access the coarse level caches
            for (var i = ActiveMax - 1; i >= 0; i--)
            {
                var lvl = _levels[i];
                lvl.SetPosition2(p[i]);
            } 
        }

        public void MoveBy(float dx, float dy)
        {
            if (Math.Abs(dx) < 0.0000001f && Math.Abs(dy) < 0.0000001f)
                return;
            /*
            _mx = dx >= 0;
            _my = dy >= 0;

            XPosition = Utilities.Fract(XPosition + 0.5f + dx) - 0.5f;
            YPosition = Utilities.Fract(YPosition + 0.5f + dy) - 0.5f;
             */

            Position = Position.MoveBy(dx, dy);
            UpdatePosition();
        }

        public void Render(Matrix4 modelviewProjection, Matrix4 normalMatrix, bool debugColors)
        {
            _shader.Begin();

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

            for (var i = ActiveMin; i < ActiveMax; i++)
            
            {
                var level = _levels[i];

                BeginLevel(i);
                _shader.Color = debugColors ? SelectColor(i).ToVector4F() : new Vector4(1.0f, 1.0f, 1.0f, 1.0f).ToVector4F();

                var mask = i == ActiveMin ? PatchLocations.PatchSelection.Everything : PatchLocations.PatchSelection.Outer;

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
                    _shader.Origin = new Vector2(p.X - Hx, p.Y - Hx).ToVector2F();
                    pp.Draw(vloc);
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

        public void Debug()
        {
            var rows = (int)(Math.Sqrt(Levels));
            var cols = (Levels + rows - 1) / rows;

            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Ortho(0, cols, rows, 0, -1, 1);

            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();
            GL.LoadIdentity();

            for (var i = 0; i < Levels; i++)
            {
                var x = i % cols;
                var y = i / cols;
                var lvl = _levels[i];

                lvl.Heightmap.Activate();
                GL.Color4(SelectColor(i));

                GL.Enable(EnableCap.Texture2D);
                GL.Begin(BeginMode.Quads);
                GL.TexCoord2(0.0f, 0.0f);
                GL.Vertex2(x, y + 1);
                GL.TexCoord2(1.0f, 0.0f);
                GL.Vertex2(x + 1, y + 1);
                GL.TexCoord2(1.0f, 1.0f);
                GL.Vertex2(x + 1, y);
                GL.TexCoord2(0.0f, 1.0f);
                GL.Vertex2(x, y);
                GL.End();
                GL.Disable(EnableCap.Texture2D);

                var px = x + Utilities.Fract(lvl.Position.X.Integer * (float)InverseD + 0.5f);
                var py = y + Utilities.Fract(-lvl.Position.Y.Integer * (float)InverseD + 0.5f);

                GL.PointSize(4.0f);
                GL.Color3(1.0f, 0.0f, 0.0f);
                GL.Begin(BeginMode.Points);
                GL.Vertex3(px, py, 0.1f);
                GL.End();

                GL.PointSize(2.0f);
                GL.Color3(0.0f, 1.0f, 0.0f);
                GL.Begin(BeginMode.Points);
                GL.Vertex3(px, py, 0.2f);
                GL.End();

                var pxn = x + Utilities.Fract(px - 0.25f);
                var pyn = y + Utilities.Fract(py - 0.25f);
                var pxp = x + Utilities.Fract(px + 0.25f);
                var pyp = y + Utilities.Fract(py + 0.25f);

                GL.LineWidth(3.0f);
                GL.Color3(1.0f, 0.0f, 0.0f);
                GL.Begin(BeginMode.Lines);

                // horizontal lines
                if (pxp > pxn)
                {
                    GL.Vertex3(pxn, pyn, 0.1f);
                    GL.Vertex3(pxp, pyn, 0.1f);
                    GL.Vertex3(pxn, pyp, 0.1f);
                    GL.Vertex3(pxp, pyp, 0.1f);
                }
                else
                {
                    GL.Vertex3(x + 1, pyn, 0.1f);
                    GL.Vertex3(pxn, pyn, 0.1f);
                    GL.Vertex3(pxp, pyn, 0.1f);
                    GL.Vertex3(x, pyn, 0.1f);
                    GL.Vertex3(x + 1, pyp, 0.1f);
                    GL.Vertex3(pxn, pyp, 0.1f);
                    GL.Vertex3(pxp, pyp, 0.1f);
                    GL.Vertex3(x, pyp, 0.1f);
                }

                // vertical lines
                if (pyp > pyn)
                {
                    GL.Vertex3(pxn, pyn, 0.1f);
                    GL.Vertex3(pxn, pyp, 0.1f);
                    GL.Vertex3(pxp, pyn, 0.1f);
                    GL.Vertex3(pxp, pyp, 0.1f);
                }
                else
                {
                    GL.Vertex3(pxn, y + 1, 0.1f);
                    GL.Vertex3(pxn, pyn, 0.1f);
                    GL.Vertex3(pxn, pyp, 0.1f);
                    GL.Vertex3(pxn, y, 0.1f);
                    GL.Vertex3(pxp, y + 1, 0.1f);
                    GL.Vertex3(pxp, pyn, 0.1f);
                    GL.Vertex3(pxp, pyp, 0.1f);
                    GL.Vertex3(pxp, y, 0.1f);
                }

                GL.End();

                GL.LineWidth(1.0f);
                GL.Color3(0.0f, 1.0f, 0.0f);
                GL.Begin(BeginMode.Lines);

                // horizontal lines
                if (pxp > pxn)
                {
                    GL.Vertex3(pxn, pyn, 0.2f);
                    GL.Vertex3(pxp, pyn, 0.2f);
                    GL.Vertex3(pxn, pyp, 0.2f);
                    GL.Vertex3(pxp, pyp, 0.2f);
                }
                else
                {
                    GL.Vertex3(x + 1, pyn, 0.2f);
                    GL.Vertex3(pxn, pyn, 0.2f);
                    GL.Vertex3(pxp, pyn, 0.2f);
                    GL.Vertex3(x, pyn, 0.2f);
                    GL.Vertex3(x + 1, pyp, 0.2f);
                    GL.Vertex3(pxn, pyp, 0.2f);
                    GL.Vertex3(pxp, pyp, 0.2f);
                    GL.Vertex3(x, pyp, 0.2f);
                }

                // vertical lines
                if (pyp > pyn)
                {
                    GL.Vertex3(pxn, pyn, 0.2f);
                    GL.Vertex3(pxn, pyp, 0.2f);
                    GL.Vertex3(pxp, pyn, 0.2f);
                    GL.Vertex3(pxp, pyp, 0.2f);
                }
                else
                {
                    GL.Vertex3(pxn, y + 1, 0.2f);
                    GL.Vertex3(pxn, pyn, 0.2f);
                    GL.Vertex3(pxn, pyp, 0.2f);
                    GL.Vertex3(pxn, y, 0.2f);
                    GL.Vertex3(pxp, y + 1, 0.2f);
                    GL.Vertex3(pxp, pyn, 0.2f);
                    GL.Vertex3(pxp, pyp, 0.2f);
                    GL.Vertex3(pxp, y, 0.2f);
                }

                GL.End();
            }

            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();
             
            /*
            var level = _levels[0];
            _debugShader.Begin();
            _debugShader.HeightSize = new Vector4(D).ToVector4F();
            _debugShader.HeightmapTex = level.Heightmap;
            Shader.RenderQuad(_debugShader, () => _debugShader.Vertex);
            _debugShader.End();
             */

        }

    }

}