using System;

// ReSharper disable InconsistentNaming

namespace IIS.SLSharp
{
    public abstract partial class ShaderDefinition
    {
        [Obsolete("Deprecated with v130", true)]
        protected static vec4 texture1D(Sampler1D sampler, float s)
        {
            throw _invalidAccess;
        }

        [Obsolete("Deprecated with v130", true)]
        protected static vec4 texture2D(Sampler2D sampler, vec2 st)
        {
            throw _invalidAccess;
        }

        [Obsolete("Deprecated with v130", true)]
        protected static vec4 texture2D(Sampler2D sampler, vec2 st, float bias)
        {
            throw _invalidAccess;
        }

        protected static vec4 texture(Sampler1D sampler, float s)
        {
            throw _invalidAccess;
        }

        protected static vec4 texture(Sampler1D sampler, float s, float bias)
        {
            throw _invalidAccess;
        }

        protected static vec4 texture(Sampler2D sampler, vec2 st)
        {
            throw _invalidAccess;
        }

        protected static vec4 texture(Sampler2D sampler, vec2 st, float bias)
        {
            throw _invalidAccess;
        }

        protected static vec4 textureGrad(Sampler2D sampler, float P, float dPdx, float dPdy)
        { throw _invalidAccess; }

        protected static vec4 textureGrad(Sampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        { throw _invalidAccess; }

        protected static vec4 textureGrad(Sampler2D sampler, vec3 P, vec3 dPdx, vec3 dPdy)
        { throw _invalidAccess; }
    }
}

// ReSharper restore InconsistentNaming
