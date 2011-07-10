using IIS.SLSharp.Annotations;

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        // Function parameters specified as angle are assumed to be in units of radians. In no case will any of these
        // functions result in a divide by zero error. If the divisor of a ratio is 0, then results will be undefined.
        // These all operate component-wise. The description is per component.

        // TODO:
        // HLSL supports matrix types for any of the builtins

        #region GLSL derived

        #region genType Radians(genType degrees)

        /// <summary>Converts degrees to radians, i.e., PI/180 * degrees</summary>
        protected internal static float Radians(float dagrees) { throw _invalidAccess; }

        /// <summary>Converts degrees to radians, i.e., PI/180 * degrees</summary>
        protected internal static vec2 Radians(vec2 dagrees) { throw _invalidAccess; }

        /// <summary>Converts degrees to radians, i.e., PI/180 * degrees</summary>
        protected internal static vec3 Radians(vec3 dagrees) { throw _invalidAccess; }

        /// <summary>Converts degrees to radians, i.e., PI/180 * degrees</summary>
        protected internal static vec4 Radians(vec4 dagrees) { throw _invalidAccess; }

        #endregion

        #region genType Degrees(genType radians)

        /// <summary>Converts radians to degrees, i.e., 180/PI*radians</summary>
        protected internal static float Degrees(float radians) { throw _invalidAccess; }

        /// <summary>Converts radians to degrees, i.e., 180/PI*radians</summary>
        protected internal static vec2 Degrees(vec2 radians) { throw _invalidAccess; }

        /// <summary>Converts radians to degrees, i.e., 180/PI*radians</summary>
        protected internal static vec3 Degrees(vec3 radians) { throw _invalidAccess; }

        /// <summary>Converts radians to degrees, i.e., 180/PI*radians</summary>
        protected internal static vec4 Degrees(vec4 radians) { throw _invalidAccess; }

        #endregion

        #region genType Sin(genType angle)

        /// <summary>The standard trigonometric sine function.</summary>
        protected internal static float Sin(float angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric sine function.</summary>
        protected internal static vec2 Sin(vec2 angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric sine function.</summary>
        protected internal static vec3 Sin(vec3 angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric sine function.</summary>
        protected internal static vec4 Sin(vec4 angle) { throw _invalidAccess; }

        #endregion

        #region genType Cos(genType angle)

        /// <summary>The standard trigonometric cosine function.</summary>
        protected internal static float Cos(float angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric cosine function.</summary>
        protected internal static vec2 Cos(vec2 angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric cosine function.</summary>
        protected internal static vec3 Cos(vec3 angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric cosine function.</summary>
        protected internal static vec4 Cos(vec4 angle) { throw _invalidAccess; }

        #endregion

        #region genType Tan(genType angle)

        /// <summary>The standard trigonometric tangent.</summary>
        protected internal static float Tan(float angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric tangent.</summary>
        protected internal static vec2 Tan(vec2 angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric tangent.</summary>
        protected internal static vec3 Tan(vec3 angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric tangent.</summary>
        protected internal static vec4 Tan(vec4 angle) { throw _invalidAccess; }

        #endregion

        #region genType Asin(genType x)

        /// <summary>
        /// Arc sine. Returns an angle whose sine is x. The range of values returned by 
        /// this function is [-PI/2, PI/2]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose sine is x.</returns>
        protected internal static float Asin(float x) { throw _invalidAccess; }

        /// <summary>
        /// Arc sine. Returns an angle whose sine is x. The range of values returned by 
        /// this function is [-PI/2, PI/2]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose sine is x.</returns>
        protected internal static vec2 Asin(vec2 x) { throw _invalidAccess; }

        /// <summary>
        /// Arc sine. Returns an angle whose sine is x. The range of values returned by 
        /// this function is [-PI/2, PI/2]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose sine is x.</returns>
        protected internal static vec3 Asin(vec3 x) { throw _invalidAccess; }

        /// <summary>
        /// Arc sine. Returns an angle whose sine is x. The range of values returned by 
        /// this function is [-PI/2, PI/2]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose sine is x.</returns>
        protected internal static vec4 Asin(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Acos(genType x)

        /// <summary>
        /// Arc cosine. Returns an angle whose cosine is x. The range of values returned by 
        /// this function is [0, PI]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose cosine is x.</returns>
        protected internal static float Acos(float x) { throw _invalidAccess; }

        /// <summary>
        /// Arc cosine. Returns an angle whose cosine is x. The range of values returned by 
        /// this function is [0, PI]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose cosine is x.</returns>
        protected internal static vec2 Acos(vec2 x) { throw _invalidAccess; }

        /// <summary>
        /// Arc cosine. Returns an angle whose cosine is x. The range of values returned by 
        /// this function is [0, PI]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose cosine is x.</returns>
        protected internal static vec3 Acos(vec3 x) { throw _invalidAccess; }

        /// <summary>
        /// Arc cosine. Returns an angle whose cosine is x. The range of values returned by 
        /// this function is [0, PI]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose cosine is x.</returns>
        protected internal static vec4 Acos(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Atan2(genType y, genType x)

        /// <summary>
        /// Arc cosine. Returns an angle whose tangent is y/x. 
        /// The signs of x and y are used to determine what quadrant the angle is in.
        /// The range of values returned by this function is [-PI, PI]
        /// The value to solve for, Result is undefined if x an y are both 0
        /// </summary>
        /// <returns>The angle whose tangent is y/x.</returns>
        protected internal static float Atan2(float y, float x) { throw _invalidAccess; }

        /// <summary>
        /// Arc cosine. Returns an angle whose tangent is y/x. 
        /// The signs of x and y are used to determine what quadrant the angle is in.
        /// The range of values returned by this function is [-PI, PI]
        /// The value to solve for, Result is undefined if x an y are both 0
        /// </summary>
        /// <returns>The angle whose tangent is y/x.</returns>
        protected internal static vec2 Atan2(vec2 y, vec2 x) { throw _invalidAccess; }

        /// <summary>
        /// Arc cosine. Returns an angle whose tangent is y/x. 
        /// The signs of x and y are used to determine what quadrant the angle is in.
        /// The range of values returned by this function is [-PI, PI]
        /// The value to solve for, Result is undefined if x an y are both 0
        /// </summary>
        /// <returns>The angle whose tangent is y/x.</returns>
        protected internal static vec3 Atan2(vec3 y, vec3 x) { throw _invalidAccess; }

        /// <summary>
        /// Arc cosine. Returns an angle whose tangent is y/x. 
        /// The signs of x and y are used to determine what quadrant the angle is in.
        /// The range of values returned by this function is [-PI, PI]
        /// The value to solve for, Result is undefined if x an y are both 0
        /// </summary>
        /// <returns>The angle whose tangent is y/x.</returns>
        protected internal static vec4 Atan2(vec4 y, vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Atan(genType y_over_x)

        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is y_over_x. 
        /// The range of values returned by this function is [-PI/2, PI/2]
        /// </summary>
        /// <returns>The angle whose tangent is y_over_x.</returns>
        protected internal static float Atan(float yOverX) { throw _invalidAccess; }

        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is y_over_x. 
        /// The range of values returned by this function is [-PI/2, PI/2]
        /// </summary>
        /// <returns>The angle whose tangent is y_over_x.</returns>
        protected internal static vec2 Atan(vec2 yOverX) { throw _invalidAccess; }

        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is y_over_x. 
        /// The range of values returned by this function is [-PI/2, PI/2]
        /// </summary>
        /// <returns>The angle whose tangent is y_over_x.</returns>
        protected internal static vec3 Atan(vec3 yOverX) { throw _invalidAccess; }

        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is y_over_x. 
        /// The range of values returned by this function is [-PI/2, PI/2]
        /// </summary>
        /// <returns>The angle whose tangent is y_over_x.</returns>
        protected internal static vec4 Atan(vec4 yOverX) { throw _invalidAccess; }

        #endregion

        #region genType Sinh(genType x)

        /// <summary>
        /// Calculates the hyperbolic sine of x as (e**x - e**-x) / 2
        /// </summary>
        /// <returns>Returns the hyperbolic sine of x.</returns>
        protected internal static float Sinh(float x) { throw _invalidAccess; }

        /// <summary>
        /// Calculates the hyperbolic sine of x as (e**x - e**-x) / 2
        /// </summary>
        /// <returns>Returns the hyperbolic sine of x.</returns>
        protected internal static vec2 Sinh(vec2 x) { throw _invalidAccess; }

        /// <summary>
        /// Calculates the hyperbolic sine of x as (e**x - e**-x) / 2
        /// </summary>
        /// <returns>Returns the hyperbolic sine of x.</returns>
        protected internal static vec3 Sinh(vec3 x) { throw _invalidAccess; }

        /// <summary>
        /// Calculates the hyperbolic sine of x as (e**x - e**-x) / 2
        /// </summary>
        /// <returns>Returns the hyperbolic sine of x.</returns>
        protected internal static vec4 Sinh(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Cosh(genType x)

        /// <summary>
        /// Calculates the hyperbolic sine of x as (e**x + e**-x) / 2
        /// </summary>
        /// <returns>Returns the hyperbolic cosine of x.</returns>
        protected internal static float Cosh(float x) { throw _invalidAccess; }

        /// <summary>
        /// Calculates the hyperbolic sine of x as (e**x + e**-x) / 2
        /// </summary>
        /// <returns>Returns the hyperbolic cosine of x.</returns>
        protected internal static vec2 Cosh(vec2 x) { throw _invalidAccess; }

        /// <summary>
        /// Calculates the hyperbolic sine of x as (e**x + e**-x) / 2
        /// </summary>
        /// <returns>Returns the hyperbolic cosine of x.</returns>
        protected internal static vec3 Cosh(vec3 x) { throw _invalidAccess; }

        /// <summary>
        /// Calculates the hyperbolic sine of x as (e**x + e**-x) / 2
        /// </summary>
        /// <returns>Returns the hyperbolic cosine of x.</returns>
        protected internal static vec4 Cosh(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Tanh(genType x)

        /// <summary>
        /// Calculates the hyperbolic tangent function sinh(x)/cosh(x)
        /// </summary>
        /// <returns>Returns the hyperbolic tangent of x.</returns>
        protected internal static float Tanh(float x) { throw _invalidAccess; }

        /// <summary>
        /// Calculates the hyperbolic tangent function sinh(x)/cosh(x)
        /// </summary>
        /// <returns>Returns the hyperbolic tangent of x.</returns>
        protected internal static vec2 Tanh(vec2 x) { throw _invalidAccess; }

        /// <summary>
        /// Calculates the hyperbolic tangent function sinh(x)/cosh(x)
        /// </summary>
        /// <returns>Returns the hyperbolic tangent of x.</returns>
        protected internal static vec3 Tanh(vec3 x) { throw _invalidAccess; }

        /// <summary>
        /// Calculates the hyperbolic tangent function sinh(x)/cosh(x)
        /// </summary>
        /// <returns>Returns the hyperbolic tangent of x.</returns>
        protected internal static vec4 Tanh(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Asinh(genType x)

        /// <summary>
        /// Asinh returns the arc hyperbolic sine of x; the inverse of Sinh.
        /// </summary>
        /// <returns>Returns the arc hyperbolic sine of x.</returns>
        protected internal static float Asinh(float x) { throw _invalidAccess; }

        /// <summary>
        /// Asinh returns the arc hyperbolic sine of x; the inverse of Sinh.
        /// </summary>
        /// <returns>Returns the arc hyperbolic sine of x.</returns>
        protected internal static vec2 Asinh(vec2 x) { throw _invalidAccess; }

        /// <summary>
        /// Asinh returns the arc hyperbolic sine of x; the inverse of Sinh.
        /// </summary>
        /// <returns>Returns the arc hyperbolic sine of x.</returns>
        protected internal static vec3 Asinh(vec3 x) { throw _invalidAccess; }

        /// <summary>
        /// Asinh returns the arc hyperbolic sine of x; the inverse of Sinh.
        /// </summary>
        /// <returns>Returns the arc hyperbolic sine of x.</returns>
        protected internal static vec4 Asinh(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Acosh(genType x)

        /// <summary>
        /// Acosh returns the arc hyperbolic cosine of x; the non-negative inverse of cosh.
        /// </summary>
        /// <remarks>Results are undefined if x &lt; 1.</remarks>
        /// <returns>Returns the arc hyperbolic cosine of x.</returns>
        [UndefinedBehavior("x < 1")]
        protected internal static float Acosh(float x) { throw _invalidAccess; }

        /// <summary>
        /// Acosh returns the arc hyperbolic cosine of x; the non-negative inverse of cosh.
        /// </summary>
        /// <remarks>Results are undefined if x &lt; 1.</remarks>
        /// <returns>Returns the arc hyperbolic cosine of x.</returns>
        [UndefinedBehavior("x < 1")]
        protected internal static vec2 Acosh(vec2 x) { throw _invalidAccess; }

        /// <summary>
        /// Acosh returns the arc hyperbolic cosine of x; the non-negative inverse of cosh.
        /// </summary>
        /// <remarks>Results are undefined if x &lt; 1.</remarks>
        /// <returns>Returns the arc hyperbolic cosine of x.</returns>
        [UndefinedBehavior("x < 1")]
        protected internal static vec3 Acosh(vec3 x) { throw _invalidAccess; }

        /// <summary>
        /// Acosh returns the arc hyperbolic cosine of x; the non-negative inverse of cosh.
        /// </summary>
        /// <remarks>Results are undefined if x &lt; 1.</remarks>
        /// <returns>Returns the arc hyperbolic cosine of x.</returns>
        [UndefinedBehavior("x < 1")]
        protected internal static vec4 Acosh(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Atanh(genType x)

        /// <summary>
        /// Atanh returns the arc hyperbolic tangent of x; the inverse of Tanh.
        /// </summary>
        /// <remarks>Results are undefined if |x| &gt;= 1.</remarks>
        /// <returns>Returns the arc hyperbolic tangent of x.</returns>
        [UndefinedBehavior("x >= 1")]
        protected internal static float Atanh(float x) { throw _invalidAccess; }

        /// <summary>
        /// Atanh returns the arc hyperbolic tangent of x; the inverse of Tanh.
        /// </summary>
        /// <remarks>Results are undefined if |x| &gt;= 1.</remarks>
        /// <returns>Returns the arc hyperbolic tangent of x.</returns>
        [UndefinedBehavior("x >= 1")]
        protected internal static vec2 Atanh(vec2 x) { throw _invalidAccess; }

        /// <summary>
        /// Atanh returns the arc hyperbolic tangent of x; the inverse of Tanh.
        /// </summary>
        /// <remarks>Results are undefined if |x| &gt;= 1.</remarks>
        /// <returns>Returns the arc hyperbolic tangent of x.</returns>
        [UndefinedBehavior("x >= 1")]
        protected internal static vec3 Atanh(vec3 x) { throw _invalidAccess; }

        /// <summary>
        /// Atanh returns the arc hyperbolic tangent of x; the inverse of Tanh.
        /// </summary>
        /// <remarks>Results are undefined if |x| &gt;= 1.</remarks>
        /// <returns>Returns the arc hyperbolic tangent of x.</returns>
        [UndefinedBehavior("x >= 1")]
        protected internal static vec4 Atanh(vec4 x) { throw _invalidAccess; }

        #endregion

        #endregion

        #region HLSL derived

        #region void SinCos(genType angle, out genType sin, out genType cos)

        /// <summary>Returns the sine and cosine of x.</summary>
        protected internal static void SinCos(float angle, out float sin, out float cos) { throw _invalidAccess; }

        /// <summary>The standard trigonometric sine function.</summary>
        protected internal static void SinCos(vec2 angle, out vec2 sin, out vec2 cos) { throw _invalidAccess; }

        /// <summary>The standard trigonometric sine function.</summary>
        protected internal static void SinCos(vec3 angle, out vec3 sin, out vec3 cos) { throw _invalidAccess; }

        /// <summary>The standard trigonometric sine function.</summary>
        protected internal static void SinCos(vec4 angle, out vec4 sin, out vec4 cos) { throw _invalidAccess; }

        #endregion

        #endregion
    }
}
