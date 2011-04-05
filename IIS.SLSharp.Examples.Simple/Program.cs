namespace IIS.SLSharp.Examples.Simple
{
    internal static class Program
    {
        private static void Main()
        {
            using (var win = new DemoWindow { Title = "GeoClip Shader Demo" })
                win.Run(0.0d);
        }
    }
}
