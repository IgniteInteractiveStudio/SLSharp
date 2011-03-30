using System;

namespace IIS.SLSharp.Annotations
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class VertexInAttribute : ShaderVariableAttribute
    {
    }
}