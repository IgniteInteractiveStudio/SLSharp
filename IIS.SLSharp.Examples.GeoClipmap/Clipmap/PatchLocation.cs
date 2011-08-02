namespace IIS.SLSharp.Examples.GeoClipmap.Clipmap
{
    public struct PatchLocation
    {
        public readonly int X;

        public readonly int Y;

        public readonly int Index;

        public readonly Patch Patch;

        public PatchLocation(int x, int y, int index, Patch patch)
        {
            X = x;
            Y = y;
            Index = index;
            Patch = patch;
        }
    }
}
