using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IIS.SLSharp.Annotations
{
    class UndefinedBehaviorAttribute: Attribute
    {
        public UndefinedBehaviorAttribute(string condition)
        {
        }
    }
}
