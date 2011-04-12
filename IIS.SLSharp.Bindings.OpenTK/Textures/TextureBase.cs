using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Bindings.OpenTK.Textures
{
    /// <summary>
    /// Basic texture class that manages an OpenGL texture
    /// </summary>
    public abstract class TextureBase : IDisposable, ITexture
    {
        public int Name { get; private set; }

        public TextureTarget Target { get; private set; }

        /// <summary>
        /// Activates the current texture
        /// </summary>
        public void Activate()
        {
            GL.BindTexture(Target, Name);
        }

        /// <summary>
        /// Disables any current texture
        /// </summary>
        public void Finish()
        {
            GL.BindTexture(Target, 0);
        }

        protected TextureBase(TextureTarget target)
        {
            Target = target;
            Name = GL.GenTexture();

            Utilities.CheckGL();
        }

        /// <summary>
        /// Sets up a BaseTexture instance using an existing OpenGL texture.
        /// </summary>
        /// <param name="target">The OpenGL texture target</param>
        /// <param name="existingName">An existing OpenGL texture name</param>
        protected TextureBase(TextureTarget target, uint existingName)
        {
            Target = target;
            Name = (int)existingName;
        }

        public virtual void Dispose()
        {
            if (Name == 0)
                return;

            GL.DeleteTexture(Name);
            Name = 0;

            GC.SuppressFinalize(this);
        }

        ~TextureBase()
        {
            Dispose();
        }

        /// <summary>
        /// Enlarges the given parameter to the next larger power of 2 when it is
        /// not a power of 2.
        /// </summary>
        /// <param name="v">The value to enlarge</param>
        /// <returns>The minimal x where x = 2**n and x >= v</returns>
        public static int EnlargeToPow2(int v)
        {
            v--;
            v |= v >> 1;
            v |= v >> 2;
            v |= v >> 4;
            v |= v >> 8;
            v |= v >> 16;
            return v + 1;
        }


        private static readonly PixelFormat[] _formats = new[]
        {
            PixelFormat.Red,
            PixelFormat.Rg,
            PixelFormat.Rgb,
            PixelFormat.Rgba,
        };

        private static readonly PixelInternalFormat[] _floatFormats = new[]
        {
            PixelInternalFormat.R32f,
            PixelInternalFormat.Rg32f,
            PixelInternalFormat.Rgb32f,
            PixelInternalFormat.Rgba32f,
        };

        private static readonly PixelInternalFormat[] _halfFormats = new[]
        {
            PixelInternalFormat.R16f,
            PixelInternalFormat.Rg16f,
            PixelInternalFormat.Rgb16f,
            PixelInternalFormat.Rgba16f,
        };

        private static readonly PixelInternalFormat[] _u8Formats = new[]
        {
            PixelInternalFormat.Alpha8,
            PixelInternalFormat.Luminance8Alpha8,
            PixelInternalFormat.Rgb8,
            PixelInternalFormat.Rgba8,
        };

        private static readonly PixelInternalFormat[] _u16Formats = new[]
        {
            PixelInternalFormat.Alpha16,
            PixelInternalFormat.Luminance16Alpha16,
            PixelInternalFormat.Rgb16,
            PixelInternalFormat.Rgb16,
        };

        private static readonly Dictionary<Type, PixelInternalFormat[]> _internalFormats = new Dictionary<Type, PixelInternalFormat[]>
        {
            { typeof(float), _floatFormats },
            { typeof(Half), _halfFormats },
            { typeof(byte), _u8Formats },
            { typeof(ushort), _u16Formats },
        };
                
            
        /// <summary>
        /// Looks up most suitable internal and clientside format specified by the parameters
        /// </summary>
        /// <param name="components">The number of components in the texture (1 2 3 or 4)</param>
        /// <param name="type">The datatype that is used on the client side</param>
        /// <param name="internalFormat">The looked up GL data format for the server side</param>
        /// <param name="format">The looked up GL data format for the client side</param>
        public static void GetFormat(int components, Type type, out PixelInternalFormat internalFormat,
            out PixelFormat format)
        {
            if (components < 1 || components > 4)
                throw new ArgumentOutOfRangeException("components", components, "Components must be between 1 and 4.");

            if (type == null)
                throw new ArgumentNullException("type");

            var index = components - 1;
            format = _formats[index];

            PixelInternalFormat[] internalTable;
            if (!_internalFormats.TryGetValue(type, out internalTable))
                throw new ArgumentException("Unsupported texture data type.", "type");

            internalFormat = internalTable[index];
        }
    }
}
