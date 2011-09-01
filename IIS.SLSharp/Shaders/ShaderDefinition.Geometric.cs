// ReSharper disable InconsistentNaming

using System;

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        // These operate on vectors as vectors, not component-wise.

        #region float Length(genType x)

        /// <summary>Returns the length of vector x</summary>
        protected internal static float Length(float x) { throw _invalidAccess; }

        /// <summary>Returns the length of vector x</summary>
        protected internal static float Length(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns the length of vector x</summary>
        protected internal static float Length(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns the length of vector x</summary>
        protected internal static float Length(vec4 x) { throw _invalidAccess; }

        #endregion

        #region double Length(genDType x)

        /// <summary>Returns the length of vector x</summary>
        protected internal static double Length(double x) { throw _invalidAccess; }

        /// <summary>Returns the length of vector x</summary>
        protected internal static double Length(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns the length of vector x</summary>
        protected internal static double Length(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns the length of vector x</summary>
        protected internal static double Length(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region float Distance(genType p0, genType p1)

        /// <summary>Returns the distance between p0 and p1, i.e., Length (p0 – p1)</summary>
        protected internal static float Distance(float p0, float p1) { throw _invalidAccess; }

        /// <summary>Returns the distance between p0 and p1, i.e., Length (p0 – p1)</summary>
        protected internal static float Distance(vec2 p0, vec2 p1) { throw _invalidAccess; }

        /// <summary>Returns the distance between p0 and p1, i.e., Length (p0 – p1)</summary>
        protected internal static float Distance(vec3 p0, vec3 p1) { throw _invalidAccess; }

        /// <summary>Returns the distance between p0 and p1, i.e., Length (p0 – p1)</summary>
        protected internal static float Distance(vec4 p0, vec4 p1) { throw _invalidAccess; }

        #endregion

        #region double Distance(genDType p0, genDType p1)

        /// <summary>Returns the distance between p0 and p1, i.e., Length (p0 – p1)</summary>
        protected internal static double Distance(double p0, double p1) { throw _invalidAccess; }

        /// <summary>Returns the distance between p0 and p1, i.e., Length (p0 – p1)</summary>
        protected internal static double Distance(dvec2 p0, dvec2 p1) { throw _invalidAccess; }

        /// <summary>Returns the distance between p0 and p1, i.e., Length (p0 – p1)</summary>
        protected internal static double Distance(dvec3 p0, dvec3 p1) { throw _invalidAccess; }

        /// <summary>Returns the distance between p0 and p1, i.e., Length (p0 – p1)</summary>
        protected internal static double Distance(dvec4 p0, dvec4 p1) { throw _invalidAccess; }

        #endregion

        #region float Dot(genType x, genType y)

        /// <summary>Returns the dot product of x and y</summary>
        protected internal static float Dot(float x, float y) { throw _invalidAccess; }

        /// <summary>Returns the dot product of x and y</summary>
        protected internal static float Dot(vec2 x, vec2 y) { throw _invalidAccess; }

        /// <summary>Returns the dot product of x and y</summary>
        protected internal static float Dot(vec3 x, vec3 y) { throw _invalidAccess; }

        /// <summary>Returns the dot product of x and y</summary>
        protected internal static float Dot(vec4 x, vec4 y) { throw _invalidAccess; }

        #endregion

        #region double Dot(genDType x, genDType y)

        /// <summary>Returns the dot product of x and y</summary>
        protected internal static double Dot(double x, double y) { throw _invalidAccess; }

        /// <summary>Returns the dot product of x and y</summary>
        protected internal static double Dot(dvec2 x, dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns the dot product of x and y</summary>
        protected internal static double Dot(dvec3 x, dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns the dot product of x and y</summary>
        protected internal static double Dot(dvec4 x, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region vec3 Cross(vec3 x, vec3 y)

        /// <summary>Returns the cross product of x and y</summary>
        protected internal static vec3 Cross(vec3 x, vec3 y) { throw _invalidAccess; }

        #endregion

        #region dvec3 Cross(dvec3 x, dvec3 y)

        /// <summary>Returns the cross product of x and y</summary>
        protected internal static dvec3 Cross(dvec3 x, dvec3 y) { throw _invalidAccess; }

        #endregion

        #region genType Normalize(genType x)

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected internal static float Normalize(float x) { throw _invalidAccess; }

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected internal static vec2 Normalize(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected internal static vec3 Normalize(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected internal static vec4 Normalize(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType Normalize(genDType x)

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected internal static double Normalize(double x) { throw _invalidAccess; }

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected internal static dvec2 Normalize(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected internal static dvec3 Normalize(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected internal static dvec4 Normalize(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region genType FaceForward (genType N, genType I, genType Nref)

        /// <summary>If Dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected internal static float FaceForward(float N, float I, float Nref) { throw _invalidAccess; }

        /// <summary>If Dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected internal static vec2 FaceForward(vec2 N, vec2 I, vec2 Nref) { throw _invalidAccess; }

        /// <summary>If Dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected internal static vec3 FaceForward(vec3 N, vec3 I, vec3 Nref) { throw _invalidAccess; }

        /// <summary>If Dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected internal static vec4 FaceForward(vec4 N, vec4 I, vec4 Nref) { throw _invalidAccess; }

        #endregion

        #region genDType FaceForward (genDType N, genDType I, genDType Nref)

        /// <summary>If Dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected static internal double FaceForward(double N, double I, double Nref) { throw _invalidAccess; }

        /// <summary>If Dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected static internal dvec2 FaceForward(dvec2 N, dvec2 I, dvec2 Nref) { throw _invalidAccess; }

        /// <summary>If Dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected static internal dvec3 FaceForward(dvec3 N, dvec3 I, dvec3 Nref) { throw _invalidAccess; }

        /// <summary>If Dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected static internal dvec4 FaceForward(dvec4 N, dvec4 I, dvec4 Nref) { throw _invalidAccess; }

        #endregion

        #region genType Reflect (genType I, genType N)

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * Dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected internal static float Reflect(float I, float N) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * Dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected internal static vec2 Reflect(vec2 I, vec2 N) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * Dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected internal static vec3 Reflect(vec3 I, vec3 N) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * Dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected internal static vec4 Reflect(vec4 I, vec4 N) { throw _invalidAccess; }

        #endregion

        #region genDType Reflect (genDType I, genDType N)

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * Dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected internal static double Reflect(double I, double N) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * Dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected internal static dvec2 Reflect(dvec2 I, dvec2 N) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * Dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected internal static dvec3 Reflect(dvec3 I, dvec3 N) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * Dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected internal static dvec4 Reflect(dvec4 I, dvec4 N) { throw _invalidAccess; }

        #endregion

        #region genType Refract (genType I, genType N, float eta)

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - Dot(N, I) * Dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * Dot(N, I) + Sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected internal static float Refract(float I, float N, float eta) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - Dot(N, I) * Dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * Dot(N, I) + Sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected internal static vec2 Refract(vec2 I, vec2 N, float eta) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - Dot(N, I) * Dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * Dot(N, I) + Sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected internal static vec3 Refract(vec3 I, vec3 N, float eta) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - Dot(N, I) * Dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * Dot(N, I) + Sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected internal static vec4 Refract(vec4 I, vec4 N, float eta) { throw _invalidAccess; }

        #endregion

        #region genDType Refract (genDType I, genDType N, double eta)

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - Dot(N, I) * Dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * Dot(N, I) + Sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected internal static double Refract(double I, double N, double eta) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - Dot(N, I) * Dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * Dot(N, I) + Sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected internal static dvec2 Refract(dvec2 I, dvec2 N, double eta) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - Dot(N, I) * Dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * Dot(N, I) + Sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected internal static dvec3 Refract(dvec3 I, dvec3 N, double eta) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - Dot(N, I) * Dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * Dot(N, I) + Sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected internal static dvec4 Refract(dvec4 I, dvec4 N, double eta) { throw _invalidAccess; }

        #endregion
    }
}

// ReSharper restore InconsistentNaming
