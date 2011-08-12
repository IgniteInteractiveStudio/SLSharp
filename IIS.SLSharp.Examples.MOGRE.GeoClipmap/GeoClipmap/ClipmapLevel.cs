using System;
using Mogre;
using Math = System.Math;

namespace IIS.SLSharp.Examples.MOGRE.GeoClipmap.GeoClipmap
{
    internal sealed class ClipmapLevel : IDisposable
    {
        public TexturePtr Heightmap { get; private set; }

        public float Scale { get; private set; }

        public int ScaleInt { get; private set; }

        private readonly Clipmap _clipmap;

        private readonly int _d;

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

        internal MaterialPtr Material;

        private float GeneratePixelAt(int xr, int yr)
        {
            // this function encodes zc and zf as described in the geoclipmapping paper

            var x = xr * ScaleInt;
            var y = yr * ScaleInt;

            var finePixel =  _clipmap.GeneratePixelAt(x, y);

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
            _n = _d - 1;

            _clipmap = clipmap;
            Scale = scale;
            ScaleInt = scaleInt;

            Heightmap = TextureManager.Singleton.CreateManual("Level_" + scaleInt, ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME, TextureType.TEX_TYPE_2D, (uint)_d, (uint)_d, 0, PixelFormat.PF_FLOAT32_RGB);
        }



        private void UpdateContinousRows(int startY, int size, int yOff)
        {
            var x = Position.X.Integer;
            var y = Position.Y.Integer;
            var d2 = _d / 2;
            var buf = Heightmap.GetBuffer();
            var endY = startY + size;

            int colAdvance;
            var data = buf.Lock(new Box(0, (uint)startY, (uint)_d, (uint)endY), HardwareBuffer.LockOptions.HBL_DISCARD);
            switch (data.format)
            {
                case PixelFormat.PF_FLOAT32_RGB:
                    colAdvance = 3;
                    break;
                case PixelFormat.PF_FLOAT32_RGBA:
                    colAdvance = 4;
                    break;
                case PixelFormat.PF_FLOAT32_R:
                    colAdvance = 1;
                    break;
                default:
                    throw new SLSharpException("No proper pixelformat supported");
            }
            var rowAdvance = data.rowPitch * colAdvance;

            unsafe
            {
                var p = (float*)data.data;
                for (var i2 = 0; i2 < size; i2++) // foreach row to be updated
                {
                    var i = yOff + i2;                    
                    for (var j = 0; j < _d; j++)
                    {
                        // physical to world
                        var cy = (y * 2 + i) & ~_n;
                        var cx = (x * 2 + j) & ~_n;
                        var yr = i - cy - d2;
                        var xr = j - cx - d2;

                        p[j * colAdvance] = GeneratePixelAt(xr, yr);
                    }

                    p += rowAdvance;
                }
            }

            buf.Unlock();
        }


        private void UpdateRows(int startY, int size)
        {
            var endY = startY + size;
            if (endY < _d)
            {
                UpdateContinousRows(startY, size, startY);
                return;
            }

            var lowCount = _d - startY;
            UpdateContinousRows(startY, lowCount, startY);
            if (size > lowCount)
                UpdateContinousRows(0, size - lowCount, startY + lowCount);
        }

        private void UpdateContinousColumns(int startX, int size, int xOff)
        {
            var x = Position.X.Integer;
            var y = Position.Y.Integer;
            var d2 = _d / 2;

            var buf = Heightmap.GetBuffer();
            var endX = startX + size;

            int colAdvance;
            var data = buf.Lock(new Box((uint)startX, 0, (uint)endX, (uint)_d), HardwareBuffer.LockOptions.HBL_DISCARD);
            switch (data.format)
            {
                case PixelFormat.PF_FLOAT32_RGB:
                    colAdvance = 3;
                    break;
                case PixelFormat.PF_FLOAT32_RGBA:
                    colAdvance = 4;
                    break;
                case PixelFormat.PF_FLOAT32_R:
                    colAdvance = 1;
                    break;
                default:
                    throw new SLSharpException("No proper pixelformat supported");
            }
            var rowAdvance = data.rowPitch * colAdvance;

            unsafe
            {
                var p = (float*)data.data;
                for (var i2 = 0; i2 < size; i2++) // for each column to be updates
                {
                    var i = xOff + i2;

                    for (var j = 0; j < _d; j++)
                    {
                        // physical to world
                        var cy = ((y * 2 + j)) & ~_n;
                        var cx = ((x * 2 + i)) & ~_n;
                        var yr = j - cy - d2;
                        var xr = i - cx - d2;

                        p[j * rowAdvance] = GeneratePixelAt(xr, yr);
                    }

                    p += colAdvance;
                }
            }

            buf.Unlock();
        }

        private void UpdateColumns(int startX, int size)
        {
            var endX = startX + size;
            if (endX < _d)
            {
                UpdateContinousColumns(startX, size, startX);
                return;
            }

            var lowCount = _d - startX;
            UpdateContinousColumns(startX, lowCount, startX);
            if (size > lowCount)
                UpdateContinousColumns(0, size - lowCount, startX + lowCount);
        }


        public void Recalculate()
        {
            UpdateRows(0, _d);
        }

        public void Dispose()
        {
            Material.Dispose();
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
            
            if (y > oldY)
                UpdateRows((_n - oldY) & _n, Math.Min((y - oldY), _n));
            else if (oldY > y)
                UpdateRows((_n - y) & _n, Math.Min((oldY - y), _n));

            if (x > oldX)
                UpdateColumns((_n - oldX) & _n, Math.Min((x - oldX), _n));
            else if (oldX > x)
                UpdateColumns((_n - x) & _n, Math.Min((oldX - x), _n));
        }
    }
}
