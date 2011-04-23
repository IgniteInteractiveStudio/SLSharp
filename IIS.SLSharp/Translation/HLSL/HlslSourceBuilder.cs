using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IIS.SLSharp.Descriptions;
using IIS.SLSharp.Shaders;
using Mono.Cecil;

namespace IIS.SLSharp.Translation.HLSL
{
    public static class HlslSourceBuilder
    {
        private static readonly Dictionary<Type, string> _complexTypeName = new Dictionary<Type, string>
        {
            { typeof(void), "void" },
            { typeof(float), "float" },
            { typeof(ShaderDefinition.vec2), "float2" },
            { typeof(ShaderDefinition.vec3), "float3" },
            { typeof(ShaderDefinition.vec4), "float4" },
            { typeof(ShaderDefinition.mat2), "flat2x2" },
            { typeof(ShaderDefinition.mat2x3), "float2x3" },
            { typeof(ShaderDefinition.mat2x4), "float2x4" },
            { typeof(ShaderDefinition.mat3x2), "float3x2" },
            { typeof(ShaderDefinition.mat3), "float3x3" },
            { typeof(ShaderDefinition.mat3x4), "float3x4" },
            { typeof(ShaderDefinition.mat4x2), "float4x2" },
            { typeof(ShaderDefinition.mat4x3), "float4x3" },
            { typeof(ShaderDefinition.mat4), "float4x4" },
            { typeof(ShaderDefinition.sampler1D), "sampler1D" },
            { typeof(ShaderDefinition.sampler2D), "sampler2D" },
            { typeof(ShaderDefinition.sampler3D), "sampler3D" },
            { typeof(ShaderDefinition.samplerCube), "samplerCube" },
            { typeof(ShaderDefinition.sampler1DShadow), "sampler1D" },
            { typeof(ShaderDefinition.sampler2DShadow), "sampler2D" },
            { typeof(ShaderDefinition.isampler1D), "sampler1D" },
            { typeof(ShaderDefinition.isampler2D), "sampler2D" },
            { typeof(ShaderDefinition.isampler3D), "sampler3D" },
            { typeof(ShaderDefinition.isamplerCube), "samplerCube" },
            { typeof(ShaderDefinition.usampler1D), "sampler1D" },
            { typeof(ShaderDefinition.usampler2D), "sampler2D" },
            { typeof(ShaderDefinition.usampler3D), "sampler3D" },
            { typeof(ShaderDefinition.usamplerCube), "samplerCube" },
            { typeof(ShaderDefinition.sampler2DRect), "sampler2D" },
            { typeof(ShaderDefinition.sampler2DRectShadow), "sampler2D" },
            { typeof(ShaderDefinition.isampler2DRect), "sampler2D" },
            { typeof(ShaderDefinition.usampler2DRect), "sampler2D" },
            { typeof(int), "int" },
            { typeof(ShaderDefinition.ivec2), "int2" },
            { typeof(ShaderDefinition.ivec3), "int3" },
            { typeof(ShaderDefinition.ivec4), "int4" },
            { typeof(uint), "uint" },
            { typeof(ShaderDefinition.uvec2), "uint2" },
            { typeof(ShaderDefinition.uvec3), "uint3" },
            { typeof(ShaderDefinition.uvec4), "uint4" },
            { typeof(double), "double" },
            { typeof(ShaderDefinition.dvec2), "double2" },
            { typeof(ShaderDefinition.dvec3), "double3" },
            { typeof(ShaderDefinition.dvec4), "double4" },
            { typeof(ShaderDefinition.dmat2), "double2x2" },
            { typeof(ShaderDefinition.dmat2x3), "double2x3" },
            { typeof(ShaderDefinition.dmat2x4), "double2x4" },
            { typeof(ShaderDefinition.dmat3x2), "double3x2" },
            { typeof(ShaderDefinition.dmat3), "double3x3" },
            { typeof(ShaderDefinition.dmat3x4), "double3x4" },
            { typeof(ShaderDefinition.dmat4x2), "double4x2" },
            { typeof(ShaderDefinition.dmat4x3), "double4x3" },
            { typeof(ShaderDefinition.dmat4), "double4x4" },
            { typeof(bool), "bool" },
            { typeof(ShaderDefinition.bvec2), "bool2" },
            { typeof(ShaderDefinition.bvec3), "bool3" },
            { typeof(ShaderDefinition.bvec4), "bool4" },
        };

        internal static string ToHlsl(this TypeReference t)
        {
            var typeDef = t.Resolve();
            return Shader.TypeMap[typeDef.MetadataToken.ToInt32()].Type.ToHlsl();
        }

        public static string ToHlsl(this Type t)
        {
            string glslName;
            if (!_complexTypeName.TryGetValue(t, out glslName))
                throw new SLSharpException(t + " is currently not supported by GLSL module");

            return glslName;
        }

        public static string ToHlsl(this SourceDescription desc)
        {
            var s = new StringBuilder();

            // define uniforms
            desc.Uniforms.ForEach(
                v => s.AppendFormat("uniform extern {0} {1}{2};", v.Type.ToHlsl(), v.Name, v.Comment).Append(Environment.NewLine));

            // expose varyings inputs and outputs as globals for unified access
            // through all functions
            var statics = desc.Varyings.Concat(desc.VertexIns).Concat(desc.FragmentOuts);
            foreach (var v in statics)
                s.AppendFormat("uniform static {0} {1}{2};", v.Type.ToHlsl(), v.Name, v.Comment).Append(Environment.NewLine);
            
            // define inputs as globals


            s.AppendLine();
            desc.ForwardDecl.ForEach(v => s.AppendLine(v));

            s.AppendLine();
            desc.Functions.ForEach(v => s.AppendLine(v.Body));

            var src = s.ToString();
            Console.WriteLine(src);

            return src;
        }
    }
}
