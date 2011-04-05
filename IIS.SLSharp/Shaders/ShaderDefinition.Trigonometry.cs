// ReSharper disable InconsistentNaming

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        // Function parameters specified as angle are assumed to be in units of radians. In no case will any of these
        // functions result in a divide by zero error. If the divisor of a ratio is 0, then results will be undefined.
        // These all operate component-wise. The description is per component.

        #region genType radians(genType degrees)

        /// <summary>Converts degrees to radians, i.e., PI/180 * degrees</summary>
        protected static float radians(float dagrees) { throw _invalidAccess; }

        /// <summary>Converts degrees to radians, i.e., PI/180 * degrees</summary>
        protected static vec2 radians(vec2 dagrees) { throw _invalidAccess; }

        /// <summary>Converts degrees to radians, i.e., PI/180 * degrees</summary>
        protected static vec3 radians(vec3 dagrees) { throw _invalidAccess; }

        /// <summary>Converts degrees to radians, i.e., PI/180 * degrees</summary>
        protected static vec4 radians(vec4 dagrees) { throw _invalidAccess; }

        #endregion

        #region genType degrees(genType radians)

        /// <summary>Converts radians to degrees, i.e., 180/PI*radians</summary>
        protected static float degrees(float radians) { throw _invalidAccess; }

        /// <summary>Converts radians to degrees, i.e., 180/PI*radians</summary>
        protected static vec2 degrees(vec2 radians) { throw _invalidAccess; }

        /// <summary>Converts radians to degrees, i.e., 180/PI*radians</summary>
        protected static vec3 degrees(vec3 radians) { throw _invalidAccess; }

        /// <summary>Converts radians to degrees, i.e., 180/PI*radians</summary>
        protected static vec4 degrees(vec4 radians) { throw _invalidAccess; }

        #endregion

        #region genType sin(genType angle)

        /// <summary>The standard trigonometric sine function.</summary>
        protected static float sin(float angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric sine function.</summary>
        protected static vec2 sin(vec2 angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric sine function.</summary>
        protected static vec3 sin(vec3 angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric sine function.</summary>
        protected static vec4 sin(vec4 angle) { throw _invalidAccess; }

        #endregion

        #region genType cos(genType angle)

        /// <summary>The standard trigonometric cosine function.</summary>
        protected static float cos(float angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric cosine function.</summary>
        protected static vec2 cos(vec2 angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric cosine function.</summary>
        protected static vec3 cos(vec3 angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric cosine function.</summary>
        protected static vec4 cos(vec4 angle) { throw _invalidAccess; }

        #endregion

        #region genType tan(genType angle)

        /// <summary>The standard trigonometric tangent.</summary>
        protected static float tan(float angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric tangent.</summary>
        protected static vec2 tan(vec2 angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric tangent.</summary>
        protected static vec3 tan(vec3 angle) { throw _invalidAccess; }

        /// <summary>The standard trigonometric tangent.</summary>
        protected static vec4 tan(vec4 angle) { throw _invalidAccess; }

        #endregion

        #region genType asin(genType x)

        /// <summary>
        /// Arc sine. Returns an angle whose sine is x. The range of values returned by 
        /// this function is [-PI/2, PI/2]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose sine is x.</returns>
        protected static float asin(float x) { throw _invalidAccess; }

        /// <summary>
        /// Arc sine. Returns an angle whose sine is x. The range of values returned by 
        /// this function is [-PI/2, PI/2]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose sine is x.</returns>
        protected static vec2 asin(vec2 x) { throw _invalidAccess; }

        /// <summary>
        /// Arc sine. Returns an angle whose sine is x. The range of values returned by 
        /// this function is [-PI/2, PI/2]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose sine is x.</returns>
        protected static vec3 asin(vec3 x) { throw _invalidAccess; }

        /// <summary>
        /// Arc sine. Returns an angle whose sine is x. The range of values returned by 
        /// this function is [-PI/2, PI/2]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose sine is x.</returns>
        protected static vec4 asin(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType acos(genType x)

        /// <summary>
        /// Arc cosine. Returns an angle whose cosine is x. The range of values returned by 
        /// this function is [0, PI]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose cosine is x.</returns>
        protected static float acos(float x) { throw _invalidAccess; }

        /// <summary>
        /// Arc cosine. Returns an angle whose cosine is x. The range of values returned by 
        /// this function is [0, PI]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose cosine is x.</returns>
        protected static vec2 acos(vec2 x) { throw _invalidAccess; }

        /// <summary>
        /// Arc cosine. Returns an angle whose cosine is x. The range of values returned by 
        /// this function is [0, PI]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose cosine is x.</returns>
        protected static vec3 acos(vec3 x) { throw _invalidAccess; }

        /// <summary>
        /// Arc cosine. Returns an angle whose cosine is x. The range of values returned by 
        /// this function is [0, PI]
        /// </summary>
        /// <param name="x">The value to solve for, Result is undefined for |x| > 1</param>
        /// <returns>The angle whose cosine is x.</returns>
        protected static vec4 acos(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType atan(genType y, genType x)

        /// <summary>
        /// Arc cosine. Returns an angle whose tangent is y/x. 
        /// The signs of x and y are used to determine what quadrant the angle is in.
        /// The range of values returned by this function is [-PI, PI]
        /// The value to solve for, Result is undefined if x an y are both 0
        /// </summary>
        /// <returns>The angle whose tangent is y/x.</returns>
        protected static float atan(float y, float x) { throw _invalidAccess; }

        /// <summary>
        /// Arc cosine. Returns an angle whose tangent is y/x. 
        /// The signs of x and y are used to determine what quadrant the angle is in.
        /// The range of values returned by this function is [-PI, PI]
        /// The value to solve for, Result is undefined if x an y are both 0
        /// </summary>
        /// <returns>The angle whose tangent is y/x.</returns>
        protected static vec2 atan(vec2 y, vec2 x) { throw _invalidAccess; }

        /// <summary>
        /// Arc cosine. Returns an angle whose tangent is y/x. 
        /// The signs of x and y are used to determine what quadrant the angle is in.
        /// The range of values returned by this function is [-PI, PI]
        /// The value to solve for, Result is undefined if x an y are both 0
        /// </summary>
        /// <returns>The angle whose tangent is y/x.</returns>
        protected static vec3 atan(vec3 y, vec3 x) { throw _invalidAccess; }

        /// <summary>
        /// Arc cosine. Returns an angle whose tangent is y/x. 
        /// The signs of x and y are used to determine what quadrant the angle is in.
        /// The range of values returned by this function is [-PI, PI]
        /// The value to solve for, Result is undefined if x an y are both 0
        /// </summary>
        /// <returns>The angle whose tangent is y/x.</returns>
        protected static vec4 atan(vec4 y, vec4 x) { throw _invalidAccess; }

        #endregion

        #region genType atan(genType y_over_x)

        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is y_over_x. 
        /// The range of values returned by this function is [-PI/2, PI/2]
        /// </summary>
        /// <returns>The angle whose tangent is y_over_x.</returns>
        protected static float atan(float y_over_x) { throw _invalidAccess; }

        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is y_over_x. 
        /// The range of values returned by this function is [-PI/2, PI/2]
        /// </summary>
        /// <returns>The angle whose tangent is y_over_x.</returns>
        protected static vec2 atan(vec2 y_over_x) { throw _invalidAccess; }

        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is y_over_x. 
        /// The range of values returned by this function is [-PI/2, PI/2]
        /// </summary>
        /// <returns>The angle whose tangent is y_over_x.</returns>
        protected static vec3 atan(vec3 y_over_x) { throw _invalidAccess; }

        /// <summary>
        /// Arc tangent. Returns an angle whose tangent is y_over_x. 
        /// The range of values returned by this function is [-PI/2, PI/2]
        /// </summary>
        /// <returns>The angle whose tangent is y_over_x.</returns>
        protected static vec4 atan(vec4 y_over_x) { throw _invalidAccess; }

        #endregion
    }
}

// ReSharper restore InconsistentNaming

