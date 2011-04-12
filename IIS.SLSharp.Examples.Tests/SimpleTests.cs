using System;
using IIS.SLSharp.Bindings.OpenTK;
using IIS.SLSharp.Examples.Simple.Shaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;
using OpenTK.Graphics;

namespace IIS.SLSharp.Examples.Tests
{
    [TestClass]
    public class SimpleTests
    {
        private MyShader _shader;

        private INativeWindow _window; // OpenTK forces us to create one ... (great design eh?)

        private IGraphicsContext _context;


        [TestInitialize]
        public void Initialize()
        {
            // <Rant>
            // OpenTK has a great fuckup in its design here. It's absolutly not possible to create
            // a render context for offscreen rendering without creating an OpenTK window.
            // before. 
            // Passing Utilities.CreateDummyWindowInfo() or anything else will cause an invalid cast exception
            // Using Utilities.CreateWindowsWindowInfo(IntPtr.Zero) binds the code to windows only
            // Really great, why do i need to have a window in order to render to memory? -_-
            //</Rant>

            _window = new NativeWindow { Visible = false };
            _context = new GraphicsContext(GraphicsMode.Default, _window.WindowInfo, 2, 0, GraphicsContextFlags.Default);
            _context.MakeCurrent(_window.WindowInfo);
            _context.LoadAll();
            
            Bindings.OpenTK.SLSharp.Init();
            _shader = Shaders.Shader.CreateInstance<MyShader>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _shader.Dispose();
            _context.Dispose();
        }

        [TestMethod]
        public void Test()
        {
            _shader.Begin();
            _shader.Blue = 0.5f;
            _shader.Invert.Channels = (new Vector4(0.0f, 1.0f, 0.0f, 0.0f)).ToVector4F();
            _shader.RenderQuad();
            _shader.End();
        }
    }
}
