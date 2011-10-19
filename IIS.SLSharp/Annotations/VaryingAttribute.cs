using System;

namespace IIS.SLSharp.Annotations
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class VaryingAttribute : ShaderVariableAttribute
    {
        public VaryingAttribute()
        {
        }

        public VaryingAttribute(UsageSemantic hint)
        {
        }
    }
}
