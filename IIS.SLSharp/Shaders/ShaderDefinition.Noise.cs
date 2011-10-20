// ReSharper disable InconsistentNaming

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        // Noise functions are available to fragment, geometry, and vertex shaders. They are stochastic functions that
        // can be used to increase visual complexity. Values returned by the following noise functions give the
        // appearance of randomness, but are not truly random.

        #region float Noise1(genType x)

        /// <summary>Returns a 1D noise value based on the input value x.</summary>
        protected internal static float Noise1(float x) { throw _invalidAccess; }

        /// <summary>Returns a 1D noise value based on the input value x.</summary>
        protected internal static float Noise1(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a 1D noise value based on the input value x.</summary>
        protected internal static float Noise1(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a 1D noise value based on the input value x.</summary>
        protected internal static float Noise1(vec4 x) { throw _invalidAccess; }

        #endregion

        #region vec2 Noise2(genType x)

        /// <summary>Returns a 2D noise value based on the input value x.</summary>
        protected internal static vec2 Noise2(float x) { throw _invalidAccess; }

        /// <summary>Returns a 2D noise value based on the input value x.</summary>
        protected internal static vec2 Noise2(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a 2D noise value based on the input value x.</summary>
        protected internal static vec2 Noise2(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a 2D noise value based on the input value x.</summary>
        protected internal static vec2 Noise2(vec4 x) { throw _invalidAccess; }

        #endregion

        #region vec3 Noise3(genType x)

        /// <summary>Returns a 3D noise value based on the input value x.</summary>
        protected internal static vec3 Noise3(float x) { throw _invalidAccess; }

        /// <summary>Returns a 3D noise value based on the input value x.</summary>
        protected internal static vec3 Noise3(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a 3D noise value based on the input value x.</summary>
        protected internal static vec3 Noise3(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a 3D noise value based on the input value x.</summary>
        protected internal static vec3 Noise3(vec4 x) { throw _invalidAccess; }

        #endregion

        #region vec4 Noise4(genType x)

        /// <summary>Returns a 4D noise value based on the input value x.</summary>
        protected internal static vec4 Noise4(float x) { throw _invalidAccess; }

        /// <summary>Returns a 4D noise value based on the input value x.</summary>
        protected internal static vec4 Noise4(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a 4D noise value based on the input value x.</summary>
        protected internal static vec4 Noise4(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a 4D noise value based on the input value x.</summary>
        protected internal static vec4 Noise4(vec4 x) { throw _invalidAccess; }

        #endregion
    }
}

// ReSharper restore InconsistentNaming
