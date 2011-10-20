using System;

// ReSharper disable InconsistentNaming

namespace IIS.SLSharp.Shaders
{
    // TODO: textureGather textureGatherOffset textureGatherOffsets and deprecated funcs

    public abstract partial class ShaderDefinition
    {
        #region TextureSize

        #region int TextureSize (gsampler1D sampler, int lod)

        protected internal static int TextureSize(sampler1D sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected internal static int TextureSize(isampler1D sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected internal static int TextureSize(usampler1D sampler, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region ivec2 TextureSize (gsampler2D sampler, int lod)

        protected internal static ivec2 TextureSize(sampler2D sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected internal static ivec2 TextureSize(isampler2D sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected internal static ivec2 TextureSize(usampler2D sampler, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region ivec3 TextureSize (gsampler3D sampler, int lod)

        protected internal static ivec3 TextureSize(sampler3D sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected internal static ivec3 TextureSize(isampler3D sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected internal static ivec3 TextureSize(usampler3D sampler, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region ivec2 TextureSize (gsamplerCube sampler, int lod)

        protected internal static ivec2 TextureSize(samplerCube sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected internal static ivec2 TextureSize(isamplerCube sampler, int lod)
        {
            throw _invalidAccess;
        }

        protected internal static ivec2 TextureSize(usamplerCube sampler, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region int TextureSize (sampler1DShadow sampler, int lod)

        protected internal static int TextureSize (sampler1DShadow sampler, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region ivec2 TextureSize (sampler2DShadow sampler, int lod)

        protected internal static ivec2 TextureSize (sampler2DShadow sampler, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region ivec2 TextureSize (samplerCubeShadow sampler, int lod)

        protected internal static ivec2 TextureSize(samplerCubeShadow sampler, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region ivec2 TextureSize (gsampler2DRect sampler)

        protected internal static ivec2 TextureSize(sampler2DRect sampler)
        {
            throw _invalidAccess;
        }

        protected internal static ivec2 TextureSize(isampler2DRect sampler)
        {
            throw _invalidAccess;
        }

        protected internal static ivec2 TextureSize(usampler2DRect sampler)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region TextureQueryLod

        #region vec2 TextureQueryLod(gsampler1D sampler, float P)

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(sampler1D sampler, float P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(isampler1D sampler, float P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(usampler1D sampler, float P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region vec2 TextureQueryLod(gsampler2D sampler, vec2 P)

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(sampler2D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(isampler2D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(usampler2D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region vec2 TextureQueryLod(gsampler3D sampler, vec3 P)

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(sampler3D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(isampler3D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(usampler3D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region vec2 TextureQueryLod(gsamplerCube sampler, vec3 P)

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(samplerCube sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(isamplerCube sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(usamplerCube sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region vec2 TextureQueryLod(sampler1DShadow sampler, float P)

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(sampler1DShadow sampler, float P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region vec2 TextureQueryLod(sampler2DShadow sampler, vec2 P)

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(sampler2DShadow sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region vec2 TextureQueryLod(samplerCubeShadow sampler, vec3 P)

        /// <summary>
        /// Returns the mipmap array(s) that would be accessed in the x component of the return value.
        /// Returns the computed level of detail relative to the base level in the y component of the return value.
        /// If called on an incomplete texture, the results are undefined.
        /// </summary>
        protected internal static vec2 TextureQueryLod(samplerCubeShadow sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region Texture

        #region gvec4 Texture (gsampler1D sampler, float P [, float bias] )

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static vec4 Texture(sampler1D sampler, float s)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static vec4 Texture(sampler1D sampler, float s, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static ivec4 Texture(isampler1D sampler, float s)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static ivec4 Texture(isampler1D sampler, float s, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static uvec4 Texture(usampler1D sampler, float s)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static uvec4 Texture(usampler1D sampler, float s, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 Texture (gsampler2D sampler, vec2 P [, float bias] )

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static vec4 Texture(sampler2D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static vec4 Texture(sampler2D sampler, vec2 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static ivec4 Texture(isampler2D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static ivec4 Texture(isampler2D sampler, vec2 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static uvec4 Texture(usampler2D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static uvec4 Texture(usampler2D sampler, vec2 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 Texture (gsampler3D sampler, vec3 P [, float bias] )

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static vec4 Texture(sampler3D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static vec4 Texture(sampler3D sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static ivec4 Texture(isampler3D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static ivec4 Texture(isampler3D sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static uvec4 Texture(usampler3D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static uvec4 Texture(usampler3D sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 Texture (gsamplerCube sampler, vec3 P [, float bias] )

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static vec4 Texture(samplerCube sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static vec4 Texture(samplerCube sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static ivec4 Texture(isamplerCube sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static ivec4 Texture(isamplerCube sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static uvec4 Texture(usamplerCube sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static uvec4 Texture(usamplerCube sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float Texture (sampler1DShadow sampler, vec3 P [, float bias] )

        /// <summary>
        /// Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.
        /// When compare is present, it is used as Dref and the array layer comes from P.w. 
        /// When compare is not present, the last component of P is used as Dref and 
        /// the array layer comes from the second to last component of P. 
        /// (The second component of P isunused for 1D shadow lookups.)
        /// </summary>
        protected internal static float Texture(sampler1DShadow sampler, vec3 P)
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
        protected internal static float Texture(sampler1DShadow sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float Texture (sampler2DShadow sampler, vec3 P [, float bias] )

        /// <summary>
        /// Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.
        /// When compare is present, it is used as Dref and the array layer comes from P.w. 
        /// When compare is not present, the last component of P is used as Dref and 
        /// the array layer comes from the second to last component of P. 
        /// (The second component of P isunused for 1D shadow lookups.)
        /// </summary>
        protected internal static float Texture(sampler2DShadow sampler, vec3 P)
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
        protected internal static float Texture(sampler2DShadow sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float Texture (samplerCubeShadow sampler, vec4 P [, float bias] )

        /// <summary>
        /// Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.
        /// When compare is present, it is used as Dref and the array layer comes from P.w. 
        /// When compare is not present, the last component of P is used as Dref and 
        /// the array layer comes from the second to last component of P. 
        /// (The second component of P isunused for 1D shadow lookups.)
        /// </summary>
        protected internal static float Texture(samplerCubeShadow sampler, vec4 P)
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
        protected internal static float Texture(samplerCubeShadow sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 Texture (gsampler2DRect sampler, vec2 P)
        
        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static vec4 Texture(sampler2DRect sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static ivec4 Texture(isampler2DRect sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Use the texture coordinate P to do a texture lookup in the texture currently bound to sampler.</summary>
        protected internal static uvec4 Texture(usampler2DRect sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region TextureProj

        #region gvec4 TextureProj (gsampler1D sampler, vec2 P [, float bias] )

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static vec4 TextureProj(sampler1D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static vec4 TextureProj(sampler1D sampler, vec2 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static ivec4 TextureProj(isampler1D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static ivec4 TextureProj(isampler1D sampler, vec2 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static uvec4 TextureProj(usampler1D sampler, vec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static uvec4 TextureProj(usampler1D sampler, vec2 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProj (gsampler1D sampler, vec4 P [, float bias] )

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static vec4 TextureProj(sampler1D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static vec4 TextureProj(sampler1D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static ivec4 TextureProj(isampler1D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static ivec4 TextureProj(isampler1D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static uvec4 TextureProj(usampler1D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static uvec4 TextureProj(usampler1D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProj (gsampler2D sampler, vec3 P [, float bias] )

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static vec4 TextureProj(sampler2D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static vec4 TextureProj(sampler2D sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static ivec4 TextureProj(isampler2D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static ivec4 TextureProj(isampler2D sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static uvec4 TextureProj(usampler2D sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static uvec4 TextureProj(usampler2D sampler, vec3 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProj (gsampler2D sampler, vec4 P [, float bias] )

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static vec4 TextureProj(sampler2D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static vec4 TextureProj(sampler2D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static ivec4 TextureProj(isampler2D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static ivec4 TextureProj(isampler2D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static uvec4 TextureProj(usampler2D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static uvec4 TextureProj(usampler2D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProj (gsampler3D sampler, vec4 P [, float bias] )

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static vec4 TextureProj(sampler3D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static vec4 TextureProj(sampler3D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static ivec4 TextureProj(isampler3D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static ivec4 TextureProj(isampler3D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static uvec4 TextureProj(usampler3D sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static uvec4 TextureProj(usampler3D sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProj (sampler1DShadow sampler, vec4 P [, float bias] )

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// The resulting 3rd component of P is used as Dref. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static float TextureProj(sampler1DShadow sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// The resulting 3rd component of P is used as Dref. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static float TextureProj(sampler1DShadow sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProj (sampler2DShadow sampler, vec4 P [, float bias] )

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// The resulting 3rd component of P is used as Dref. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static float TextureProj(sampler2DShadow sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// The resulting 3rd component of P is used as Dref. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static float TextureProj(sampler2DShadow sampler, vec4 P, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProj (gsampler2DRect sampler, vec3 P)
       
        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static vec4 TextureProj(sampler2DRect sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static ivec4 TextureProj(isampler2DRect sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static uvec4 TextureProj(usampler2DRect sampler, vec3 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProj (gsampler2DRect sampler, vec4 P)

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static vec4 TextureProj(sampler2DRect sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static ivec4 TextureProj(isampler2DRect sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static uvec4 TextureProj(usampler2DRect sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProj (sampler2DRectShadow sampler, vec4 P)

        /// <summary>Do a texture lookup with projection. The texture coordinates consumed from P,
        /// not including the last component of P, are divided by the last component of P. 
        /// After these values are computed,texture lookup proceeds as in texture.</summary>
        protected internal static float TextureProj(sampler2DRectShadow sampler, vec4 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region TextureLod

        #region gvec4 TextureLod (gsampler1D sampler, float P, float lod)

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected internal static vec4 TextureLod(sampler1D sampler, float P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected internal static ivec4 TextureLod(isampler1D sampler, float P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected internal static uvec4 TextureLod(usampler1D sampler, float P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureLod (gsampler2D sampler, vec2 P, float lod)

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected internal static vec4 TextureLod(sampler2D sampler, vec2 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected internal static ivec4 TextureLod(isampler2D sampler, vec2 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected internal static uvec4 TextureLod(usampler2D sampler, vec2 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureLod (gsampler3D sampler, vec3 P, float lod)

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected internal static vec4 TextureLod(sampler3D sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected internal static ivec4 TextureLod(isampler3D sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected internal static uvec4 TextureLod(usampler3D sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureLod (gsamplerCube sampler, vec3 P, float lod)

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected internal static vec4 TextureLod(samplerCube sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected internal static ivec4 TextureLod(isamplerCube sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected internal static uvec4 TextureLod(usamplerCube sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureLod (sampler1DShadow sampler, vec3 P, float lod)

        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected internal static float TextureLod(sampler1DShadow sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureLod (sampler2DShadow sampler, vec3 P, float lod)
        
        /// <summary>
        /// Do a texture lookup as in texture but with explicit LOD; lod specifies λbase and sets the partial derivatives as follows. 
        /// (See section 3.8.11 “Texture Minification” and equation 3.17 in the OpenGL Graphics SystemSpecification.)
        /// ∂u/∂x = 0; ∂v/∂x = 0; ∂w/∂x = 0; ∂u/∂y = 0; ∂v/∂y = 0; ∂w/∂y = 0; 
        /// </summary>
        protected internal static float TextureLod(sampler2DShadow sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region TextureOffset

        #region gvec4 TextureOffset (gsampler1D sampler, float P, int offset [, float bias] )

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static vec4 TextureOffset(sampler1D sampler, float P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static vec4 TextureOffset(sampler1D sampler, float P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static ivec4 TextureOffset(isampler1D sampler, float P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static ivec4 TextureOffset(isampler1D sampler, float P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static uvec4 TextureOffset(usampler1D sampler, float P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static uvec4 TextureOffset(usampler1D sampler, float P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureOffset (gsampler2D sampler, vec2 P, ivec2 offset [, float bias] )

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static vec4 TextureOffset(sampler2D sampler, vec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static vec4 TextureOffset(sampler2D sampler, vec2 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static uvec4 TextureOffset(usampler2D sampler, vec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static uvec4 TextureOffset(usampler2D sampler, vec2 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static ivec4 TextureOffset(isampler2D sampler, vec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static ivec4 TextureOffset(isampler2D sampler, vec2 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureOffset (gsampler3D sampler, vec3 P, ivec3 offset [, float bias] )

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static vec4 TextureOffset(sampler3D sampler, vec3 P, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static vec4 TextureOffset(sampler3D sampler, vec3 P, ivec3 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static ivec4 TextureOffset(isampler3D sampler, vec3 P, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static ivec4 TextureOffset(isampler3D sampler, vec3 P, ivec3 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static uvec4 TextureOffset(usampler3D sampler, vec3 P, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static uvec4 TextureOffset(usampler3D sampler, vec3 P, ivec3 offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureOffset (gsampler2DRect sampler, vec2 P, ivec2 offset )

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static vec4 TextureOffset(sampler2DRect sampler, vec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static ivec4 TextureOffset(isampler2DRect sampler, vec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static uvec4 TextureOffset(usampler2DRect sampler, vec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureOffset (sampler2DRectShadow sampler, vec3 P, ivec2 offset )

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static float TextureOffset(sampler2DRectShadow sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureOffset (sampler1DShadow sampler, vec3 P, int offset [, float bias] )

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static float TextureOffset(sampler1DShadow sampler, vec3 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static float TextureOffset(sampler1DShadow sampler, vec3 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureOffset (sampler2DShadow sampler, vec3 P, ivec2 offset [, float bias] )
        
        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static float TextureOffset(sampler2DShadow sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with offset added to the (u,v,w) texel coordinates before looking up each texel.
        /// The offset value must be a constant expression. A limited range of offset values are supported; 
        /// the minimum and maximum offset values are implementation-dependent and given by MIN_PROGRAM_TEXEL_OFFSET and MAX_PROGRAM_TEXEL_OFFSET, respectively.
        /// Note that offset does not apply to the layer coordinate for texture arrays. This is explained in detail in section 3.8.11
        /// “Texture Minification” of the OpenGL Graphics System Specification, where offset is (∂u ,∂v ,∂w).
        /// </summary>
        protected internal static float TextureOffset(sampler2DShadow sampler, vec3 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region TexelFetch

        #region gvec4 TexelFetch (gsampler1D sampler, int P, int lod)

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected internal static vec4 TexelFetch(sampler1D sampler, int P, int lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected internal static ivec4 TexelFetch(isampler1D sampler, int P, int lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected internal static uvec4 TexelFetch(usampler1D sampler, int P, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TexelFetch (gsampler2D sampler, ivec2 P, int lod)

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected internal static vec4 TexelFetch(sampler2D sampler, ivec2 P, int lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected internal static ivec4 TexelFetch(isampler2D sampler, ivec2 P, int lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected internal static uvec4 TexelFetch(usampler2D sampler, ivec2 P, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TexelFetch (gsampler3D sampler, ivec3 P, int lod)

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected internal static vec4 TexelFetch(sampler3D sampler, ivec3 P, int lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected internal static ivec4 TexelFetch(isampler3D sampler, ivec3 P, int lod)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected internal static uvec4 TexelFetch(usampler3D sampler, ivec3 P, int lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TexelFetch (gsampler2DRect sampler, ivec2 P)

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected internal static vec4 TexelFetch(sampler2DRect sampler, ivec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected internal static ivec4 TexelFetch(isampler2DRect sampler, ivec2 P)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Use integer texture coordinate P to lookup a single texel from sampler. 
        /// The level-ofdetail lod is as described in sections 2.11.8 “Shader Execution” 
        /// under Texel Fetches and 3.8 “Texturing” of the OpenGL GraphicsSystem Specification.
        /// </summary>
        protected internal static uvec4 TexelFetch(usampler2DRect sampler, ivec2 P)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region TexelFetchOffset

        #region gvec4 TexelFetchOffset (gsampler1D sampler, int P, int lod, int offset)

        /// <summary> Fetch a single texel as in TexelFetch offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TexelFetchOffset(sampler1D sampler, int P, int lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in TexelFetch offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TexelFetchOffset(isampler1D sampler, int P, int lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in TexelFetch offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TexelFetchOffset(usampler1D sampler, int P, int lod, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TexelFetchOffset (gsampler2D sampler, ivec2 P, int lod, ivec2 offset)

        /// <summary> Fetch a single texel as in TexelFetch offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TexelFetchOffset(sampler2D sampler, ivec2 P, int lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in TexelFetch offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TexelFetchOffset(isampler2D sampler, ivec2 P, int lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in TexelFetch offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TexelFetchOffset(usampler2D sampler, ivec2 P, int lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TexelFetchOffset (gsampler3D sampler, ivec3 P, int lod, ivec3 offset)

        /// <summary> Fetch a single texel as in TexelFetch offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TexelFetchOffset(sampler3D sampler, ivec3 P, int lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in TexelFetch offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TexelFetchOffset(isampler3D sampler, ivec3 P, int lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in TexelFetch offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TexelFetchOffset(usampler3D sampler, ivec3 P, int lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TexelFetchOffset (gsampler2DRect sampler, ivec2 P, ivec2 offset)

        /// <summary> Fetch a single texel as in TexelFetch offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TexelFetchOffset(sampler2DRect sampler, ivec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in TexelFetch offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TexelFetchOffset(isampler2DRect sampler, ivec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary> Fetch a single texel as in TexelFetch offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TexelFetchOffset(usampler2DRect sampler, ivec2 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region TextureProjOffset

        #region gvec4 TextureProjOffset (gsampler1D sampler, vec2 P, int offset [, float bias] )

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TextureProjOffset(sampler1D sampler, vec2 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TextureProjOffset(sampler1D sampler, vec2 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TextureProjOffset(isampler1D sampler, vec2 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TextureProjOffset(isampler1D sampler, vec2 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TextureProjOffset(usampler1D sampler, vec2 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TextureProjOffset(usampler1D sampler, vec2 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjOffset (gsampler1D sampler, vec4 P, int offset [, float bias] )

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TextureProjOffset(sampler1D sampler, vec4 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TextureProjOffset(sampler1D sampler, vec4 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TextureProjOffset(isampler1D sampler, vec4 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TextureProjOffset(isampler1D sampler, vec4 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TextureProjOffset(usampler1D sampler, vec4 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TextureProjOffset(usampler1D sampler, vec4 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjOffset (gsampler2D sampler, vec3 P, ivec2 offset [, float bias] )

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TextureProjOffset(sampler2D sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TextureProjOffset(sampler2D sampler, vec3 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TextureProjOffset(isampler2D sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TextureProjOffset(isampler2D sampler, vec3 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TextureProjOffset(usampler2D sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TextureProjOffset(usampler2D sampler, vec3 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjOffset (gsampler2D sampler, vec4 P, ivec2 offset [, float bias] )

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TextureProjOffset(sampler2D sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TextureProjOffset(sampler2D sampler, vec4 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TextureProjOffset(isampler2D sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TextureProjOffset(isampler2D sampler, vec4 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TextureProjOffset(usampler2D sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TextureProjOffset(usampler2D sampler, vec4 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjOffset (gsampler3D sampler, vec4 P, ivec3 offset [, float bias] )

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TextureProjOffset(sampler3D sampler, vec4 P, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TextureProjOffset(sampler3D sampler, vec4 P, ivec3 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TextureProjOffset(isampler3D sampler, vec4 P, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TextureProjOffset(isampler3D sampler, vec4 P, ivec3 offset, float bias)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TextureProjOffset(usampler3D sampler, vec4 P, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TextureProjOffset(usampler3D sampler, vec4 P, ivec3 offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjOffset (gsampler2DRect sampler, vec3 P, ivec2 offset )
        
        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TextureProjOffset(sampler2DRect sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TextureProjOffset(isampler2DRect sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TextureProjOffset(usampler2DRect sampler, vec3 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjOffset (gsampler2DRect sampler, vec4 P, ivec2 offset )
        
        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static vec4 TextureProjOffset(sampler2DRect sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static ivec4 TextureProjOffset(isampler2DRect sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static uvec4 TextureProjOffset(usampler2DRect sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProjOffset (sampler2DRectShadow sampler, vec4 P, ivec2 offset )
        
        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static float TextureProjOffset(sampler2DRectShadow sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProjOffset (sampler1DShadow sampler, vec4 P, int offset [, float bias] )

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static float TextureProjOffset(sampler1DShadow sampler, vec4 P, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static float TextureProjOffset(sampler1DShadow sampler, vec4 P, int offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProjOffset (sampler2DShadow sampler, vec4 P,ivec2 offset [, float bias] )

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static float TextureProjOffset(sampler2DShadow sampler, vec4 P, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do a projective texture lookup as described in TextureProj offset by offset as described in TextureOffset. </summary>
        protected internal static float TextureProjOffset(sampler2DShadow sampler, vec4 P, ivec2 offset, float bias)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region TextureLodOffset

        #region gvec4 TextureLodOffset (gsampler1D sampler, float P, float lod, int offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static vec4 TextureLodOffset(sampler1D sampler, float P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static ivec4 TextureLodOffset(isampler1D sampler, float P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static uvec4 TextureLodOffset(usampler1D sampler, float P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureLodOffset (gsampler2D sampler, vec2 P, float lod, ivec2 offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static vec4 TextureLodOffset(sampler2D sampler, vec2 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static ivec4 TextureLodOffset(isampler2D sampler, vec2 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static uvec4 TextureLodOffset(usampler2D sampler, vec2 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureLodOffset (gsampler3D sampler, vec3 P, float lod, ivec3 offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static vec4 TextureLodOffset(sampler3D sampler, vec3 P, float lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static ivec4 TextureLodOffset(isampler3D sampler, vec3 P, float lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static uvec4 TextureLodOffset(usampler3D sampler, vec3 P, float lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureLodOffset (sampler1DShadow sampler, vec3 P, float lod, int offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static float TextureLodOffset(sampler1DShadow sampler, vec3 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureLodOffset (sampler2DShadow sampler, vec3 P, float lod, ivec2 offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static float TextureLodOffset(sampler2DShadow sampler, vec3 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region TextureProjLod

        #region gvec4 TextureProjLod (gsampler1D sampler, vec2 P, float lod)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static vec4 TextureProjLod(sampler1D sampler, vec2 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static ivec4 TextureProjLod(isampler1D sampler, vec2 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static uvec4 TextureProjLod(usampler1D sampler, vec2 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjLod (gsampler1D sampler, vec4 P, float lod)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static vec4 TextureProjLod(sampler1D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static ivec4 TextureProjLod(isampler1D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static uvec4 TextureProjLod(usampler1D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjLod (gsampler2D sampler, vec3 P, float lod)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static vec4 TextureProjLod(sampler2D sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static ivec4 TextureProjLod(isampler2D sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static uvec4 TextureProjLod(usampler2D sampler, vec3 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjLod (gsampler2D sampler, vec4 P, float lod)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static vec4 TextureProjLod(sampler2D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static ivec4 TextureProjLod(isampler2D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static uvec4 TextureProjLod(usampler2D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjLod (gsampler3D sampler, vec4 P, float lod)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static vec4 TextureProjLod(sampler3D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static ivec4 TextureProjLod(isampler3D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static uvec4 TextureProjLod(usampler3D sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProjLod (sampler1DShadow sampler, vec4 P, float lod)
        
        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static float TextureProjLod(sampler1DShadow sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProjLod (sampler2DShadow sampler, vec4 P, float lod)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static float TextureProjLod(sampler2DShadow sampler, vec4 P, float lod)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region TextureProjLodOffset

        #region gvec4 TextureProjLodOffset (gsampler1D sampler, vec2 P, float lod, int offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static vec4 TextureProjLodOffset(sampler1D sampler, vec2 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static ivec4 TextureProjLodOffset(isampler1D sampler, vec2 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static uvec4 TextureProjLodOffset(usampler1D sampler, vec2 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjLodOffset (gsampler1D sampler, vec4 P, float lod, int offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static vec4 TextureProjLodOffset(sampler1D sampler, vec4 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static ivec4 TextureProjLodOffset(isampler1D sampler, vec4 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static uvec4 TextureProjLodOffset(usampler1D sampler, vec4 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjLodOffset (gsampler2D sampler, vec3 P, float lod, ivec2 offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static vec4 TextureProjLodOffset(sampler2D sampler, vec3 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static ivec4 TextureProjLodOffset(isampler2D sampler, vec3 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static uvec4 TextureProjLodOffset(usampler2D sampler, vec3 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjLodOffset (gsampler2D sampler, vec4 P, float lod, ivec2 offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static vec4 TextureProjLodOffset(sampler2D sampler, vec4 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static ivec4 TextureProjLodOffset(isampler2D sampler, vec4 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static uvec4 TextureProjLodOffset(usampler2D sampler, vec4 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjLodOffset (gsampler3D sampler, vec4 P, float lod, ivec3 offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static vec4 TextureProjLodOffset(sampler3D sampler, vec4 P, float lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static ivec4 TextureProjLodOffset(isampler3D sampler, vec4 P, float lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static uvec4 TextureProjLodOffset(usampler3D sampler, vec4 P, float lod, ivec3 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProjLodOffset (sampler1DShadow sampler, vec4 P, float lod, int offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static float TextureProjLodOffset(sampler1DShadow sampler, vec4 P, float lod, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProjLodOffset (sampler2DShadow sampler, vec4 P, float lod, ivec2 offset)

        /// <summary>  Do an offset texture lookup with explicit LOD. See TextureLod and TextureOffset.</summary>
        protected internal static float TextureProjLodOffset(sampler2DShadow sampler, vec4 P, float lod, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region TextureGrad

        #region gvec4 TextureGrad (gsampler1D sampler, float P, float dPdx, float dPdy)

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P/∂x; ∂s/∂y = ∂P/∂y; ∂t/∂x = 0; ∂t/∂y = 0; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected internal static vec4 TextureGrad(sampler1D sampler, float P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P/∂x; ∂s/∂y = ∂P/∂y; ∂t/∂x = 0; ∂t/∂y = 0; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected internal static ivec4 TextureGrad(isampler1D sampler, float P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P/∂x; ∂s/∂y = ∂P/∂y; ∂t/∂x = 0; ∂t/∂y = 0; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected internal static uvec4 TextureGrad(usampler1D sampler, float P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureGrad (gsampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy)

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected internal static vec4 TextureGrad(sampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected internal static ivec4 TextureGrad(isampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected internal static uvec4 TextureGrad(usampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureGrad (gsampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy)

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = ∂P.p/∂x; ∂r/∂y = ∂P.p/∂y;</summary>
        protected internal static vec4 TextureGrad(sampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = ∂P.p/∂x; ∂r/∂y = ∂P.p/∂y;</summary>
        protected internal static ivec4 TextureGrad(isampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = ∂P.p/∂x; ∂r/∂y = ∂P.p/∂y;</summary>
        protected internal static uvec4 TextureGrad(usampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureGrad (gsamplerCube sampler, vec3 P, vec3 dPdx, vec3 dPdy)

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = ∂P.p/∂x; ∂r/∂y = ∂P.p/∂y;</summary>
        protected internal static vec4 TextureGrad(samplerCube sampler, vec3 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = ∂P.p/∂x; ∂r/∂y = ∂P.p/∂y;</summary>
        protected internal static ivec4 TextureGrad(isamplerCube sampler, vec3 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = ∂P.p/∂x; ∂r/∂y = ∂P.p/∂y;</summary>
        protected internal static uvec4 TextureGrad(usamplerCube sampler, vec3 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureGrad (gsampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        
        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected internal static vec4 TextureGrad(sampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected internal static ivec4 TextureGrad(isampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected internal static uvec4 TextureGrad(usampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }
        
        #endregion

        #region float TextureGrad (sampler2DRectShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        
        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected internal static float TextureGrad(sampler2DRectShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureGrad (sampler1DShadow sampler, vec3 P, float dPdx, float dPdy)

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P/∂x; ∂s/∂y = ∂P/∂y; ∂t/∂x = 0; ∂t/∂y = 0; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected internal static float TextureGrad(sampler1DShadow sampler, vec3 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureGrad (sampler2DShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        
        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = 0; ∂r/∂y = 0;</summary>
        protected internal static float TextureGrad(sampler2DShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureGrad (samplerCubeShadow sampler, vec4 P, vec3 dPdx, vec3 dPdy)

        /// <summary> Do a texture lookup as in texture but with explicit gradients. 
        /// The partial derivatives of P are with respect to window x and window y.
        /// ∂s/∂x = ∂P.s/∂x; ∂s/∂y = ∂P.s/∂y; ∂t/∂x = ∂P.t/∂x; ∂t/∂y = ∂P.t/∂y; ∂r/∂x = ∂P.p/∂x; ∂r/∂y = ∂P.p/∂y;</summary>
        protected internal static float TextureGrad(samplerCubeShadow sampler, vec4 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region TextureGradOffset

        #region gvec4 TextureGradOffset (gsampler1D sampler, float P, float dPdx, float dPdy, int offset)

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static vec4 TextureGradOffset(sampler1D sampler, float P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static ivec4 TextureGradOffset(isampler1D sampler, float P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static uvec4 TextureGradOffset(usampler1D sampler, float P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureGradOffset (gsampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static vec4 TextureGradOffset(sampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static ivec4 TextureGradOffset(isampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static uvec4 TextureGradOffset(usampler2D sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureGradOffset (gsampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy, ivec3 offset)

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static vec4 TextureGradOffset(sampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static ivec4 TextureGradOffset(isampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static uvec4 TextureGradOffset(usampler3D sampler, vec3 P, vec3 dPdx, vec3 dPdy, ivec3 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureGradOffset (gsampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static vec4 TextureGradOffset(sampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static ivec4 TextureGradOffset(isampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static uvec4 TextureGradOffset(usampler2DRect sampler, vec2 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureGradOffset (sampler2DRectShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static float TextureGradOffset(sampler2DRectShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureGradOffset (sampler1DShadow sampler, vec3 P, float dPdx, float dPdy, int offset )

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static float TextureGradOffset(sampler1DShadow sampler, vec3 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureGradOffset (sampler2DShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup with both explicit gradient and offset, as described in TextureGrad and TextureOffset. </summary>
        protected internal static float TextureGradOffset(sampler2DShadow sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region TextureProjGrad

        #region gvec4 TextureProjGrad (gsampler1D sampler, vec2 P, float dPdx, float dPdy)

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static vec4 TextureProjGrad(sampler1D sampler, vec2 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static ivec4 TextureProjGrad(isampler1D sampler, vec2 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static uvec4 TextureProjGrad(usampler1D sampler, vec2 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjGrad (gsampler1D sampler, vec4 P, float dPdx, float dPdy)

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static vec4 TextureProjGrad(sampler1D sampler, vec4 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static ivec4 TextureProjGrad(isampler1D sampler, vec4 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static uvec4 TextureProjGrad(usampler1D sampler, vec4 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjGrad (gsampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        
        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static vec4 TextureProjGrad(sampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static ivec4 TextureProjGrad(isampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static uvec4 TextureProjGrad(usampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjGrad (gsampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy)

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static vec4 TextureProjGrad(sampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static ivec4 TextureProjGrad(isampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static uvec4 TextureProjGrad(usampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjGrad (gsampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy)

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static vec4 TextureProjGrad(sampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static ivec4 TextureProjGrad(isampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static uvec4 TextureProjGrad(usampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjGrad (gsampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy)

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static vec4 TextureProjGrad(sampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static ivec4 TextureProjGrad(isampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static uvec4 TextureProjGrad(usampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjGrad (gsampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy)

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static vec4 TextureProjGrad(sampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static ivec4 TextureProjGrad(isampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static uvec4 TextureProjGrad(usampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProjGrad (sampler2DRectShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy)

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static float TextureProjGrad(sampler2DRectShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProjGrad (sampler1DShadow sampler, vec4 P, float dPdx, float dPdy)

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static float TextureProjGrad(sampler1DShadow sampler, vec4 P, float dPdx, float dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProjGrad (sampler2DShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy)

        /// <summary>Do a texture lookup both projectively, as described in TextureProj, and with explicit gradient as 
        /// described in TextureGrad. The partial derivatives dPdx and dPdy are assumed to be already projected.</summary>
        protected internal static float TextureProjGrad(sampler2DShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion

        #region TextureProjGradOffset

        #region gvec4 TextureProjGradOffset (gsampler1D sampler, vec2 P, float dPdx, float dPdy, int offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static vec4 TextureProjGradOffset(sampler1D sampler, vec2 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static ivec4 TextureProjGradOffset(isampler1D sampler, vec2 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static uvec4 TextureProjGradOffset(usampler1D sampler, vec2 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjGradOffset (gsampler1D sampler, vec4 P, float dPdx, float dPdy, int offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static vec4 TextureProjGradOffset(sampler1D sampler, vec4 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static ivec4 TextureProjGradOffset(isampler1D sampler, vec4 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static uvec4 TextureProjGradOffset(usampler1D sampler, vec4 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjGradOffset (gsampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static vec4 TextureProjGradOffset(sampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static ivec4 TextureProjGradOffset(isampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static uvec4 TextureProjGradOffset(usampler2D sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjGradOffset (gsampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static vec4 TextureProjGradOffset(sampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static ivec4 TextureProjGradOffset(isampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static uvec4 TextureProjGradOffset(usampler2D sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjGradOffset (gsampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        
        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static vec4 TextureProjGradOffset(sampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static ivec4 TextureProjGradOffset(isampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static uvec4 TextureProjGradOffset(usampler2DRect sampler, vec3 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjGradOffset (gsampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static vec4 TextureProjGradOffset(sampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static ivec4 TextureProjGradOffset(isampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static uvec4 TextureProjGradOffset(usampler2DRect sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion
        
        #region float TextureProjGradOffset (sampler2DRectShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static float TextureProjGradOffset(sampler2DRectShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region gvec4 TextureProjGradOffset (gsampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy, ivec3 offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static vec4 TextureProjGradOffset(sampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static ivec4 TextureProjGradOffset(isampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy, ivec3 offset)
        {
            throw _invalidAccess;
        }

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static uvec4 TextureProjGradOffset(usampler3D sampler, vec4 P, vec3 dPdx, vec3 dPdy, ivec3 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProjGradOffset (sampler1DShadow sampler, vec4 P, float dPdx, float dPdy, int offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static float TextureProjGradOffset(sampler1DShadow sampler, vec4 P, float dPdx, float dPdy, int offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #region float TextureProjGradOffset (sampler2DShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)

        /// <summary>Do a texture lookup projectively and with explicit gradient as described in TextureProjGrad,
        /// as well as with offset, as described in TextureOffset.</summary>
        protected internal static float TextureProjGradOffset(sampler2DShadow sampler, vec4 P, vec2 dPdx, vec2 dPdy, ivec2 offset)
        {
            throw _invalidAccess;
        }

        #endregion

        #endregion
    }
}

// ReSharper restore InconsistentNaming
