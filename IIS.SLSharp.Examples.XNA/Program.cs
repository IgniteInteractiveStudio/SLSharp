using Microsoft.Xna.Framework;

namespace IIS.SLSharp.Examples.XNA
{
    internal static class Program
    {
        private static void Main()
        {
            using (var win = new DemoWindow())
            {
                win.Run();
            }
        }
    }
}
