using System;
using System.Diagnostics;
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

        private readonly int _level;

        private readonly int _scaleInt;

        private readonly Clipmap _clipmap;

        private readonly ClipmapLevel _parent;

        private readonly int _d;

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

      
        /// <summary>
        /// Generates the height value at the given physical pixel xp/yp
        /// The pixel coordinates must be within range [0.._d]
        /// </summary>
        /// <param name="xp">physical x position</param>
        /// <param name="yp">physical y position</param>
        /// <returns></returns>
        private float GeneratePixelAt2(int xp, int yp)
        {
            var d2 = _d / 2;
            var x = Position.X.Integer;
            var y = Position.Y.Integer;
            var cx = (x * 2 + xp) & ~_n;
            var cy = (y * 2 + yp) & ~_n;
            var xr = xp - cx - d2;
            var yr = yp - cy - d2;
            var xw = xr << _level;
            var yw = yr << _level;

            //Debug.Assert((((xw + _scaleInt) / _scaleInt + d2) & _n) == (xp + 1) % _d);
            //Debug.Assert((((yw + _scaleInt) / _scaleInt + d2) & _n) == (yp + 1) % _d);

            const float quantizeSteps = 512.0f;

            var coarsePixel = 0.0f;

            // any of these values actually must be cached in the parent layer
            // as the current later lies within it.
            // the outermost layer will not need to generate the coarse information at all
            // the maximum visible layer(s) should update in the interior region
            // as this data needs to be re(used) anyway.

            var l2 = _level + 1;
            if (_parent != null)
            {
                switch ((xr & 1) | ((yr & 1) << 1))
                {
                    case 3: // odd odd (plain parent pixel)
                    {
                        var px1 = (((xw + _scaleInt) >> l2) + d2) & _n;
                        var py1 = (((yw + _scaleInt) >> l2) + d2) & _n;
                        coarsePixel = _parent._cache[py1, px1];

                        //coarsePixel = _clipmap.GeneratePixelAt(xw + ScaleInt, yw + ScaleInt);
                        break;
                    }
                    case 2: // even/odd
                    {
                        var px0 = (((xw) >> l2) + d2) & _n;
                        var py1 = (((yw + _scaleInt) >> l2) + d2) & _n;
                        var px2 = (((xw + _scaleInt*2) >> l2) + d2) & _n;
                        coarsePixel = (_parent._cache[py1, px2] + _parent._cache[py1, px0]) * 0.5f;
                        
                        //coarsePixel = (_clipmap.GeneratePixelAt(xw + scaleInt2, yw + ScaleInt) + _clipmap.GeneratePixelAt(xw, yw + ScaleInt)) * 0.5f;                       
                        break;
                    }
                    case 1: // odd/even
                    {
                        var px1 = (((xw + _scaleInt) >> l2) + d2) & _n;
                        var py0 = (((yw) >> l2) + d2) & _n;
                        var py2 = (((yw + _scaleInt * 2) >> l2) + d2) & _n;
                        coarsePixel = (_parent._cache[py2, px1] + _parent._cache[py0, px1]) * 0.5f;

                        //coarsePixel = (_clipmap.GeneratePixelAt(xw + ScaleInt, yw + scaleInt2) + _clipmap.GeneratePixelAt(xw + ScaleInt, yw)) * 0.5f;
                        break;
                    }
                    case 0: // even/even
                    {
                        var px0 = (((xw) >> l2) + d2) & _n;
                        var px2 = (((xw + _scaleInt * 2) >> l2) + d2) & _n;
                        var py0 = (((yw) >> l2) + d2) & _n;
                        var py2 = (((yw + _scaleInt * 2) >> l2) + d2) & _n;
                        coarsePixel = (_parent._cache[py0, px2] + _parent._cache[py2, px0]) * 0.5f;

                        //coarsePixel = (_clipmap.GeneratePixelAt(xw + scaleInt2, yw) + _clipmap.GeneratePixelAt(xw, yw + scaleInt2)) * 0.5f;
                        break;
                    }
                }
            }

            var finePixel = _clipmap.GeneratePixelAt(xw, yw);
            _cache[yp, xp] = finePixel;

            //var finePixel = coarsePixel;
            var zfzd = ((float)Math.Floor(coarsePixel * quantizeSteps) + finePixel) / quantizeSteps;
            return zfzd;
        }

        public ClipmapLevel(int level, float scale, Clipmap clipmap, ClipmapLevel parent)
        {
            _d = clipmap.DValue;
            _n = _d - 1;

            _cache = new float[_d, _d];

            _clipmap = clipmap;
            _parent = parent;
            _level = level;
            _scaleInt = 1 << _level;
            Scale = scale * _scaleInt;
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
            Heightmap.Activate();
            for (var i2 = 0; i2 < size; i2++) // foreach row to be updated
            {
                var i = startY + i2;
                var yt = i & _n; // row in texture

                for (var j = 0; j < _d; j++)
                    _slice[j] = GeneratePixelAt2(j, yt);

                GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, yt, _d, 1, PixelFormat.Luminance,
                                 PixelType.Float, _slice); 
            }
        }

        private void UpdateColumns(int startX, int size)
        {
            Heightmap.Activate();
            for (var i2 = 0; i2 < size; i2++)
            {
                var i = startX + i2;
                var xt = i & _n;

                for (var j = 0; j < _d; j++)
                    _slice[j] = GeneratePixelAt2(xt, j);

                
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
