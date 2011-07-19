// ReSharper disable InconsistentNaming

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        // These all operate component-wise. The description is per component.

        // TODO:
        // HLSL supports matrix types for any of the builtins

        // NOTE: ldexp and frexp belong to common function group

        #region GLSL derived

        #region genType Pow(genType x, genType y)

        /// <summary>Raises x to the power of y.</summary>
        /// <param name="x">Base, results are undefined for x &lt; 0 or (x == 0 and y &lt;= 0)</param>
        /// <param name="y">Exponent</param>
        /// <returns>x raised to the y power, i.e., x^y. </returns>
        protected internal static float Pow(float x, float y) { throw _invalidAccess; }

        /// <summary>Raises x to the power of y.</summary>
        /// <param name="x">Base, results are undefined for x &lt; 0 or (x == 0 and y &lt;= 0)</param>
        /// <param name="y">Exponent</param>
        /// <returns>x raised to the y power, i.e., x^y. </returns>
        protected internal static vec2 Pow(vec2 x, vec2 y) { throw _invalidAccess; }

        /// <summary>Raises x to the power of y.</summary>
        /// <param name="x">Base, results are undefined for x &lt; 0 or (x == 0 and y &lt;= 0)</param>
        /// <param name="y">Exponent</param>
        /// <returns>x raised to the y power, i.e., x^y. </returns>
        protected internal static vec3 Pow(vec3 x, vec3 y) { throw _invalidAccess; }

        /// <summary>Raises x to the power of y.</summary>
        /// <param name="x">Base, results are undefined for x &lt; 0 or (x == 0 and y &lt;= 0)</param>
        /// <param name="y">Exponent</param>
        /// <returns>x raised to the y power, i.e., x^y. </returns>
        protected internal static vec4 Pow(vec4 x, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genType Exp(genType x)

        /// <summary>Returns the natural exponentiation of x, i.e., e^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns the natural exponentiation of x, i.e., e^x. </returns>
        protected internal static float Exp(float x) { throw _invalidAccess; }

        /// <summary>Returns the natural exponentiation of x, i.e., e^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns the natural exponentiation of x, i.e., e^x. </returns>
        protected internal static vec2 Exp(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns the natural exponentiation of x, i.e., e^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns the natural exponentiation of x, i.e., e^x. </returns>
        protected internal static vec3 Exp(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns the natural exponentiation of x, i.e., e^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns the natural exponentiation of x, i.e., e^x. </returns>
        protected internal static vec4 Exp(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Log(genType x)

        /// <summary>Returns the natural logarithm of x, i.e.,  returns the value 
        /// y which satisfies the equation x = e**y.</summary>
        /// <returns>Returns the natural logarithm of x. </returns>
        protected internal static float Log(float x) { throw _invalidAccess; }

        /// <summary>Returns the natural logarithm of x, i.e.,  returns the value 
        /// y which satisfies the equation x = e**y.</summary>
        /// <returns>Returns the natural logarithm of x. </returns>
        protected internal static vec2 Log(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns the natural logarithm of x, i.e.,  returns the value 
        /// y which satisfies the equation x = e**y.</summary>
        /// <returns>Returns the natural logarithm of x. </returns>
        protected internal static vec3 Log(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns the natural logarithm of x, i.e.,  returns the value 
        /// y which satisfies the equation x = e**y.</summary>
        /// <returns>Returns the natural logarithm of x. </returns>
        protected internal static vec4 Log(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Exp2(genType x)

        /// <summary>Returns 2 raised to the power of x, i.e., 2^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns 2^x. </returns>
        protected internal static float Exp2(float x) { throw _invalidAccess; }

        /// <summary>Returns 2 raised to the power of x, i.e., 2^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns 2^x. </returns>
        protected internal static vec2 Exp2(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns 2 raised to the power of x, i.e., 2^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns 2^x. </returns>
        protected internal static vec3 Exp2(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns 2 raised to the power of x, i.e., 2^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns 2^x. </returns>
        protected internal static vec4 Exp2(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Log2(genType x)

        /// <summary>Returns the base 2 logarithm of x, i.e., returns the value
        /// y which satisfies the equation x=2**y</summary>
        protected internal static float Log2(float x) { throw _invalidAccess; }

        /// <summary>Returns the base 2 logarithm of x, i.e., returns the value
        /// y which satisfies the equation x=2**y</summary>
        protected internal static vec2 Log2(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns the base 2 logarithm of x, i.e., returns the value
        /// y which satisfies the equation x=2**y</summary>
        protected internal static vec3 Log2(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns the base 2 logarithm of x, i.e., returns the value
        /// y which satisfies the equation x=2**y</summary>
        protected internal static vec4 Log2(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Sqrt(genType x)

        /// <summary>Returns the square root of x</summary>
        protected internal static float Sqrt(float x) { throw _invalidAccess; }

        /// <summary>Returns the square root of x</summary>
        protected internal static vec2 Sqrt(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns the square root of x</summary>
        protected internal static vec3 Sqrt(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns the square root of x</summary>
        protected internal static vec4 Sqrt(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType Sqrt(genDType x)

        /// <summary>Returns the square root of x</summary>
        protected internal static double Sqrt(double x) { throw _invalidAccess; }

        /// <summary>Returns the square root of x</summary>
        protected internal static dvec2 Sqrt(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns the square root of x</summary>
        protected internal static dvec3 Sqrt(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns the square root of x</summary>
        protected internal static dvec4 Sqrt(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType InverseSqrt(genType x)

        /// <summary>Returns the reciprocal square root of x, i.e: 1/Sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected internal static float InverseSqrt(float x) { throw _invalidAccess; }

        /// <summary>Returns the reciprocal square root of x, i.e: 1/Sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected internal static vec2 InverseSqrt(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns the reciprocal square root of x, i.e: 1/Sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected internal static vec3 InverseSqrt(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns the reciprocal square root of x, i.e: 1/Sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected internal static vec4 InverseSqrt(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType InverseSqrt(genDType x)

        /// <summary>Returns the reciprocal square root of x, i.e: 1/Sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected internal static double InverseSqrt(double x) { throw _invalidAccess; }

        /// <summary>Returns the reciprocal square root of x, i.e: 1/Sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected internal static dvec2 InverseSqrt(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns the reciprocal square root of x, i.e: 1/Sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected internal static dvec3 InverseSqrt(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns the reciprocal square root of x, i.e: 1/Sqrt(x)
        /// Results are undefined if x &lt;= 0 </summary>
        protected internal static dvec4 InverseSqrt(dvec4 x) { throw _invalidAccess; }

        #endregion

        #endregion

        #region HLSL derived

        #region genType Log10(genType x)

        /// <summary>Returns the base 10 logarithm of x, i.e., returns the value
        /// y which satisfies the equation x=10**y</summary>
        protected internal static float Log10(float x) { throw _invalidAccess; }

        /// <summary>Returns the base 10 logarithm of x, i.e., returns the value
        /// y which satisfies the equation x=10**y</summary>
        protected internal static vec2 Log10(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns the base 10 logarithm of x, i.e., returns the value
        /// y which satisfies the equation x=10**y</summary>
        protected internal static vec3 Log10(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns the base 10 logarithm of x, i.e., returns the value
        /// y which satisfies the equation x=10**y</summary>
        protected internal static vec4 Log10(vec4 x) { throw _invalidAccess; }

        #endregion

        #endregion

        #region Additional functionality

        #region genType Exp10(genType x)

        /// <summary>Returns 10 raised to the power of x, i.e., 10^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns 10^x. </returns>
        protected internal static float Exp10(float x) { throw _invalidAccess; }

        /// <summary>Returns 10 raised to the power of x, i.e., 10^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns 10^x. </returns>
        protected internal static vec2 Exp10(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns 10 raised to the power of x, i.e., 10^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns 10^x. </returns>
        protected internal static vec3 Exp10(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns 10 raised to the power of x, i.e., 10^x.</summary>
        /// <param name="x">The exponent</param>
        /// <returns>Returns 10^x. </returns>
        protected internal static vec4 Exp10(vec4 x) { throw _invalidAccess; }

        #endregion

        #endregion
    }
}

// ReSharper restore InconsistentNaming
