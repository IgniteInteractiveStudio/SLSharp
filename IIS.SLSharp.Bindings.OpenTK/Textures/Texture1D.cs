using System;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Bindings.OpenTK.Textures
{
    /// <summary>
    /// Specialization of BaseTexture for 1D Textures.
    /// </summary>
    public class Texture1D : TextureBase
    {
        public int Width { get; private set; }

        /// <summary>
        /// Creates a new managed 1D Texture
        /// </summary>
        /// <param name="width">The width in Pixels of the Texture</param>
        /// <param name="components">The number of components. Must be 1 2 3 or 4.</param>
        /// <param name="type">The data type to use (Default is 16bit Half)</param>
        public Texture1D(int width, int components = 4, Type type = null)
            : base(TextureTarget.Texture1D)
        {
            Width = width;

            Activate();
            GL.TexParameter(TextureTarget.Texture1D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge); // GL_REPEAT
            GL.TexParameter(TextureTarget.Texture1D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture1D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            PixelInternalFormat internalformat;
            PixelFormat format;
            GetFormat(components, type ?? typeof(byte), out internalformat, out format);

            GL.TexImage1D(TextureTarget.Texture1D, 0, internalformat, Width, 0, format, PixelType.UnsignedByte, IntPtr.Zero);

            Utilities.CheckGL();
        }
    }
}
