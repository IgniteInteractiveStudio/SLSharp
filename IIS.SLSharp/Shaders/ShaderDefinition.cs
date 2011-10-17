using System;

namespace IIS.SLSharp.Shaders
{
    /// <summary>
    /// Contains definitions to allow GLSL syntax within Shaders
    /// </summary>
    public abstract partial class ShaderDefinition
    {
        private static readonly Exception _invalidAccess = new InvalidOperationException("Invalid usage");

        // ReSharper disable InconsistentNaming
        // ReSharper disable UnusedParameter.Local

        protected vec4 gl_Position;

        // ReSharper restore InconsistentNaming
        // ReSharper restore UnusedParameter.Local
    }
}
