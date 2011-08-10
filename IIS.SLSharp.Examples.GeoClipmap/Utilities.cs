using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IIS.SLSharp.Examples.GeoClipmap
{
    public static class Utilities
    {
        public static float Fract(float f)
        {
            var fout = (float)Math.Floor(f);
            return f - fout;
        }
    }
}
