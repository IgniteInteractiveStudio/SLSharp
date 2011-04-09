using System;
using System.Runtime.Serialization;

namespace IIS.SLSharp
{
    /// <summary>
    /// Exception thrown by the SL# library when an error occurs.
    /// </summary>
    [Serializable]
    public class SLSharpException : Exception
    {
        public SLSharpException()
        {
        }

        public SLSharpException(string message)
            : base(message)
        {
        }

        public SLSharpException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected SLSharpException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
