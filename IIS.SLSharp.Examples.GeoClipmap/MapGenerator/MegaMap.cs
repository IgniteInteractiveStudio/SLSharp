using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IIS.SLSharp.Bindings.OpenTK.Textures;
using IIS.SLSharp.Examples.GeoClipmap.Clipmap;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Examples.GeoClipmap.MapGenerator
{
    public class MegaMap
    {
        private readonly Stream _s;

        private readonly Stream _alphas;

        private readonly BinaryReader _r;

        public float MinZ { get; private set; }

        public float MaxZ { get; private set; }

        public float ZRange { get; private set; }

        public float InverseZRange { get; private set; }

        public float ZRangeMinMax { get; private set; }

        public float InverseZRangeMinMax { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public int NumTextures { get; private set; }

        public int NumAlphas { get; private set; }

        private readonly int _texStart;

        private readonly long _startOff;

        private readonly string[] _names;

        public MegaMap(string fileName, string alphaName)
        {
            _s = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            _r = new BinaryReader(_s);
            _alphas = new FileStream(alphaName, FileMode.Open, FileAccess.Read);

            NumAlphas = (int)(_alphas.Length / (64 * 64 * 3));

            Width = _r.ReadInt32();
            Height = _r.ReadInt32();

            MinZ = _r.ReadSingle();
            MaxZ = _r.ReadSingle();

            _texStart = _r.ReadInt32();
            var texNameStart = _r.ReadInt32();

            ZRange = MaxZ - MinZ;

            ZRangeMinMax = Math.Max(Math.Abs(MinZ), Math.Abs(MaxZ));
            InverseZRangeMinMax = 1.0f / ZRangeMinMax;

            InverseZRange = 1.0f / ZRange;

            _startOff = _s.Position;

            // read tex names
            _s.Position = texNameStart;
            NumTextures = _r.ReadInt32();

            _names = new string[NumTextures];
            for (var i = 0; i < NumTextures; i++)
                _names[i] = _r.ReadString();
        }

        public HeightData GetPixel(int x, int y)
        {
            _s.Position = _startOff + (y * Width + x) * (4 + 3 + 4 + 3);
            HeightData result;
            result.Z = _r.ReadSingle();
            result.Nx = _r.ReadByte();
            result.Ny = _r.ReadByte();
            result.Nz = _r.ReadByte();
            result.R = _r.ReadByte();
            result.G = _r.ReadByte();
            result.B = _r.ReadByte();
            result.A = _r.ReadByte();
            result.Layer1 = _r.ReadByte();
            result.Layer2 = _r.ReadByte();
            result.Layer3 = _r.ReadByte();

            // read texId
            x /= 17;
            y /= 17;
            var width16 = Width / 17;
            _s.Position = _texStart + (y * width16 + x) * (4 * 5);
            
            result.Tex.Tex0 = _r.ReadInt32();
            result.Tex.Tex1 = _r.ReadInt32();
            result.Tex.Tex2 = _r.ReadInt32();
            result.Tex.Tex3 = _r.ReadInt32();
            result.Tex.AlphaId = _r.ReadInt32();

            return result;
        }

       

        public void LoadTexture(int level, int id, Texture2D atlas, Tuple<int, int> pos, int size)
        {
            var debug = false;
            if (size == 17)
            {
                size = 16;
                debug = true;
            }

            var filename = Program.WoWDir + _names[id];
            var rawTex = filename + "." + size + ".raw";
            byte[] tex;
            if (!File.Exists(rawTex))
                tex = Decompress(level, filename, rawTex, size);
            else
            {
                var sz = size * size * 4;
                var s = new FileStream(rawTex, FileMode.Open, FileAccess.Read);
                tex = new byte[sz];
                s.Read(tex, 0, sz);
                s.Close();
                s.Dispose();
            }

            Check();
            atlas.Activate();
            GL.TexSubImage2D(atlas.Target, 0, pos.Item1, pos.Item2, size, size, PixelFormat.Rgba, PixelType.UnsignedByte, tex);
            Check();
            if (debug)
            {
                var rnd = new Random();
                

                var slice = new byte[4 * (size + 1)];
                for (var i = 0; i < slice.Length; i += 4)
                {
                    if ((i & 4) == 0)
                    {
                        var r = (byte)rnd.Next(256);
                        var g = (byte)(255 - r);
                        slice[i] = r;
                        slice[i + 1] = g;
                    }
                }
                GL.TexSubImage2D(atlas.Target, 0, pos.Item1 + size, pos.Item2, 1, size+1, PixelFormat.Rgba, PixelType.UnsignedByte, slice);
                Check();
                GL.TexSubImage2D(atlas.Target, 0, pos.Item1, pos.Item2 + size, size + 1, 1, PixelFormat.Rgba, PixelType.UnsignedByte, slice);
                Check();
            }

            Check();
        }

        public byte[] Decompress(int level, string inName, string outName, int size)
        {
            var fs = new FileStream(inName, FileMode.Open, FileAccess.Read);
            var r = new BinaryReader(fs);
            r.ReadInt32(); // magic
            var type = r.ReadInt32(); // 0 = jpg, 1 = dxt
            var encoding = r.ReadByte();
            var alphaDepth = r.ReadByte();
            var alphaCoding = r.ReadByte();
            var hasMipmaps = r.ReadByte();
            var width = r.ReadInt32();
            var height = r.ReadInt32();

            if (type != 1)
                throw new NotImplementedException(inName + " is no DXT texture");

            var sz = Math.Max(width, height);

            if (hasMipmaps == 0)
                throw new NotImplementedException(inName + " has no mipmaps");

            var loadLevel = 0;
            while (sz > size)
            {
                sz /= 2;
                width /= 2;
                height /= 2;
                loadLevel++;
            }

            fs.Position += 4 * loadLevel;
            var dataStart = r.ReadInt32();
            fs.Position += 15 * 4;
            var dataLen = r.ReadInt32();

            var buf = new byte[dataLen];
            fs.Position = dataStart;
            fs.Read(buf, 0, dataLen);

            // load the data
           

            /*
            switch (encoding << 8 | alphaDepth)
            {
                // case 0x0100: // uncompressed paletted image with no alpha
                // case 0x0101: // uncompressed paletted image with 1-bit alpha 
                // case 0x0108: // uncompressed paletted image with 8-bit alpha
                // case 0x0200: // DXT1 no alpha
                // case 0x0201: // DXT1 one bit alpha
                // case 0x0204: // DXT3 four bits alpha
                // case 0x0208: // DXT3 eight bits alpha
                     

                default:
                    throw new NotImplementedException("Unsupported compression");
            }*/

            PixelInternalFormat format;
            switch (encoding)
            {
                case 2:
                    switch (alphaDepth << 8 | alphaCoding)
                    {
                        case 0x0000: // DXT1 no alpha
                            format = PixelInternalFormat.CompressedRgbS3tcDxt1Ext;
                            break;
                        case 0x0100: // DXT1 one bit alpha
                            format = PixelInternalFormat.CompressedRgbaS3tcDxt1Ext; // or does wow use srgba?
                            break;
                        case 0x0401: // DXT3 four bits alpha
                            format = PixelInternalFormat.CompressedRgbaS3tcDxt3Ext; // or srgba?
                            break;
                        case 0x0801: // DXT3 eight bits alpha
                            format = PixelInternalFormat.CompressedRgbaS3tcDxt3Ext; // or srgba?
                            break;
                        case 0x0807: // DXT5
                            format = PixelInternalFormat.CompressedSrgbAlphaS3tcDxt5Ext; // or srgba?
                            break;
                        default:
                            throw new NotImplementedException("Unsupported compression");
                    }
                    break;
                default:
                    return new byte[size*size*4]; // no idea :(
                    //throw new NotImplementedException("Unsupported compression");
            }

            var tmp = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, tmp);
            GL.TexImage2D(TextureTarget.Texture2D, 0, format, size, size, 0, PixelFormat.Rgb, PixelType.UnsignedByte, IntPtr.Zero);
            GL.CompressedTexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, width, height, (PixelFormat)format, dataLen, buf);
            Check();
            
            var bytes = new byte[size * size * 4];
            GL.GetTexImage(TextureTarget.Texture2D, 0, PixelFormat.Rgba, PixelType.Byte, bytes);
            GL.DeleteTexture(tmp);
            Check();

            var of = new FileStream(outName, FileMode.Create, FileAccess.Write);
            of.Write(bytes, 0, bytes.Length);
            of.Close();
            return bytes;
        }

        private void Check()
        {
            var err = GL.GetError();
            if (err != ErrorCode.NoError)
                throw new Exception(err.ToString());
        }

        public void UnloadTexture(int level, int id)
        {
            Console.WriteLine("Unload: {0}@:{1}", level, _names[id]);
        }

        public void UnloadAlpha(int level, int id)
        {
            //Console.WriteLine("Unload: {0}@:{1}", level, _names[id]);
        }

        private readonly byte[] _alphaBuf = new byte[64*64*3];
        private readonly byte[] _alphaRot = new byte[64 * 64 * 3];

        public void LoadAlpha(int level, int id, Texture2D alphas, Tuple<int, int> pos)
        {
            _alphas.Position = id * (64 * 64 * 3);
            _alphas.Read(_alphaRot, 0, 64 * 64 * 3);

            // rotate alphas
            
            for (var i = 0; i < 64; i++)
            {
                for (var j = 0; j < 64; j++)
                {
                    //var idxIn = i * 64 + j;
                    //var idxOut = (i) + (63-j) * 64;

                    var idxIn = i * 64 + j;
                    var idxOut = i * 64 + (63 - j);

                    _alphaBuf[idxOut * 3 + 0] = _alphaRot[idxIn * 3 + 0];
                    _alphaBuf[idxOut * 3 + 1] = _alphaRot[idxIn * 3 + 1];
                    _alphaBuf[idxOut * 3 + 2] = _alphaRot[idxIn * 3 + 2];
                }
            }


            alphas.Activate();
            GL.TexSubImage2D(alphas.Target, 0, pos.Item1 * 64, pos.Item2 * 64, 64, 64, PixelFormat.Rgb, PixelType.UnsignedByte, _alphaBuf);
        }


    }
}
