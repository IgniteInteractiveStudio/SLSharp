using System;

namespace IIS.SLSharp.Examples.GeoClipmap
{
    internal static class Program
    {
        public static string WoWDir;
        private static void Main(string[] args)
        {
            if (args.Length < 1)
                throw new ArgumentException("You did not specify the working dir!");

            WoWDir = args[0] + "\\";
            using (var win = new DemoWindow { Title = "GeoClip Shader Demo" })
                win.Run(0.0d);
        }
    }
}
