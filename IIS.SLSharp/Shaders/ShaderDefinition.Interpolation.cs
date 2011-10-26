// ReSharper disable InconsistentNaming

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        // Built-in interpolation functions are available to compute an interpolated value of a fragment shader input
        // variable at a shader-specified (x, y) location. A separate (x, y) location may be used for each invocation of
        // the built-in function, and those locations may differ from the default (x, y) location used to produce the
        // default value of the input.

        #region genType InterpolateAtCentroid(genType interpolant)

        /// <summary> Return the value of the input varying interpolant sampled at a location inside the both the pixel 
        /// and the primitive being processed. The value obtained would be the same value assigned to the input variable
        /// if declared with the centroid qualifier.</summary>
        protected internal static float InterpolateAtCentroid(float interpolant) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant sampled at a location inside the both the pixel 
        /// and the primitive being processed. The value obtained would be the same value assigned to the input variable
        /// if declared with the centroid qualifier.</summary>
        protected internal static vec2 InterpolateAtCentroid(vec2 interpolant) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant sampled at a location inside the both the pixel 
        /// and the primitive being processed. The value obtained would be the same value assigned to the input variable
        /// if declared with the centroid qualifier.</summary>
        protected internal static vec3 InterpolateAtCentroid(vec3 interpolant) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant sampled at a location inside the both the pixel 
        /// and the primitive being processed. The value obtained would be the same value assigned to the input variable
        /// if declared with the centroid qualifier.</summary>
        protected internal static vec4 InterpolateAtCentroid(vec4 interpolant) { throw _invalidAccess; }

        #endregion

        #region genType InterpolateAtSample(genType interpolant, int sample)

        /// <summary> Return the value of the input varying interpolant at the location of sample number sample. 
        /// If multisample buffers are not available, the input varying will be evaluated at the center of the pixel. 
        /// If sample sample does not exist, the position used to interpolate the input varying is undefined.</summary>
        protected internal static float InterpolateAtSample(float interpolant, int sample) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant at the location of sample number sample. 
        /// If multisample buffers are not available, the input varying will be evaluated at the center of the pixel. 
        /// If sample sample does not exist, the position used to interpolate the input varying is undefined.</summary>
        protected internal static vec2 InterpolateAtSample(vec2 interpolant, int sample) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant at the location of sample number sample. 
        /// If multisample buffers are not available, the input varying will be evaluated at the center of the pixel. 
        /// If sample sample does not exist, the position used to interpolate the input varying is undefined.</summary>
        protected internal static vec3 InterpolateAtSample(vec3 interpolant, int sample) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant at the location of sample number sample. 
        /// If multisample buffers are not available, the input varying will be evaluated at the center of the pixel. 
        /// If sample sample does not exist, the position used to interpolate the input varying is undefined.</summary>
        protected internal static vec4 InterpolateAtSample(vec4 interpolant, int sample) { throw _invalidAccess; }

        #endregion

        #region genType InterpolateAtOffset(genType interpolant, vec2 offset)

        /// <summary> Return the value of the input varying interpolant sampled at a fixed offset offset from the 
        /// center of the pixel. The two floating-point components of offset, give the offset in pixels in the x and y 
        /// directions, respectively. An offset of (0, 0) identifies the center of the pixel. 
        /// The range and granularity of offsets supported by this function is implementationdependent.</summary>
        protected internal static float InterpolateAtOffset(float interpolant, vec2 offset) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant sampled at a fixed offset offset from the 
        /// center of the pixel. The two floating-point components of offset, give the offset in pixels in the x and y 
        /// directions, respectively. An offset of (0, 0) identifies the center of the pixel. 
        /// The range and granularity of offsets supported by this function is implementationdependent.</summary>
        protected internal static vec2 InterpolateAtOffset(vec2 interpolant, vec2 offset) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant sampled at a fixed offset offset from the 
        /// center of the pixel. The two floating-point components of offset, give the offset in pixels in the x and y 
        /// directions, respectively. An offset of (0, 0) identifies the center of the pixel. 
        /// The range and granularity of offsets supported by this function is implementationdependent.</summary>
        protected internal static vec3 InterpolateAtOffset(vec3 interpolant, vec2 offset) { throw _invalidAccess; }

        /// <summary> Return the value of the input varying interpolant sampled at a fixed offset offset from the 
        /// center of the pixel. The two floating-point components of offset, give the offset in pixels in the x and y 
        /// directions, respectively. An offset of (0, 0) identifies the center of the pixel. 
        /// The range and granularity of offsets supported by this function is implementationdependent.</summary>
        protected internal static vec4 InterpolateAtOffset(vec4 interpolant, vec2 offset) { throw _invalidAccess; }

        #endregion
    }
}

// ReSharper restore InconsistentNaming
