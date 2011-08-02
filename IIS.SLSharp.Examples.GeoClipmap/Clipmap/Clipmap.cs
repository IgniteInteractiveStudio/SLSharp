using System;
using IIS.SLSharp.Bindings.OpenTK;
using IIS.SLSharp.Examples.GeoClipmap.Shaders;
using IIS.SLSharp.Shaders;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Examples.GeoClipmap.Clipmap
{
    public sealed class Clipmap : IDisposable
    {
        private const int K = 8;

        private const int D = 1 << K;

        private const int N = D - 1;

        private const int M = D / 4;

        private const int H = -M - M + 1;

        private const int Hx = -D / 2;

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

        private const int Levels = 1;

        public const float Scale = 2.0f / D;

        private bool _initialized;

        private readonly ClipmapShader _shader = Shader.CreateSharedShader<ClipmapShader>();

        private readonly ClipmapLevel[] _levels = new ClipmapLevel[Levels];

        public float XPosition { get; private set; }

        public float YPosition { get; private set; }

        private bool _mx, _my;

        public int DebugIndex { get; set; }

        public PatchLocations Locations { get; private set; }

        public float GeneratePixelAt(float x, float y)
        {
            return (float)(Math.Sin(y * 10.0f) * Math.Sin(x * 10.0f));
        }

        private void GenerateTestTexture()
        {
            foreach (var lvl in _levels)
                lvl.Recalculate();
        }

        public Clipmap()
        {
            Locations = new PatchLocations(H, M);

            var scale = Scale;

            for (var i = 0; i < Levels; i++)
            {
                _levels[i] = new ClipmapLevel(scale, this);
                scale *= 0.5f;
            }

            GenerateTestTexture();
            UpdatePosition();

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
            var xpos = XPosition * (2 * D);
            var ypos = YPosition * (2 * D);
            var xraw = xpos;
            var yraw = ypos;

            foreach (var lvl in _levels)
            {
                lvl.UpdatePosition(ref xpos, ref ypos, xraw, yraw);

                xpos += xpos;
                ypos += ypos;
                xraw += xraw;
                yraw += yraw;

                lvl.SetPosition((int)-lvl.IntX & N, (int)-lvl.IntY & N, _mx, _my);
            }
        }

        public void MoveBy(float dx, float dy)
        {
            if (Math.Abs(dx) < 0.0000001f && Math.Abs(dy) < 0.0000001f)
                return;

            _mx = dx >= 0;
            _my = dy >= 0;

            XPosition = Utilities.Fract(XPosition + 0.5f + dx) - 0.5f;
            YPosition = Utilities.Fract(YPosition + 0.5f + dy) - 0.5f;

            UpdatePosition();
        }

        public void Render(Matrix4 modelviewProjection, bool debugColors)
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
 
            var vloc = Shader.AttributeLocation(_shader, () => _shader.Vertex);

            //var tmp = new List<AxisAlignedBoundingBox>();
            for (var i = 0; i < Levels; i++)
            {
                var level = _levels[i];

                BeginLevel(i);
                if (debugColors)
                    SelectColor(i);
                else
                    GL.Color3(1.0f, 1.0f, 1.0f);

                var mask = i == Levels - 1 ? PatchLocations.PatchSelection.Everything : PatchLocations.PatchSelection.Outer;

                // test line
                //mask = PatchLocations.PatchSelection.OuterDegenerated | PatchLocations.PatchSelection.BaseBottomLeft;

                if (i != 0)
                    mask |= PatchLocations.PatchSelection.OuterDegenerated;

                mask |= level.Bottom ? PatchLocations.PatchSelection.InteriorBottom : PatchLocations.PatchSelection.InteriorTop;
                mask |= level.Left ? PatchLocations.PatchSelection.InteriorLeft : PatchLocations.PatchSelection.InteriorRight;

                foreach (var p in Locations.Select(mask))
                {
                    var pp = p.Patch;

                    //GL.Color3(1.0f, 1.0f, 1.0f);
                    //if (((1 << p.Index) & (int)PatchLocations.PatchSelection.Fixup) != 0)
                    //    GL.Color3(1.0f, 0.0f, 0.0f);

                    _shader.ScaleFactor = new Vector4(p.X + level.SubX, p.Y + level.SubY, level.Scale, level.Scale).ToVector4F();
                    _shader.FineBlockOrigin = new Vector4(p.X - Hx - level.IntX + 0.5f, p.Y - Hx - level.IntY + 0.5f, (float)InverseD, (float)InverseD).ToVector4F();
                    pp.Draw(vloc);
                }
            }

            EndDraw();
            _shader.End();

            /*
            foreach (var lvl in _levels)
            {
                if (Intersection.SolidSolid(cam.Frustum, lvl.BoundingBoxes[5]))
                    GL.Color3(1.0, 0.0, 0.0);
                else GL.Color3(0.0, 1.0, 0.0);

                lvl.BoundingBoxes[5].Render();
            }*/

            //foreach (var bb in tmp)
            //    bb.Render();
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

        public static void SelectColor(int index)
        {
            //GL.Color3(Colors[index % Colors.Length]);
            GL.Color3(1.0f, 1.0f, 1.0f);
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
                SelectColor(i);

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

                var px = x + Utilities.Fract(lvl.X * (float)InverseD + 0.5f);
                var py = y + Utilities.Fract(-lvl.Y * (float)InverseD + 0.5f);

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
        }

    }

}