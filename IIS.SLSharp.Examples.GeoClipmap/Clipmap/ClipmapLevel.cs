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

        public float Scale { get; private set; }

        public int ScaleInt { get; private set; }

        private readonly Clipmap _clipmap;

        private readonly int _d;

        private readonly int _h;

        private readonly int _n;

        public IntFloatVector2 Position;

        private readonly float [,]_cache;

        public bool Left
        {
            get { return Position.X.Fraction < 0.5f; }
        }

        public bool Bottom
        {
            get { return Position.Y.Fraction < 0.5f; }
        }

        private float GeneratePixelAt(int xr, int yr)
        {
            // this function encodes zc and zf as described in the geoclipmapping paper

            var x = xr * ScaleInt;
            var y = yr * ScaleInt;

            const float quantizeSteps = 512.0f;


            var scaleInt2 = ScaleInt + ScaleInt;
            var coarsePixel = 0.0f;

            // any of these values actually must be cached in the parent layer
            // as the current later lies within it.
            // the outermost layer will not need to generate the coarse information at all
            // the maximum visible layer(s) should update in the interior region
            // as this data needs to be re(used) anyway.

            switch ((xr & 1) | ((yr & 1) << 1))
            {
                case 3: // odd odd (plain parent pixel)
                    coarsePixel = _clipmap.GeneratePixelAt(x + ScaleInt, y + ScaleInt);
                    break;
                case 2: // even/odd
                    coarsePixel = (_clipmap.GeneratePixelAt(x + scaleInt2, y + ScaleInt) + _clipmap.GeneratePixelAt(x, y + ScaleInt)) * 0.5f;
                    break;
                case 1: // odd/even
                    coarsePixel = (_clipmap.GeneratePixelAt(x + ScaleInt, y + scaleInt2) + _clipmap.GeneratePixelAt(x + ScaleInt, y)) * 0.5f;
                    break;
                case 0: // even/even
                    coarsePixel = (_clipmap.GeneratePixelAt(x + scaleInt2, y) + _clipmap.GeneratePixelAt(x, y + scaleInt2)) * 0.5f;
                    break;
            }

            var finePixel = _clipmap.GeneratePixelAt(x, y);
            //_cache[xr, yr]

            //var finePixel = coarsePixel;
            var zfzd = ((float)Math.Floor(coarsePixel * quantizeSteps) + finePixel) / quantizeSteps;
            return zfzd;
        }

        public ClipmapLevel(float scale, int scaleInt, Clipmap clipmap)
        {
            _d = clipmap.DValue;
            _h = clipmap.HValue;
            _n = _d - 1;

            _cache = new float[_d, _d];

            _clipmap = clipmap;
            Scale = scale;
            ScaleInt = scaleInt;
            Heightmap = new Texture2D(_d, _d, 3, typeof(float));
            Heightmap.Activate();

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

            Heightmap.Finish();
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

        private void UpdateRows(int startY, int size)
        {
            var x = Position.X.Integer;
            var y = Position.Y.Integer;
            var d2 = _d / 2;

            Heightmap.Activate();
            for (var i2 = 0; i2 < size; i2++) // foreach row to be updated
            {
                var i = startY + i2;
                var yt = i & _n; // row in texture

                for (var j = 0; j < _d; j++)
                {
                    // physical to world
                    var cy = ((y * 2 + i)) & ~_n;
                    var cx = ((x * 2 + j)) & ~_n;
                    var yr = i - cy - d2;
                    var xr = j - cx - d2;
                   
                    _slice[j] = GeneratePixelAt(xr, yr);
                }

                GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, yt, _d, 1, PixelFormat.Luminance,
                                 PixelType.Float, _slice); 
            }
        }

        private void UpdateColumns(int startX, int size)
        {
            var x = Position.X.Integer;
            var y = Position.Y.Integer;
            var d2 = _d / 2;

            Heightmap.Activate();
            for (var i2 = 0; i2 < size; i2++)
            {
                var i = startX + i2;
                var xt = i & _n;

                for (var j = 0; j < _d; j++)
                {
                    // physical to world
                    var cy = ((y*2 + j)) & ~_n;
                    var cx = ((x*2 + i)) & ~_n;
                    var yr = j - cy - d2;
                    var xr = i - cx - d2;


                    _slice[j] = GeneratePixelAt(xr, yr);
                }

                
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

        public void Dispose()
        {
            Heightmap.Dispose();
        }

        public void SetPosition2(IntFloatVector2 pos)
        {
            var x = pos.X.Integer * 2 + 1;
            var y = pos.Y.Integer * 2 + 1;
            var oldX = Position.X.Integer * 2 + 1;
            var oldY = Position.Y.Integer * 2 + 1;

            Position = pos;

            // for slice updates we are only interested in the integer part
            if (x == oldX && y == oldY)
                return;

            BeginUpdate();

            
            if (y > oldY)
                UpdateRows((_n - oldY) & _n, Math.Min((y - oldY), _n));
            else if (oldY > y)
                UpdateRows((_n - y) & _n, Math.Min((oldY - y), _n));

            if (x > oldX)
                UpdateColumns((_n - oldX) & _n, Math.Min((x - oldX), _n));
            else if (oldX > x)
                UpdateColumns((_n - x) & _n, Math.Min((oldX - x), _n));

            EndUpdate();
        }
    }
}
