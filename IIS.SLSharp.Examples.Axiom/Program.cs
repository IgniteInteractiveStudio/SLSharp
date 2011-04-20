using Axiom.Core;

namespace IIS.SLSharp.Examples.Axiom
{
    internal static class Program
    {
        private static void Main()
        {
            using (var r = new Root())
            {
                r.RenderSystem = r.RenderSystems[0];
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
