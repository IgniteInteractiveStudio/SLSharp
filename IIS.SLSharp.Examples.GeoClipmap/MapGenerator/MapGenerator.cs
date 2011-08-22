using System;
using System.Collections.Generic;
using System.Drawing;

namespace IIS.SLSharp.Examples.GeoClipmap.MapGenerator
{

    public enum Tile
    {
        Undefined = 0,
        Water,
        Ground,
        Mountain,
        Desert,
    }

    public struct CellData
    {
        public bool IsWater;
        public bool Flag;
        public int Height;
        public int DistanceToWater;
        public float Noise;
    }

    public class MapGenerator
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public int Levels { get; private set; }

        public int MaxHeight
        {
            get { return _hullIteration; }
        }

        public CellData[,] Cells;

        private readonly Random _rand = new Random();

        private List<Point> _hull;

        private List<Point> _backHull;

        public float HeightAsFloat(int x, int y)
        {
            var c = Cells[y, x];
            return (c.Height + _hullIteration + 1 + c.Noise) * FineScale;
        }

        public float FineScale
        {
            get { return 1.0f/ (2 * _hullIteration + 2); }
        }

        public MapGenerator(int sz)
        {
            var size = 1 << sz;
            Width = size;
            Height = size;
            Levels = sz;

            Cells = new CellData[Height, Width];

            sz -= 3;
            Seed(sz);
            for (var i = sz; i > 0; i--)
                Generate(i);

            PropagageHeights();
        }       

        private int _hullIteration;

        private void PropagateHeightAt(int x, int y)
        {
            var c = Cells[y, x];
            if (c.Height != 0)
                return;

            if (c.IsWater)
                Cells[y, x].Height = -_hullIteration -1;
            else Cells[y, x].Height = _hullIteration;
            _backHull.Add(new Point(x, y));
        }

        private void PropagageHeights()
        {
            // collect water hull and generate noise
            _hull = new List<Point>();
            _backHull = new List<Point>();
            for (var y = 0; y < Height; y++)
            {
                var yl = (y - 1 + Height) % Height;
                var yn = (y + 1) % Height;
                for (var x = 0; x < Width; x++)
                {
                    var xl = (x - 1 + Width) % Width;
                    var xn = (x + 1) % Width;

                    //Cells[y, x].Noise = (float)_rand.NextDouble();

                    if (Cells[y, x].IsWater && 
                        (
                        !Cells[y, xl].IsWater || !Cells[y, xn].IsWater ||
                        !Cells[yl, x].IsWater || !Cells[yn, x].IsWater ||
                        !Cells[yl, xl].IsWater || !Cells[yn, xn].IsWater
                        ))
                    {
                        _hull.Add(new Point(x, y));
                    }
                }
            }

            for (_hullIteration = 1; _hull.Count != 0; _hullIteration++)
            {
                _backHull.Clear();
                foreach (var p in _hull)
                {
                    var yl = (p.Y - 1 + Height) % Height;
                    var yn = (p.Y + 1) % Height;
                    var xl = (p.X - 1 + Width) % Width;
                    var xn = (p.X + 1) % Width;

                    PropagateHeightAt(xl, p.Y);
                    PropagateHeightAt(xn, p.Y);
                    PropagateHeightAt(p.X, yl);
                    PropagateHeightAt(p.X, yn);
                    PropagateHeightAt(xl, yl);
                    PropagateHeightAt(xn, yn);

                }
                var tmp = _hull;
                _hull = _backHull;
                _backHull = tmp;
            }

            _hull = null;
            _backHull = null;
        }



        private bool RandBool()
        {
            return _rand.Next(2) == 1;
        }

        private void Seed(int sz)
        {
            var size = 1 << sz;
            for (var y = 0; y < Height; y += size)
            {
                for (var x = 0; x < Width; x += size)
                {
                    if (_rand.Next(2) != 0)
                        continue;
                    Cells[y, x].IsWater = true;
                    //Cells[y, x].Height = -1;
                }
            }
        }

        private CellData Region(CellData a, CellData b)
        {
            return RandBool() ? a : b;
        }

        private void Generate(int level)
        {

            var size = 1 << level;

            var sz2 = size / 2;
            for (var y = 0; y < Height; y += size)
            {
                for (var x = 0; x < Width; x += size)
                {
                    
                    var c = Cells[y, x];
                    var r = Cells[y, (x + size) % Width];
                    var b = Cells[(y + size) % Height, x];

                    Cells[y, x + sz2] = Region(c, r);
                    Cells[y + sz2, x] = Region(c, b);
                    Cells[y + sz2, x + sz2] = Region(r, b);
                }
            }
        }
    }
}
