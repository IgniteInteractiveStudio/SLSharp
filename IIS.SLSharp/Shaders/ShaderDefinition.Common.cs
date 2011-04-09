// ReSharper disable InconsistentNaming


namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        // These all operate component-wise. The description is per component.

        #region genType abs(genType x)

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected static float abs(float x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected static vec2 abs(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected static vec3 abs(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected static vec4 abs(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genIType abs(genIType x)

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected static int abs(int x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected static ivec2 abs(ivec2 x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected static ivec3 abs(ivec3 x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected static ivec4 abs(ivec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType abs(genDType x)

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected static double abs(double x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected static dvec2 abs(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected static dvec3 abs(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected static dvec4 abs(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType sign(genType x)

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected static float sign(float x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected static vec2 sign(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected static vec3 sign(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected static vec4 sign(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genIType sign(genIType x)

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected static int sign(int x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected static ivec2 sign(ivec2 x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected static ivec3 sign(ivec3 x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected static ivec4 sign(ivec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType sign(genType x)

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected static double sign(double x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected static dvec2 sign(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected static dvec3 sign(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected static dvec4 sign(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType floor(genType x)

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected static float floor(float x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected static vec2 floor(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected static vec3 floor(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected static vec4 floor(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType floor(genDType x)

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected static double floor(double x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected static dvec2 floor(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected static dvec3 floor(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected static dvec4 floor(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType trunc(genType x)

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected static float trunc(float x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected static vec2 trunc(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected static vec3 trunc(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected static vec4 trunc(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType trunc(genDType x)

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected static double trunc(double x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected static dvec2 trunc(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected static dvec3 trunc(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected static dvec4 trunc(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType round(genType x)

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that round(x) returns the same value 
        /// as roundEven(x) for all values of x.</summary>
        protected static float round(float x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that round(x) returns the same value 
        /// as roundEven(x) for all values of x.</summary>
        protected static vec2 round(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that round(x) returns the same value 
        /// as roundEven(x) for all values of x.</summary>
        protected static vec3 round(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that round(x) returns the same value 
        /// as roundEven(x) for all values of x.</summary>
        protected static vec4 round(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType round(genType x)

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that round(x) returns the same value 
        /// as roundEven(x) for all values of x.</summary>
        protected static double round(double x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that round(x) returns the same value 
        /// as roundEven(x) for all values of x.</summary>
        protected static dvec2 round(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that round(x) returns the same value 
        /// as roundEven(x) for all values of x.</summary>
        protected static dvec3 round(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that round(x) returns the same value 
        /// as roundEven(x) for all values of x.</summary>
        protected static dvec4 round(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType roundEven(genType x)

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected static float roundEven(float x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected static vec2 roundEven(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected static vec3 roundEven(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected static vec4 roundEven(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType roundEven(genDType x)

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected static double roundEven(double x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected static dvec2 roundEven(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected static dvec3 roundEven(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected static dvec4 roundEven(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType ceil(genType x)

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected static float ceil(float x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected static vec2 ceil(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected static vec3 ceil(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected static vec4 ceil(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType ceil(genDType x)

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected static double ceil(double x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected static dvec2 ceil(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected static dvec3 ceil(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected static dvec4 ceil(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType fract(genType x)

        /// <summary>Returns x – floor (x).</summary>
        protected static float fract(float x) { throw _invalidAccess; }

        /// <summary>Returns x – floor (x).</summary>
        protected static vec2 fract(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns x – floor (x).</summary>
        protected static vec3 fract(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns x – floor (x).</summary>
        protected static vec4 fract(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType fract(genDType x)

        /// <summary>Returns x – floor (x).</summary>
        protected static double fract(double x) { throw _invalidAccess; }

        /// <summary>Returns x – floor (x).</summary>
        protected static dvec2 fract(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns x – floor (x).</summary>
        protected static dvec3 fract(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns x – floor (x).</summary>
        protected static dvec4 fract(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType mod(genType x, float y)

        /// <summary>Modulus. Returns x – y * floor (x/y).</summary>
        protected static float mod(float x, float y) { throw _invalidAccess; }

        /// <summary>Modulus. Returns x – y * floor (x/y).</summary>
        protected static vec2 mod(vec2 x, float y) { throw _invalidAccess; }

        /// <summary>Modulus. Returns x – y * floor (x/y).</summary>
        protected static vec3 mod(vec3 x, float y) { throw _invalidAccess; }

        /// <summary>Modulus. Returns x – y * floor (x/y).</summary>
        protected static vec4 mod(vec4 x, float y) { throw _invalidAccess; }

        #endregion

        #region genType mod(genType x, genType y)

        /// <summary>Modulus. Returns x – y * floor (x/y).</summary>
        protected static vec2 mod(vec2 x, vec2 y) { throw _invalidAccess; }

        /// <summary>Modulus. Returns x – y * floor (x/y).</summary>
        protected static vec3 mod(vec3 x, vec3 y) { throw _invalidAccess; }

        /// <summary>Modulus. Returns x – y * floor (x/y).</summary>
        protected static vec4 mod(vec4 x, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genDType mod(genDType x, double y)

        /// <summary>Modulus. Returns x – y * floor (x/y).</summary>
        protected static double mod(double x, double y) { throw _invalidAccess; }

        /// <summary>Modulus. Returns x – y * floor (x/y).</summary>
        protected static dvec2 mod(dvec2 x, double y) { throw _invalidAccess; }

        /// <summary>Modulus. Returns x – y * floor (x/y).</summary>
        protected static dvec3 mod(dvec3 x, double y) { throw _invalidAccess; }

        /// <summary>Modulus. Returns x – y * floor (x/y).</summary>
        protected static dvec4 mod(dvec4 x, double y) { throw _invalidAccess; }

        #endregion

        #region genDType mod(genDType x, genDType y)

        /// <summary>Modulus. Returns x – y * floor (x/y).</summary>
        protected static dvec2 mod(dvec2 x, dvec2 y) { throw _invalidAccess; }

        /// <summary>Modulus. Returns x – y * floor (x/y).</summary>
        protected static dvec3 mod(dvec3 x, dvec3 y) { throw _invalidAccess; }

        /// <summary>Modulus. Returns x – y * floor (x/y).</summary>
        protected static dvec4 mod(dvec4 x, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region genType modf (genType x, out genType i)

        /// <summary>Returns the fractional part of x and sets i to the integer part 
        /// (as a whole number floating point value). 
        /// Both the return value and the output parameter will have the same sign as x..</summary>
        protected static float mod(float x, out float y) { throw _invalidAccess; }

        /// <summary>Returns the fractional part of x and sets i to the integer part 
        /// (as a whole number floating point value). 
        /// Both the return value and the output parameter will have the same sign as x..</summary>
        protected static vec2 mod(vec2 x, out vec2 y) { throw _invalidAccess; }

        /// <summary>Returns the fractional part of x and sets i to the integer part 
        /// (as a whole number floating point value). 
        /// Both the return value and the output parameter will have the same sign as x..</summary>
        protected static vec3 mod(vec3 x, out vec3 y) { throw _invalidAccess; }

        /// <summary>Returns the fractional part of x and sets i to the integer part 
        /// (as a whole number floating point value). 
        /// Both the return value and the output parameter will have the same sign as x..</summary>
        protected static vec4 mod(vec4 x, out vec4 y) { throw _invalidAccess; }

        #endregion

        #region genDType modf (genDType x, out genDType i)

        /// <summary>Returns the fractional part of x and sets i to the integer part 
        /// (as a whole number floating point value). 
        /// Both the return value and the output parameter will have the same sign as x..</summary>
        protected static double mod(double x, out double y) { throw _invalidAccess; }

        /// <summary>Returns the fractional part of x and sets i to the integer part 
        /// (as a whole number floating point value). 
        /// Both the return value and the output parameter will have the same sign as x..</summary>
        protected static dvec2 mod(dvec2 x, out dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns the fractional part of x and sets i to the integer part 
        /// (as a whole number floating point value). 
        /// Both the return value and the output parameter will have the same sign as x..</summary>
        protected static dvec3 mod(dvec3 x, out dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns the fractional part of x and sets i to the integer part 
        /// (as a whole number floating point value). 
        /// Both the return value and the output parameter will have the same sign as x..</summary>
        protected static dvec4 mod(dvec4 x, out dvec4 y) { throw _invalidAccess; }

        #endregion

        #region genType min(genType x, float y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static float min(float x, float y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static vec2 min(vec2 x, float y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static vec3 min(vec3 x, float y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static vec4 min(vec4 x, float y) { throw _invalidAccess; }

        #endregion

        #region genType min(genType x, genType y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static vec2 min(vec2 x, vec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static vec3 min(vec3 x, vec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static vec4 min(vec4 x, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genDType min(genDType x, double y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static double min(double x, double y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static dvec2 min(dvec2 x, double y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static dvec3 min(dvec3 x, double y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static dvec4 min(dvec4 x, double y) { throw _invalidAccess; }

        #endregion

        #region genDType min(genDType x, genDType y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static dvec2 min(dvec2 x, dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static dvec3 min(dvec3 x, dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static dvec4 min(dvec4 x, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region genIType min(genIType x, int y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static int min(int x, int y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static ivec2 min(ivec2 x, int y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static ivec3 min(ivec3 x, int y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static ivec4 min(ivec4 x, int y) { throw _invalidAccess; }

        #endregion

        #region genIType min(genIType x, genIType y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static ivec2 min(ivec2 x, ivec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static ivec3 min(ivec3 x, ivec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static ivec4 min(ivec4 x, ivec4 y) { throw _invalidAccess; }

        #endregion

        #region genUType min(genUType x, uint y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static uint min(uint x, uint y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static uvec2 min(uvec2 x, uint y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static uvec3 min(uvec3 x, uint y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static uvec4 min(uvec4 x, uint y) { throw _invalidAccess; }

        #endregion

        #region genUType min(genUType x, genUType y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static uvec2 min(uvec2 x, uvec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static uvec3 min(uvec3 x, uvec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected static uvec4 min(uvec4 x, uvec4 y) { throw _invalidAccess; }

        #endregion

        #region genType max(genType x, float y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static float max(float x, float y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static vec2 max(vec2 x, float y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static vec3 max(vec3 x, float y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static vec4 max(vec4 x, float y) { throw _invalidAccess; }

        #endregion

        #region genType max(genType x, genType y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static vec2 max(vec2 x, vec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static vec3 max(vec3 x, vec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static vec4 max(vec4 x, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genDType max(genDType x, double y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static double max(double x, double y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static dvec2 max(dvec2 x, double y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static dvec3 max(dvec3 x, double y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static dvec4 max(dvec4 x, double y) { throw _invalidAccess; }

        #endregion

        #region genDType max(genDType x, genDType y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static dvec2 max(dvec2 x, dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static dvec3 max(dvec3 x, dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static dvec4 max(dvec4 x, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region genIType max(genIType x, int y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static int max(int x, int y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static ivec2 max(ivec2 x, int y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static ivec3 max(ivec3 x, int y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static ivec4 max(ivec4 x, int y) { throw _invalidAccess; }

        #endregion

        #region genIType max(genIType x, genIType y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static ivec2 max(ivec2 x, ivec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static ivec3 max(ivec3 x, ivec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static ivec4 max(ivec4 x, ivec4 y) { throw _invalidAccess; }

        #endregion

        #region genUType max(genUType x, int y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static uint max(uint x, uint y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static uvec2 max(uvec2 x, uint y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static uvec3 max(uvec3 x, uint y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static uvec4 max(uvec4 x, uint y) { throw _invalidAccess; }

        #endregion

        #region genUType max(genUType x, genUType y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static uvec2 max(uvec2 x, uvec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static uvec3 max(uvec3 x, uvec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected static uvec4 max(uvec4 x, uvec4 y) { throw _invalidAccess; }

        #endregion

        #region genType clamp(genType x, float minVal, float maxVal)

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static float clamp(float x, float minVal, float maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static vec2 clamp(vec2 x, float minVal, float maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static vec3 clamp(vec3 x, float minVal, float maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static vec4 clamp(vec4 x, float minVal, float maxVal) { throw _invalidAccess; }

        #endregion

        #region genType clamp(genType x, genType minVal, genType maxVal)

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static vec2 clamp(vec2 x, vec2 minVal, vec2 maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static vec3 clamp(vec3 x, vec3 minVal, vec3 maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static vec4 clamp(vec4 x, vec4 minVal, vec4 maxVal) { throw _invalidAccess; }

        #endregion

        #region genDType clamp(genDType x, double minVal, double maxVal)

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static double clamp(double x, double minVal, double maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static dvec2 clamp(dvec2 x, double minVal, double maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static dvec3 clamp(dvec3 x, double minVal, double maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static dvec4 clamp(dvec4 x, double minVal, double maxVal) { throw _invalidAccess; }

        #endregion

        #region genDType clamp(genDType x, genDType minVal, genDType maxVal)

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static dvec2 clamp(dvec2 x, dvec2 minVal, dvec2 maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static dvec3 clamp(dvec3 x, dvec3 minVal, dvec3 maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static dvec4 clamp(dvec4 x, dvec4 minVal, dvec4 maxVal) { throw _invalidAccess; }

        #endregion

        #region genIType clamp(genIType x, int minVal, int maxVal)

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static int clamp(int x, int minVal, int maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static ivec2 clamp(ivec2 x, int minVal, int maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static ivec3 clamp(ivec3 x, int minVal, int maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static ivec4 clamp(ivec4 x, int minVal, int maxVal) { throw _invalidAccess; }

        #endregion

        #region genIType clamp(genIType x, genIType minVal, genIType maxVal)

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static ivec2 clamp(ivec2 x, ivec2 minVal, ivec2 maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static ivec3 clamp(ivec3 x, ivec3 minVal, ivec3 maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static ivec4 clamp(ivec4 x, ivec4 minVal, ivec4 maxVal) { throw _invalidAccess; }

        #endregion

        #region genUType clamp(genUType x, uint minVal, uint maxVal)

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static uint clamp(uint x, uint minVal, uint maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static uvec2 clamp(uvec2 x, uint minVal, uint maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static uvec3 clamp(uvec3 x, uint minVal, uint maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static uvec4 clamp(uvec4 x, uint minVal, uint maxVal) { throw _invalidAccess; }

        #endregion

        #region genUType clamp(genUType x, genUType minVal, genUType maxVal)

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static uvec2 clamp(uvec2 x, uvec2 minVal, uvec2 maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static uvec3 clamp(uvec3 x, uvec3 minVal, uvec3 maxVal) { throw _invalidAccess; }

        /// <summary>Returns min (max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected static uvec4 clamp(uvec4 x, uvec4 minVal, uvec4 maxVal) { throw _invalidAccess; }

        #endregion

        #region genType mix(genType x, genType y, float a)

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected static float mix(float x, float y, float a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected static vec2 mix(vec2 x, vec2 y, float a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected static vec3 mix(vec3 x, vec3 y, float a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected static vec4 mix(vec4 x, vec4 y, float a) { throw _invalidAccess; }

        #endregion

        #region genType mix(genType x, genType y, genType a)

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected static vec2 mix(vec2 x, vec2 y, vec2 a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected static vec3 mix(vec3 x, vec3 y, vec3 a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected static vec4 mix(vec4 x, vec4 y, vec4 a) { throw _invalidAccess; }

        #endregion

        #region genDType mix(genDType x, genDType y, double a)

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected static double mix(double x, double y, double a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected static dvec2 mix(dvec2 x, dvec2 y, double a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected static dvec3 mix(dvec3 x, dvec3 y, double a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected static dvec4 mix(dvec4 x, dvec4 y, double a) { throw _invalidAccess; }

        #endregion

        #region genDType mix(genDType x, genDType y, genDType a)

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected static dvec2 mix(dvec2 x, dvec2 y, dvec2 a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected static dvec3 mix(dvec3 x, dvec3 y, dvec3 a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected static dvec4 mix(dvec4 x, dvec4 y, dvec4 a) { throw _invalidAccess; }

        #endregion

        #region genType step(float edge, genType x)

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected static float step(float edge, float y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected static vec2 step(float edge, vec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected static vec3 step(float edge, vec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected static vec4 step(float edge, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genType step(genType edge, genType x)

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected static vec2 step(vec2 edge, vec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected static vec3 step(vec3 edge, vec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected static vec4 step(vec4 edge, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genDType step(double edge, genDType x)

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected static double step(double edge, double y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected static dvec2 step(double edge, dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected static dvec3 step(double edge, dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected static dvec4 step(double edge, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region genDType step(genDType edge, genDType x)

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected static dvec2 step(dvec2 edge, dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected static dvec3 step(dvec3 edge, dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected static dvec4 step(dvec4 edge, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region genType smoothstep(float edge0, float step1, genType x)

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected static float smoothstep(float edge0, float edge1, float y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected static vec2 smoothstep(float edge0, float edge1, vec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected static vec3 smoothstep(float edge0, float edge1, vec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected static vec4 smoothstep(float edge0, float edge1, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genType smoothstep(genType edge0, genType step1, genType x)

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected static vec2 smoothstep(vec2 edge0, vec2 edge1, vec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected static vec3 smoothstep(vec3 edge0, vec3 edge1, vec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected static vec4 smoothstep(vec4 edge0, vec4 edge1, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genDType smoothstep(double edge0, double step1, genDType x)

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected static double smoothstep(double edge0, double edge1, double y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected static dvec2 smoothstep(double edge0, double edge1, dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected static dvec3 smoothstep(double edge0, double edge1, dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected static dvec4 smoothstep(double edge0, double edge1, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region genDType smoothstep(genDType edge0, genDType step1, genDType x)

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected static dvec2 smoothstep(dvec2 edge0, dvec2 edge1, dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected static dvec3 smoothstep(dvec3 edge0, dvec3 edge1, dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected static dvec4 smoothstep(dvec4 edge0, dvec4 edge1, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region genIType floatBitsToInt (genType value)

        /// <summary>
        /// Returns a signed integer value representing the encoding of floating-point value. 
        /// The floatingpoint value's bit-level representation is preserved.
        /// </summary>
        protected static int floatBitsToInt(float value) { throw _invalidAccess; }

        /// <summary>
        /// Returns a signed or unsigned integer value representing the encoding of floating-point value. 
        /// The floatingpoint value's bit-level representation is preserved.
        /// </summary>
        protected static ivec2 floatBitsToInt(vec2 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns a signed integer value representing the encoding of floating-point value. 
        /// The floatingpoint value's bit-level representation is preserved.
        /// </summary>
        protected static ivec3 floatBitsToInt(vec3 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns a signed integer value representing the encoding of floating-point value. 
        /// The floatingpoint value's bit-level representation is preserved.
        /// </summary>
        protected static ivec4 floatBitsToInt(vec4 value) { throw _invalidAccess; }

        #endregion

        #region genUType floatBitsToUint (genType value)

        /// <summary>
        /// Returns an unsigned integer value representing the encoding of floating-point value. 
        /// The floatingpoint value's bit-level representation is preserved.
        /// </summary>
        protected static uint floatBitsToUint(float value) { throw _invalidAccess; }

        /// <summary>
        /// Returns an unsigned integer value representing the encoding of floating-point value. 
        /// The floatingpoint value's bit-level representation is preserved.
        /// </summary>
        protected static uvec2 floatBitsToUint(vec2 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns an unsigned integer value representing the encoding of floating-point value. 
        /// The floatingpoint value's bit-level representation is preserved.
        /// </summary>
        protected static uvec3 floatBitsToUint(vec3 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns an unsigned integer value representing the encoding of floating-point value. 
        /// The floatingpoint value's bit-level representation is preserved.
        /// </summary>
        protected static uvec4 floatBitsToUint(vec4 value) { throw _invalidAccess; }

        #endregion

        #region genType intBitsToFloat (genIType value)
        
        /// <summary>
        /// Returns a floating-point value corresponding to a signed integer encoding 
        /// of a floating-point value. If a NaN is passed in, it will not signal, 
        /// and the resulting floating point value is unspecified. If an Inf is passed in,
        /// the resulting floating-point value is the corresponding Inf.
        /// </summary>
        protected static float intBitsToFloat(int value) { throw _invalidAccess; }

        /// <summary>
        /// Returns a floating-point value corresponding to a signed integer encoding 
        /// of a floating-point value. If a NaN is passed in, it will not signal, 
        /// and the resulting floating point value is unspecified. If an Inf is passed in,
        /// the resulting floating-point value is the corresponding Inf.
        /// </summary>
        protected static vec2 intBitsToFloat(ivec2 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns a floating-point value corresponding to a signed integer encoding 
        /// of a floating-point value. If a NaN is passed in, it will not signal, 
        /// and the resulting floating point value is unspecified. If an Inf is passed in,
        /// the resulting floating-point value is the corresponding Inf.
        /// </summary>
        protected static vec3 intBitsToFloat(ivec3 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns a floating-point value corresponding to a signed integer encoding 
        /// of a floating-point value. If a NaN is passed in, it will not signal, 
        /// and the resulting floating point value is unspecified. If an Inf is passed in,
        /// the resulting floating-point value is the corresponding Inf.
        /// </summary>
        protected static vec4 intBitsToFloat(ivec4 value) { throw _invalidAccess; }

        #endregion

        #region genType uintBitsToFloat (genUType value)

        /// <summary>
        /// Returns a floating-point value corresponding to an unsigned integer encoding 
        /// of a floating-point value. If a NaN is passed in, it will not signal, 
        /// and the resulting floating point value is unspecified. If an Inf is passed in,
        /// the resulting floating-point value is the corresponding Inf.
        /// </summary>
        protected static float uintBitsToFloat(uint value) { throw _invalidAccess; }

        /// <summary>
        /// Returns a floating-point value corresponding to an unsigned integer encoding 
        /// of a floating-point value. If a NaN is passed in, it will not signal, 
        /// and the resulting floating point value is unspecified. If an Inf is passed in,
        /// the resulting floating-point value is the corresponding Inf.
        /// </summary>
        protected static vec2 uintBitsToFloat(uvec2 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns a floating-point value corresponding to an unsigned integer encoding 
        /// of a floating-point value. If a NaN is passed in, it will not signal, 
        /// and the resulting floating point value is unspecified. If an Inf is passed in,
        /// the resulting floating-point value is the corresponding Inf.
        /// </summary>
        protected static vec3 uintBitsToFloat(uvec3 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns a floating-point value corresponding to an unsigned integer encoding 
        /// of a floating-point value. If a NaN is passed in, it will not signal, 
        /// and the resulting floating point value is unspecified. If an Inf is passed in,
        /// the resulting floating-point value is the corresponding Inf.
        /// </summary>
        protected static vec4 uintBitsToFloat(uvec4 value) { throw _invalidAccess; }

        #endregion

        #region genType fma(genType a, genType b, genType c)

        /// <summary>Computes and returns a*b + c.</summary>
        protected static float fma(float a, float b, float c) { throw _invalidAccess; }

        /// <summary>Computes and returns a*b + c.</summary>
        protected static vec2 fma(vec2 a, vec2 b, vec2 c) { throw _invalidAccess; }

        /// <summary>Computes and returns a*b + c.</summary>
        protected static vec3 fma(vec3 a, vec3 b, vec3 c) { throw _invalidAccess; }

        /// <summary>Computes and returns a*b + c.</summary>
        protected static vec4 fma(vec4 a, vec4 b, vec4 c) { throw _invalidAccess; }

        #endregion

        #region genDType fma(genDType a, genDType b, genDType c)

        /// <summary>Computes and returns a*b + c.</summary>
        protected static double fma(double a, double b, double c) { throw _invalidAccess; }

        /// <summary>Computes and returns a*b + c.</summary>
        protected static dvec2 fma(dvec2 a, dvec2 b, dvec2 c) { throw _invalidAccess; }

        /// <summary>Computes and returns a*b + c.</summary>
        protected static dvec3 fma(dvec3 a, dvec3 b, dvec3 c) { throw _invalidAccess; }

        /// <summary>Computes and returns a*b + c.</summary>
        protected static dvec4 fma(dvec4 a, dvec4 b, dvec4 c) { throw _invalidAccess; }

        #endregion

        #region genType frexp (genType x, out genIType exp)

        /// <summary>
        /// Splits x into a floating-point significand in the range [0.5, 1.0) 
        /// and an integral exponent of two, such that: x=significand⋅2**exponent
        /// The significand is returned by the function and the exponent is returned in the parameter exp. 
        /// For a floating-point value of zero, the significant and exponent are both zero. 
        /// For a floating-point value that is an infinity or is not a number, the results are undefined.
        /// </summary>
        protected static float frexp(float x, out int exp) { throw _invalidAccess; }

        /// <summary>
        /// Splits x into a floating-point significand in the range [0.5, 1.0) 
        /// and an integral exponent of two, such that: x=significand⋅2**exponent
        /// The significand is returned by the function and the exponent is returned in the parameter exp. 
        /// For a floating-point value of zero, the significant and exponent are both zero. 
        /// For a floating-point value that is an infinity or is not a number, the results are undefined.
        /// </summary>
        protected static vec2 frexp(vec2 x, out ivec2 exp) { throw _invalidAccess; }

        /// <summary>
        /// Splits x into a floating-point significand in the range [0.5, 1.0) 
        /// and an integral exponent of two, such that: x=significand⋅2**exponent
        /// The significand is returned by the function and the exponent is returned in the parameter exp. 
        /// For a floating-point value of zero, the significant and exponent are both zero. 
        /// For a floating-point value that is an infinity or is not a number, the results are undefined.
        /// </summary>
        protected static vec3 frexp(vec3 x, out ivec3 exp) { throw _invalidAccess; }

        /// <summary>
        /// Splits x into a floating-point significand in the range [0.5, 1.0) 
        /// and an integral exponent of two, such that: x=significand⋅2**exponent
        /// The significand is returned by the function and the exponent is returned in the parameter exp. 
        /// For a floating-point value of zero, the significant and exponent are both zero. 
        /// For a floating-point value that is an infinity or is not a number, the results are undefined.
        /// </summary>
        protected static vec4 frexp(vec4 x, out ivec4 exp) { throw _invalidAccess; }

        #endregion
        
        #region genDType frexp (genDType x, out genIType exp)

        /// <summary>
        /// Splits x into a floating-point significand in the range [0.5, 1.0) 
        /// and an integral exponent of two, such that: x=significand⋅2**exponent
        /// The significand is returned by the function and the exponent is returned in the parameter exp. 
        /// For a floating-point value of zero, the significant and exponent are both zero. 
        /// For a floating-point value that is an infinity or is not a number, the results are undefined.
        /// </summary>
        protected static double frexp(double x, out int exp) { throw _invalidAccess; }

        /// <summary>
        /// Splits x into a floating-point significand in the range [0.5, 1.0) 
        /// and an integral exponent of two, such that: x=significand⋅2**exponent
        /// The significand is returned by the function and the exponent is returned in the parameter exp. 
        /// For a floating-point value of zero, the significant and exponent are both zero. 
        /// For a floating-point value that is an infinity or is not a number, the results are undefined.
        /// </summary>
        protected static dvec2 frexp(dvec2 x, out ivec2 exp) { throw _invalidAccess; }

        /// <summary>
        /// Splits x into a floating-point significand in the range [0.5, 1.0) 
        /// and an integral exponent of two, such that: x=significand⋅2**exponent
        /// The significand is returned by the function and the exponent is returned in the parameter exp. 
        /// For a floating-point value of zero, the significant and exponent are both zero. 
        /// For a floating-point value that is an infinity or is not a number, the results are undefined.
        /// </summary>
        protected static dvec3 frexp(dvec3 x, out ivec3 exp) { throw _invalidAccess; }

        /// <summary>
        /// Splits x into a floating-point significand in the range [0.5, 1.0) 
        /// and an integral exponent of two, such that: x=significand⋅2**exponent
        /// The significand is returned by the function and the exponent is returned in the parameter exp. 
        /// For a floating-point value of zero, the significant and exponent are both zero. 
        /// For a floating-point value that is an infinity or is not a number, the results are undefined.
        /// </summary>
        protected static dvec4 frexp(dvec4 x, out ivec4 exp) { throw _invalidAccess; }

        #endregion

        #region genType ldexp (genType x, in genIType exp)

        /// <summary>
        /// Builds a floating-point number from x and the corresponding integral exponent of two in exp, 
        /// returning: significand⋅2*+exponent
        /// If this product is too large to be represented in the floating-point type, the result is undefined.
        /// </summary>
        protected static float ldexp(float x, int exp) { throw _invalidAccess; }

        /// <summary>
        /// Builds a floating-point number from x and the corresponding integral exponent of two in exp, 
        /// returning: significand⋅2*+exponent
        /// If this product is too large to be represented in the floating-point type, the result is undefined.
        /// </summary>
        protected static vec2 ldexp(vec2 x, ivec2 exp) { throw _invalidAccess; }

        /// <summary>
        /// Builds a floating-point number from x and the corresponding integral exponent of two in exp, 
        /// returning: significand⋅2*+exponent
        /// If this product is too large to be represented in the floating-point type, the result is undefined.
        /// </summary>
        protected static vec3 ldexp(vec3 x, ivec3 exp) { throw _invalidAccess; }

        /// <summary>
        /// Builds a floating-point number from x and the corresponding integral exponent of two in exp, 
        /// returning: significand⋅2*+exponent
        /// If this product is too large to be represented in the floating-point type, the result is undefined.
        /// </summary>
        protected static vec4 ldexp(vec4 x, ivec4 exp) { throw _invalidAccess; }

        #endregion

        #region genDType ldexp (genDType x, in genIType exp)

        /// <summary>
        /// Builds a floating-point number from x and the corresponding integral exponent of two in exp, 
        /// returning: significand⋅2*+exponent
        /// If this product is too large to be represented in the floating-point type, the result is undefined.
        /// </summary>
        protected static double ldexp(double x, int exp) { throw _invalidAccess; }

        /// <summary>
        /// Builds a floating-point number from x and the corresponding integral exponent of two in exp, 
        /// returning: significand⋅2*+exponent
        /// If this product is too large to be represented in the floating-point type, the result is undefined.
        /// </summary>
        protected static dvec2 ldexp(dvec2 x, ivec2 exp) { throw _invalidAccess; }

        /// <summary>
        /// Builds a floating-point number from x and the corresponding integral exponent of two in exp, 
        /// returning: significand⋅2*+exponent
        /// If this product is too large to be represented in the floating-point type, the result is undefined.
        /// </summary>
        protected static dvec3 ldexp(dvec3 x, ivec3 exp) { throw _invalidAccess; }

        /// <summary>
        /// Builds a floating-point number from x and the corresponding integral exponent of two in exp, 
        /// returning: significand⋅2*+exponent
        /// If this product is too large to be represented in the floating-point type, the result is undefined.
        /// </summary>
        protected static dvec4 ldexp(dvec4 x, ivec4 exp) { throw _invalidAccess; }

        #endregion
    }
}

// ReSharper restore InconsistentNaming
