using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Descriptions;
using IIS.SLSharp.Shaders;
using Mono.Cecil;

namespace IIS.SLSharp.Translation.GLSL
{
    public static class GlslSourceBuilder
    {
        private static readonly Dictionary<Type, string> _complexTypeName = new Dictionary<Type, string>
        {
            { typeof(void), "void" },
            { typeof(float), "float" },
            { typeof(ShaderDefinition.vec2), "vec2" },
            { typeof(ShaderDefinition.vec3), "vec3" },
            { typeof(ShaderDefinition.vec4), "vec4" },
            { typeof(ShaderDefinition.mat2), "mat2" },
            { typeof(ShaderDefinition.mat2x3), "mat2x3" },
            { typeof(ShaderDefinition.mat2x4), "mat2x4" },
            { typeof(ShaderDefinition.mat3x2), "mat3x2" },
            { typeof(ShaderDefinition.mat3), "mat3" },
            { typeof(ShaderDefinition.mat3x4), "mat3x4" },
            { typeof(ShaderDefinition.mat4x2), "mat4x2" },
            { typeof(ShaderDefinition.mat4x3), "mat4x3" },
            { typeof(ShaderDefinition.mat4), "mat4" },
            { typeof(ShaderDefinition.sampler1D), "sampler1D" },
            { typeof(ShaderDefinition.sampler2D), "sampler2D" },
            { typeof(ShaderDefinition.sampler3D), "sampler3D" },
            { typeof(ShaderDefinition.samplerCube), "samplerCube" },
            { typeof(ShaderDefinition.sampler1DShadow), "sampler1DShadow" },
            { typeof(ShaderDefinition.sampler2DShadow), "sampler2DShadow" },
            { typeof(ShaderDefinition.isampler1D), "isampler1D" },
            { typeof(ShaderDefinition.isampler2D), "isampler2D" },
            { typeof(ShaderDefinition.isampler3D), "isampler3D" },
            { typeof(ShaderDefinition.isamplerCube), "isamplerCube" },
            { typeof(ShaderDefinition.usampler1D), "usampler1D" },
            { typeof(ShaderDefinition.usampler2D), "usampler2D" },
            { typeof(ShaderDefinition.usampler3D), "usampler3D" },
            { typeof(ShaderDefinition.usamplerCube), "usamplerCube" },
            { typeof(ShaderDefinition.sampler2DRect), "sampler2DRect" },
            { typeof(ShaderDefinition.sampler2DRectShadow), "sampler2DRectShadow" },
            { typeof(ShaderDefinition.isampler2DRect), "isampler2DRect" },
            { typeof(ShaderDefinition.usampler2DRect), "usampler2DRect" },
            { typeof(int), "int" },
            { typeof(ShaderDefinition.ivec2), "ivec2" },
            { typeof(ShaderDefinition.ivec3), "ivec3" },
            { typeof(ShaderDefinition.ivec4), "ivec4" },
            { typeof(uint), "uint" },
            { typeof(ShaderDefinition.uvec2), "uvec2" },
            { typeof(ShaderDefinition.uvec3), "uvec3" },
            { typeof(ShaderDefinition.uvec4), "uvec4" },
            { typeof(double), "double" },
            { typeof(ShaderDefinition.dvec2), "dvec2" },
            { typeof(ShaderDefinition.dvec3), "dvec3" },
            { typeof(ShaderDefinition.dvec4), "dvec4" },
            { typeof(ShaderDefinition.dmat2), "dmat2" },
            { typeof(ShaderDefinition.dmat2x3), "dmat2x3" },
            { typeof(ShaderDefinition.dmat2x4), "dmat2x4" },
            { typeof(ShaderDefinition.dmat3x2), "dmat3x2" },
            { typeof(ShaderDefinition.dmat3), "dmat3" },
            { typeof(ShaderDefinition.dmat3x4), "dmat3x4" },
            { typeof(ShaderDefinition.dmat4x2), "dmat4x2" },
            { typeof(ShaderDefinition.dmat4x3), "dmat4x3" },
            { typeof(ShaderDefinition.dmat4), "dmat4" },
            { typeof(bool), "bool" },
            { typeof(ShaderDefinition.bvec2), "bvec2" },
            { typeof(ShaderDefinition.bvec3), "bvec3" },
            { typeof(ShaderDefinition.bvec4), "bvec4" },
        };

