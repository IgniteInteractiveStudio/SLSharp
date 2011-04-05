// ReSharper disable InconsistentNaming

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        public class Sampler
        {
            public static int value;
        }

        public sealed class sampler1D : Sampler
        {
            public static implicit operator sampler1D(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class sampler2D : Sampler
        {
            public static implicit operator sampler2D(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class sampler3D : Sampler
        {
            public static implicit operator sampler3D(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class samplerCube : Sampler
        {
            public static implicit operator samplerCube(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class sampler1DShadow : Sampler
        {
            public static implicit operator sampler1DShadow(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class sampler2DShadow : Sampler
        {
            public static implicit operator sampler2DShadow(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class samplerCubeShadow : Sampler
        {
            public static implicit operator samplerCubeShadow(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class isampler1D : Sampler
        {
            public static implicit operator isampler1D(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class isampler2D : Sampler
        {
            public static implicit operator isampler2D(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class isampler3D : Sampler
        {
            public static implicit operator isampler3D(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class isamplerCube : Sampler
        {
            public static implicit operator isamplerCube(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class usampler1D : Sampler
        {
            public static implicit operator usampler1D(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class usampler2D : Sampler
        {
            public static implicit operator usampler2D(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class usampler3D : Sampler
        {
            public static implicit operator usampler3D(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class usamplerCube : Sampler
        {
            public static implicit operator usamplerCube(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class sampler2DRect : Sampler
        {
            public static implicit operator sampler2DRect(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class sampler2DRectShadow : Sampler
        {
            public static implicit operator sampler2DRectShadow(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class isampler2DRect : Sampler
        {
            public static implicit operator isampler2DRect(int i)
            {
                value = i;
                return null;
            }
        }

        public sealed class usampler2DRect : Sampler
        {
            public static implicit operator usampler2DRect(int i)
            {
                value = i;
                return null;
            }
        }
    }
}

// ReSharper restore InconsistentNaming
