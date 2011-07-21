﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IIS.SLSharp.Bindings.OpenTK.Textures;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Examples.Tests.OpenTKTestRuntime
{
    internal sealed class OpenTKTestRuntime: ITestRuntime
    {
        private INativeWindow _window; // OpenTK forces us to create one ... (great design eh?)

        private IGraphicsContext _context;

        private RenderToTexture _rtt;

        public void Initialize()
        {
            // <Rant>
            // OpenTK has a great fuckup in its design here. It's absolutly nohm it possible to create
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

            // create offscreen rendertarget with high precision
            _rtt = new RenderToTexture(1, 1, false, 4, typeof(float));

            // init SL#
            Bindings.OpenTK.SLSharp.Init();
        }

        public void Cleanup()
        {
            _rtt.Dispose();
            _context.Dispose();
            _window.Dispose();
        }

        public Vector4 ProcessFragment()
        {
            var pixel = new float[4];
            _rtt.Activate();
            GL.Viewport(0, 0, 1, 1);
            GL.ClearColor(0.1f, 0.3f, 0.6f, 0.9f);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            //GL.Arb.ClampColor(ArbColorBufferFloat.ClampFragmentColorArb, ArbColorBufferFloat.RgbaFloatModeArb);
            //GL.Arb.ClampColor(ArbColorBufferFloat.ClampVertexColorArb, ArbColorBufferFloat.RgbaFloatModeArb);
            //GL.Arb.ClampColor(ArbColorBufferFloat.ClampReadColorArb, ArbColorBufferFloat.RgbaFloatModeArb);
            //GL.ClampColor(ClampColorTarget.ClampVertexColor, ClampColorMode.False);
            //GL.ClampColor(ClampColorTarget.ClampFragmentColor, ClampColorMode.False);
            //GL.ClampColor(ClampColorTarget.ClampReadColor, ClampColorMode.False);

            GL.Begin(BeginMode.Points);
            GL.Vertex3(0, 0, 0);
            GL.End();
            GL.Flush();
            GL.ReadPixels(0, 0, 1, 1, PixelFormat.Rgba, PixelType.Float, pixel);
            _rtt.Finish();
            Utilities.CheckGL();

            //_context.SwapBuffers();
            
            return new Vector4(pixel[0], pixel[1], pixel[2], pixel[3]);
        }
    }
}
