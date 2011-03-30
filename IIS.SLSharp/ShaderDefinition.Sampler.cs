// ReSharper disable InconsistentNaming

namespace IIS.SLSharp
{
    public abstract partial class ShaderDefinition
    {
        public class Sampler
        {
            public static int value;
        }

        public sealed class Sampler1D : Sampler
        {
            public static implicit operator Sampler1D(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class Sampler2D : Sampler
        {
            public static implicit operator Sampler2D(int i)
            {
                value = i;
                return null;
            }
        }
    }
}

// ReSharper restore InconsistentNaming
