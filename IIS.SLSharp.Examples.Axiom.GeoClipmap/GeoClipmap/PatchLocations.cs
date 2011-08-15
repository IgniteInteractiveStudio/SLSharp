using System;
using System.Collections.Generic;
using IIS.SLSharp.Examples.Axiom.GeoClipmap.Shaders;
using IIS.SLSharp.Shaders;
using ResourceManager = IIS.SLSharp.Runtime.ResourceManager;

namespace IIS.SLSharp.Examples.Axiom.GeoClipmap.GeoClipmap
{
    public sealed class PatchLocations : IDisposable
    {
        private readonly List<PatchLocation> _locations = new List<PatchLocation>();

        private readonly Patch[] _patches = new Patch[6];

        [Flags]
        [Serializable]
        public enum PatchSelection
        {
            BaseBottomLeft0  = 0x000001,
            BaseBottomLeft1  = 0x000002,
            BaseBottomLeft2  = 0x000004,
            BaseBottomLeft   = BaseBottomLeft0 | BaseBottomLeft1 | BaseBottomLeft2,

            BaseBottomRight0 = 0x000008,
            BaseBottomRight1 = 0x000010,
            BaseBottomRight2 = 0x000020,
            BaseBottomRight  = BaseBottomRight0 | BaseBottomRight1 | BaseBottomRight2,

            BaseTopLeft0     = 0x000040,
            BaseTopLeft1     = 0x000080,
            BaseTopLeft2     = 0x000100,
            BaseTopLeft      = BaseTopLeft0 | BaseTopLeft1 | BaseTopLeft2,
            
            BaseTopRight0    = 0x000200,
            BaseTopRight1    = 0x000400,
            BaseTopRight2    = 0x000800,
            BaseTopRight     = BaseTopRight0 | BaseTopRight1 | BaseTopRight2,

            Base             = BaseBottomLeft | BaseBottomRight | BaseTopLeft | BaseTopRight,

            InnerTopRight    = 0x001000,
            InnerTopLeft     = 0x002000,
            InnerBottomRight = 0x004000,
            InnerBottomLeft  = 0x008000,

            Inner = InnerTopRight | InnerTopLeft | InnerBottomRight | InnerBottomLeft,

            FixupLeft        = 0x010000,
            FixupRight       = 0x020000,
            FixupBottom      = 0x040000,
            FixupTop         = 0x080000,
            Fixup            = FixupLeft | FixupRight | FixupBottom | FixupTop,

            Outer            = Base | Fixup,

            InteriorTop      = 0x100000,
            InteriorBottom   = 0x200000,
            InteriorRight    = 0x400000,
            InteriorLeft     = 0x800000,

            OuterDegenerated = 0x1000000,

            InteriorAll      = InteriorTop | InteriorBottom | InteriorRight | InteriorLeft,

            Everything       = Outer | InteriorAll | Inner
        }

        [Serializable]
        private enum Buffer
        {
            BasePatch = 0,
            RingFixup1 = 1,
            RingFixup2 = 2,
            InteriorTrim1 = 3,
            InteriorTrim2 = 4,
            OuterDegenerated = 5
        }

        private void AddPatch(int x, int y, Buffer id)
        {
            _locations.Add(new PatchLocation(x, y, _locations.Count, _patches[(int)id]));
        }

        public PatchLocations(int h, int m)
        {
            // patches are sorted by type so the least number of buffer switches
            // is required when rendering through the iterator

            // use shared resources here rather than new'ing Patch() es
            _patches[(int)Buffer.BasePatch] = ResourceManager.Instance<Patch>(m, m);
            _patches[(int)Buffer.RingFixup1] = ResourceManager.Instance<Patch>(m, 3);
            _patches[(int)Buffer.RingFixup2] = ResourceManager.Instance<Patch>(3, m);
            _patches[(int)Buffer.InteriorTrim1] = ResourceManager.Instance<Patch>(2 * m + 1, 2);
            _patches[(int)Buffer.InteriorTrim2] = ResourceManager.Instance<Patch>(2, 2 * m + 1);
            _patches[(int)Buffer.OuterDegenerated] = ResourceManager.Instance<Patch>(4 * m - 1);

            // bottomleft
            AddPatch(h, h, Buffer.BasePatch);
            AddPatch(-m, h, Buffer.BasePatch);
            AddPatch(h, -m, Buffer.BasePatch);

            // bottomright
            AddPatch(1, h, Buffer.BasePatch);
            AddPatch(m, h, Buffer.BasePatch);
            AddPatch(m, -m, Buffer.BasePatch);

            // topleft
            AddPatch(h, m, Buffer.BasePatch);
            AddPatch(-m, m, Buffer.BasePatch);
            AddPatch(h, 1, Buffer.BasePatch);

            // topright
            AddPatch(1, m, Buffer.BasePatch);
            AddPatch(m, 1, Buffer.BasePatch);
            AddPatch(m, m, Buffer.BasePatch);

            // inner for final level
            AddPatch(0, 0, Buffer.BasePatch); // topright
            AddPatch(1 - m, 0, Buffer.BasePatch); // topleft
            AddPatch(0, 1 - m, Buffer.BasePatch); // bottomright
            AddPatch(1 - m, 1 - m, Buffer.BasePatch); // bottomleft

            // fixup regions
            AddPatch(h, -1, Buffer.RingFixup1); // left
            AddPatch(m, -1, Buffer.RingFixup1); // right
            AddPatch(-1, h, Buffer.RingFixup2); // bottom
            AddPatch(-1, m, Buffer.RingFixup2); // top

            // interior trims
            AddPatch(-m, m - 1, Buffer.InteriorTrim1); // top
            AddPatch(-m, -m, Buffer.InteriorTrim1);    // bottom
            AddPatch(m - 1, -m, Buffer.InteriorTrim2); // right
            AddPatch(-m, -m, Buffer.InteriorTrim2);    // left

            // degenerated outer
            AddPatch(h, h, Buffer.OuterDegenerated);
        }

        public IEnumerable<PatchLocation> Select(PatchSelection selection)
        {
            //return new EnumHelper<PatchLocation>(GetEnumerator(selection));
            var iSelection = (int)selection;
            for (var i = 0; i < 25; i++)
                if ((iSelection & (1 << i)) != 0)
                    yield return _locations[i];

            yield break;
        }

        public void Dispose()
        {
            foreach (var p in _patches)
                p.Dispose();
        }
    }
}
