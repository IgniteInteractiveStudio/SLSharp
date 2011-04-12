using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using IIS.SLSharp.Bindings.OpenTK.Textures.Externals;
using OpenTK.Graphics.OpenGL;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;

namespace IIS.SLSharp.Bindings.OpenTK.Textures
{
    /// <summary>
    /// Specialization of BaseTexture for 1D Textures.
    /// </summary>
    public class Texture2D : TextureBase
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        private readonly PixelInternalFormat _internalFormat;

        /// <summary>
        /// Creates a managed wrapper around an existing 2D OpenGL texture.
        /// </summary>
        /// <param name="existingName"></param>
        private Texture2D(uint existingName) 
            : base(TextureTarget.Texture2D, existingName)
        {
            int width, height;

            Activate();
            GL.GetTexLevelParameter(Target, 0, GetTextureParameter.TextureWidth, out width);
            GL.GetTexLevelParameter(Target, 0, GetTextureParameter.TextureHeight, out height);
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Creates a new managed 2D Texture
        /// </summary>
        /// <param name="width">The width in Pixels of the Texture</param>
        /// <param name="height">The height in Pixels of the Texture</param>
        /// <param name="components">The number of components. Must be 1 2 3 or 4.</param>
        /// <param name="type">The data type to use (Default is 16bit Half)</param>
        /// <param name="target">The target this Texture will be bound to</param>
        public Texture2D(int width, int height, int components, Type type, TextureTarget target = TextureTarget.Texture2D)
            : base(target)
        {
            Activate();
            GL.TexParameter(Target, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge); // GL_REPEAT
            GL.TexParameter(Target, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge); // GL_REPEAT
            GL.TexParameter(Target, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(Target, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            PixelFormat format;
            GetFormat(components, type ?? typeof(byte), out _internalFormat, out format);

            Resize(width, height);
        }

        /// <summary>
        /// Creates a new managed 2D Texture with an explicitly specified format
        /// </summary>
        /// <param name="width">The width in Pixels of the Texture</param>
        /// <param name="height">The height in Pixels of the Texture</param>
        /// <param name="format">The format to use</param>
        /// <param name="target">The target this Texture will be bound to</param>
        public Texture2D(int width, int height, PixelInternalFormat format,  TextureTarget target = TextureTarget.Texture2D)
            : base(target)
         {
            _internalFormat = format;
            Activate();
            GL.TexParameter(Target, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge); // GL_REPEAT
            GL.TexParameter(Target, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge); // GL_REPEAT
            GL.TexParameter(Target, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(Target, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            Resize(width, height);
        }

        /// <summary>
        /// Creates a new managed 2D Texture with the same format as an existing one
        /// </summary>
        /// <param name="width">The width in Pixels of the Texture</param>
        /// <param name="height">The height in Pixels of the Texture</param>
        /// <param name="other">The texture to copy the format from</param>
        public Texture2D(int width, int height, Texture2D other)
            : this(width, height, other._internalFormat, other.Target)
        {
            if (other == null)
                throw new ArgumentNullException("other");
        }

        /// <summary>
        /// Utility function that creates a mip map chain for the texture.
        /// </summary>
        /// <param name="maxLevel"></param>
        public void GenerateMipMaps(int maxLevel)
        {
            Activate();

            GL.TexParameter(Target, TextureParameterName.TextureMaxLod, maxLevel);
            GL.TexParameter(Target, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);

            if (Utilities.IsVersion(3) || Utilities.HasExtension("GL_EXT_framebuffer_object"))
                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            else
            {
                GL.TexParameter(Target, TextureParameterName.GenerateMipmap, 1);
                throw new NotImplementedException("You currently GL_EXT_framebuffer_object; we need need testing here as the" +
                    " fallback version doesn't seem to work.");
            }

            Utilities.CheckGL();
        }

        /// <summary>
        /// Loads a texture from a bitmap
        /// </summary>
        /// <param name="bmp">The bitmap to load from</param>
        /// <returns>The texture object</returns>
        public static Texture2D FromBitmap(Bitmap bmp)
        {
            if (bmp == null)
                throw new ArgumentNullException("bmp");

            var bits = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            var components = Image.IsAlphaPixelFormat(bmp.PixelFormat) ? 4 : 3;
            var tex = new Texture2D(bmp.Width, bmp.Height, components, typeof(byte)); // lotsa possible opts here
            tex.Activate();

            var p = bits.Scan0;
            for (var y = 0; y < bits.Height; y++, p += bits.Stride)
            {
                GL.TexSubImage2D(tex.Target, 0, 0, y, bits.Width, 1,
                PixelFormat.Bgra, PixelType.UnsignedByte, p);
            }

            return tex;
        }

        /// <summary>
        /// Loads a texture from a stream
        /// </summary>
        /// <param name="s">The stream to load from</param>
        /// <returns>The texture object</returns>
        public static Texture2D FromStream(Stream s)
        {
            if (s == null)
                throw new ArgumentNullException("s");

            return FromBitmap((Bitmap)Image.FromStream(s));
        }

        /// <summary>
        /// Loads a texture from a file which is supported by System.Drawing.Image
        /// </summary>
        /// <param name="fileName">The file to be loaded</param>
        /// <returns>The texture object</returns>
        public static Texture2D FromFile(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");

            return FromBitmap((Bitmap) Image.FromFile(fileName));
        }

        /// <summary>
        /// Loads a texture from a dds file
        /// </summary>
        /// <param name="fileName">The file to be loaded</param>
        /// <returns>The texture object</returns>
        public static Texture2D FromDdsFile(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");

            uint name;
            TextureTarget dim;
            ImageDDS.LoadFromDisk(fileName, out name, out dim);

            if (dim != TextureTarget.Texture2D)
                throw new InvalidDataException("Texture was not 2D.");

            if (!GL.IsTexture(name))
                throw new InvalidDataException("Texture loading failed.");

            return new Texture2D(name);
        }

        /// <summary>
        /// Resizes the texture.
        /// </summary>
        /// <param name="width">New width</param>
        /// <param name="height">New Height</param>
        /// <param name="keepContent">
        /// Set to true to copy over old content to new texture.
        /// This is likeley to be very slow!
        /// </param>
        public void Resize(int width, int height, bool keepContent = false)
        {
            Activate();
            if (keepContent)
            {
                var tmpWidth = Width < width ? Width : width;
                var tmpHeight = Height < height ? Height : height;
                var tmp = new float[tmpWidth*tmpHeight*4];
                GL.ReadPixels(0, 0, tmpWidth, tmpHeight, PixelFormat.Rgba, PixelType.Float, tmp);

                Width = width;
                Height = height;
                GL.TexImage2D(Target, 0, _internalFormat, Width, Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);
                GL.TexSubImage2D(Target, 0, 0, 0, tmpWidth, tmpHeight, PixelFormat.Rgba, PixelType.Float, tmp);
            }
            else
            {
                Width = width;
                Height = height;
                GL.TexImage2D(Target, 0, _internalFormat, Width, Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);
            }

            Utilities.CheckGL();
        }
    }
}
