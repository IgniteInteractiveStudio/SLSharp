using System;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Bindings.OpenTK.Textures
{
    /// <summary>
    /// Manages an OpenGl framebuffer object
    /// This is normally only used internally by the RenderToTexture class
    /// </summary>
    public sealed class FramebufferObject : IDisposable
    {
        private int _fbo;

        public FramebufferObject()
        {
            GL.GenFramebuffers(1, out _fbo);

            Utilities.CheckGL();
        }

        public void Dispose()
        {
            if (_fbo == 0)
                return;

            GL.DeleteFramebuffers(1, ref _fbo);

            Utilities.CheckGL();

            _fbo = 0;

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Activates the framebuffer object.
        /// All fragment output that follows will be captured by it. 
        /// </summary>
        public void Activate()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, _fbo);
        }

        /// <summary>
        /// Removes any current framebuffer object.
        /// </summary>
        public void Finish()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }

        /// <summary>
        /// Associates a Texture with the framebuffer object
        /// </summary>
        /// <param name="texture">The texture to associate</param>
        /// <param name="index">The channel to asscociate</param>
        public void SetTexture(Texture2D texture, int index = 0)
        {
            if (texture == null)
                throw new ArgumentNullException("texture");

            Activate();

            GL.FramebufferTexture2D(FramebufferTarget.Framebuffer,
                FramebufferAttachment.ColorAttachment0 + index,
                texture.Target, texture.Name, 0);

            Finish();
        }

        /// <summary>
        /// Validates readyness of the framebuffer object
        /// </summary>
        public void Check()
        {
            Activate();
            var code = GL.CheckFramebufferStatus(FramebufferTarget.Framebuffer);
            Finish();

            if (code == FramebufferErrorCode.FramebufferComplete)
                return;

            Utilities.ThrowGLError(GL.GetError());
        }

        ~FramebufferObject()
        {
            Dispose();
        }
    }
}
