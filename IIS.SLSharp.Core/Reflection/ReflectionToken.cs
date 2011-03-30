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
        ShaderUniformMatrix4Helper,
        ShaderBegin,
        ResourceHelperRelease,
        ShaderSamplerHelper
    }
}
