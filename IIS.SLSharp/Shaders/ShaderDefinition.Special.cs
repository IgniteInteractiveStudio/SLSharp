using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        /// <summary>
        /// Discards the current fragment.
        /// </summary>
        protected internal static void Discard() { throw _invalidAccess; }
    }
}
