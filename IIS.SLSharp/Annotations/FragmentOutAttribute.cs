using System;

namespace IIS.SLSharp.Annotations
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class FragmentOutAttribute : ShaderVariableAttribute
    {
        public FragmentOutAttribute(UsageSemantic hint)
        {}
    }
}