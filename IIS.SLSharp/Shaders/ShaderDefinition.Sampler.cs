// ReSharper disable InconsistentNaming

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        public class Sampler
        {
        }

        public class SamplerTmp
        {
        }

        public sealed class sampler1D : Sampler
        {
            public static implicit operator sampler1D(SamplerTmp s) { return null; }
        }

        public sealed class sampler2D : Sampler
        {
            public static implicit operator sampler2D(SamplerTmp s) { return null; }
        }

        public sealed class sampler3D : Sampler
        {
            public static implicit operator sampler3D(SamplerTmp s) { return null; }
        }

        public sealed class samplerCube : Sampler
        {
            public static implicit operator samplerCube(SamplerTmp s) { return null; }
        }

        public sealed class sampler1DShadow : Sampler
        {
            public static implicit operator sampler1DShadow(SamplerTmp s) { return null; }
        }

        public sealed class sampler2DShadow : Sampler
        {
            public static implicit operator sampler2DShadow(SamplerTmp s) { return null; }
        }

        public sealed class samplerCubeShadow : Sampler
        {
            public static implicit operator samplerCubeShadow(SamplerTmp s) { return null; }
        }

        public sealed class isampler1D : Sampler
        {
            public static implicit operator isampler1D(SamplerTmp s) { return null; }
        }

        public sealed class isampler2D : Sampler
        {
            public static implicit operator isampler2D(SamplerTmp s) { return null; }
        }

        public sealed class isampler3D : Sampler
        {
            public static implicit operator isampler3D(SamplerTmp s) { return null; }
        }

        public sealed class isamplerCube : Sampler
        {
            public static implicit operator isamplerCube(SamplerTmp s) { return null; }
        }

        public sealed class usampler1D : Sampler
        {
            public static implicit operator usampler1D(SamplerTmp s) { return null; }
        }

        public sealed class usampler2D : Sampler
        {
            public static implicit operator usampler2D(SamplerTmp s) { return null; }
        }

        public sealed class usampler3D : Sampler
        {
            public static implicit operator usampler3D(SamplerTmp s) { return null; }
        }

        public sealed class usamplerCube : Sampler
        {
            public static implicit operator usamplerCube(SamplerTmp s) { return null; }
        }

        public sealed class sampler2DRect : Sampler
        {
            public static implicit operator sampler2DRect(SamplerTmp s) { return null; }
        }

        public sealed class sampler2DRectShadow : Sampler
        {
            public static implicit operator sampler2DRectShadow(SamplerTmp s) { return null; }
        }

        public sealed class isampler2DRect : Sampler
        {
            public static implicit operator isampler2DRect(SamplerTmp s) { return null; }
        }

        public sealed class usampler2DRect : Sampler
        {
            public static implicit operator usampler2DRect(SamplerTmp s) { return null; }
        }
    }
}

// ReSharper restore InconsistentNaming