        internal static string ToGlsl(this TypeReference t)
        {
            var typeDef = t.Resolve();
            return Shader.TypeMap[typeDef.MetadataToken.ToInt32()].Type.ToGlsl();
        }

        public static string ToGlsl(this Type t)
        {
            string glslName;
            if (!_complexTypeName.TryGetValue(t, out glslName))
                throw new SLSharpException(t + " is currently not supported by GLSL module");

            return glslName;
        }

        public static string ToGlsl(this SourceDescription desc, ShaderType type)
        {
            var s = new StringBuilder();

            s.AppendLine("#version 130");

            if (type == ShaderType.FragmentShader)
                s.AppendLine("precision highp float;");

            s.AppendLine("// " + type);
            
            desc.Uniforms.ForEach(
                v => s.AppendFormat("uniform {0} {1};{2}", v.Type.ToGlsl(), v.Name, v.Comment).Append(Environment.NewLine));

            var varyingDirection = type == ShaderType.VertexShader ? "out" : "in";
            desc.Varyings.ForEach(
                v =>
                s.AppendFormat("{0} {1} {2};{3}", varyingDirection, v.Type.ToGlsl(), v.Name, v.Comment).Append(
                    Environment.NewLine));


            if (type == ShaderType.VertexShader)
                desc.VertexIns.ForEach(
                    v => s.AppendFormat("in {0} {1};{2}", v.Type.ToGlsl(), v.Name, v.Comment).Append(Environment.NewLine));

            if (type == ShaderType.FragmentShader)
                desc.FragmentOuts.ForEach(
                    v => s.AppendFormat("out {0} {1};{2}", v.Type.ToGlsl(), v.Name, v.Comment).Append(Environment.NewLine));

            s.AppendLine();
            desc.ForwardDecl.ForEach(v => s.AppendLine(v));
            s.AppendLine();


            desc.Functions.ForEach(v => s.AppendLine(v.Body));

            var entry = desc.Functions.FirstOrDefault(x => x.Type == type && x.EntryPoint);
            if (entry != null)
            {
                s.AppendLine("void main()").AppendLine("{");
                s.AppendLine("    " + entry.Name + "();");
                if (type == ShaderType.VertexShader)
                {
                    var glPosition = desc.Varyings.FirstOrDefault(x => x.Semantic == UsageSemantic.Position0);
                    // glPosition write is mandatory in a vs.
                    // In theory a lib could supply this, we dont support this with the new syntax anymore at the moment tho.
                    // in order for support we'd need to scan over all dependency varyings as well.
                    if (glPosition == null)
                        throw new SLSharpException("Vertexshader must output a Position");
                    s.AppendLine("    gl_Position = " + glPosition.Name + ";");
                }

                if (type == ShaderType.FragmentShader)
                {
                    var glFragDepth = desc.FragmentOuts.FirstOrDefault(x => x.Semantic == UsageSemantic.Depth);

                    if (glFragDepth != null)
                    {
                        // validate type and let SL# throw rather than generate invalid GL code
                        if (glFragDepth.Type != typeof(float))
                            throw new SLSharpException(glFragDepth.Name + "'s must be float, as it is marked as fragment depth!");
                        s.AppendLine("    gl_FragDepth = " + glFragDepth.Name + ";");
                    }
                }

                s.AppendLine("}");
            }

            var src = s.ToString();
            Console.WriteLine(src);

            return src;
        }
    }
}
