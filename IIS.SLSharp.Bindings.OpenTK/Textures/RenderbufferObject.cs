using System;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Bindings.OpenTK.Textures
{
    /// <summary>
    /// Manages an OpenGL renderbuffer object
    /// This is similar to a FramebufferObject but the resources wont be
    /// accessable. As the FramebufferObject this is normally used only
    /// internally by RenderToTexture
    /// </summary>
    public sealed class RenderbufferObject : IDisposable
    {
        private int _rbo;

        public RenderbufferObject()
        {
            GL.GenRenderbuffers(1, out _rbo);
        }

        public void Dispose()
        {
            if (_rbo == 0)
                return;

            GL.DeleteRenderbuffers(1, ref _rbo);
            _rbo = 0;

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Makes this renderbuffer active
        /// </summary>
        public void Activate()
        {
            GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, _rbo);
        }

        /// <summary>
        /// Removes any currently active renderbuffer
        /// </summary>
        public void Finish()
        {
            GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, 0);
        }

        /// <summary>
        /// Sets the size of the renderbuffer
        /// </summary>
        /// <param name="width">The width in pixels of the renderbuffer</param>
        /// <param name="height">The height in pixels of the renderbuffer</param>
        public void SetSize(int width, int height)
        {
            Activate();

            GL.RenderbufferStorage(RenderbufferTarget.Renderbuffer, RenderbufferStorage.DepthComponent24, width, height);
            GL.FramebufferRenderbuffer(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, 
                RenderbufferTarget.Renderbuffer, _rbo);

            Finish();
        }

        ~RenderbufferObject()
        {
            Dispose();
        }
    }
}
