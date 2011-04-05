using IIS.SLSharp.Core.Reflection;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp
{
    public static class ShaderHelpers
    {
        [ReflectionMarker(ReflectionToken.ShaderVec2Helper)]
        public static void UniformVecHelper2(int location)
        {
            GL.Uniform2(location, ShaderDefinition.vec2.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderVec3Helper)]
        public static void UniformVecHelper3(int location)
        {
            GL.Uniform3(location, ShaderDefinition.vec3.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderVec4Helper)]
        public static void UniformVecHelper4(int location)
        {
            GL.Uniform4(location, ShaderDefinition.vec4.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderIvec2Helper)]
        public static void UniformIvecHelper2(int location)
        {
            GL.Uniform2(location, 1, ShaderDefinition.ivec2.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderIvec3Helper)]
        public static void UniformIvecHelper3(int location)
        {
            GL.Uniform3(location, 1, ShaderDefinition.ivec3.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderIvec4Helper)]
        public static void UniformIvecHelper4(int location)
        {
            GL.Uniform4(location, 1, ShaderDefinition.ivec4.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderUvec2Helper)]
        public static void UniformUvecHelper2(int location)
        {
            GL.Uniform2(location, 1, ShaderDefinition.uvec2.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderUvec3Helper)]
        public static void UniformUvecHelper3(int location)
        {
            GL.Uniform3(location, 1, ShaderDefinition.uvec3.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderUvec4Helper)]
        public static void UniformUvecHelper4(int location)
        {
            GL.Uniform4(location, 1, ShaderDefinition.uvec4.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderDvec2Helper)]
        public static void UniformDvecHelper2(int location)
        {
            GL.Uniform2(location, ShaderDefinition.dvec2.value.X, ShaderDefinition.dvec2.value.Y);
        }

        [ReflectionMarker(ReflectionToken.ShaderDvec3Helper)]
        public static void UniformDvecHelper3(int location)
        {
            GL.Uniform3(location, ShaderDefinition.dvec3.value.X, ShaderDefinition.dvec3.value.Y, ShaderDefinition.dvec3.value.Z);
        }

        [ReflectionMarker(ReflectionToken.ShaderDvec4Helper)]
        public static void UniformDvecHelper4(int location)
        {
            GL.Uniform4(location, ShaderDefinition.dvec4.value.X, ShaderDefinition.dvec4.value.Y, ShaderDefinition.dvec4.value.Z,
                ShaderDefinition.dvec4.value.W);
        }

        [ReflectionMarker(ReflectionToken.ShaderUniformMatrix2X2Helper)]
        public static void UniformMatrix2Helper(int location)
        {
            GL.UniformMatrix2(location, 1, false, ShaderDefinition.mat2.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderUniformMatrix2X3Helper)]
        public static void UniformMatrix2X3Helper(int location)
        {
            GL.UniformMatrix2x3(location, 1, false, ShaderDefinition.mat2x3.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderUniformMatrix2X4Helper)]
        public static void UniformMatrix2X4Helper(int location)
        {
            GL.UniformMatrix2x4(location, 1, false, ShaderDefinition.mat2x4.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderUniformMatrix3X2Helper)]
        public static void UniformMatrix3X2Helper(int location)
        {
            GL.UniformMatrix3x2(location, 1, false, ShaderDefinition.mat3x2.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderUniformMatrix3X3Helper)]
        public static void UniformMatrix3Helper(int location)
        {
            GL.UniformMatrix3(location, 1, false, ShaderDefinition.mat3.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderUniformMatrix3X4Helper)]
        public static void UniformMatrix3X4Helper(int location)
        {
            GL.UniformMatrix3x4(location, 1, false, ShaderDefinition.mat3x4.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderUniformMatrix4X2Helper)]
        public static void UniformMatrix4X2Helper(int location)
        {
            GL.UniformMatrix4x2(location, 1, false, ShaderDefinition.mat4x2.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderUniformMatrix4X3Helper)]
        public static void UniformMatrix4X3Helper(int location)
        {
            GL.UniformMatrix4x3(location, 1, false, ShaderDefinition.mat4x3.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderUniformMatrix4X4Helper)]
        public static void UniformMatrix4Helper(int location)
        {
            GL.UniformMatrix4(location, false, ref ShaderDefinition.mat4.value);
        }

        [ReflectionMarker(ReflectionToken.ShaderSamplerHelper)]
        public static void UniformSamplerHelper(int location)
        {
            GL.Uniform1(location, ShaderDefinition.Sampler.value);
        }
    }
}
