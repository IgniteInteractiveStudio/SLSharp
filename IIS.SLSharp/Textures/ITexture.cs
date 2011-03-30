using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Textures
{
    public interface ITexture
    {
        /// <summary>
        /// OpenGL texture target
        /// </summary>
        TextureTarget Target { get; }

        /// <summary>
        /// Binds the texture
        /// </summary>
        void Activate();

        /// <summary>
        /// Unbinds any current texture
        /// </summary>
        void Finish();
    }
}
