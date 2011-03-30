using System;

namespace IIS.SLSharp.Annotations
{
    /// <summary>
    /// Attribute to flag Uniform shader variables.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class UniformAttribute : ShaderVariableAttribute
    {
        public string ExplicitName { get; private set; }

        public UniformAttribute()
        {
        }

        public UniformAttribute(string explicitName)
        {
            ExplicitName = explicitName;
        }
    }
}
