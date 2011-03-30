// ReSharper disable InconsistentNaming

namespace IIS.SLSharp
{
    public abstract partial class ShaderDefinition
    {
        // These operate on vectors as vectors, not component-wise.

        #region float length(genType x)

        /// <summary>Returns the length of vector x</summary>
        protected static float length(float x) { throw _invalidAccess; }

        /// <summary>Returns the length of vector x</summary>
        protected static float length(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns the length of vector x</summary>
        protected static float length(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns the length of vector x</summary>
        protected static float length(vec4 x) { throw _invalidAccess; }

        #endregion

        #region double length(genDType x)

        /// <summary>Returns the length of vector x</summary>
        protected static double length(double x) { throw _invalidAccess; }

        /// <summary>Returns the length of vector x</summary>
        protected static double length(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns the length of vector x</summary>
        protected static double length(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns the length of vector x</summary>
        protected static double length(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region float distance(genType p0, genType p1)

        /// <summary>Returns the distance between p0 and p1, i.e., length (p0 – p1)</summary>
        protected static float distance(float p0, float p1) { throw _invalidAccess; }

        /// <summary>Returns the distance between p0 and p1, i.e., length (p0 – p1)</summary>
        protected static float distance(vec2 p0, vec2 p1) { throw _invalidAccess; }

        /// <summary>Returns the distance between p0 and p1, i.e., length (p0 – p1)</summary>
        protected static float distance(vec3 p0, vec3 p1) { throw _invalidAccess; }

        /// <summary>Returns the distance between p0 and p1, i.e., length (p0 – p1)</summary>
        protected static float distance(vec4 p0, vec4 p1) { throw _invalidAccess; }

        #endregion

        #region double distance(genDType p0, genDType p1)

        /// <summary>Returns the distance between p0 and p1, i.e., length (p0 – p1)</summary>
        protected static double distance(double p0, double p1) { throw _invalidAccess; }

        /// <summary>Returns the distance between p0 and p1, i.e., length (p0 – p1)</summary>
        protected static double distance(dvec2 p0, dvec2 p1) { throw _invalidAccess; }

        /// <summary>Returns the distance between p0 and p1, i.e., length (p0 – p1)</summary>
        protected static double distance(dvec3 p0, dvec3 p1) { throw _invalidAccess; }

        /// <summary>Returns the distance between p0 and p1, i.e., length (p0 – p1)</summary>
        protected static double distance(dvec4 p0, dvec4 p1) { throw _invalidAccess; }

        #endregion

        #region float dot(genType x, genType y)

        /// <summary>Returns the dot product of x and y</summary>
        protected static float dot(float x, float y) { throw _invalidAccess; }

        /// <summary>Returns the dot product of x and y</summary>
        protected static float dot(vec2 x, vec2 y) { throw _invalidAccess; }

        /// <summary>Returns the dot product of x and y</summary>
        protected static float dot(vec3 x, vec3 y) { throw _invalidAccess; }

        /// <summary>Returns the dot product of x and y</summary>
        protected static float dot(vec4 x, vec4 y) { throw _invalidAccess; }

        #endregion

        #region double dot(genDType x, genDType y)

        /// <summary>Returns the dot product of x and y</summary>
        protected static double dot(double x, double y) { throw _invalidAccess; }

        /// <summary>Returns the dot product of x and y</summary>
        protected static double dot(dvec2 x, dvec2 y) { throw _invalidAccess; }

        /// <summary>Returns the dot product of x and y</summary>
        protected static double dot(dvec3 x, dvec3 y) { throw _invalidAccess; }

        /// <summary>Returns the dot product of x and y</summary>
        protected static double dot(dvec4 x, dvec4 y) { throw _invalidAccess; }

        #endregion

        #region vec3 cross(vec3 x, vec3 y)

        /// <summary>Returns the cross product of x and y</summary>
        protected static vec3 cross(vec3 x, vec3 y) { throw _invalidAccess; }

        #endregion

        #region dvec3 cross(dvec3 x, dvec3 y)

        /// <summary>Returns the cross product of x and y</summary>
        protected static dvec3 cross(dvec3 x, dvec3 y) { throw _invalidAccess; }

        #endregion

        #region genType normalize(genType x)

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected static float normalize(float x) { throw _invalidAccess; }

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected static vec2 normalize(vec2 x) { throw _invalidAccess; }

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected static vec3 normalize(vec3 x) { throw _invalidAccess; }

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected static vec4 normalize(vec4 x) { throw _invalidAccess; }

        #endregion

        #region genDType normalize(genDType x)

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected static double normalize(double x) { throw _invalidAccess; }

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected static dvec2 normalize(dvec2 x) { throw _invalidAccess; }

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected static dvec3 normalize(dvec3 x) { throw _invalidAccess; }

        /// <summary>Returns a vector in the same direction as x but with a length of 1.</summary>
        protected static dvec4 normalize(dvec4 x) { throw _invalidAccess; }

        #endregion

        #region vec4 ftransform()

        /// <summary>
        /// compatibility profile only
        /// For vertex shaders only. This function will ensure that the incoming vertex value 
        /// will be transformed in a way that produces exactly the same result as would be 
        /// produced by OpenGL’s fixed functionality transform. It is intended to be used to 
        /// compute gl_Position, e.g.,
        /// gl_Position = ftransform()
        /// This function should be used, for example, when an application is rendering the same 
        /// geometry in separate passes, and one pass uses the fixed functionality path to 
        /// render and another pass uses programmable shaders.
        /// </summary>
        protected static vec4 ftransform() { throw _invalidAccess; }

        #endregion

        #region genType faceforward (genType N, genType I, genType Nref)

        /// <summary>If dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected static float faceforward(float N, float I, float Nref) { throw _invalidAccess; }

        /// <summary>If dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected static vec2 faceforward(vec2 N, vec2 I, vec2 Nref) { throw _invalidAccess; }

        /// <summary>If dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected static vec3 faceforward(vec3 N, vec3 I, vec3 Nref) { throw _invalidAccess; }

        /// <summary>If dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected static vec4 faceforward(vec4 N, vec4 I, vec4 Nref) { throw _invalidAccess; }

        #endregion

        #region genDType faceforward (genDType N, genDType I, genDType Nref)

        /// <summary>If dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected static double faceforward(double N, double I, double Nref) { throw _invalidAccess; }

        /// <summary>If dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected static dvec2 faceforward(dvec2 N, dvec2 I, dvec2 Nref) { throw _invalidAccess; }

        /// <summary>If dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected static dvec3 faceforward(dvec3 N, dvec3 I, dvec3 Nref) { throw _invalidAccess; }

        /// <summary>If dot(Nref, I) &lt; 0 return N, otherwise return –N.</summary>
        protected static dvec4 faceforward(dvec4 N, dvec4 I, dvec4 Nref) { throw _invalidAccess; }

        #endregion

        #region genType reflect (genType I, genType N)

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected static float reflect(float I, float N) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected static vec2 reflect(vec2 I, vec2 N) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected static vec3 reflect(vec3 I, vec3 N) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected static vec4 reflect(vec4 I, vec4 N) { throw _invalidAccess; }

        #endregion

        #region genDType reflect (genDType I, genDType N)

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected static double reflect(double I, double N) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected static dvec2 reflect(dvec2 I, dvec2 N) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected static dvec3 reflect(dvec3 I, dvec3 N) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface orientation N,
        /// returns the reflection direction: 
        /// I – 2 * dot(N, I) * N
        /// N must already be normalized in order to achieve the desired result..</summary>
        /// <param name="I">The incident vector</param>
        /// <param name="N">The normal to reflect around</param>
        /// <returns>The reflected vector</returns>
        protected static dvec4 reflect(dvec4 I, dvec4 N) { throw _invalidAccess; }

        #endregion

        #region genType refract (genType I, genType N)

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - dot(N, I) * dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * dot(N, I) + sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected static float refract(float I, float N, float eta) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - dot(N, I) * dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * dot(N, I) + sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected static vec2 refract(vec2 I, vec2 N, float eta) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - dot(N, I) * dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * dot(N, I) + sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected static vec3 refract(vec3 I, vec3 N, float eta) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - dot(N, I) * dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * dot(N, I) + sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected static vec4 refract(vec4 I, vec4 N, float eta) { throw _invalidAccess; }

        #endregion

        #region genDType refract (genDType I, genDType N)

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - dot(N, I) * dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * dot(N, I) + sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected static double refract(double I, double N, double eta) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - dot(N, I) * dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * dot(N, I) + sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected static dvec2 refract(dvec2 I, dvec2 N, double eta) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - dot(N, I) * dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * dot(N, I) + sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected static dvec3 refract(dvec3 I, dvec3 N, double eta) { throw _invalidAccess; }

        /// <summary>For the incident vector I and surface normal N, and the ratio of indices 
        /// of refraction eta, return the refraction vector. 
        /// The result is computed by
        /// <code>
        /// k = 1.0 - eta * eta * (1.0 - dot(N, I) * dot(N, I))
        /// if (k &lt; 0.0)
        ///   return genType(0.0) // or genDType(0.0)
        /// else
        /// return eta * I - (eta * dot(N, I) + sqrt(k)) * N
        /// </code>
        /// The input parameters for the incident vector I and the surface normal N must 
        /// already be normalized to get thedesired results.</summary>
        protected static dvec4 refract(dvec4 I, dvec4 N, double eta) { throw _invalidAccess; }

        #endregion
    }
}

// ReSharper restore InconsistentNaming
