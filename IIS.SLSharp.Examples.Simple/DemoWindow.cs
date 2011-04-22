using System;
using System.Runtime.InteropServices;
using IIS.SLSharp.Bindings.OpenTK;
using IIS.SLSharp.Examples.Simple.Shaders;
using IIS.SLSharp.Shaders;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Examples.Simple
{
    public sealed class DemoWindow : GameWindow
    {
        private MyShader _myShader;

        protected override void OnLoad(EventArgs e)
        {
            Bindings.OpenTK.SLSharp.Init();
            _myShader = Shader.CreateSharedShader<MyShader>();
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
            _myShader.Invert.Channels = (new Vector4(0.0f, 1.0f, 0.0f, 0.0f)).ToVector4F();
            _myShader.RenderQuad();
            _myShader.End();

            SwapBuffers();
        }
    }
}
