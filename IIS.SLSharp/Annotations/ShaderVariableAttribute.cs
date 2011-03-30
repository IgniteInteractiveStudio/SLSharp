using System;

namespace IIS.SLSharp.Annotations
{
    /// <summary>
    /// Attribute to flag Varying shader variables.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public abstract class ShaderVariableAttribute : Attribute
    {
    }
}
