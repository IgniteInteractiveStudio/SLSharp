using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IIS.SLSharp.Annotations
{
    internal class WarningAttribute: Attribute
    {
        public WarningAttribute(string warning)
        {
        }
    }
}
