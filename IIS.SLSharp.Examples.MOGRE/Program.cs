using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mogre;

namespace IIS.SLSharp.Examples.MOGRE
{
    class Program
    {
        private static void Main()
        {
            using (var r = new Root())
            {
                r.LoadPlugin("RenderSystem_GL");
                r.RenderSystem = r.GetRenderSystemByName("OpenGL Rendering Subsystem");
                using (r.Initialise(false))
                {
                    using (var w = r.RenderSystem._createRenderWindow("SL# Demo", 640, 480, false))
                    {
                        var win = new DemoWindow(r, w);
                        win.OnLoad();
                        r.FrameRenderingQueued += win.OnRenderFrame;
                        r.StartRendering();
                        win.OnUnload();
                    }
                }
            }
        }
    }
}
