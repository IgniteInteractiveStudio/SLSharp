using System;

namespace IIS.SLSharp.Annotations
{
    /// <summary>
    /// Attribute to flag Vertex-shader routines
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class VertexShaderAttribute : Attribute, IShaderAttribute
    {
        public bool EntryPoint { get; private set; }

        /// <summary>
        /// Flags a method to be compiled as vertex routine.
        /// </summary>
        /// <param name="entryPoint">Set to true for the function that serves as vertex entrypoint (main)</param>
        public VertexShaderAttribute(bool entryPoint = false)
        {
            EntryPoint = entryPoint;
        }
    }
}
