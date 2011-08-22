using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using IIS.SLSharp.Bindings.OpenTK.Textures;
using IIS.SLSharp.Shaders;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Examples.GeoClipmap.Clipmap
{
    public struct TexInfo
    {
        public int Tex0, Tex1, Tex2, Tex3, AlphaId;

        public TexInfo(int init)
        {
            Tex0 = init;
            Tex1 = init;
            Tex2 = init;
            Tex3 = init;
            AlphaId = init;
        }
    }

    public struct HeightData
    {
        public float Z;
        public byte Nx, Ny, Nz;
        public byte R, G, B, A;
        public byte Layer1, Layer2, Layer3;
        public TexInfo Tex;

        public HeightData(float z, byte nx, byte ny, byte nz,
            byte r, byte g, byte b, byte a, int texId)
        {
            Z = z;
            Nx = nx;
            Ny = ny;
            Nz = nz;
            R = r;
            G = g;
            B = b;
            A = a;
            Tex.Tex0 = texId;
            Tex.Tex1 = texId;
            Tex.Tex2 = texId;
            Tex.Tex3 = texId;
            Tex.AlphaId = texId;
            Layer1 = 0;
            Layer2 = 0;
            Layer3 = 0;
        }
    }

    internal sealed class ClipmapLevel : IDisposable
    {
        private struct TexSlot
        {
            public int X, Y;

            public TexSlot(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        private struct TexCacheEntry
        {
            public int RefCount;
            public TexSlot Slot;
        }

        public Texture2D Heightmap { get; private set; }

        public Texture2D Normalmap { get; private set; }

        public Texture2D Colormap { get; private set; }

        public Texture2D Atlas { get; private set; }

        public Texture2D IndexMap { get; private set; }

        public Texture2D Index2Map { get; private set; }

        public Texture2D AlphaIndexMap { get; private set; }

        public Texture2D AlphaLayer { get; private set; }

        private readonly TexInfo[,] _texIndices;

        private readonly TexCacheEntry[] _texRefs;

        private readonly TexCacheEntry[] _alphaRefs;

        private readonly Queue<TexSlot> _freeSlots = new Queue<TexSlot>();

        private readonly Queue<TexSlot> _freeAlphaSlots = new Queue<TexSlot>();

        public float Scale { get; private set; }

        public int ScaleInt { get; private set; }

        public int Level { get; private set; }

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

        private HeightData GeneratePixelAt(int xr, int yr)
        {
            // this function encodes zc and zf as described in the geoclipmapping paper

            var x = xr * ScaleInt;
            var y = yr * ScaleInt;

            var finePixel =  _clipmap.GeneratePixelAt(x, y);
            return finePixel;

            /*
            //x &= ~1;
            //y &= ~1;

           
            

            //x += ScaleInt;
            //y += ScaleInt;

            // odd/even == central??
            
            // even/odd  odd/ood
            // even/even odd/even

            var dx = ((x >> 31) & ~1) | (x & 1);
            var dy = ((y >> 31) & ~1) | (y & 1);


            var coarsePixel = _clipmap.GeneratePixelAt((x/2)*2, (y/2)*2);

            var zf = finePixel;
            if (zf < 0.0f)
                zf = 0.0f;
            if (zf > 1.0f)
                zf = 1.0f;
            zf = (float)Math.Round(zf * 512.0f);
            //var zd = coarsePixel - finePixel; // should be 0 for innermost level?!
            //zd = - finePixel;

            /*
            var zd = 0.0f;
            if ((x & 1) == 0 && (y & 1) == 0)
                zd = -finePixel;
            */

            //var zd = coarsePixel - finePixel;
            /*
            var zd = 0.0f;

            // zd can range from -1 to 1 thus normalize to 0..1
            zd += 1.0f;
            zd *= 0.5f; 

            var zfzd = zf + zd;
            zfzd *= 0.001953125f;

            return zfzd;
             */
        }

        readonly int _atlasSize;
        public int TEXSize { get; private set; }
        public int NumPatches { get; private set; }

        public ClipmapLevel(float scale, int scaleInt, int level, Clipmap clipmap)
        {
            _d = clipmap.DValue;
            _n = _d - 1;

            //_atlasSize = 512;
            //_texSize = 128 >> level;

            switch (level)
            {
                case 0:
                    _atlasSize = 1024;
                    TEXSize = 256;
                    break;
                case 1:
                    _atlasSize = 1024;
                    TEXSize = 128;
                    break;
                case 2:
                    _atlasSize = 512;
                    TEXSize = 64;
                    break;
                case 3:
                    _atlasSize = 512;
                    TEXSize = 32;
                    break;
                case 4:
                    _atlasSize = 256;
                    TEXSize = 16;
                    break;
                default:
                    _atlasSize = 256;
                    TEXSize = 8;
                    break;
            }

            //_atlasSize = 128;
            //TEXSize = 17; // DEBUG!

            if (TEXSize < 4)
                TEXSize = 4;
            NumPatches = _atlasSize / TEXSize;


            _texIndices = new TexInfo[_d, _d];
            for (var y = 0; y < _d; y++)
                for (var x = 0; x < _d; x++)
                    _texIndices[y, x] = new TexInfo(-1);

            _texRefs = new TexCacheEntry[clipmap._wow.NumTextures];
            _alphaRefs = new TexCacheEntry[clipmap._wow.NumAlphas];

            _clipmap = clipmap;
            Scale = scale;
            ScaleInt = scaleInt;
            Level = level;

            // // Luminance32fAti
            Heightmap = new Texture2D(_d, _d, (PixelInternalFormat)0x8818);
            Heightmap.Activate();
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            Heightmap.Finish();

            
            Normalmap = new Texture2D(_d, _d, 3, typeof(byte));
            Normalmap.Activate();
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            Normalmap.Finish();
            
            Colormap = new Texture2D(_d, _d, 3, typeof(byte));
            Colormap.Activate();
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            Colormap.Finish();

            IndexMap = new Texture2D(_d, _d, 4, typeof(byte));
            IndexMap.Activate();
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            IndexMap.Finish();

            
            Index2Map = new Texture2D(_d, _d, 4, typeof(byte));
            Index2Map.Activate();
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            Index2Map.Finish();

            

            if (level == 0)
            {
                // actual used size: _d / 17 * 64 where 17 = chunk size and 64 = alphatex size
                AlphaLayer = new Texture2D(_d * 8, _d * 8, 3, typeof(byte));
                AlphaIndexMap = new Texture2D(_d, _d, 3, typeof(byte));
            }
            else
            {
                // all levels above will only use vertex alphas
                AlphaLayer = new Texture2D(_d, _d, 3, typeof(byte));
                AlphaIndexMap = new Texture2D(1, 1, 3, typeof(byte));
            }

            AlphaLayer.Activate();
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            AlphaLayer.Finish();

            AlphaIndexMap.Activate();
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            AlphaIndexMap.Finish();


            // TODO: cache to compressed textures?

            Atlas = new Texture2D(_atlasSize, _atlasSize, 4, typeof(byte));
            //Atlas = new Texture2D(_atlasSize, _atlasSize, PixelInternalFormat.CompressedRgb);
            Atlas.Activate();
            //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            Atlas.Finish();

            var slotsX = Atlas.Width / TEXSize;
            var slotsY = Atlas.Height / TEXSize;

            for (var y = 0; y < slotsY; y++)
                for (var x = 0; x < slotsX; x++)
                    _freeSlots.Enqueue(new TexSlot(x, y));

            for (var y = 0; y < AlphaLayer.Height ; y += 64)
                for (var x = 0; x < AlphaLayer.Width; x += 64)
                    _freeAlphaSlots.Enqueue(new TexSlot(x / 64, y / 64));
        }


        private int _lastTex;

        private float[] _sliceZ;
        private byte[,] _sliceIndex;
        private byte[,] _sliceLayer1;
        private byte[,] _sliceNorm;
        private byte[,] _sliceColor;
        private byte[,] _sliceAlphaIndex;
        private byte[,] _sliceAlphas;
        
        private void BeginUpdate()
        {
            if (_sliceZ == null)
            {
                _sliceZ = new float[_d];
                _sliceNorm = new byte[_d,3];
                _sliceIndex = new byte[_d,4];
                _sliceLayer1 = new byte[_d,4];
                _sliceColor = new byte[_d,4];
                _sliceAlphaIndex = new byte[_d,3];
                _sliceAlphas = new byte[_d, 3];
            }

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

                    var pix = GeneratePixelAt(xr, yr);

                    var tex = _texIndices[j, yt];
                    var mappedId0 = SwapTex(ref tex.Tex0, pix.Tex.Tex0);
                    var mappedId1 = SwapTex(ref tex.Tex1, pix.Tex.Tex1);
                    var mappedId2 = SwapTex(ref tex.Tex2, pix.Tex.Tex2);
                    var mappedId3 = SwapTex(ref tex.Tex3, pix.Tex.Tex3);
                    if (Level == 0)
                    {
                        var mappedAlpha = SwapAlpha(ref tex.AlphaId, pix.Tex.AlphaId);
                        //_sliceAlphaIndex[j, 0] = (byte)((mappedAlpha.X * 64 * 255) / AlphaLayer.Width);
                        //_sliceAlphaIndex[j, 1] = (byte)((mappedAlpha.Y * 64 * 255) / AlphaLayer.Height);

                        _sliceAlphaIndex[j, 0] = (byte)mappedAlpha.X;
                        _sliceAlphaIndex[j, 1] = (byte)mappedAlpha.Y;
                    }
                    else
                    {
                        _sliceAlphas[j, 0] = pix.Layer1;
                        _sliceAlphas[j, 1] = pix.Layer2;
                        _sliceAlphas[j, 2] = pix.Layer3;
                    }

                    _texIndices[j, yt] = tex;

                    _sliceIndex[j, 0] = (byte)((mappedId0.X * TEXSize * 255) / _atlasSize);
                    _sliceIndex[j, 1] = (byte)((mappedId0.Y * TEXSize * 255) / _atlasSize);
                    _sliceIndex[j, 2] = (byte)((mappedId1.X * TEXSize * 255) / _atlasSize);
                    _sliceIndex[j, 3] = (byte)((mappedId1.Y * TEXSize * 255) / _atlasSize);
                    _sliceLayer1[j, 0] = (byte)((mappedId2.X * TEXSize * 255) / _atlasSize);
                    _sliceLayer1[j, 1] = (byte)((mappedId2.Y * TEXSize * 255) / _atlasSize);
                    _sliceLayer1[j, 2] = (byte)((mappedId3.X * TEXSize * 255) / _atlasSize);
                    _sliceLayer1[j, 3] = (byte)((mappedId3.Y * TEXSize * 255) / _atlasSize);

                    

                    _sliceZ[j] = pix.Z;
                    _sliceNorm[j, 0] = pix.Nx;
                    _sliceNorm[j, 1] = pix.Ny;
                    _sliceNorm[j, 2] = pix.Nz;
                    _sliceColor[j, 0] = pix.R;
                    _sliceColor[j, 1] = pix.G;
                    _sliceColor[j, 2] = pix.B;
                    _sliceColor[j, 3] = pix.A;
                    
                }

                Heightmap.Activate();
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, yt, _d, 1, PixelFormat.Luminance,
                                 PixelType.Float, _sliceZ);

                Normalmap.Activate();
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, yt, _d, 1, PixelFormat.Rgb,
                                 PixelType.Byte, _sliceNorm);

                Colormap.Activate();
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, yt, _d, 1, PixelFormat.Rgba,
                                 PixelType.UnsignedByte, _sliceColor);

                IndexMap.Activate();
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, yt, _d, 1, PixelFormat.Rgba,
                                PixelType.UnsignedByte, _sliceIndex);
                
                Index2Map.Activate();
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, yt, _d, 1, PixelFormat.Rgba,
                                PixelType.UnsignedByte, _sliceLayer1);

                if (Level == 0)
                {
                    AlphaIndexMap.Activate();
                    GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, yt, _d, 1, PixelFormat.Rgb,
                                     PixelType.UnsignedByte, _sliceAlphaIndex);
                }
                else
                {
                    AlphaLayer.Activate();
                    GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, yt, _d, 1, PixelFormat.Rgb,
                                     PixelType.UnsignedByte, _sliceAlphas);
                }
            }
        }

        private void UpdateColumns(int startX, int size)
        {
            var x = Position.X.Integer;
            var y = Position.Y.Integer;
            var d2 = _d / 2;

            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);
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

                    var pix = GeneratePixelAt(xr, yr);

                    var tex = _texIndices[xt, j];
                    var mappedId0 = SwapTex(ref tex.Tex0, pix.Tex.Tex0);
                    var mappedId1 = SwapTex(ref tex.Tex1, pix.Tex.Tex1);
                    var mappedId2 = SwapTex(ref tex.Tex2, pix.Tex.Tex2);
                    var mappedId3 = SwapTex(ref tex.Tex3, pix.Tex.Tex3);
                    if (Level == 0)
                    {
                        var mappedAlpha = SwapAlpha(ref tex.AlphaId, pix.Tex.AlphaId);
                        //_sliceAlphaIndex[j, 0] = (byte)((mappedAlpha.X * 64 * 255) / AlphaLayer.Width);
                        //_sliceAlphaIndex[j, 1] = (byte)((mappedAlpha.Y * 64 * 255) / AlphaLayer.Height);

                        _sliceAlphaIndex[j, 0] = (byte)mappedAlpha.X;
                        _sliceAlphaIndex[j, 1] = (byte)mappedAlpha.Y;
                    }
                    else
                    {
                        _sliceAlphas[j, 0] = pix.Layer1;
                        _sliceAlphas[j, 1] = pix.Layer2;
                        _sliceAlphas[j, 2] = pix.Layer3;
                    }

                    _texIndices[xt, j] = tex;

                    _sliceIndex[j, 0] = (byte)((mappedId0.X * TEXSize * 255) / _atlasSize);
                    _sliceIndex[j, 1] = (byte)((mappedId0.Y * TEXSize * 255) / _atlasSize);
                    _sliceIndex[j, 2] = (byte)((mappedId1.X * TEXSize * 255) / _atlasSize);
                    _sliceIndex[j, 3] = (byte)((mappedId1.Y * TEXSize * 255) / _atlasSize);
                    _sliceLayer1[j, 0] = (byte)((mappedId2.X * TEXSize * 255) / _atlasSize);
                    _sliceLayer1[j, 1] = (byte)((mappedId2.Y * TEXSize * 255) / _atlasSize);
                    _sliceLayer1[j, 2] = (byte)((mappedId3.X * TEXSize * 255) / _atlasSize);
                    _sliceLayer1[j, 3] = (byte)((mappedId3.Y * TEXSize * 255) / _atlasSize);

                    _sliceZ[j] = pix.Z;
                    _sliceNorm[j, 0] = pix.Nx;
                    _sliceNorm[j, 1] = pix.Ny;
                    _sliceNorm[j, 2] = pix.Nz;
                    _sliceColor[j, 0] = pix.R;
                    _sliceColor[j, 1] = pix.G;
                    _sliceColor[j, 2] = pix.B;
                    _sliceColor[j, 3] = pix.A;
                   
                }

                Heightmap.Activate();
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, xt, 0, 1, _d, PixelFormat.Luminance,
                                 PixelType.Float, _sliceZ);

                Normalmap.Activate();
                
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, xt, 0, 1, _d, PixelFormat.Rgb,
                                     PixelType.Byte, _sliceNorm);

                Colormap.Activate();
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, xt, 0, 1, _d, PixelFormat.Rgba,
                                     PixelType.UnsignedByte, _sliceColor);

                IndexMap.Activate();
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, xt, 0, 1, _d, PixelFormat.Rgba,
                                     PixelType.UnsignedByte, _sliceIndex);

                Index2Map.Activate();
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, xt, 0, 1, _d, PixelFormat.Rgba,
                                     PixelType.UnsignedByte, _sliceLayer1);

                if (Level == 0)
                {
                    AlphaIndexMap.Activate();
                    GL.TexSubImage2D(TextureTarget.Texture2D, 0, xt, 0, 1, _d, PixelFormat.Rgb,
                                     PixelType.UnsignedByte, _sliceAlphaIndex);
                }
                else
                {
                    AlphaLayer.Activate();
                    GL.TexSubImage2D(TextureTarget.Texture2D, 0, xt, 0, 1, _d, PixelFormat.Rgb,
                                     PixelType.UnsignedByte, _sliceAlphas);
                }
            }
            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 4);
        }

        private TexSlot SwapTex(ref int currentId, int newId)
        {
            // return already allocated slot
            
            if (currentId == newId)
            {
                if (newId == -1)
                    return new TexSlot(0, 0); // cant do anything about this
                return _texRefs[newId].Slot;
            }

            var oldId = currentId;
            currentId = newId;

            int refCount;
            if (oldId != -1)
            {
                // deref oldId
                refCount = _texRefs[oldId].RefCount--;
                if (refCount == 1)
                {
                    _clipmap._wow.UnloadTexture(Level, oldId);
                    _freeSlots.Enqueue(_texRefs[oldId].Slot);
                }
            }

            if (newId == -1)
                return new TexSlot(0, 0);

            // ref newId
            refCount = _texRefs[newId].RefCount++;
            if (refCount == 0)
            {
                // we need to load the texture

                if (_freeSlots.Count == 0)
                    throw new Exception("Sorry, too many concurent textures :(");

                var slot = _freeSlots.Dequeue();

                _texRefs[newId].Slot = slot;
                _clipmap._wow.LoadTexture(Level, newId, Atlas, new Tuple<int, int>(slot.X * TEXSize, slot.Y * TEXSize), TEXSize);
            }

            return _texRefs[newId].Slot;
        }


        private TexSlot SwapAlpha(ref int currentId, int newId)
        {
            if (currentId == newId)
            {
                if (newId == -1)
                    return new TexSlot(0, 0); // cant do anything about this
                return _alphaRefs[newId].Slot;
            }

            var oldId = currentId;
            currentId = newId;

            int refCount;
            if (oldId != -1)
            {
                // deref oldId
                refCount = _alphaRefs[oldId].RefCount--;
                if (refCount == 1)
                {
                    _clipmap._wow.UnloadAlpha(Level, oldId);
                    _freeAlphaSlots.Enqueue(_alphaRefs[oldId].Slot);
                }
            }

            if (newId == -1)
                return new TexSlot(0, 0);

            // ref newId
            refCount = _alphaRefs[newId].RefCount++;
            if (refCount == 0)
            {
                // we need to load the texture

                if (_freeAlphaSlots.Count == 0)
                    throw new Exception("Sorry, too many concurent alpha textures :(");

                var slot = _freeAlphaSlots.Dequeue();

                _alphaRefs[newId].Slot = slot;
                _clipmap._wow.LoadAlpha(Level, newId, AlphaLayer, new Tuple<int, int>(slot.X, slot.Y));
            }

            return _alphaRefs[newId].Slot;
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
            Normalmap.Dispose();
            Colormap.Dispose();
            Atlas.Dispose();
            IndexMap.Dispose();
            Index2Map.Dispose();
            AlphaIndexMap.Dispose();
            AlphaLayer.Dispose();
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
