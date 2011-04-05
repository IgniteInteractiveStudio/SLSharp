// ReSharper disable InconsistentNaming

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        // These all operate component-wise. The description is per component.

        #region genType pow(genType x, genType y)

        /// <summary>Raises x to the power of y.</summary>
        /// <param name="x">Base, results are undefined for x &lt; 0 or (x == 0 and y &lt;= 0)</param>
        /// <param name="y">Exponent</param>
        /// <returns>x raised to the y power, i.e., x^y. </returns>
        protected static float pow(float x, float y) { throw _invalidAccess; }

        /// <summary>Raises x to the power of y.</summary>
        /// <param name="x">Base, results are undefined for x &lt; 0 or (x == 0 and y &lt;= 0)</param>
        /// <param name="y">Exponent</param>
        /// <returns>x raised to the y power, i.e., x^y. </returns>
        protected static vec2 pow(vec2 x, vec2 y) { throw _invalidAccess; }

        /// <summary>Raises x to the power of y.</summary>
        /// <param name="x">Base, results are undefined for x &lt; 0 or (x == 0 and y &lt;= 0)</param>
        /// <param name="y">Exponent</param>
        /// <returns>x raised to the y power, i.e., x^y. </returns>
        protected static vec3 pow(vec3 x, vec3 y) { throw _invalidAccess; }

        /// <summary>Raises x to the power of y.</summary>
        /// <param name="x">Base, results are undefined for x &lt; 0 or (x == 0 and y &lt;= 0)</param>
        /// <param name="y">Exponent</param>
        /// <returns>x raised to the y power, i.e., x^y. </returns>
        protected static vec4 pow(vec4 x, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genType exp(genType x)

        /// <summary>Returns the natural exponentiation of x, i.e., e^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns the natural exponentiation of x, i.e., e^x. </returns>
        protected static float exp(float x) { throw _invalidAccess; }

        /// <summary>Returns the natural exponentiation of x, i.e., e^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns the natural exponentiation of x, i.e., e^x. </returns>
        protected static vec2 exp(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns the natural exponentiation of x, i.e., e^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns the natural exponentiation of x, i.e., e^x. </returns>
        protected static vec3 exp(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns the natural exponentiation of x, i.e., e^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns the natural exponentiation of x, i.e., e^x. </returns>
        protected static vec4 exp(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType log(genType x)

        /// <summary>Returns the natural logarithm of x, i.e.,  returns the value 
        /// y which satisfies the equation x = ey.</summary>
        /// <returns>Returns the natural logarithm of x. </returns>
        protected static float log(float x) { throw _invalidAccess; }

        /// <summary>Returns the natural logarithm of x, i.e.,  returns the value 
        /// y which satisfies the equation x = ey.</summary>
        /// <returns>Returns the natural logarithm of x. </returns>
        protected static vec2 log(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns the natural logarithm of x, i.e.,  returns the value 
        /// y which satisfies the equation x = ey.</summary>
        /// <returns>Returns the natural logarithm of x. </returns>
        protected static vec3 log(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns the natural logarithm of x, i.e.,  returns the value 
        /// y which satisfies the equation x = ey.</summary>
        /// <returns>Returns the natural logarithm of x. </returns>
        protected static vec4 log(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType exp2(genType x)

        /// <summary>Returns 2 raised to the power of x, i.e., 2^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns 2^x. </returns>
        protected static float exp2(float x) { throw _invalidAccess; }

        /// <summary>Returns 2 raised to the power of x, i.e., 2^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns 2^x. </returns>
        protected static vec2 exp2(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns 2 raised to the power of x, i.e., 2^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns 2^x. </returns>
        protected static vec3 exp2(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns 2 raised to the power of x, i.e., 2^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns 2^x. </returns>
        protected static vec4 exp2(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType log2(genType x)

        /// <summary>Returns the base 2 logarithm of x, i.e., returns the value
        /// y which satisfies the equation x=2y</summary>
        protected static float log2(float x) { throw _invalidAccess; }

        /// <summary>Returns the base 2 logarithm of x, i.e., returns the value
        /// y which satisfies the equation x=2y</summary>
        protected static vec2 log2(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns the base 2 logarithm of x, i.e., returns the value
        /// y which satisfies the equation x=2y</summary>
        protected static vec3 log2(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns the base 2 logarithm of x, i.e., returns the value
        /// y which satisfies the equation x=2y</summary>
        protected static vec4 log2(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType sqrt(genType x)

        /// <summary>Returns the square root of x</summary>
        protected static float sqrt(float x) { throw _invalidAccess; }

        /// <summary>Returns the square root of x</summary>
        protected static vec2 sqrt(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns the square root of x</summary>
        protected static vec3 sqrt(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns the square root of x</summary>
        protected static vec4 sqrt(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType sqrt(genDType x)

        /// <summary>Returns the square root of x</summary>
        protected static double sqrt(double x) { throw _invalidAccess; }

        /// <summary>Returns the square root of x</summary>
        protected static dvec2 sqrt(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns the square root of x</summary>
        protected static dvec3 sqrt(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns the square root of x</summary>
        protected static dvec4 sqrt(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType inversesqrt(genType x)

        /// <summary>Returns the reciprocal square root of x, i.e: 1/sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected static float inversesqrt(float x) { throw _invalidAccess; }

        /// <summary>Returns the reciprocal square root of x, i.e: 1/sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected static vec2 inversesqrt(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns the reciprocal square root of x, i.e: 1/sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected static vec3 inversesqrt(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns the reciprocal square root of x, i.e: 1/sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected static vec4 inversesqrt(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType inversesqrt(genDType x)

        /// <summary>Returns the reciprocal square root of x, i.e: 1/sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected static double inversesqrt(double x) { throw _invalidAccess; }

        /// <summary>Returns the reciprocal square root of x, i.e: 1/sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected static dvec2 inversesqrt(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns the reciprocal square root of x, i.e: 1/sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected static dvec3 inversesqrt(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns the reciprocal square root of x, i.e: 1/sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected static dvec4 inversesqrt(dvec4 x) { throw _invalidAccess; }

        #endregion
    }
}

// ReSharper restore InconsistentNaming
