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

            var finePixel =  _clipmap.GeneratePixelAt(x, y);

            //x &= ~1;
            //y &= ~1;

           
            

            //x += ScaleInt;
            //y += ScaleInt;

            // odd/even == central??
            
            // even/odd  odd/ood
            // even/even odd/even
            var coarsePixel = _clipmap.GeneratePixelAt(x, y);

            var zf = finePixel;
            if (zf < 0.0f)
                zf = 0.0f;
            if (zf > 1.0f)
                zf = 1.0f;
            zf = (float)Math.Round(zf * 512.0f);
            //var zd = coarsePixel - finePixel; // should be 0 for innermost level?!
            //zd = - finePixel;

            var zd = 0.0f;
            //if ((x & 1) == 0 && (y & 1) == 0)
            //    zd = -finePixel;

            // zd can range from -1 to 1 thus normalize to 0..1
            zd += 1.0f;
            zd *= 0.5f; 

            var zfzd = zf + zd;
            zfzd *= 0.001953125f;

            return zfzd;
        }

        public ClipmapLevel(float scale, int scaleInt, Clipmap clipmap)
        {
            _d = clipmap.DValue;
            _h = clipmap.HValue;
            _n = _d - 1;

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
                   
                    _slice[j] = GeneratePixelAt(xr, yr );
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
