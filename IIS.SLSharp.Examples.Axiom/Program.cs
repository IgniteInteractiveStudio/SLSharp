using System;
using System.IO;
using Axiom.Core;

namespace IIS.SLSharp.Examples.Axiom
{
    internal static class Program
    {
        private static void Main()
        {
            using (var r = new Root())
            {
                if (r.RenderSystems.Count == 0)
                    throw new Exception("No Rendersystem found");

                Console.WriteLine("Select a Rendersystem");
                for (var i = 0; i < r.RenderSystems.Count; i++)
                    Console.WriteLine("{0}: {1}", i + 1, r.RenderSystems[i].Name);

                while (true)
                {
                    int index;
                    if (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out index))
                        continue;

                    if (index < 1)
                        continue;
                    index--;

                    if (index >= r.RenderSystems.Count)
                        continue;

                    r.RenderSystem = r.RenderSystems[index];
                    break;
                }

                
                using (r.Initialize(true))
                {
                    var win = new DemoWindow(r);
                    win.OnLoad();
                    r.FrameRenderingQueued += win.OnRenderFrame;
                    r.StartRendering();
                    win.OnUnload();
                }
            }
        }
    }
}
