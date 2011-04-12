#define InvariantVersion // generates recursive wangset rotation invariant
#define MirrorInvariant  // generates recursive wangset mirror invariant

using System;
using System.Drawing;
using IIS.SLSharp.Bindings.OpenTK.Textures;
using OpenTK.Graphics.OpenGL;

///////////////////////////////////////////////////////////////
//  +--0--+  +--1--+
//  | Bit |  |     |
//  1 Ind 2  2     4
//  | ex  |  |     |
//  +--3--+  +--8--+
// 
// 
//  +--0--+--0--+--0--+--0--+
//  |     |     |     |     |
//  0  8  0  12 1  14 1  10 0
//  |     |     |     |     |
//  +--1--+--1--+--1--+--1--+
//  |     |     |     |     |
//  0  9  0  13 1  15 1  11 0
//  |     |     |     |     |
//  +--1--+--1--+--1--+--1--+
//  |     |     |     |     |
//  0  1  0  5  1  7  1  3  0
//  |     |     |     |     |
//  +--0--+--0--+--0--+--0--+
//  |     |     |     |     |
//  0  0  0  4  1  6  1  2  0
//  |     |     |     |     |
//  +--0--+--0--+--0--+--0--+

// index x table        index y table
// 0 <- 8, 9, 1, 0      0 <- 8, 12, 14, 10
// 1 <- 12, 13, 5, 4    1 <- 9, 13, 15, 11
// 2 <- 14, 15, 7, 6    2 <- 1, 5, 7, 3
// 3 <- 10, 11, 3, 2    3 <- 0, 4, 6, 2
//
// inverse tables
// x: 0, 0, 3, 3, 1, 1, 2, 2, 0, 0, 3, 3, 1, 1, 2, 2
// y: 3, 2, 3, 2, 3, 2, 3, 2, 0, 1, 0, 1, 0, 1, 0, 1

// 0 => 0
// 1 => 64
// 2 => 128
// 3 => 196

namespace IIS.SLSharp.Examples.Complex.Textures
{
    internal static class WangHelper
    {
        [Serializable]
        public enum Bit
        {
            Top = 1,
            Left = 2,
            Right = 4,
            Bottom = 8
        }

