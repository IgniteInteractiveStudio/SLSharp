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

        [Obsolete("Deprecated with v130", true)]
        protected vec4 gl_Vertex;

        [Obsolete("Deprecated with v130", true)]
        protected vec4 gl_FragColor;

        [Obsolete("Deprecated with v130", true)]
        protected mat4 gl_ModelViewProjectionMatrix;

        [Obsolete("Deprecated with v130", true)]
        protected mat3 gl_NormalMatrix;

        [Obsolete("Deprecated with v130", true)]
        protected vec4[] gl_TexCoord;

        [Obsolete("Deprecated with v130", true)]
        protected vec4 gl_Color;

        // ReSharper restore InconsistentNaming
        // ReSharper restore UnusedParameter.Local
    }
}
