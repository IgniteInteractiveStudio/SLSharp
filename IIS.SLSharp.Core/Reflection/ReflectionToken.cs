using System;

namespace IIS.SLSharp.Core.Reflection
{
    [Serializable]
    public enum ReflectionToken
    {
        ShaderName,
        ShaderActivate,
        ShaderVec2Helper,
        ShaderVec3Helper,
        ShaderVec4Helper,
        ShaderUniformMatrix2X2Helper,
        ShaderUniformMatrix2X3Helper,
        ShaderUniformMatrix2X4Helper,
        ShaderUniformMatrix3X2Helper,
        ShaderUniformMatrix3X3Helper,
        ShaderUniformMatrix3X4Helper,
        ShaderUniformMatrix4X2Helper,
        ShaderUniformMatrix4X3Helper,
        ShaderUniformMatrix4X4Helper,
        ShaderBegin,
        ResourceHelperRelease,
        ShaderSamplerHelper,
        ShaderIvec2Helper,
        ShaderIvec3Helper,
        ShaderIvec4Helper,
        ShaderUvec2Helper,
        ShaderUvec3Helper,
        ShaderUvec4Helper,
        ShaderDvec2Helper,
        ShaderDvec3Helper,
        ShaderDvec4Helper,
    }
}