        public static void GenerateTile(int width, int height, Random rng, byte[,] pixels,
            byte[] left, byte[] right, byte[] top, byte[] bottom, bool copyTopLeft = false)
        {
            var xmax = width - 1;
            var ymax = height - 1;

            if (right == null)
                xmax = -1;

            if (bottom == null)
                ymax = -1;

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var tile = rng.Next() & 0xF;

                    if (x > 0)
                    {
                        // left edge is constrained by x-1 and must be
                        // same as x-1's right edge
                        if ((pixels[(x - 1) + y * width,0] & (int)Bit.Right) != 0)
                            tile |= (int)(Bit.Left);
                        else
                            tile &= (int)(~Bit.Left);
                    }
                    else if (left != null)
                    {
                        // left edge is constrained by "left"
                        if (copyTopLeft)
                            tile = left[y];
                        else if ((left[y] & (int)Bit.Right) != 0)
                            tile |= (int)(Bit.Left);
                        else
                            tile &= (int)(~Bit.Left);
                    }

                    if (y > 0)
                    {
                        // top edge is constrainted by y-1 and must be
                        // same as y-1's bottom edge
                        if ((pixels[x + (y - 1) * width,0] & (int)Bit.Bottom) != 0)
                            tile |= (int)(Bit.Top);
                        else
                            tile &= (int)(~Bit.Top);
                    }
                    else if (top != null)
                    {
                        // top edge is constrained by "top"
                        if (copyTopLeft)
                            tile = top[x];
                        else if ((top[x] & (int)Bit.Bottom) != 0)
                            tile |= (int)(Bit.Top);
                        else
                            tile &= (int)(~Bit.Top);
                    }

                    if (x == xmax)
                    {
                        // right edge is constrained by "right"
                        // ReSharper disable PossibleNullReferenceException
                        if ((right[y] & (int)Bit.Left) != 0)
                            // ReSharper restore PossibleNullReferenceException
                            tile |= (int)(Bit.Right);
                        else
                            tile &= (int)(~Bit.Right);
                    }
                    if (y == ymax)
                    {
                        // bottom edge is constrained by "bottom"
                        // ReSharper disable PossibleNullReferenceException
                        if ((bottom[x] & (int)Bit.Top) != 0)
                            // ReSharper restore PossibleNullReferenceException
                            tile |= (int)(Bit.Bottom);
                        else
                            tile &= (int)(~Bit.Bottom);
                    }

                    pixels[x + y * width,0] = (byte)tile;
                }
            }
        }

        public static void GenerateIndices(byte[,] map)
        {
            var indices = new byte[,]
            {
                { 0, 192 },
                { 0, 128 },
                { 192, 192 },
                { 192, 128 },
                { 64, 192 },
                { 64, 128 },
                { 128, 192 },
                { 128, 128 },
                { 0, 0 },
                { 0, 64 },
                { 192, 0 },
                { 192, 64 },
                { 64, 0 },
                { 64, 64 },
                { 128, 0 },
                { 128, 64 }
            };

            var pels = map.GetLength(0);
            for (var i = 0; i < pels; i++)
            {
                var idx = map[i, 0];
                map[i, 0] = indices[idx, 0];
                map[i, 1] = indices[idx, 1];
            }
        }
    }

    // creates a recursive wang map
    // that is a wang index map which itself is a wang tilemap
    public class WangMap : Texture2D
    {
        private readonly byte[,] _map;

        private readonly int _subHeight;

        private readonly int _subWidth;

        private readonly Random _rand = new Random(123);
 
        private readonly int[] _xTable = { 0, 0, 3, 3, 1, 1, 2, 2, 0, 0, 3, 3, 1, 1, 2, 2 };

        private readonly int[] _yTable = { 3, 2, 3, 2, 3, 2, 3, 2, 0, 1, 0, 1, 0, 1, 0, 1 };

        private void Upload(byte[,] tile, int index)
        {
            var startx = _xTable[index]*_subWidth;
            var starty = _yTable[index]*_subHeight;
            var w = Width;

            for (var y = 0; y < _subHeight; y++)
                for (var x = 0; x < _subWidth; x++)
                    _map[startx + x + (starty + y)*w, 0] = tile[x + y*_subWidth, 0];
        }

        public void Dump()
        {
            var bmp = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    bmp.SetPixel(x, y, Color.FromArgb(
                        0,
                        _map[x + y * Width, 0],
                        _map[x + y * Width, 1],
                        0));
                }
            }

            bmp.Save("dump.bmp");
        }

        public WangMap(int width, int height) : base(width * 4, height * 4, 2, typeof(byte))
        {
            _subHeight = height;
            _subWidth = width;

            // start off with generating tile "12"
            // which has red top red left and green bottom green right
            // thus it can have ompletley random side edges

            _map = new byte[height * width * 4 * 4, 2];
            var basetile = new byte[height*width, 1];
#if !InvariantVersion

            #region Simple Version

            var constraints = new byte[8][];
            constraints[0] = new byte[_subWidth];  // top red
            constraints[1] = new byte[_subWidth];  // top green
            constraints[2] = new byte[_subHeight]; // left red
            constraints[3] = new byte[_subHeight]; // left green
            constraints[4] = new byte[_subHeight]; // right red
            constraints[5] = new byte[_subHeight]; // right green
            constraints[6] = new byte[_subWidth];  // bottom red
            constraints[7] = new byte[_subWidth];  // bottom green

            // generate tile 12
            WangHelper.GenerateTile(_subWidth, _subHeight, _rand, basetile, null, null, null, null);
            Upload(basetile, 12);

            // copy constraints
            for (var x = 0; x < _subWidth; x++)
            {
                constraints[6][x] = basetile[x,0];
                constraints[1][x] = basetile[(_subHeight - 1)*_subWidth + x,0];
            }

            for (var y = 0; y < _subHeight; y++)
            {
                constraints[4][y] = basetile[y*_subWidth,0];
                constraints[3][y] = basetile[y*_subWidth + _subWidth - 1,0];  
            }

            // generate tile 3
            WangHelper.GenerateTile(_subWidth, _subHeight, _rand, basetile,
                constraints[3], constraints[4],
                constraints[1], constraints[6]);
            Upload(basetile, 3);

            // copy constraints
            for (var x = 0; x < _subWidth; x++)
            {
                constraints[7][x] = basetile[x,0];
                constraints[0][x] = basetile[(_subHeight - 1) * _subWidth + x,0];
            }

            for (var y = 0; y < _subHeight; y++)
            {
                constraints[5][y] = basetile[y * _subWidth,0];
                constraints[2][y] = basetile[y * _subWidth + _subWidth - 1,0];
            }

            for (var map = 0; map < 16; map++)
            {
                if ((map == 12) || (map == 3))
                    continue; // skip the base tile

                //                                        red              green
                var top =  ((map & (int)WangHelper.Bit.Top) == 0)      ? constraints[0] : constraints[1];
                var left = ((map & (int)WangHelper.Bit.Left) == 0)     ? constraints[2] : constraints[3];
                var right = ((map & (int)WangHelper.Bit.Right) == 0)   ? constraints[4] : constraints[5];
                var bottom = ((map & (int)WangHelper.Bit.Bottom) == 0) ? constraints[6] : constraints[7];
                    
                WangHelper.GenerateTile(_subWidth, _subHeight, _rand, 
                    basetile, left, right, top, bottom);
                Upload(basetile, map);
            }

            #endregion

#else

            // this is a far more restrictive version that is invariant under rotations
            #region Invariant version

            if (height != width)
                throw new Exception("Width must be same as height for invariant map");

            var constraints = new byte[2][];
            constraints[0] = new byte[_subWidth];  // red
            constraints[1] = new byte[_subWidth];  // green

#if MirrorInvariant

            for (var i = 0; i < _subWidth / 2; i++)
            {
                var rnd = (byte)((_rand.Next() & 0x1) * 0xF);
                
                constraints[0][i] = rnd;
                constraints[0][_subWidth - i - 1] = rnd;
                rnd = (byte)((_rand.Next() & 0x1) * 0xF);
                
                constraints[1][i] = rnd;
                constraints[1][_subWidth - i - 1] = rnd;
            }

#else

            for (var i = 0; i < _subWidth; i++)
            {
                constraints[0][i] = (byte)((_rand.Next() & 0x1) * 0xF);
                constraints[1][i] = (byte)((_rand.Next() & 0x1) * 0xF);
            }

#endif
          

              
            for (var map = 0; map < 16; map++)
            {                                                 
                var top = ((map & (int)WangHelper.Bit.Top) == 0) ? constraints[0] : constraints[1];
                var left = ((map & (int)WangHelper.Bit.Left) == 0) ? constraints[0] : constraints[1];
                var right = ((map & (int)WangHelper.Bit.Right) == 0) ? constraints[0] : constraints[1];
                var bottom = ((map & (int)WangHelper.Bit.Bottom) == 0) ? constraints[0] : constraints[1];

                WangHelper.GenerateTile(_subWidth, _subHeight, _rand,
                    basetile, left, right, top, bottom);

                Upload(basetile, map);
            }

            #endregion

#endif

            WangHelper.GenerateIndices(_map);

            // finally upload the image
            Activate();
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, Width, Height,PixelFormat.LuminanceAlpha, PixelType.UnsignedByte, _map);
        }
    }
}
