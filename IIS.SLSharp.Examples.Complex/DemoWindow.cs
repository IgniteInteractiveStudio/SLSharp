using System;
using System.Diagnostics;
using IIS.SLSharp.Bindings.OpenTK;
using IIS.SLSharp.Examples.Complex.Shaders;
using IIS.SLSharp.Shaders;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Examples.Complex
{
    public sealed class DemoWindow : GameWindow
    {
        private CubeShader _cubeShader;

        private BackdropShader _backdropShader;

        private Cube _cube;

        private readonly Stopwatch _timer = new Stopwatch();

        private float _time;

        private float _aspect;

        protected override void OnLoad(EventArgs e)
        {
            Bindings.OpenTK.SLSharp.Init();
            _backdropShader = Shader.CreateSharedShader<BackdropShader>();
            _cubeShader = Shader.CreateSharedShader<CubeShader>();
            _cube = new Cube();
            _timer.Start();
        }

        protected override void OnUnload(EventArgs e)
        {
            _backdropShader.Dispose();
            _cubeShader.Dispose();
            _cube.Dispose();
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(ClientRectangle);
        }

        private Matrix4 SetupCamera()
        {
            const float r = 4.0f;
            var eyeX = (float)System.Math.Cos(_time * MathHelper.TwoPi) * r;
            var eyeZ = (float)System.Math.Sin(_time * MathHelper.TwoPi) * r;
            var eyeY = (float)System.Math.Sin(_time * MathHelper.TwoPi * 3) * 1.5f;

            var lookAt = Matrix4.LookAt(eyeX, eyeY, eyeZ, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
            var projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), _aspect, 0.01f, 6.0f);

            return lookAt * projection;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            _time = (_timer.ElapsedMilliseconds % 4000) / 4000.0f;
            _aspect = (float)Width / Height;

            GL.ClearColor(0.3f, 0.3f, 1.0f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.CullFace);

            SetupCamera();

            _backdropShader.Begin();
            _backdropShader.Render(_time, _aspect);
            _backdropShader.End();

            _cubeShader.Begin();
            _cubeShader.ModelViewProjectionMatrix = SetupCamera().ToMatrix4F();
            _cube.Render(Shader.AttributeLocation(_cubeShader, () => _cubeShader.Vertex));
            _cubeShader.End();

            SwapBuffers();
        }
    }
}
