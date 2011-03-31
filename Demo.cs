using System;
using GeoClip.Shaders.Examples.Shaders;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GeoClip.Shaders.Examples
{
    public sealed class DemoWindow : GameWindow
    {
        private MyShader _myShader;

        protected override void OnLoad(EventArgs e)
        {
            _myShader = Shader.CreateSharedShader<MyShader>();
            Console.WriteLine("Vertex Shader");
            Console.WriteLine("=============");
            Console.WriteLine(_myShader.VertexShader);
            Console.WriteLine("Fragment Shader");
            Console.WriteLine("===============");
            Console.WriteLine(_myShader.FragmentShader);
        }

        protected override void OnUnload(EventArgs e)
        {
            _myShader.Dispose();
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(ClientRectangle);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Disable(EnableCap.CullFace);

            _myShader.Begin();
            _myShader.Blue = 0.5f;
            _myShader.Invert.Channels = new Vector4(0.0f, 1.0f, 0.0f, 0.0f);
            GL.Rect(-1, -1, 1, 1);
            _myShader.End();

            SwapBuffers();
        }
    }
}
