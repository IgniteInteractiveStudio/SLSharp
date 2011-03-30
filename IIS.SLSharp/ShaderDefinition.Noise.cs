// ReSharper disable InconsistentNaming

namespace IIS.SLSharp
{
    public abstract partial class ShaderDefinition
    {
        // Noise functions are available to fragment, geometry, and vertex shaders. They are stochastic functions that
        // can be used to increase visual complexity. Values returned by the following noise functions give the
        // appearance of randomness, but are not truly random.

        #region float noise1(genType x)

        /// <summary>Returns a 1D noise value based on the input value x.</summary>
        protected static float noise1(float x) { throw _invalidAccess; }

        /// <summary>Returns a 1D noise value based on the input value x.</summary>
        protected static float noise1(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a 1D noise value based on the input value x.</summary>
        protected static float noise1(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a 1D noise value based on the input value x.</summary>
        protected static float noise1(vec4 x) { throw _invalidAccess; }

        #endregion

        #region vec2 noise2(genType x)

        /// <summary>Returns a 2D noise value based on the input value x.</summary>
        protected static vec2 noise2(float x) { throw _invalidAccess; }

        /// <summary>Returns a 2D noise value based on the input value x.</summary>
        protected static vec2 noise2(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a 2D noise value based on the input value x.</summary>
        protected static vec2 noise2(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a 2D noise value based on the input value x.</summary>
        protected static vec2 noise2(vec4 x) { throw _invalidAccess; }

        #endregion

        #region vec3 noise3(genType x)

        /// <summary>Returns a 3D noise value based on the input value x.</summary>
        protected static vec3 noise3(float x) { throw _invalidAccess; }

        /// <summary>Returns a 3D noise value based on the input value x.</summary>
        protected static vec3 noise3(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a 3D noise value based on the input value x.</summary>
        protected static vec3 noise3(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a 3D noise value based on the input value x.</summary>
        protected static vec3 noise3(vec4 x) { throw _invalidAccess; }

        #endregion

        #region vec4 noise4(genType x)

        /// <summary>Returns a 4D noise value based on the input value x.</summary>
        protected static vec4 noise4(float x) { throw _invalidAccess; }

        /// <summary>Returns a 4D noise value based on the input value x.</summary>
        protected static vec4 noise4(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a 4D noise value based on the input value x.</summary>
        protected static vec4 noise4(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a 4D noise value based on the input value x.</summary>
        protected static vec4 noise4(vec4 x) { throw _invalidAccess; }

        #endregion
    }
}

// ReSharper restore InconsistentNaming
