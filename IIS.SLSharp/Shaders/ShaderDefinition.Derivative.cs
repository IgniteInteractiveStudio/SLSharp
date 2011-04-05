// ReSharper disable InconsistentNaming

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        // Derivatives may be computationally expensive and/or numerically unstable. Therefore, an OpenGL
        // implementation may approximate the true derivatives by using a fast but not entirely accurate derivative
        // computation. Derivatives are undefined within non-uniform control flow.

        #region genType dFdx(genType p)

        /// <summary>Returns the derivative in x using local differencing for the input argument p.</summary>
        protected static float dFdx(float p) { throw _invalidAccess; }

        /// <summary>Returns the derivative in x using local differencing for the input argument p.</summary>
        protected static vec2 dFdx(vec2 p) { throw _invalidAccess; }

        /// <summary>Returns the derivative in x using local differencing for the input argument p.</summary>
        protected static vec3 dFdx(vec3 p) { throw _invalidAccess; }

        /// <summary>Returns the derivative in x using local differencing for the input argument p.</summary>
        protected static vec4 dFdx(vec4 p) { throw _invalidAccess; }

        #endregion

        #region genType dFdy(genType p)

        /// <summary>Returns the derivative in y using local differencing for the input argument p.</summary>
        protected static float dFdy(float p) { throw _invalidAccess; }

        /// <summary>Returns the derivative in y using local differencing for the input argument p.</summary>
        protected static vec2 dFdy(vec2 p) { throw _invalidAccess; }

        /// <summary>Returns the derivative in y using local differencing for the input argument p.</summary>
        protected static vec3 dFdy(vec3 p) { throw _invalidAccess; }

        /// <summary>Returns the derivative in y using local differencing for the input argument p.</summary>
        protected static vec4 dFdy(vec4 p) { throw _invalidAccess; }

        #endregion

        #region genType fwidth(genType p)

        /// <summary>Returns the sum of the absolute derivative in x and y using local 
        /// differencing for the input argument p, i.e., abs (dFdx (p)) + abs (dFdy (p));</summary>
        protected static float fwidth(float p) { throw _invalidAccess; }

        /// <summary>Returns the sum of the absolute derivative in x and y using local 
        /// differencing for the input argument p, i.e., abs (dFdx (p)) + abs (dFdy (p));</summary>
        protected static vec2 fwidth(vec2 p) { throw _invalidAccess; }

        /// <summary>Returns the sum of the absolute derivative in x and y using local 
        /// differencing for the input argument p, i.e., abs (dFdx (p)) + abs (dFdy (p));</summary>
        protected static vec3 fwidth(vec3 p) { throw _invalidAccess; }

        /// <summary>Returns the sum of the absolute derivative in x and y using local 
        /// differencing for the input argument p, i.e., abs (dFdx (p)) + abs (dFdy (p));</summary>
        protected static vec4 fwidth(vec4 p) { throw _invalidAccess; }

        #endregion
    }
}

// ReSharper restore InconsistentNaming
