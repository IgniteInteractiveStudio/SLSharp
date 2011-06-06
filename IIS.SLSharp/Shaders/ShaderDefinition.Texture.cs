using System;

// ReSharper disable InconsistentNaming

namespace IIS.SLSharp.Shaders
{
    // TODO: textureGather textureGatherOffset textureGatherOffsets and deprecated funcs

    public abstract partial class ShaderDefinition
    {
        #region Deprecated 120 functions

        [Obsolete("Deprecated with v130", true)]
        protected static vec4 texture1D(sampler1D sampler, float s)
        {
            throw _invalidAccess;
        }

        [Obsolete("Deprecated with v130", true)]
        protected static vec4 texture2D(sampler2D sampler, vec2 st)
        {
            throw _invalidAccess;
        }

        [Obsolete("Deprecated with v130", true)]
        protected static vec4 texture2D(sampler2D sampler, vec2 st, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region textureSize

        #region int textureSize (gsampler1D sampler, int lod)

        protected static int textureSize(sampler1D sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected static int textureSize(isampler1D sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected static int textureSize(usampler1D sampler, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region ivec2 textureSize (gsampler2D sampler, int lod)

        protected static ivec2 textureSize(sampler2D sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected static ivec2 textureSize(isampler2D sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected static ivec2 textureSize(usampler2D sampler, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region ivec3 textureSize (gsampler3D sampler, int lod)

        protected static ivec3 textureSize(sampler3D sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected static ivec3 textureSize(isampler3D sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected static ivec3 textureSize(usampler3D sampler, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region ivec2 textureSize (gsamplerCube sampler, int lod)

        protected static ivec2 textureSize(samplerCube sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected static ivec2 textureSize(isamplerCube sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected static ivec2 textureSize(usamplerCube sampler, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region int textureSize (sampler1DShadow sampler, int lod)

        protected static int textureSize (sampler1DShadow sampler, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region ivec2 textureSize (sampler2DShadow sampler, int lod)

        protected static ivec2 textureSize (sampler2DShadow sampler, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region ivec2 textureSize (samplerCubeShadow sampler, int lod)

        protected static ivec2 textureSize(samplerCubeShadow sampler, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region ivec2 textureSize (gsampler2DRect sampler)

        protected static ivec2 textureSize(sampler2DRect sampler)
        {
            throw _invalidAccess;
        }

        protected static ivec2 textureSize(isampler2DRect sampler)
        {
            throw _invalidAccess;
        }

        protected static ivec2 textureSize(usampler2DRect sampler)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region textureQueryLod

        #region vec2 textureQueryLod(gsampler1D sampler, float P)

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(sampler1D sampler, float P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(isampler1D sampler, float P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(usampler1D sampler, float P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region vec2 textureQueryLod(gsampler2D sampler, vec2 P)

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(sampler2D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(isampler2D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(usampler2D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region vec2 textureQueryLod(gsampler3D sampler, vec3 P)

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(sampler3D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(isampler3D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(usampler3D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region vec2 textureQueryLod(gsamplerCube sampler, vec3 P)

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(samplerCube sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(isamplerCube sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(usamplerCube sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region vec2 textureQueryLod(sampler1DShadow sampler, float P)

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(sampler1DShadow sampler, float P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region vec2 textureQueryLod(sampler2DShadow sampler, vec2 P)

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(sampler2DShadow sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region vec2 textureQueryLod(samplerCubeShadow sampler, vec3 P)

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected static vec2 textureQueryLod(samplerCubeShadow sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region texture

        #region gvec4 texture (gsampler1D sampler, float P [, float bias] )

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static vec4 texture(sampler1D sampler, float s)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static vec4 texture(sampler1D sampler, float s, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static ivec4 texture(isampler1D sampler, float s)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static ivec4 texture(isampler1D sampler, float s, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static uvec4 texture(usampler1D sampler, float s)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static uvec4 texture(usampler1D sampler, float s, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 texture (gsampler2D sampler, vec2 P [, float bias] )

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static vec4 texture(sampler2D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static vec4 texture(sampler2D sampler, vec2 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static ivec4 texture(isampler2D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static ivec4 texture(isampler2D sampler, vec2 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static uvec4 texture(usampler2D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static uvec4 texture(usampler2D sampler, vec2 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 texture (gsampler3D sampler, vec3 P [, float bias] )

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static vec4 texture(sampler3D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static vec4 texture(sampler3D sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static ivec4 texture(isampler3D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static ivec4 texture(isampler3D sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static uvec4 texture(usampler3D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static uvec4 texture(usampler3D sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 texture (gsamplerCube sampler, vec3 P [, float bias] )

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static vec4 texture(samplerCube sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static vec4 texture(samplerCube sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static ivec4 texture(isamplerCube sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static ivec4 texture(isamplerCube sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static uvec4 texture(usamplerCube sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static uvec4 texture(usamplerCube sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float texture (sampler1DShadow sampler, vec3 P [, float bias] )

        /// <summary>
        /// Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.
        /// When compare is present, it is used as Dref and the array layer comes from P.w. 
        /// When compare is not present, the last component of P is used as Dref and 
        /// the array layer comes from the second to last component of P. 
        /// (The second component of P isunused for 1D shadow lookups.)
        /// </summary>
        protected static float texture(sampler1DShadow sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.
        /// When compare is present, it is used as Dref and the array layer comes from P.w. 
        /// When compare is not present, the last component of P is used as Dref and 
        /// the array layer comes from the second to last component of P. 
        /// (The second component of P isunused for 1D shadow lookups.)
        /// </summary>
        protected static float texture(sampler1DShadow sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float texture (sampler2DShadow sampler, vec3 P [, float bias] )

        /// <summary>
        /// Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.
        /// When compare is present, it is used as Dref and the array layer comes from P.w. 
        /// When compare is not present, the last component of P is used as Dref and 
        /// the array layer comes from the second to last component of P. 
        /// (The second component of P isunused for 1D shadow lookups.)
        /// </summary>
        protected static float texture(sampler2DShadow sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.
        /// When compare is present, it is used as Dref and the array layer comes from P.w. 
        /// When compare is not present, the last component of P is used as Dref and 
        /// the array layer comes from the second to last component of P. 
        /// (The second component of P isunused for 1D shadow lookups.)
        /// </summary>
        protected static float texture(sampler2DShadow sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float texture (samplerCubeShadow sampler, vec4 P [, float bias] )

        /// <summary>
        /// Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.
        /// When compare is present, it is used as Dref and the array layer comes from P.w. 
        /// When compare is not present, the last component of P is used as Dref and 
        /// the array layer comes from the second to last component of P. 
        /// (The second component of P isunused for 1D shadow lookups.)
        /// </summary>
        protected static float texture(samplerCubeShadow sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.
        /// When compare is present, it is used as Dref and the array layer comes from P.w. 
        /// When compare is not present, the last component of P is used as Dref and 
        /// the array layer comes from the second to last component of P. 
        /// (The second component of P isunused for 1D shadow lookups.)
        /// </summary>
        protected static float texture(samplerCubeShadow sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 texture (gsampler2DRect sampler, vec2 P)
        
        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static vec4 texture(sampler2DRect sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static ivec4 texture(isampler2DRect sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected static uvec4 texture(usampler2DRect sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region textureProj

        #region gvec4 textureProj (gsampler1D sampler, vec2 P [, float bias] )

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static vec4 textureProj(sampler1D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static vec4 textureProj(sampler1D sampler, vec2 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static ivec4 textureProj(isampler1D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static ivec4 textureProj(isampler1D sampler, vec2 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static uvec4 textureProj(usampler1D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static uvec4 textureProj(usampler1D sampler, vec2 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProj (gsampler1D sampler, vec4 P [, float bias] )

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static vec4 textureProj(sampler1D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static vec4 textureProj(sampler1D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static ivec4 textureProj(isampler1D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static ivec4 textureProj(isampler1D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static uvec4 textureProj(usampler1D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static uvec4 textureProj(usampler1D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProj (gsampler2D sampler, vec3 P [, float bias] )

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static vec4 textureProj(sampler2D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static vec4 textureProj(sampler2D sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static ivec4 textureProj(isampler2D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static ivec4 textureProj(isampler2D sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static uvec4 textureProj(usampler2D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static uvec4 textureProj(usampler2D sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProj (gsampler2D sampler, vec4 P [, float bias] )

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static vec4 textureProj(sampler2D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static vec4 textureProj(sampler2D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static ivec4 textureProj(isampler2D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static ivec4 textureProj(isampler2D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static uvec4 textureProj(usampler2D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static uvec4 textureProj(usampler2D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProj (gsampler3D sampler, vec4 P [, float bias] )

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static vec4 textureProj(sampler3D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static vec4 textureProj(sampler3D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static ivec4 textureProj(isampler3D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static ivec4 textureProj(isampler3D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static uvec4 textureProj(usampler3D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static uvec4 textureProj(usampler3D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProj (sampler1DShadow sampler, vec4 P [, float bias] )

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// The resulting 3rd component of P is used as Dref. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static float textureProj(sampler1DShadow sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// The resulting 3rd component of P is used as Dref. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static float textureProj(sampler1DShadow sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProj (sampler2DShadow sampler, vec4 P [, float bias] )

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// The resulting 3rd component of P is used as Dref. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static float textureProj(sampler2DShadow sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// The resulting 3rd component of P is used as Dref. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static float textureProj(sampler2DShadow sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProj (gsampler2DRect sampler, vec3 P)
       
        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static vec4 textureProj(sampler2DRect sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static ivec4 textureProj(isampler2DRect sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static uvec4 textureProj(usampler2DRect sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProj (gsampler2DRect sampler, vec4 P)

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static vec4 textureProj(sampler2DRect sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static ivec4 textureProj(isampler2DRect sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static uvec4 textureProj(usampler2DRect sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProj (sampler2DRectShadow sampler, vec4 P)

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected static float textureProj(sampler2DRectShadow sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region textureLod

        #region gvec4 textureLod (gsampler1D sampler, float P, float lod)

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected static vec4 textureLod(sampler1D sampler, float P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected static ivec4 textureLod(isampler1D sampler, float P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected static uvec4 textureLod(usampler1D sampler, float P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureLod (gsampler2D sampler, vec2 P, float lod)

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected static vec4 textureLod(sampler2D sampler, vec2 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected static ivec4 textureLod(isampler2D sampler, vec2 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected static uvec4 textureLod(sampler2D sampler, uvec2 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureLod (gsampler3D sampler, vec3 P, float lod)

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected static vec4 textureLod(sampler3D sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected static ivec4 textureLod(isampler3D sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected static uvec4 textureLod(usampler3D sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureLod (gsamplerCube sampler, vec3 P, float lod)

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected static vec4 textureLod(samplerCube sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected static ivec4 textureLod(isamplerCube sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected static uvec4 textureLod(usamplerCube sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureLod (sampler1DShadow sampler, vec3 P, float lod)

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected static float textureLod(sampler1DShadow sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureLod (sampler2DShadow sampler, vec3 P, float lod)
        
        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected static float textureLod(sampler2DShadow sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region textureOffset

        #region gvec4 textureOffset (gsampler1D sampler, float P, int offset [, float bias] )

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static vec4 textureOffset(sampler1D sampler, float P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static vec4 textureOffset(sampler1D sampler, float P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static ivec4 textureOffset(isampler1D sampler, float P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static ivec4 textureOffset(isampler1D sampler, float P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static uvec4 textureOffset(usampler1D sampler, float P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static uvec4 textureOffset(usampler1D sampler, float P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureOffset (gsampler2D sampler, vec2 P, ivec2 offset [, float bias] )

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static vec4 textureOffset(sampler2D sampler, vec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static vec4 textureOffset(sampler2D sampler, vec2 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static uvec4 textureOffset(usampler2D sampler, vec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static uvec4 textureOffset(usampler2D sampler, vec2 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static ivec4 textureOffset(isampler2D sampler, vec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static ivec4 textureOffset(isampler2D sampler, vec2 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureOffset (gsampler3D sampler, vec3 P, ivec3 offset [, float bias] )

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static vec4 textureOffset(sampler3D sampler, vec3 P, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static vec4 textureOffset(sampler3D sampler, vec3 P, ivec3 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static ivec4 textureOffset(isampler3D sampler, vec3 P, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static ivec4 textureOffset(isampler3D sampler, vec3 P, ivec3 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static uvec4 textureOffset(usampler3D sampler, vec3 P, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static uvec4 textureOffset(usampler3D sampler, vec3 P, ivec3 offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureOffset (gsampler2DRect sampler, vec2 P, ivec2 offset )

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static vec4 textureOffset(sampler2DRect sampler, vec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static ivec4 textureOffset(isampler2DRect sampler, vec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static uvec4 textureOffset(usampler2DRect sampler, vec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureOffset (sampler2DRectShadow sampler, vec3 P, ivec2 offset )

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static float textureOffset(sampler2DRectShadow sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureOffset (sampler1DShadow sampler, vec3 P, int offset [, float bias] )

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static float textureOffset(sampler1DShadow sampler, vec3 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static float textureOffset(sampler1DShadow sampler, vec3 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureOffset (sampler2DShadow sampler, vec3 P, ivec2 offset [, float bias] )
        
        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static float textureOffset(sampler2DShadow sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected static float textureOffset(sampler2DShadow sampler, vec3 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region texelFetch

        #region gvec4 texelFetch (gsampler1D sampler, int P, int lod)

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected static vec4 texelFetch(sampler1D sampler, int P, int lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected static ivec4 texelFetch(isampler1D sampler, int P, int lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected static uvec4 texelFetch(usampler1D sampler, int P, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 texelFetch (gsampler2D sampler, ivec2 P, int lod)

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected static vec4 texelFetch(sampler2D sampler, ivec2 P, int lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected static ivec4 texelFetch(isampler2D sampler, ivec2 P, int lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected static uvec4 texelFetch(usampler2D sampler, ivec2 P, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 texelFetch (gsampler3D sampler, ivec3 P, int lod)

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected static vec4 texelFetch(sampler3D sampler, ivec3 P, int lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected static ivec4 texelFetch(isampler3D sampler, ivec3 P, int lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected static uvec4 texelFetch(usampler3D sampler, ivec3 P, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 texelFetch (gsampler2DRect sampler, ivec2 P)

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected static vec4 texelFetch(sampler2DRect sampler, ivec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected static ivec4 texelFetch(isampler2DRect sampler, ivec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected static uvec4 texelFetch(usampler2DRect sampler, ivec2 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region texelFetchOffset

        #region gvec4 texelFetchOffset (gsampler1D sampler, int P, int lod, int offset)

        /// <summary> Fetch a single texel as in texelFetch offset by offset as described in textureOffset. </summary>
        protected static vec4 texelFetchOffset(sampler1D sampler, int P, int lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in texelFetch offset by offset as described in textureOffset. </summary>
        protected static ivec4 texelFetchOffset(isampler1D sampler, int P, int lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in texelFetch offset by offset as described in textureOffset. </summary>
        protected static uvec4 texelFetchOffset(usampler1D sampler, int P, int lod, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 texelFetchOffset (gsampler2D sampler, ivec2 P, int lod, ivec2 offset)

        /// <summary> Fetch a single texel as in texelFetch offset by offset as described in textureOffset. </summary>
        protected static vec4 texelFetchOffset(sampler2D sampler, ivec2 P, int lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in texelFetch offset by offset as described in textureOffset. </summary>
        protected static ivec4 texelFetchOffset(isampler2D sampler, ivec2 P, int lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in texelFetch offset by offset as described in textureOffset. </summary>
        protected static uvec4 texelFetchOffset(usampler2D sampler, ivec2 P, int lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 texelFetchOffset (gsampler3D sampler, ivec3 P, int lod, ivec3 offset)

        /// <summary> Fetch a single texel as in texelFetch offset by offset as described in textureOffset. </summary>
        protected static vec4 texelFetchOffset(sampler3D sampler, ivec3 P, int lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in texelFetch offset by offset as described in textureOffset. </summary>
        protected static ivec4 texelFetchOffset(isampler3D sampler, ivec3 P, int lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in texelFetch offset by offset as described in textureOffset. </summary>
        protected static uvec4 texelFetchOffset(sampler3D sampler, uvec3 P, int lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 texelFetchOffset (gsampler2DRect sampler, ivec2 P, ivec2 offset)

        /// <summary> Fetch a single texel as in texelFetch offset by offset as described in textureOffset. </summary>
        protected static vec4 texelFetchOffset(sampler2DRect sampler, ivec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in texelFetch offset by offset as described in textureOffset. </summary>
        protected static ivec4 texelFetchOffset(isampler2DRect sampler, ivec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in texelFetch offset by offset as described in textureOffset. </summary>
        protected static uvec4 texelFetchOffset(usampler2DRect sampler, ivec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region textureProjOffset

        #region gvec4 textureProjOffset (gsampler1D sampler, vec2 P, int offset [, float bias] )

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static vec4 textureProjOffset(sampler1D sampler, vec2 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static vec4 textureProjOffset(sampler1D sampler, vec2 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static ivec4 textureProjOffset(isampler1D sampler, vec2 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static ivec4 textureProjOffset(isampler1D sampler, vec2 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static uvec4 textureProjOffset(usampler1D sampler, vec2 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static uvec4 textureProjOffset(usampler1D sampler, vec2 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjOffset (gsampler1D sampler, vec4 P, int offset [, float bias] )

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static vec4 textureProjOffset(sampler1D sampler, vec4 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static vec4 textureProjOffset(sampler1D sampler, vec4 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static ivec4 textureProjOffset(isampler1D sampler, vec4 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static ivec4 textureProjOffset(isampler1D sampler, vec4 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static uvec4 textureProjOffset(usampler1D sampler, vec4 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static uvec4 textureProjOffset(usampler1D sampler, vec4 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjOffset (gsampler2D sampler, vec3 P, ivec2 offset [, float bias] )

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static vec4 textureProjOffset(sampler2D sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static vec4 textureProjOffset(sampler2D sampler, vec3 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static ivec4 textureProjOffset(isampler2D sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static ivec4 textureProjOffset(isampler2D sampler, vec3 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static uvec4 textureProjOffset(usampler2D sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static uvec4 textureProjOffset(usampler2D sampler, vec3 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjOffset (gsampler2D sampler, vec4 P, ivec2 offset [, float bias] )

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static vec4 textureProjOffset(sampler2D sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static vec4 textureProjOffset(sampler2D sampler, vec4 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static ivec4 textureProjOffset(isampler2D sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static ivec4 textureProjOffset(isampler2D sampler, vec4 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static uvec4 textureProjOffset(usampler2D sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static uvec4 textureProjOffset(usampler2D sampler, vec4 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjOffset (gsampler3D sampler, vec4 P, ivec3 offset [, float bias] )

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static vec4 textureProjOffset(sampler3D sampler, vec4 P, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static vec4 textureProjOffset(sampler3D sampler, vec4 P, ivec3 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static ivec4 textureProjOffset(isampler3D sampler, vec4 P, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static ivec4 textureProjOffset(isampler3D sampler, vec4 P, ivec3 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static uvec4 textureProjOffset(usampler3D sampler, vec4 P, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static uvec4 textureProjOffset(usampler3D sampler, vec4 P, ivec3 offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjOffset (gsampler2DRect sampler, vec3 P, ivec2 offset )
        
        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static vec4 textureProjOffset(sampler2DRect sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static ivec4 textureProjOffset(isampler2DRect sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static uvec4 textureProjOffset(usampler2DRect sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjOffset (gsampler2DRect sampler, vec4 P, ivec2 offset )
        
        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static vec4 textureProjOffset(sampler2DRect sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static ivec4 textureProjOffset(isampler2DRect sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static uvec4 textureProjOffset(usampler2DRect sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProjOffset (sampler2DRectShadow sampler, vec4 P, ivec2 offset )
        
        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static float textureProjOffset(sampler2DRectShadow sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProjOffset (sampler1DShadow sampler, vec4 P, int offset [, float bias] )

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static float textureProjOffset(sampler1DShadow sampler, vec4 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static float textureProjOffset(sampler1DShadow sampler, vec4 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProjOffset (sampler2DShadow sampler, vec4 P,ivec2 offset [, float bias] )

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static float textureProjOffset(sampler2DShadow sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in textureProj offset by offset as described in textureOffset. </summary>
        protected static float textureProjOffset(sampler2DShadow sampler, vec4 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region textureLodOffset

        #region gvec4 textureLodOffset (gsampler1D sampler, float P, float lod, int offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static vec4 textureLodOffset(sampler1D sampler, float P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static ivec4 textureLodOffset(isampler1D sampler, float P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static uvec4 textureLodOffset(usampler1D sampler, float P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureLodOffset (gsampler2D sampler, vec2 P, float lod, ivec2 offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static vec4 textureLodOffset(sampler2D sampler, vec2 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static ivec4 textureLodOffset(isampler2D sampler, vec2 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static uvec4 textureLodOffset(usampler2D sampler, vec2 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureLodOffset (gsampler3D sampler, vec3 P, float lod, ivec3 offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static vec4 textureLodOffset(sampler3D sampler, vec3 P, float lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static ivec4 textureLodOffset(isampler3D sampler, vec3 P, float lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static uvec4 textureLodOffset(usampler3D sampler, vec3 P, float lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureLodOffset (sampler1DShadow sampler, vec3 P, float lod, int offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static float textureLodOffset(sampler1DShadow sampler, vec3 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureLodOffset (sampler2DShadow sampler, vec3 P, float lod, ivec2 offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static float textureLodOffset(sampler2DShadow sampler, vec3 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region textureProjLod

        #region gvec4 textureProjLod (gsampler1D sampler, vec2 P, float lod)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static vec4 textureProjLod(sampler1D sampler, vec2 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static ivec4 textureProjLod(isampler1D sampler, vec2 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static uvec4 textureProjLod(usampler1D sampler, vec2 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjLod (gsampler1D sampler, vec4 P, float lod)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static vec4 textureProjLod(sampler1D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static ivec4 textureProjLod(isampler1D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static uvec4 textureProjLod(usampler1D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjLod (gsampler2D sampler, vec3 P, float lod)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static vec4 textureProjLod(sampler2D sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static ivec4 textureProjLod(isampler2D sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static uvec4 textureProjLod(usampler2D sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjLod (gsampler2D sampler, vec4 P, float lod)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static vec4 textureProjLod(sampler2D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static ivec4 textureProjLod(isampler2D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static uvec4 textureProjLod(usampler2D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjLod (gsampler3D sampler, vec4 P, float lod)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static vec4 textureProjLod(sampler3D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static ivec4 textureProjLod(isampler3D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static uvec4 textureProjLod(usampler3D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProjLod (sampler1DShadow sampler, vec4 P, float lod)
        
        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static float textureProjLod(sampler1DShadow sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProjLod (sampler2DShadow sampler, vec4 P, float lod)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static float textureProjLod(sampler2DShadow sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region textureProjLodOffset

        #region gvec4 textureProjLodOffset (gsampler1D sampler, vec2 P, float lod, int offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static vec4 textureProjLodOffset(sampler1D sampler, vec2 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static ivec4 textureProjLodOffset(isampler1D sampler, vec2 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static uvec4 textureProjLodOffset(usampler1D sampler, vec2 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjLodOffset (gsampler1D sampler, vec4 P, float lod, int offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static vec4 textureProjLodOffset(sampler1D sampler, vec4 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static ivec4 textureProjLodOffset(isampler1D sampler, vec4 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static uvec4 textureProjLodOffset(usampler1D sampler, vec4 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjLodOffset (gsampler2D sampler, vec3 P, float lod, ivec2 offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static vec4 textureProjLodOffset(sampler2D sampler, vec3 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static ivec4 textureProjLodOffset(isampler2D sampler, vec3 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static uvec4 textureProjLodOffset(usampler2D sampler, vec3 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjLodOffset (gsampler2D sampler, vec4 P, float lod, ivec2 offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static vec4 textureProjLodOffset(sampler2D sampler, vec4 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static ivec4 textureProjLodOffset(isampler2D sampler, vec4 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static uvec4 textureProjLodOffset(usampler2D sampler, vec4 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjLodOffset (gsampler3D sampler, vec4 P, float lod, ivec3 offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static vec4 textureProjLodOffset(sampler3D sampler, vec4 P, float lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static ivec4 textureProjLodOffset(isampler3D sampler, vec4 P, float lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static uvec4 textureProjLodOffset(usampler3D sampler, vec4 P, float lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProjLodOffset (sampler1DShadow sampler, vec4 P, float lod, int offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static float textureProjLodOffset(sampler1DShadow sampler, vec4 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProjLodOffset (sampler2DShadow sampler, vec4 P, float lod, ivec2 offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See textureLod and textureOffset.</summary>
        protected static float textureProjLodOffset(sampler2DShadow sampler, vec4 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region textureGrad

        #region gvec4 textureGrad (gsampler1D sampler, float P, float dPdx, float dPdy)

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P/∂x; ∂s/∂y = ∂P/∂y; ∂t/∂x = 0; ∂t/∂y = 0; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected static vec4 textureGrad(sampler1D sampler, float P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P/∂x; ∂s/∂y = ∂P/∂y; ∂t/∂x = 0; ∂t/∂y = 0; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected static ivec4 textureGrad(isampler1D sampler, float P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P/∂x; ∂s/∂y = ∂P/∂y; ∂t/∂x = 0; ∂t/∂y = 0; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected static uvec4 textureGrad(usampler1D sampler, float P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureGrad (gsampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy)

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected static vec4 textureGrad(sampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected static ivec4 textureGrad(isampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected static uvec4 textureGrad(usampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureGrad (gsampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy)

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = ∂P.p/∂x; ∂r/∂y = ∂P.p/∂y;</summary>
        protected static vec4 textureGrad(sampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = ∂P.p/∂x; ∂r/∂y = ∂P.p/∂y;</summary>
        protected static ivec4 textureGrad(isampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = ∂P.p/∂x; ∂r/∂y = ∂P.p/∂y;</summary>
        protected static uvec4 textureGrad(usampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureGrad (gsamplerCube sampler, vec3 P, vec3 dPdx, vec3 dPdy)

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = ∂P.p/∂x; ∂r/∂y = ∂P.p/∂y;</summary>
        protected static vec4 textureGrad(samplerCube sampler, vec3 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = ∂P.p/∂x; ∂r/∂y = ∂P.p/∂y;</summary>
        protected static ivec4 textureGrad(isamplerCube sampler, vec3 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = ∂P.p/∂x; ∂r/∂y = ∂P.p/∂y;</summary>
        protected static uvec4 textureGrad(usamplerCube sampler, vec3 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureGrad (gsampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        
        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected static vec4 textureGrad(sampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected static ivec4 textureGrad(isampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected static uvec4 textureGrad(usampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }
        
        #endregion

        #region float textureGrad (sampler2DRectShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        
        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected static float textureGrad(sampler2DRectShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureGrad (sampler1DShadow sampler, vec3 P, float dPdx, float dPdy)

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P/∂x; ∂s/∂y = ∂P/∂y; ∂t/∂x = 0; ∂t/∂y = 0; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected static float textureGrad(sampler1DShadow sampler, vec3 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureGrad (sampler2DShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        
        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected static float textureGrad(sampler2DShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureGrad (samplerCubeShadow sampler, vec4 P, vec3 dPdx, vec3 dPdy)

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = ∂P.p/∂x; ∂r/∂y = ∂P.p/∂y;</summary>
        protected static float textureGrad(samplerCubeShadow sampler, vec4 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region textureGradOffset

        #region gvec4 textureGradOffset (gsampler1D sampler, float P, float dPdx, float dPdy, int offset)

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static vec4 textureGradOffset(sampler1D sampler, float P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static ivec4 textureGradOffset(isampler1D sampler, float P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static uvec4 textureGradOffset(usampler1D sampler, float P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureGradOffset (gsampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static vec4 textureGradOffset(sampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static ivec4 textureGradOffset(isampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static uvec4 textureGradOffset(usampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureGradOffset (gsampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy, ivec3 offset)

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static vec4 textureGradOffset(sampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static ivec4 textureGradOffset(isampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static uvec4 textureGradOffset(usampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy, ivec3 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureGradOffset (gsampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static vec4 textureGradOffset(sampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static ivec4 textureGradOffset(isampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static uvec4 textureGradOffset(usampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureGradOffset (sampler2DRectShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static float textureGradOffset(sampler2DRectShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureGradOffset (sampler1DShadow sampler, vec3 P, float dPdx, float dPdy, int offset )

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static float textureGradOffset(sampler1DShadow sampler, vec3 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureGradOffset (sampler2DShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in textureGrad and textureOffset. </summary>
        protected static float textureGradOffset(sampler2DShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region textureProjGrad

        #region gvec4 textureProjGrad (gsampler1D sampler, vec2 P, float dPdx, float dPdy)

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static vec4 textureProjGrad(sampler1D sampler, vec2 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static ivec4 textureProjGrad(isampler1D sampler, vec2 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static uvec4 textureProjGrad(usampler1D sampler, vec2 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjGrad (gsampler1D sampler, vec4 P, float dPdx, float dPdy)

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static vec4 textureProjGrad(sampler1D sampler, vec4 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static ivec4 textureProjGrad(isampler1D sampler, vec4 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static uvec4 textureProjGrad(usampler1D sampler, vec4 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjGrad (gsampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        
        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static vec4 textureProjGrad(sampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static ivec4 textureProjGrad(isampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static uvec4 textureProjGrad(usampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjGrad (gsampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy)

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static vec4 textureProjGrad(sampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static ivec4 textureProjGrad(isampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static uvec4 textureProjGrad(usampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjGrad (gsampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy)

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static vec4 textureProjGrad(sampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static ivec4 textureProjGrad(isampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static uvec4 textureProjGrad(usampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjGrad (gsampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy)

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static vec4 textureProjGrad(sampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static ivec4 textureProjGrad(isampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static uvec4 textureProjGrad(usampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjGrad (gsampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy)

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static vec4 textureProjGrad(sampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static ivec4 textureProjGrad(isampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static uvec4 textureProjGrad(usampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProjGrad (sampler2DRectShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy)

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static float textureProjGrad(sampler2DRectShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProjGrad (sampler1DShadow sampler, vec4 P, float dPdx, float dPdy)

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static float textureProjGrad(sampler1DShadow sampler, vec4 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProjGrad (sampler2DShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy)

        /// <summary>Do a texture lookup both projectively, as described in textureProj, and with explicit gradient as 
        /// described in textureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected static float textureProjGrad(sampler2DShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region textureProjGradOffset

        #region gvec4 textureProjGradOffset (gsampler1D sampler, vec2 P, float dPdx, float dPdy, int offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static vec4 textureProjGradOffset(sampler1D sampler, vec2 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static ivec4 textureProjGradOffset(isampler1D sampler, vec2 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static uvec4 textureProjGradOffset(usampler1D sampler, vec2 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjGradOffset (gsampler1D sampler, vec4 P, float dPdx, float dPdy, int offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static vec4 textureProjGradOffset(sampler1D sampler, vec4 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static ivec4 textureProjGradOffset(isampler1D sampler, vec4 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static uvec4 textureProjGradOffset(usampler1D sampler, vec4 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjGradOffset (gsampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy, vec2 offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static vec4 textureProjGradOffset(sampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static ivec4 textureProjGradOffset(isampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static uvec4 textureProjGradOffset(usampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjGradOffset (gsampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy, vec2 offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static vec4 textureProjGradOffset(sampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static ivec4 textureProjGradOffset(isampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static uvec4 textureProjGradOffset(usampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjGradOffset (gsampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        
        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static vec4 textureProjGradOffset(sampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static ivec4 textureProjGradOffset(isampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static uvec4 textureProjGradOffset(usampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjGradOffset (gsampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static vec4 textureProjGradOffset(sampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static ivec4 textureProjGradOffset(isampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static uvec4 textureProjGradOffset(usampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion
        
        #region float textureProjGradOffset (sampler2DRectShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static float textureProjGradOffset(sampler2DRectShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 textureProjGradOffset (gsampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy, vec3 offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static vec4 textureProjGradOffset(sampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static ivec4 textureProjGradOffset(isampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static uvec4 textureProjGradOffset(usampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy, ivec3 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProjGradOffset (sampler1DShadow sampler, vec4 P, float dPdx, float dPdy, int offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static float textureProjGradOffset(sampler1DShadow sampler, vec4 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float textureProjGradOffset (sampler2DShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy, vec2 offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in textureProjGrad,
        /// as well as with offset, as described in textureOffset.</summary>
        protected static float textureProjGradOffset(sampler2DShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy, vec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion
    }
}

// ReSharper restore InconsistentNaming
