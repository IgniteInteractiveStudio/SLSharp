// ReSharper disable InconsistentNaming

using System;

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        // TODO: 
        //
        // unify sign()
        // GLSL has T1<T2> sign(T1<T2>) overloads
        // HLSL has T1<int> sign(T1<T2>) overloads
        // where T1 = scalar, vec, matrix (hlsl only)
        // and T2 = int, float, double (glsl only)
        //
        // emulate RoundEven in HLSL

        // These all operate component-wise. The description is per component.

        #region genType Abs(genType x)

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected internal static float Abs(float x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected internal static vec2 Abs(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected internal static vec3 Abs(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected internal static vec4 Abs(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genIType Abs(genIType x)

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected internal static int Abs(int x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected internal static ivec2 Abs(ivec2 x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected internal static ivec3 Abs(ivec3 x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected internal static ivec4 Abs(ivec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType Abs(genDType x)

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected internal static double Abs(double x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected internal static dvec2 Abs(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected internal static dvec3 Abs(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns x if x >= 0, otherwise it returns –x.</summary>
        /// <returns>The absolute value of x</returns>
        protected internal static dvec4 Abs(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Sign(genType x)

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected internal static float Sign(float x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected internal static vec2 Sign(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected internal static vec3 Sign(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected internal static vec4 Sign(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genIType Sign(genIType x)

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected internal static int Sign(int x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected internal static ivec2 Sign(ivec2 x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected internal static ivec3 Sign(ivec3 x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected internal static ivec4 Sign(ivec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType Sign(genType x)

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected internal static double Sign(double x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected internal static dvec2 Sign(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected internal static dvec3 Sign(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns 1.0 if x &gt; 0, 0.0 if x = 0, or –1.0 if x &lt; 0.</summary>
        /// <returns>The sign of x</returns>
        protected internal static dvec4 Sign(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Floor(genType x)

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected internal static float Floor(float x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected internal static vec2 Floor(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected internal static vec3 Floor(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected internal static vec4 Floor(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType Floor(genDType x)

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected internal static double Floor(double x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected internal static dvec2 Floor(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected internal static dvec3 Floor(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is less than or equal to x.</summary>
        protected internal static dvec4 Floor(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Trunc(genType x)

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected internal static float Trunc(float x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected internal static vec2 Trunc(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected internal static vec3 Trunc(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected internal static vec4 Trunc(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType Trunc(genDType x)

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected internal static double Trunc(double x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected internal static dvec2 Trunc(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected internal static dvec3 Trunc(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x whose
        /// absolute value is not larger than the absolute value of x.</summary>
        protected internal static dvec4 Trunc(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Round(genType x)

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that Round(x) returns the same value 
        /// as RoundEven(x) for all values of x.</summary>
        protected internal static float Round(float x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that Round(x) returns the same value 
        /// as RoundEven(x) for all values of x.</summary>
        protected internal static vec2 Round(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that Round(x) returns the same value 
        /// as RoundEven(x) for all values of x.</summary>
        protected internal static vec3 Round(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that Round(x) returns the same value 
        /// as RoundEven(x) for all values of x.</summary>
        protected internal static vec4 Round(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType Round(genType x)

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that Round(x) returns the same value 
        /// as RoundEven(x) for all values of x.</summary>
        protected internal static double Round(double x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that Round(x) returns the same value 
        /// as RoundEven(x) for all values of x.</summary>
        protected internal static dvec2 Round(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that Round(x) returns the same value 
        /// as RoundEven(x) for all values of x.</summary>
        protected internal static dvec3 Round(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// The fraction 0.5 will round in a direction chosen by the implementation, 
        /// presumably the direction that is fastest.
        /// This includes the possibility that Round(x) returns the same value 
        /// as RoundEven(x) for all values of x.</summary>
        protected internal static dvec4 Round(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType RoundEven(genType x)

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected internal static float RoundEven(float x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected internal static vec2 RoundEven(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected internal static vec3 RoundEven(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected internal static vec4 RoundEven(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType RoundEven(genDType x)

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected internal static double RoundEven(double x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected internal static dvec2 RoundEven(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected internal static dvec3 RoundEven(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer to x. 
        /// A fractional part of 0.5 will round toward the nearest even integer. 
        /// (Both 3.5 and 4.5 for x will return 4.0.)</summary>
        protected internal static dvec4 RoundEven(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Ceiling(genType x)

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected internal static float Ceiling(float x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected internal static vec2 Ceiling(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected internal static vec3 Ceiling(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected internal static vec4 Ceiling(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType Ceiling(genDType x)

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected internal static double Ceiling(double x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected internal static dvec2 Ceiling(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected internal static dvec3 Ceiling(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns a value equal to the nearest integer that is greater than or equal to x.</summary>
        protected internal static dvec4 Ceiling(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType Fraction(genType x)

        /// <summary>Returns x – Floor (x).</summary>
        protected internal static float Fraction(float x) { throw _invalidAccess; }

        /// <summary>Returns x – Floor (x).</summary>
        protected internal static vec2 Fraction(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns x – Floor (x).</summary>
        protected internal static vec3 Fraction(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns x – Floor (x).</summary>
        protected internal static vec4 Fraction(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType Fraction(genDType x)

        /// <summary>Returns x – Floor (x).</summary>
        protected internal static double Fraction(double x) { throw _invalidAccess; }

        /// <summary>Returns x – Floor (x).</summary>
        protected internal static dvec2 Fraction(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns x – Floor (x).</summary>
        protected internal static dvec3 Fraction(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns x – Floor (x).</summary>
        protected internal static dvec4 Fraction(dvec4 x) { throw _invalidAccess; }

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

        #region genType Min(genType x, float y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static float Min(float x, float y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static vec2 Min(vec2 x, float y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static vec3 Min(vec3 x, float y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static vec4 Min(vec4 x, float y) { throw _invalidAccess; }

        #endregion

        #region genType Min(genType x, genType y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static vec2 Min(vec2 x, vec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static vec3 Min(vec3 x, vec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static vec4 Min(vec4 x, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genDType Min(genDType x, double y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static double Min(double x, double y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static dvec2 Min(dvec2 x, double y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static dvec3 Min(dvec3 x, double y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static dvec4 Min(dvec4 x, double y) { throw _invalidAccess; }

        #endregion

        #region genDType Min(genDType x, genDType y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static dvec2 Min(dvec2 x, dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static dvec3 Min(dvec3 x, dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static dvec4 Min(dvec4 x, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region genIType Min(genIType x, int y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static int Min(int x, int y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static ivec2 Min(ivec2 x, int y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static ivec3 Min(ivec3 x, int y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static ivec4 Min(ivec4 x, int y) { throw _invalidAccess; }

        #endregion

        #region genIType Min(genIType x, genIType y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static ivec2 Min(ivec2 x, ivec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static ivec3 Min(ivec3 x, ivec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static ivec4 Min(ivec4 x, ivec4 y) { throw _invalidAccess; }

        #endregion

        #region genUType Min(genUType x, uint y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static uint Min(uint x, uint y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static uvec2 Min(uvec2 x, uint y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static uvec3 Min(uvec3 x, uint y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static uvec4 Min(uvec4 x, uint y) { throw _invalidAccess; }

        #endregion

        #region genUType Min(genUType x, genUType y)

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static uvec2 Min(uvec2 x, uvec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static uvec3 Min(uvec3 x, uvec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if y &lt; x, otherwise it returns x.</summary>
        protected internal static uvec4 Min(uvec4 x, uvec4 y) { throw _invalidAccess; }

        #endregion

        #region genType Max(genType x, float y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static float Max(float x, float y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static vec2 Max(vec2 x, float y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static vec3 Max(vec3 x, float y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static vec4 Max(vec4 x, float y) { throw _invalidAccess; }

        #endregion

        #region genType Max(genType x, genType y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static vec2 Max(vec2 x, vec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static vec3 Max(vec3 x, vec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static vec4 Max(vec4 x, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genDType Max(genDType x, double y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static double Max(double x, double y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static dvec2 Max(dvec2 x, double y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static dvec3 Max(dvec3 x, double y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static dvec4 Max(dvec4 x, double y) { throw _invalidAccess; }

        #endregion

        #region genDType Max(genDType x, genDType y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static dvec2 Max(dvec2 x, dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static dvec3 Max(dvec3 x, dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static dvec4 Max(dvec4 x, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region genIType Max(genIType x, int y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static int Max(int x, int y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static ivec2 Max(ivec2 x, int y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static ivec3 Max(ivec3 x, int y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static ivec4 Max(ivec4 x, int y) { throw _invalidAccess; }

        #endregion

        #region genIType Max(genIType x, genIType y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static ivec2 Max(ivec2 x, ivec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static ivec3 Max(ivec3 x, ivec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static ivec4 Max(ivec4 x, ivec4 y) { throw _invalidAccess; }

        #endregion

        #region genUType Max(genUType x, int y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static uint Max(uint x, uint y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static uvec2 Max(uvec2 x, uint y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static uvec3 Max(uvec3 x, uint y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static uvec4 Max(uvec4 x, uint y) { throw _invalidAccess; }

        #endregion

        #region genUType Max(genUType x, genUType y)

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static uvec2 Max(uvec2 x, uvec2 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static uvec3 Max(uvec3 x, uvec3 y) { throw _invalidAccess; }

        /// <summary>Returns y if x &lt; y, otherwise it returns x.</summary>
        protected internal static uvec4 Max(uvec4 x, uvec4 y) { throw _invalidAccess; }

        #endregion

        #region genType Clamp(genType x, float minVal, float maxVal)

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static float Clamp(float x, float minVal, float maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static vec2 Clamp(vec2 x, float minVal, float maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static vec3 Clamp(vec3 x, float minVal, float maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static vec4 Clamp(vec4 x, float minVal, float maxVal) { throw _invalidAccess; }

        #endregion

        #region genType Clamp(genType x, genType minVal, genType maxVal)

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static vec2 Clamp(vec2 x, vec2 minVal, vec2 maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static vec3 Clamp(vec3 x, vec3 minVal, vec3 maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static vec4 Clamp(vec4 x, vec4 minVal, vec4 maxVal) { throw _invalidAccess; }

        #endregion

        #region genDType Clamp(genDType x, double minVal, double maxVal)

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static double Clamp(double x, double minVal, double maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static dvec2 Clamp(dvec2 x, double minVal, double maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static dvec3 Clamp(dvec3 x, double minVal, double maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static dvec4 Clamp(dvec4 x, double minVal, double maxVal) { throw _invalidAccess; }

        #endregion

        #region genDType Clamp(genDType x, genDType minVal, genDType maxVal)

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static dvec2 Clamp(dvec2 x, dvec2 minVal, dvec2 maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static dvec3 Clamp(dvec3 x, dvec3 minVal, dvec3 maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static dvec4 Clamp(dvec4 x, dvec4 minVal, dvec4 maxVal) { throw _invalidAccess; }

        #endregion

        #region genIType Clamp(genIType x, int minVal, int maxVal)

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static int Clamp(int x, int minVal, int maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static ivec2 Clamp(ivec2 x, int minVal, int maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static ivec3 Clamp(ivec3 x, int minVal, int maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static ivec4 Clamp(ivec4 x, int minVal, int maxVal) { throw _invalidAccess; }

        #endregion

        #region genIType Clamp(genIType x, genIType minVal, genIType maxVal)

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static ivec2 Clamp(ivec2 x, ivec2 minVal, ivec2 maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static ivec3 Clamp(ivec3 x, ivec3 minVal, ivec3 maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static ivec4 Clamp(ivec4 x, ivec4 minVal, ivec4 maxVal) { throw _invalidAccess; }

        #endregion

        #region genUType Clamp(genUType x, uint minVal, uint maxVal)

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static uint Clamp(uint x, uint minVal, uint maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static uvec2 Clamp(uvec2 x, uint minVal, uint maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static uvec3 Clamp(uvec3 x, uint minVal, uint maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static uvec4 Clamp(uvec4 x, uint minVal, uint maxVal) { throw _invalidAccess; }

        #endregion

        #region genUType Clamp(genUType x, genUType minVal, genUType maxVal)

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static uvec2 Clamp(uvec2 x, uvec2 minVal, uvec2 maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static uvec3 Clamp(uvec3 x, uvec3 minVal, uvec3 maxVal) { throw _invalidAccess; }

        /// <summary>Returns Min (Max (x, minVal), maxVal). Results are undefined if minVal > maxVal.</summary>
        protected internal static uvec4 Clamp(uvec4 x, uvec4 minVal, uvec4 maxVal) { throw _invalidAccess; }

        #endregion

        #region genType Lerp(genType x, genType y, float a)

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected internal static float Lerp(float x, float y, float a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected internal static vec2 Lerp(vec2 x, vec2 y, float a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected internal static vec3 Lerp(vec3 x, vec3 y, float a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected internal static vec4 Lerp(vec4 x, vec4 y, float a) { throw _invalidAccess; }

        #endregion

        #region genType Lerp(genType x, genType y, genType a)

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected internal static vec2 Lerp(vec2 x, vec2 y, vec2 a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected internal static vec3 Lerp(vec3 x, vec3 y, vec3 a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected internal static vec4 Lerp(vec4 x, vec4 y, vec4 a) { throw _invalidAccess; }

        #endregion

        #region genDType Lerp(genDType x, genDType y, double a)

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected internal static double Lerp(double x, double y, double a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected internal static dvec2 Lerp(dvec2 x, dvec2 y, double a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected internal static dvec3 Lerp(dvec3 x, dvec3 y, double a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected internal static dvec4 Lerp(dvec4 x, dvec4 y, double a) { throw _invalidAccess; }

        #endregion

        #region genDType Lerp(genDType x, genDType y, genDType a)

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected internal static dvec2 Lerp(dvec2 x, dvec2 y, dvec2 a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected internal static dvec3 Lerp(dvec3 x, dvec3 y, dvec3 a) { throw _invalidAccess; }

        /// <summary>Returns the linear blend of x and y, i.e., x*(1−a) + y*a</summary>
        protected internal static dvec4 Lerp(dvec4 x, dvec4 y, dvec4 a) { throw _invalidAccess; }

        #endregion

        #region genType Lerp (genType x, genType y, genBType a)

        /// <summary>
        /// Selects which vector each returned component comes from. For a component of a that is false, 
        /// the corresponding component of x is returned. For a component of a that is true, 
        /// the corresponding component of y is returned. Components of x and y that are not selected 
        /// are allowed to be invalid floating point values and will have no effect on the results. 
        /// Thus, this provides different functionality than, for example,
        /// genType Lerp(genType x, genType y, genType(a)) where a is a Boolean vector.
        /// </summary>
        protected internal static float Lerp(float x, float y, bool a) { throw _invalidAccess; }

        /// <summary>
        /// Selects which vector each returned component comes from. For a component of a that is false, 
        /// the corresponding component of x is returned. For a component of a that is true, 
        /// the corresponding component of y is returned. Components of x and y that are not selected 
        /// are allowed to be invalid floating point values and will have no effect on the results. 
        /// Thus, this provides different functionality than, for example,
        /// genType Lerp(genType x, genType y, genType(a)) where a is a Boolean vector.
        /// </summary>
        protected internal static vec2 Lerp(vec2 x, vec2 y, bvec2 a) { throw _invalidAccess; }

        /// <summary>
        /// Selects which vector each returned component comes from. For a component of a that is false, 
        /// the corresponding component of x is returned. For a component of a that is true, 
        /// the corresponding component of y is returned. Components of x and y that are not selected 
        /// are allowed to be invalid floating point values and will have no effect on the results. 
        /// Thus, this provides different functionality than, for example,
        /// genType Lerp(genType x, genType y, genType(a)) where a is a Boolean vector.
        /// </summary>
        protected internal static vec3 Lerp(vec3 x, vec3 y, bvec3 a) { throw _invalidAccess; }

        /// <summary>
        /// Selects which vector each returned component comes from. For a component of a that is false, 
        /// the corresponding component of x is returned. For a component of a that is true, 
        /// the corresponding component of y is returned. Components of x and y that are not selected 
        /// are allowed to be invalid floating point values and will have no effect on the results. 
        /// Thus, this provides different functionality than, for example,
        /// genType Lerp(genType x, genType y, genType(a)) where a is a Boolean vector.
        /// </summary>
        protected internal static vec4 Lerp(vec4 x, vec4 y, bvec4 a) { throw _invalidAccess; }

        #endregion

        #region genDType Lerp (genDType x, genDType y, genBType a)

        /// <summary>
        /// Selects which vector each returned component comes from. For a component of a that is false, 
        /// the corresponding component of x is returned. For a component of a that is true, 
        /// the corresponding component of y is returned. Components of x and y that are not selected 
        /// are allowed to be invalid floating point values and will have no effect on the results. 
        /// Thus, this provides different functionality than, for example,
        /// genType Lerp(genType x, genType y, genType(a)) where a is a Boolean vector.
        /// </summary>
        protected internal static double Lerp(double x, double y, bool a) { throw _invalidAccess; }

        /// <summary>
        /// Selects which vector each returned component comes from. For a component of a that is false, 
        /// the corresponding component of x is returned. For a component of a that is true, 
        /// the corresponding component of y is returned. Components of x and y that are not selected 
        /// are allowed to be invalid floating point values and will have no effect on the results. 
        /// Thus, this provides different functionality than, for example,
        /// genType Lerp(genType x, genType y, genType(a)) where a is a Boolean vector.
        /// </summary>
        protected internal static dvec2 Lerp(dvec2 x, dvec2 y, bvec2 a) { throw _invalidAccess; }

        /// <summary>
        /// Selects which vector each returned component comes from. For a component of a that is false, 
        /// the corresponding component of x is returned. For a component of a that is true, 
        /// the corresponding component of y is returned. Components of x and y that are not selected 
        /// are allowed to be invalid floating point values and will have no effect on the results. 
        /// Thus, this provides different functionality than, for example,
        /// genType Lerp(genType x, genType y, genType(a)) where a is a Boolean vector.
        /// </summary>
        protected internal static dvec3 Lerp(dvec3 x, dvec3 y, bvec3 a) { throw _invalidAccess; }

        /// <summary>
        /// Selects which vector each returned component comes from. For a component of a that is false, 
        /// the corresponding component of x is returned. For a component of a that is true, 
        /// the corresponding component of y is returned. Components of x and y that are not selected 
        /// are allowed to be invalid floating point values and will have no effect on the results. 
        /// Thus, this provides different functionality than, for example,
        /// genType Lerp(genType x, genType y, genType(a)) where a is a Boolean vector.
        /// </summary>
        protected internal static dvec4 Lerp(dvec4 x, dvec4 y, bvec4 a) { throw _invalidAccess; }

        #endregion

        #region genType Step(float edge, genType x)

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected internal static float Step(float edge, float y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected internal static vec2 Step(float edge, vec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected internal static vec3 Step(float edge, vec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected internal static vec4 Step(float edge, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genType Step(genType edge, genType x)

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected internal static vec2 Step(vec2 edge, vec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected internal static vec3 Step(vec3 edge, vec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected internal static vec4 Step(vec4 edge, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genDType Step(double edge, genDType x)

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected internal static double Step(double edge, double y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected internal static dvec2 Step(double edge, dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected internal static dvec3 Step(double edge, dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected internal static dvec4 Step(double edge, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region genDType Step(genDType edge, genDType x)

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected internal static dvec2 Step(dvec2 edge, dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected internal static dvec3 Step(dvec3 edge, dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge, otherwise it returns 1.0.</summary>
        protected internal static dvec4 Step(dvec4 edge, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region genType SmoothStep(float edge0, float step1, genType x)

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected internal static float SmoothStep(float edge0, float edge1, float y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected internal static vec2 SmoothStep(float edge0, float edge1, vec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected internal static vec3 SmoothStep(float edge0, float edge1, vec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected internal static vec4 SmoothStep(float edge0, float edge1, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genType SmoothStep(genType edge0, genType step1, genType x)

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected internal static vec2 SmoothStep(vec2 edge0, vec2 edge1, vec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected internal static vec3 SmoothStep(vec3 edge0, vec3 edge1, vec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected internal static vec4 SmoothStep(vec4 edge0, vec4 edge1, vec4 y) { throw _invalidAccess; }

        #endregion

        #region genDType SmoothStep(double edge0, double step1, genDType x)

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected internal static double SmoothStep(double edge0, double edge1, double y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected internal static dvec2 SmoothStep(double edge0, double edge1, dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected internal static dvec3 SmoothStep(double edge0, double edge1, dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected internal static dvec4 SmoothStep(double edge0, double edge1, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region genDType SmoothStep(genDType edge0, genDType step1, genDType x)

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected internal static dvec2 SmoothStep(dvec2 edge0, dvec2 edge1, dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected internal static dvec3 SmoothStep(dvec3 edge0, dvec3 edge1, dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns 0.0 if x &lt; edge0 and 1.0 if x &gt;= edge1 and
        /// performs smooth Hermite interpolation between 0 and 1 when edge0 &lt; x &lt; edge1.
        /// This is useful in cases where you would want a threshold function with a smooth
        /// transition.</summary>
        protected internal static dvec4 SmoothStep(dvec4 edge0, dvec4 edge1, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region genBType IsNaN (genType x)

        /// <summary>Returns true if x holds a NaN. Returns false otherwise.</summary>
        protected internal static bool IsNaN(float x) { throw _invalidAccess; }

        /// <summary>Returns true if x holds a NaN. Returns false otherwise.</summary>
        protected internal static bvec2 IsNaN(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns true if x holds a NaN. Returns false otherwise.</summary>
        protected internal static bvec3 IsNaN(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns true if x holds a NaN. Returns false otherwise.</summary>
        protected internal static bvec4 IsNaN(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genBType IsNaN (genDType x)

        /// <summary>Returns true if x holds a NaN. Returns false otherwise.</summary>
        protected internal static bool IsNaN(double x) { throw _invalidAccess; }

        /// <summary>Returns true if x holds a NaN. Returns false otherwise.</summary>
        protected internal static bvec2 IsNaN(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns true if x holds a NaN. Returns false otherwise.</summary>
        protected internal static bvec3 IsNaN(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns true if x holds a NaN. Returns false otherwise.</summary>
        protected internal static bvec4 IsNaN(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genBType IsInfinity (genType x)

        /// <summary>Returns true if x holds a positive infinity or negative infinity. 
        /// Returns false otherwise.</summary>
        protected internal static bool IsInfinity(float x) { throw _invalidAccess; }

        /// <summary>Returns true if x holds a positive infinity or negative infinity. 
        /// Returns false otherwise.</summary>
        protected internal static bvec2 IsInfinity(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns true if x holds a positive infinity or negative infinity. 
        /// Returns false otherwise.</summary>
        protected internal static bvec3 IsInfinity(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns true if x holds a positive infinity or negative infinity. 
        /// Returns false otherwise.</summary>
        protected internal static bvec4 IsInfinity(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genBType IsInfinity (genDType x)

        /// <summary>Returns true if x holds a positive infinity or negative infinity. 
        /// Returns false otherwise.</summary>
        protected internal static bool IsInfinity(double x) { throw _invalidAccess; }

        /// <summary>Returns true if x holds a positive infinity or negative infinity. 
        /// Returns false otherwise.</summary>
        protected internal static bvec2 IsInfinity(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns true if x holds a positive infinity or negative infinity. 
        /// Returns false otherwise.</summary>
        protected internal static bvec3 IsInfinity(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns true if x holds a positive infinity or negative infinity. 
        /// Returns false otherwise.</summary>
        protected internal static bvec4 IsInfinity(dvec4 x) { throw _invalidAccess; }

        #endregion

        // use public static explicit operator Int(Float) here

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

        #region genType FusedMultiplyAdd(genType a, genType b, genType c)

        /// <summary>Computes and returns a*b + c.</summary>
        protected internal static float FusedMultiplyAdd(float a, float b, float c) { throw _invalidAccess; }

        /// <summary>Computes and returns a*b + c.</summary>
        protected internal static vec2 FusedMultiplyAdd(vec2 a, vec2 b, vec2 c) { throw _invalidAccess; }

        /// <summary>Computes and returns a*b + c.</summary>
        protected internal static vec3 FusedMultiplyAdd(vec3 a, vec3 b, vec3 c) { throw _invalidAccess; }

        /// <summary>Computes and returns a*b + c.</summary>
        protected internal static vec4 FusedMultiplyAdd(vec4 a, vec4 b, vec4 c) { throw _invalidAccess; }

        #endregion

        #region genDType FusedMultiplyAdd(genDType a, genDType b, genDType c)

        /// <summary>Computes and returns a*b + c.</summary>
        protected internal static double FusedMultiplyAdd(double a, double b, double c) { throw _invalidAccess; }

        /// <summary>Computes and returns a*b + c.</summary>
        protected internal static dvec2 FusedMultiplyAdd(dvec2 a, dvec2 b, dvec2 c) { throw _invalidAccess; }

        /// <summary>Computes and returns a*b + c.</summary>
        protected internal static dvec3 FusedMultiplyAdd(dvec3 a, dvec3 b, dvec3 c) { throw _invalidAccess; }

        /// <summary>Computes and returns a*b + c.</summary>
        protected internal static dvec4 FusedMultiplyAdd(dvec4 a, dvec4 b, dvec4 c) { throw _invalidAccess; }

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
