using System;
using IIS.SLSharp.Bindings.OpenTK;
using IIS.SLSharp.Examples.GeoClipmap.Shaders;
using IIS.SLSharp.Shaders;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace IIS.SLSharp.Examples.GeoClipmap
{
    public sealed class DemoWindow : GameWindow
    {
        private Clipmap.Clipmap _clipmap;

        private int _rotation;

        private int _up;

        protected override void OnLoad(EventArgs e)
        {
            Mouse.Move += (x, args) =>
            {
                if (!Mouse[MouseButton.Left])
                    return;

                _rotation = (_rotation + 360 + args.XDelta) % 360;
                _up += args.YDelta;
                if (_up < -100)
                    _up = -100;
                if (_up > 100)
                    _up = 100;
            };

            Bindings.OpenTK.SLSharp.Init();
            _clipmap = new Clipmap.Clipmap();
        }

        protected override void OnUnload(EventArgs e)
        {
            _clipmap.Dispose();
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(ClientRectangle);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            var dx = 0;
            var dy = 0;
            if (Keyboard[Key.W])
                dy++;
            if (Keyboard[Key.S])
                dy--;
            if (Keyboard[Key.A])
                dx--;
            if (Keyboard[Key.D])
                dx++;
            if (Keyboard[Key.R])
                _clipmap.Reset();

            if (dx != 0 || dy != 0)
                _clipmap.MoveBy(dx * 0.001f, dy * 0.001f);
            
 

            GL.ClearColor(0.6f, 0.6f, 0.8f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Disable(EnableCap.CullFace);
            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            
            var aspect = Width / (float)Height;

            var phi = MathHelper.DegreesToRadians(_rotation);
            var cosPhi = (float)Math.Cos(phi);
            var sinPhi = (float)Math.Sin(phi);

            var mod = Matrix4.LookAt(0.0f, 0.0f, 0.3f, cosPhi, sinPhi, _up * 0.01f, 0.0f, 0.0f, 1.0f);
            var proj = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(90.0f), aspect, 0.0001f, 10.0f);

            
            _clipmap.Render(mod * proj, true);
            //_clipmap.Debug();

            SwapBuffers();
        }
    }
}
