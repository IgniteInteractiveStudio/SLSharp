using OpenTK;

// ReSharper disable InconsistentNaming

namespace IIS.SLSharp
{
    public abstract partial class ShaderDefinition
    {
        public sealed class mat4
        {
            public static Matrix4 value;

            public static implicit operator mat4(Matrix4 v)
            { value = v; return null; }
        }

        public sealed class mat3
        {
        }
    }
}

// ReSharper restore InconsistentNaming
