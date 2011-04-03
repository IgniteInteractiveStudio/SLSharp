using System;

namespace IIS.SLSharp.Annotations
{
    /// <summary>
    /// Attribute to flag Fragment-shader routines
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class FragmentShaderAttribute : Attribute, IShaderAttribute
    {
        public bool EntryPoint { get; private set; }

        /// <summary>
        /// Flags a method to be compiled as fragment routine.
        /// </summary>
        /// <param name="entryPoint">Set to true for the function that serves as fragment entrypoint (main)</param>
        public FragmentShaderAttribute(bool entryPoint = false)
        {
            EntryPoint = entryPoint;
        }
    }
}
