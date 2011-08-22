using System;
using System.Drawing;
using IIS.SLSharp.Bindings.OpenTK;
using IIS.SLSharp.Examples.GeoClipmap.MapGenerator;
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

        //private readonly Bitmap _testMap;

        //private readonly Bitmap _testMap2;

        internal readonly MegaMap _wow;

        private readonly MapGenerator.MapGenerator _map = new MapGenerator.MapGenerator(6);

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

        private const int Levels = 8;

        public const float Scale = 2.0f / D;

        private bool _initialized;

        private readonly ClipmapShaderLevel0 _shader0 = Shader.CreateSharedShader<ClipmapShaderLevel0>();

        private readonly ClipmapShader _shader = Shader.CreateSharedShader<ClipmapShader>();

        private readonly ClipmapLevel[] _levels = new ClipmapLevel[Levels];

        public IntFloatVector2 Position;

        public float DebugValue { get; set; }

        public PatchLocations Locations { get; private set; }

        private float Lerp(float a, float b, float w)
        {
            //w = (1.0f - (float)Math.Cos(w * Math.PI)) / 2.0f;
            return b * w + a * (1.0f - w);
        }

        private float Hermite(float a, float b, float c, float w)
        {
            var p0 = a;
            var p1 = b;
            var m0 = b - a;
            var m1 = c - b;
            var w2 = w * w;
            var w3 = w2 * w;

            return (2 * w3 - 3 * w2 + 1) * p0 + (w3 - 2 * w2 + w) * m0 + (-2 * w3 + 3 * w2) * p1 + (w3 - w2) * m1;
        }

        public HeightData GeneratePixelAt(int x, int y)
        {
            /*
            if ((x <= 10) && (y <= 10) && (x >= -10) && (y >= -10))
            {

                var h = 1.0f - (x * x + y * y) * 0.01f;
                if (h < 0.0f)
                    h = 0.0f;
                if (h > 1.0f)
                    h = 1.0f;
                return h;
            }
            return 0.5f;
            */


            //var cx = (int)((uint)(-x) % _wow.Width);
            //var cy = (int)((uint)(y) % _wow.Height);


            
            // Test config
            /*
            var cb = (((x ^ y) & 1) == 1) ? (byte)0 : (byte)127;
            
            if (x >= 0 && y >= 0 && x < 17 && y < 17)
                return new HeightData(0.005f, 0, 0, 127, cb, cb, cb, 127, 0);

            if (x < 0 || y < 0)
                return new HeightData(0.0f, 0, 0, 127, cb, cb, cb, 127, 1);

            x /= 17;
            y /= 17;
            var tid = (((x ^ y) & 2) == 2) ? (byte)5 : (byte)6;
            return new HeightData(0.0f, 0, 0, 127, cb, cb, cb, 127, tid);
            */


            
            if (x < 0 || y < 0 || x >= _wow.Width || y >= _wow.Height)
            {
                var cb = (((x ^ y) & 1) == 1) ? (byte)0 : (byte)127;
                return new HeightData(0.0f, 0, 0, 127, cb, cb, cb, 127, 0);
            }
            var cx = _wow.Width - x - 1;
            var cy = y;

            var pix = _wow.GetPixel(cx, cy);
            pix.Z = (pix.Z - _wow.MinZ) * _wow.InverseZRange;
            return pix; // *2.0f - 1.0f;
         

            /*
            // wrap to positive values
            const int tw = 64;
            const int th = 64;
            
            x += tw*300;
            y += th*300;

            var cx = (int)((uint)(x / tw) % _testMap2.Width);
            var cy = (int)((uint)(y / th) % _testMap2.Width);
            
            var sx = (int)((uint)x % _testMap.Width);
            var sy = (int)((uint)y % _testMap.Width);
            var wx = (int)((uint)x % tw) / (float)tw;
            var wy = (int)((uint)y % th) / (float)th;

            var cx1 = (cx + 1) % _testMap2.Width;
            var cx2 = (cx + 2) % _testMap2.Width;
            var cx3 = (cx + 3) % _testMap2.Width;
            var cy1 = (cy + 1) % _testMap2.Height;
            var cy2 = (cy + 2) % _testMap2.Height;
            var cy3 = (cy + 3) % _testMap2.Height;

            var a0 = _testMap2.GetPixel(cx, cy).R / 255.0f;
            var a1 = _testMap2.GetPixel(cx1, cy).R / 255.0f;
            var a2 = _testMap2.GetPixel(cx2, cy).R / 255.0f;
            var a3 = _testMap2.GetPixel(cx3, cy).R / 255.0f;
            var b0 = _testMap2.GetPixel(cx, cy1).R / 255.0f;
            var b1 = _testMap2.GetPixel(cx1, cy1).R / 255.0f;
            var b2 = _testMap2.GetPixel(cx2, cy1).R / 255.0f;
            var b3 = _testMap2.GetPixel(cx3, cy1).R / 255.0f;
            var c0 = _testMap2.GetPixel(cx, cy2).R / 255.0f;
            var c1 = _testMap2.GetPixel(cx1, cy2).R / 255.0f;
            var c2 = _testMap2.GetPixel(cx2, cy2).R / 255.0f;
            var c3 = _testMap2.GetPixel(cx3, cy2).R / 255.0f;
            var d0 = _testMap2.GetPixel(cx, cy3).R / 255.0f;
            var d1 = _testMap2.GetPixel(cx1, cy3).R / 255.0f;
            var d2 = _testMap2.GetPixel(cx2, cy3).R / 255.0f;
            var d3 = _testMap2.GetPixel(cx3, cy3).R / 255.0f;

            var e0 = a1 + 0.5f * wx * (a2 - a0 + wx * (2.0f * a0 - 5.0f * a1 + 4.0f * a2 - a3 + wx * (3.0f * (a1 - a2) + a3 - a0)));
            var e1 = b1 + 0.5f * wx * (b2 - b0 + wx * (2.0f * b0 - 5.0f * b1 + 4.0f * b2 - b3 + wx * (3.0f * (b1 - b2) + b3 - b0)));
            var e2 = c1 + 0.5f * wx * (c2 - c0 + wx * (2.0f * c0 - 5.0f * c1 + 4.0f * c2 - c3 + wx * (3.0f * (c1 - c2) + c3 - c0)));
            var e3 = d1 + 0.5f * wx * (d2 - d0 + wx * (2.0f * d0 - 5.0f * d1 + 4.0f * d2 - d3 + wx * (3.0f * (d1 - d2) + d3 - d0)));
            var c = e1 + 0.5f * wy * (e2 - e0 + wy * (2.0f * e0 - 5.0f * e1 + 4.0f * e2 - e3 + wy * (3.0f * (e1 - e2) + e3 - e0)));

            var h = _testMap.GetPixel(sx, sy).R / 255.0f;

            return c + h * 0.1f;
            */


            /*
            // wrap to positive values
            var tw = 128; // _testmap.Width
            var th = 128; // _testmap.Height
            var cx = (int)(((uint)x / tw) % _map.Width);
            var cy = (int)(((uint)y / th) % _map.Height);
            x = (int)((uint)x % _testMap.Width);
            y = (int)((uint)y % _testMap.Width);

            

           
            /*
            var cx1 = (cx + 1) % _map.Width;
            var cy1 = (cy + 1) % _map.Height;

            var ctl = _map.HeightAsFloat(cx, cy);
            var ctr = _map.HeightAsFloat(cx1, cy);
            var cbl = _map.HeightAsFloat(cx, cy1);
            var cbr = _map.HeightAsFloat(cx1, cy1);
            var wx = (x % tw) / (float)(tw);
            var wy = (y % th) / (float)(th);
            var c1 = Lerp(ctl, ctr, wx);
            var c2 = Lerp(cbl, cbr, wx);
            var c = Lerp(c1, c2, wy);
            */

            // hermite interpolation
            /*
            var wx = (x % tw) / (float)(tw);
            var wy = (y % th) / (float)(th);

            var cx1 = (cx + 1) % _map.Width;
            var cx2 = (cx + 2) % _map.Width;
            var cy1 = (cy + 1) % _map.Height;
            var cy2 = (cy + 2) % _map.Height;

            var a0 = _map.HeightAsFloat(cx, cy);
            var a1 = _map.HeightAsFloat(cx1, cy);
            var a2 = _map.HeightAsFloat(cx2, cy);
            var b0 = _map.HeightAsFloat(cx, cy1);
            var b1 = _map.HeightAsFloat(cx1, cy1);
            var b2 = _map.HeightAsFloat(cx2, cy1);
            var c0 = _map.HeightAsFloat(cx, cy2);
            var c1 = _map.HeightAsFloat(cx1, cy2);
            var c2 = _map.HeightAsFloat(cx2, cy2);

            var d0 = Hermite(a0, a1, a2, wx);
            var d1 = Hermite(b0, b1, b2, wx);
            var d2 = Hermite(c0, c1, c2, wx);
            var c = Hermite(d0, d1, d2, wy);
             */

            // bicubic interpolation.. (yuck slow)
            /*
            var wx = (x % tw) / (float)(tw);
            var wy = (y % th) / (float)(th);

            var cx1 = (cx + 1) % _map.Width;
            var cx2 = (cx + 2) % _map.Width;
            var cx3 = (cx + 3) % _map.Width;
            var cy1 = (cy + 1) % _map.Height;
            var cy2 = (cy + 2) % _map.Height;
            var cy3 = (cy + 3) % _map.Height;

            var a0 = _map.HeightAsFloat(cx, cy);
            var a1 = _map.HeightAsFloat(cx1, cy);
            var a2 = _map.HeightAsFloat(cx2, cy);
            var a3 = _map.HeightAsFloat(cx3, cy);

            var b0 = _map.HeightAsFloat(cx, cy1);
            var b1 = _map.HeightAsFloat(cx1, cy1);
            var b2 = _map.HeightAsFloat(cx2, cy1);
            var b3 = _map.HeightAsFloat(cx3, cy1);

            var c0 = _map.HeightAsFloat(cx, cy2);
            var c1 = _map.HeightAsFloat(cx1, cy2);
            var c2 = _map.HeightAsFloat(cx2, cy2);
            var c3 = _map.HeightAsFloat(cx3, cy2);

            var d0 = _map.HeightAsFloat(cx, cy3);
            var d1 = _map.HeightAsFloat(cx1, cy3);
            var d2 = _map.HeightAsFloat(cx2, cy3);
            var d3 = _map.HeightAsFloat(cx3, cy3);

            var e0 = a1 + 0.5f * wx * (a2 - a0 + wx * (2.0f * a0 - 5.0f * a1 + 4.0f * a2 - a3 + wx * (3.0f * (a1 - a2) + a3 - a0)));
            var e1 = b1 + 0.5f * wx * (b2 - b0 + wx * (2.0f * b0 - 5.0f * b1 + 4.0f * b2 - b3 + wx * (3.0f * (b1 - b2) + b3 - b0)));
            var e2 = c1 + 0.5f * wx * (c2 - c0 + wx * (2.0f * c0 - 5.0f * c1 + 4.0f * c2 - c3 + wx * (3.0f * (c1 - c2) + c3 - c0)));
            var e3 = d1 + 0.5f * wx * (d2 - d0 + wx * (2.0f * d0 - 5.0f * d1 + 4.0f * d2 - d3 + wx * (3.0f * (d1 - d2) + d3 - d0)));
            var c = e1 + 0.5f * wy * (e2 - e0 + wy * (2.0f * e0 - 5.0f * e1 + 4.0f * e2 - e3 + wy * (3.0f * (e1 - e2) + e3 - e0)));
            

            //var r = (c.Height + m + c.Noise*0.5f) / (2*m);
            //return r;
           

            var fineZ = _testMap.GetPixel(x, y).R / 255.0f;

            return c +(fineZ - 0.5f) * _map.FineScale;
            */

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
            //
            //_testMap = (Bitmap)Image.FromFile(@"perlin256.png");
            //_testMap2 = (Bitmap)Image.FromFile(@"E:\SLSharp\Resources\testmap2.png");

            _wow = new MegaMap(Program.WoWDir + "map.dat", Program.WoWDir + "alpha.dat");
            Position = new IntFloatVector2(new IntFloat(-_wow.Width / 4), new IntFloat(-_wow.Height / 4));

            //Position = new IntFloatVector2(new IntFloat(-_testMap.Width / 4), new IntFloat(-_testMap.Height / 4));

            Locations = new PatchLocations(H, M);

            var scale = Scale;
            var scaleInt = 1;

            for (var i = 0; i < Levels; i++)
            {
                _levels[i] = new ClipmapLevel(scale, scaleInt, i, this);
                scale *= 2.0f;
                scaleInt *= 2;
            }

            GenerateTestTexture();
            UpdatePosition();
            Reset();

            _initialized = true;
        }

        private static void BeginDraw()
        {
        }

        private void BeginLevel(int i)
        {
            //var sz = _levels[i].TEXSize;
            //var s = ((float)(sz - 2)) / sz;
            //var atsca = s / _levels[i].NumPatches;

            var sx = (float)_levels[i].TEXSize / _levels[i].Atlas.Width;
            var sy = (float)_levels[i].TEXSize / _levels[i].Atlas.Height;

            var alphax = 64.0f / _levels[i].AlphaLayer.Width;
            var alphay = 64.0f / _levels[i].AlphaLayer.Height;

            if (i == 0)
            {
                _shader0.HeightmapTex = _levels[i].Heightmap;
                _shader0.NormalTex = _levels[i].Normalmap;
                _shader0.ColorTex = _levels[i].Colormap;
                _shader0.AtlasTex = _levels[i].Atlas;
                _shader0.IndexTex = _levels[i].IndexMap;
                _shader0.IndexTex2 = _levels[i].Index2Map;
                _shader0.AlphaIndexTex = _levels[i].AlphaIndexMap;
                _shader0.AlphaLayerTex = _levels[i].AlphaLayer;
                _shader0.AtlasScale = new Vector4(sx, sy, alphax, alphay).ToVector4F();
            }
            else
            {
                _shader.HeightmapTex = _levels[i].Heightmap;
                _shader.NormalTex = _levels[i].Normalmap;
                _shader.ColorTex = _levels[i].Colormap;
                _shader.AtlasTex = _levels[i].Atlas;
                _shader.IndexTex = _levels[i].IndexMap;
                _shader.IndexTex2 = _levels[i].Index2Map;
                _shader.AlphaTex = _levels[i].AlphaLayer;
                _shader.AtlasScale = new Vector4(sx, sy, alphax, alphay).ToVector4F();
            }            
        }

        private static void EndDraw()
        {
        }


        private void UpdatePosition()
        {
            /*
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
            }*/

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
            

            BeginDraw();


            var vloc = -1;
            for (var i = 0; i < Levels; i++)
            {
                if (i == 0)
                {
                    _shader0.Begin();
                    _shader0.alpha = 0.5f + 0.5f * (float)Math.Sin((DateTime.Now.Millisecond + DateTime.Now.Second * 1000) * 0.01f);
                    _shader0.ModelViewProjectionMatrix = modelviewProjection.ToMatrix4F();
                    _shader0.DebugValue = DebugValue;
                    _shader0.ScaleFactor = new Vector4(0.1f, 0.1f, 0.0f, 0.0f).ToVector4F();
                    _shader0.FineBlockOrigin = (new Vector4(0.01f, 0.01f, 0.0f, 0.0f)).ToVector4F();
                    _shader0.ViewerPosition = new Vector2(0.0f, 0.0f).ToVector2F();
                    _shader0.AlphaOffset = new Vector2(0.0f, 0.0f).ToVector2F();
                    _shader0.OneOverWidth = new Vector2(1.0f / M, 1.0f / M).ToVector2F();
                    _shader0.NormalMatrix = normalMatrix.ToMatrix4F();
                    _shader0.alpha = 1.0f;
                    vloc = Shader.AttributeLocation(_shader0, () => _shader0.Vertex);
                }
                else if (i == 1) // keep for > 1
                {
                    _shader0.End();
                    _shader.Begin();
                    _shader.alpha = 0.5f + 0.5f * (float)Math.Sin((DateTime.Now.Millisecond + DateTime.Now.Second * 1000) * 0.01f);
                    _shader.ModelViewProjectionMatrix = modelviewProjection.ToMatrix4F();
                    _shader.DebugValue = DebugValue;
                    _shader.ScaleFactor = new Vector4(0.1f, 0.1f, 0.0f, 0.0f).ToVector4F();
                    _shader.FineBlockOrigin = (new Vector4(0.01f, 0.01f, 0.0f, 0.0f)).ToVector4F();
                    _shader.ViewerPosition = new Vector2(0.0f, 0.0f).ToVector2F();
                    _shader.AlphaOffset = new Vector2(0.0f, 0.0f).ToVector2F();
                    _shader.OneOverWidth = new Vector2(1.0f / M, 1.0f / M).ToVector2F();
                    _shader.NormalMatrix = normalMatrix.ToMatrix4F();
                    _shader.alpha = 0.0f;
                    vloc = Shader.AttributeLocation(_shader, () => _shader.Vertex);
                }


                var level = _levels[i];

                BeginLevel(i);

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

                    var zx = (float)(intX * 2) / N;
                    var zy = (float)(intY * 2) / N;

                    /*
                    zx %= 17;
                    if (zx < 0)
                        zx += 17;
                    zy %= 17;
                    if (zy < 0)
                        zy += 17;
                    */
                    //Console.Write("\r{0}  {1}  ", zx, zy);

                    if (i == 0)
                    {
                        _shader0.ScaleFactor = new Vector4(p.X + subX, p.Y + subY, level.Scale, level.Scale).ToVector4F();
                        _shader0.FineBlockOrigin = new Vector4(p.X - Hx - texX, p.Y - Hx - texY, (float)InverseD, (float)InverseD).ToVector4F();
                        _shader0.Block = new Vector2(zx, zy).ToVector2F();
                    }
                    else
                    {
                        _shader.ScaleFactor = new Vector4(p.X + subX, p.Y + subY, level.Scale, level.Scale).ToVector4F();
                        _shader.FineBlockOrigin = new Vector4(p.X - Hx - texX, p.Y - Hx - texY, (float)InverseD, (float)InverseD).ToVector4F();
                        _shader.Block = new Vector2(zx, zy).ToVector2F();
                    }

                    pp.Draw(vloc);
                }
            }

            EndDraw();

            if (Levels > 1)
                _shader.End();
            else
                _shader0.End();
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
            _shader0.Dispose();
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

                lvl.Atlas.Activate();
                //lvl.Heightmap.Activate();
                //GL.Color4(SelectColor(i));

                GL.Color4(1.0f, 1.0f, 1.0f, 1.0f);

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