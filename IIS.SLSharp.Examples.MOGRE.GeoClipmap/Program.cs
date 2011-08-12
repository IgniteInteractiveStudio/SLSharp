using System;
using Mogre;

namespace IIS.SLSharp.Examples.MOGRE.GeoClipmap
{
    class Program
    {
        private static void Main()
        {
            using (var r = new Root())
            {

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Select Render system:");
                Console.WriteLine("1.) OpenGL");
                Console.WriteLine("2.) Direct3D9");
                while (true)
                {
                    var k = Console.ReadKey(true);
                    int v;
                    if (!int.TryParse(k.KeyChar.ToString(), out v))
                        continue;
                    if (v > 2 || v == 0)
                        continue;

                    if (v == 1)
                    {
                        r.LoadPlugin("RenderSystem_GL");
                        r.RenderSystem = r.GetRenderSystemByName("OpenGL Rendering Subsystem");
                    }
                    else
                    {
                        r.LoadPlugin("RenderSystem_Direct3D9");
                        r.RenderSystem = r.GetRenderSystemByName("Direct3D9 Rendering Subsystem");
                    }
                    break;
                }

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
