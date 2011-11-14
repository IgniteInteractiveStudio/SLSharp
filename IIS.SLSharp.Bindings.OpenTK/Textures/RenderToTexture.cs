using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Bindings.OpenTK.Textures
{
    /// <summary>
    /// This class is used, when render output should be captured offscreen into a (set of) Texture(s).
    /// 
    /// A fragment shader outputs to the i'th texture by writing to gl_FragData[i] or using an out
    /// variable bound to the index
    /// After rendering to the RenderToTexture is completed, the independant textures can be accessed 
    /// through the [index] operator.
    /// </summary>
    public sealed class RenderToTexture : IDisposable
    {
        private readonly FramebufferObject _fbo;

        private readonly RenderbufferObject _rbo;

        private readonly Texture2D[] _textures;

        private readonly DrawBuffersEnum[] _bufs;

        /// <summary>
        /// Retrieves the texture that was rendered to
        /// </summary>
        /// <param name="index">The output channel index to retrieve</param>
        /// <returns></returns>
        public Texture2D this[int index] 
        { 
            get { return _textures[index]; } 
        }

        /// <summary>
        /// Creates new (set of) renderable Texture(s)
        /// </summary>
        /// <param name="width">The width in pixels of the Texture(s)</param>
        /// <param name="height">The height in pixels of the Texture(s)</param>
        /// <param name="depth">True if depthbuffer is required when rendering to the Texture(s)</param>
        /// <param name="components">The number of color components the Texture(s) have</param>
        /// <param name="format">The data format the Texture(s) shall use, default is 16bit Half</param>
        /// <param name="buffers">The number of Textures to use.</param>
        public RenderToTexture(int width, int height, bool depth, int components = 3, Type format = null, int buffers = 1)
            : this(width, height, depth, buffers, () => new Texture2D(width, height, components, format ?? typeof(Half)))
        {
        }


        /// <summary>
        /// Creates new (set of) renderable Texture(s)
        /// </summary>
        /// <param name="width">The width in pixels of the Texture(s)</param>
        /// <param name="height">The height in pixels of the Texture(s)</param>
        /// <param name="depth">True if depthbuffer is required when rendering to the Texture(s)</param>
        /// <param name="format">Explicit format to be used</param>
        /// <param name="buffers">The number of Textures to use.</param>
        public RenderToTexture(int width, int height, bool depth, PixelInternalFormat format, int buffers = 1)
            : this(width, height, depth, buffers, () => new Texture2D(width, height, format))
        {
        }

        private RenderToTexture(int width, int height, bool depth, int buffers, Func<Texture2D> createTexture )
        {
            _fbo = new FramebufferObject();
            _textures = new Texture2D[buffers];
            _bufs = new DrawBuffersEnum[buffers];

            for (var i = 0; i < buffers; i++)
                _bufs[i] = DrawBuffersEnum.ColorAttachment0 + i;

            _fbo.Activate();
            GL.DrawBuffers(_textures.Length, _bufs);
            Utilities.CheckGL();

            _fbo.Finish();
            GL.DrawBuffer(DrawBufferMode.Back);
            Utilities.CheckGL();

            for (var i = 0; i < buffers; i++)
            {
                _textures[i] = createTexture();
                _fbo.SetTexture(_textures[i], i);
            }

            if (depth)
            {
                _rbo = new RenderbufferObject();
                _fbo.Activate();
                _rbo.SetSize(width, height);
                _fbo.Finish();
            }

            _fbo.Check();
            Utilities.CheckGL();
        }

        /// <summary>
        /// Starts to capture to the textures
        /// </summary>
        public void Activate()
        {
            GL.PushAttrib(AttribMask.ViewportBit);
            GL.Viewport(0, 0, _textures[0].Width, _textures[0].Height);
            _fbo.Activate();
        }

        /// <summary>
        /// Finishs capturing
        /// </summary>
        public void Finish()
        {
            _fbo.Finish();
            GL.PopAttrib();
        }

        public void Dispose()
        {
            _fbo.Dispose();
            if (_rbo != null)
                _rbo.Dispose();

            foreach (var tex in _textures)
                tex.Dispose();

            GC.SuppressFinalize(this);
        }

        ~RenderToTexture()
        {
            Dispose();
        }
    }
}
