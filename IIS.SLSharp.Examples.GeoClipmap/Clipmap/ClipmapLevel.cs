using System;
using System.Linq;
using IIS.SLSharp.Bindings.OpenTK.Textures;
using IIS.SLSharp.Shaders;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Examples.GeoClipmap.Clipmap
{
    internal sealed class ClipmapLevel : IDisposable
    {
        public Texture2D Heightmap { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }

        public float Scale { get; private set; }

        private readonly Clipmap _clipmap;

        private readonly int _d;

        private readonly int _h;

        private readonly int _n;

        public float SubX { get; private set; }

        public float SubY { get; private set; }

        public float IntX { get; private set; }

        public float IntY { get; private set; }

        public bool Left { get; private set; }

        public bool Bottom { get; private set; }

        public ClipmapLevel(float scale, Clipmap clipmap)
        {
            _d = clipmap.DValue;
            _h = clipmap.HValue;
            _n = _d - 1;

            _clipmap = clipmap;
            Scale = scale;
            Heightmap = new Texture2D(_d, _d, 3, typeof(float));
            Heightmap.Activate();

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

            Heightmap.Finish();
            X = 0;
            Y = 0;
        }


        private int _lastTex;

        private float[] _slice;
        
        private void BeginUpdate()
        {
            if (_slice == null)
                _slice = new float[_d];

            GL.GetInteger(GetPName.TextureBinding2D, out _lastTex);
            Heightmap.Activate();
        }

        private void EndUpdate()
        {
            //Texture.Finish();
            GL.BindTexture(TextureTarget.Texture2D, _lastTex);
        }

        private void UpdateRows(int y, int size)
        {
            float hx = _h;
            float hy = _h;
            hx += SubX - 1;
            hy += SubY - 1;
    
            Heightmap.Activate();
            for (var i = 0; i < size; i++)
            {
                var yt = (y + i) & _n;
                var yr = (-Y + yt) & _n;
                var py = (hy + yr) * Scale;

                for (var j = 0; j < _d; j++)
                {
                    var xr = (-X + j) & _n;
                    var px = (hx + xr)*Scale;
                    // px py = virtual position
                    // j, yt = physical position in texture
                    _slice[j] = _clipmap.GeneratePixelAt(px, py);
                }

                GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, yt, _d, 1, PixelFormat.Luminance,
                                 PixelType.Float, _slice); 
            }
        }

        private void UpdateColumns(int x, int size)
        {
            float hx = _h;
            float hy = _h;
            hx += SubX - 1;
            hy += SubY - 1;

            for (var i = 0; i < size; i++)
            {
                var xt = (x + i) & _n;
                var xr = (-X + xt) & _n;
                var px = (hx + xr) * Scale;

                for (var j = 0; j < _d; j++)
                {
                    var yr = (-Y + j) & _n;
                    var py = (hy + yr)*Scale;
                    _slice[j] = _clipmap.GeneratePixelAt(px, py);
                }

                Heightmap.Activate();
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, xt, 0, 1, _d, PixelFormat.Luminance,
                                 PixelType.Float, _slice);
            }
        }


        public void Recalculate()
        {
            BeginUpdate();
            UpdateRows(0, _d);
            EndUpdate();
        }

        public void SetPosition(int x, int y, bool mx, bool my)
        {
            x &= _n;
            y &= _n;

            if (X == x && Y == y)
                return;

            // TODO: could remove double update of crossing region
            // by using Slice() more intelligent

            // gotta do this more stable
            // currently wrong when moving fast (more than half the region)

            var oldX = X;
            var oldY = Y;

            // might need to do this before updates?
            Y = y;
            X = x;

            BeginUpdate();
            if (oldY != y)
            {
                var y1 = (y - oldY) & _n;
                var y2 = (oldY - y) & _n;

                if (y1 < y2)
                    UpdateRows(oldY, y1);
                else
                    UpdateRows(y, y2);
            }

            if (oldX != x)
            {
                var x1 = (x - oldX) & _n;
                var x2 = (oldX - x) & _n;

                if (x1 < x2)
                    UpdateColumns(oldX, x1);
                else
                    UpdateColumns(x, x2);
            }   

            EndUpdate();
        }

        public void UpdatePosition(ref float xpos, ref float ypos, float xraw, float yraw)
        {
            SubX = (Utilities.Fract(xpos * 0.5f + 0.5f) - 0.5f) * 2;
            SubY = (Utilities.Fract(ypos * 0.5f + 0.5f) - 0.5f) * 2;
            IntX = xraw - SubX;
            IntY = yraw - SubY;
            Left = SubX < 0.0f;
            Bottom = SubY < 0.0f;
            ypos += Bottom ? 0.5f : -0.5f;
            xpos += Left ? 0.5f : -0.5f;
        }

        public void Dispose()
        {
            Heightmap.Dispose();
        }
    }
}
