// ReSharper disable InconsistentNaming

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        // Built-in interpolation functions are available to compute an interpolated value of a fragment shader input
        // variable at a shader-specified (x, y) location. A separate (x, y) location may be used for each invocation of
        // the built-in function, and those locations may differ from the default (x, y) location used to produce the
        // default value of the input.

        #region genType interpolateAtCentroid(genType interpolant)

        /// <summary> Return the value of the input varying interpolant sampled at a location inside the both the pixel 
        /// and the primitive being processed. The value obtained would be the same value assigned to the input variable
        /// if declared with the centroid qualifier.</summary>
        protected static float interpolateAtCentroid(float interpolant) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant sampled at a location inside the both the pixel 
        /// and the primitive being processed. The value obtained would be the same value assigned to the input variable
        /// if declared with the centroid qualifier.</summary>
        protected static vec2 interpolateAtCentroid(vec2 interpolant) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant sampled at a location inside the both the pixel 
        /// and the primitive being processed. The value obtained would be the same value assigned to the input variable
        /// if declared with the centroid qualifier.</summary>
        protected static vec3 interpolateAtCentroid(vec3 interpolant) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant sampled at a location inside the both the pixel 
        /// and the primitive being processed. The value obtained would be the same value assigned to the input variable
        /// if declared with the centroid qualifier.</summary>
        protected static vec4 interpolateAtCentroid(vec4 interpolant) { throw _invalidAccess; }

        #endregion

        #region genType interpolateAtSample(genType interpolant, int sample)

        /// <summary> Return the value of the input varying interpolant at the location of sample number sample. 
        /// If multisample buffers are not available, the input varying will be evaluated at the center of the pixel. 
        /// If sample sample does not exist, the position used to interpolate the input varying is undefined.</summary>
        protected static float interpolateAtSample(float interpolant, int sample) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant at the location of sample number sample. 
        /// If multisample buffers are not available, the input varying will be evaluated at the center of the pixel. 
        /// If sample sample does not exist, the position used to interpolate the input varying is undefined.</summary>
        protected static vec2 interpolateAtSample(vec2 interpolant, int sample) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant at the location of sample number sample. 
        /// If multisample buffers are not available, the input varying will be evaluated at the center of the pixel. 
        /// If sample sample does not exist, the position used to interpolate the input varying is undefined.</summary>
        protected static vec3 interpolateAtSample(vec3 interpolant, int sample) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant at the location of sample number sample. 
        /// If multisample buffers are not available, the input varying will be evaluated at the center of the pixel. 
        /// If sample sample does not exist, the position used to interpolate the input varying is undefined.</summary>
        protected static vec4 interpolateAtSample(vec4 interpolant, int sample) { throw _invalidAccess; }

        #endregion

        #region genType interpolateAtOffset(genType interpolant, vec2 offset)

        /// <summary> Return the value of the input varying interpolant sampled at a fixed offset offset from the 
        /// center of the pixel. The two floating-point components of offset, give the offset in pixels in the x and y 
        /// directions, respectively. An offset of (0, 0) identifies the center of the pixel. 
        /// The range and granularity of offsets supported by this function is implementationdependent.</summary>
        protected static float interpolateAtOffset(float interpolant, vec2 offset) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant sampled at a fixed offset offset from the 
        /// center of the pixel. The two floating-point components of offset, give the offset in pixels in the x and y 
        /// directions, respectively. An offset of (0, 0) identifies the center of the pixel. 
        /// The range and granularity of offsets supported by this function is implementationdependent.</summary>
        protected static vec2 interpolateAtOffset(vec2 interpolant, vec2 offset) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant sampled at a fixed offset offset from the 
        /// center of the pixel. The two floating-point components of offset, give the offset in pixels in the x and y 
        /// directions, respectively. An offset of (0, 0) identifies the center of the pixel. 
        /// The range and granularity of offsets supported by this function is implementationdependent.</summary>
        protected static vec3 interpolateAtOffset(vec3 interpolant, vec2 offset) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant sampled at a fixed offset offset from the 
        /// center of the pixel. The two floating-point components of offset, give the offset in pixels in the x and y 
        /// directions, respectively. An offset of (0, 0) identifies the center of the pixel. 
        /// The range and granularity of offsets supported by this function is implementationdependent.</summary>
        protected static vec4 interpolateAtOffset(vec4 interpolant, vec2 offset) { throw _invalidAccess; }

        #endregion
    }
}

// ReSharper restore InconsistentNaming
