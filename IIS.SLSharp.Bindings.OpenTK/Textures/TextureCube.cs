using System;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Bindings.OpenTK.Textures
{
    /// <summary>
    /// Specialization of BaseTexture for Cube maps.
    /// </summary>
    public class TextureCube : Bindings.OpenTK.Textures.TextureBase
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        /// <summary>
        /// Creates a new managed 2D Texture
        /// </summary>
        /// <param name="width">The width in Pixels of the Texture</param>
        /// <param name="height">The height in Pixels of the Texture</param>
        /// <param name="components">The number of components. Must be 1 2 3 or 4.</param>
        /// <param name="type">The data type to use (Default is 16bit Half)</param>
        public TextureCube(int width, int height, int components, Type type = null)
            : base(TextureTarget.TextureCubeMap)
        {
            Width = width;
            Height = height;

            Activate();
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge); // GL_REPEAT
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge); // GL_REPEAT
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR, (int)TextureWrapMode.ClampToEdge); // GL_REPEAT
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            PixelInternalFormat internalformat;
            PixelFormat format;
            GetFormat(components, type ?? typeof(byte), out internalformat, out format);

            for (var i = 0; i < 6; i++)
                GL.TexImage2D(TextureTarget.TextureCubeMapPositiveX + i, 0, internalformat, Width, Height, 0, format,
                    PixelType.UnsignedByte, IntPtr.Zero);
        }
    }
}
