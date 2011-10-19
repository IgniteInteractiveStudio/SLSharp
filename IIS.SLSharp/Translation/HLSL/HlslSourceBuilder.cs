using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IIS.SLSharp.Annotations;
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
            { typeof(ShaderDefinition.sampler2D), "sampler" },
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

        public static string ToHlsl(this UsageSemantic semantic)
        {
            switch (semantic)
            {
                case UsageSemantic.Position0: return "POSITION0";
                case UsageSemantic.Position1: return "POSITION1";
                case UsageSemantic.Position2: return "POSITION2";
                case UsageSemantic.Position3: return "POSITION3";
                case UsageSemantic.Position4: return "POSITION4";
                case UsageSemantic.Position5: return "POSITION5";
                case UsageSemantic.Position6: return "POSITION6";
                case UsageSemantic.Position7: return "POSITION7";
                case UsageSemantic.Position8: return "POSITION8";
                case UsageSemantic.Position9: return "POSITION9";
                case UsageSemantic.Position10: return "POSITION10";
                case UsageSemantic.Position11: return "POSITION11";
                case UsageSemantic.Position12: return "POSITION12";
                case UsageSemantic.Position13: return "POSITION13";
                case UsageSemantic.Position14: return "POSITION14";
                case UsageSemantic.Position15: return "POSITION15";

                case UsageSemantic.Color0: return "COLOR0";
                case UsageSemantic.Color1: return "COLOR1";
                case UsageSemantic.Color2: return "COLOR2";
                case UsageSemantic.Color3: return "COLOR3";
                case UsageSemantic.Color4: return "COLOR4";
                case UsageSemantic.Color5: return "COLOR5";
                case UsageSemantic.Color6: return "COLOR6";
                case UsageSemantic.Color7: return "COLOR7";
                case UsageSemantic.Color8: return "COLOR8";
                case UsageSemantic.Color9: return "COLOR9";
                case UsageSemantic.Color10: return "COLOR10";
                case UsageSemantic.Color11: return "COLOR11";
                case UsageSemantic.Color12: return "COLOR12";
                case UsageSemantic.Color13: return "COLOR13";
                case UsageSemantic.Color14: return "COLOR14";
                case UsageSemantic.Color15: return "COLOR15";

                case UsageSemantic.Texcoord0: return "TEXCOORD0";
                case UsageSemantic.Texcoord1: return "TEXCOORD1";
                case UsageSemantic.Texcoord2: return "TEXCOORD2";
                case UsageSemantic.Texcoord3: return "TEXCOORD3";
                case UsageSemantic.Texcoord4: return "TEXCOORD4";
                case UsageSemantic.Texcoord5: return "TEXCOORD5";
                case UsageSemantic.Texcoord6: return "TEXCOORD6";
                case UsageSemantic.Texcoord7: return "TEXCOORD7";
                case UsageSemantic.Texcoord8: return "TEXCOORD8";
                case UsageSemantic.Texcoord9: return "TEXCOORD9";
                case UsageSemantic.Texcoord10: return "TEXCOORD10";
                case UsageSemantic.Texcoord11: return "TEXCOORD11";
                case UsageSemantic.Texcoord12: return "TEXCOORD12";
                case UsageSemantic.Texcoord13: return "TEXCOORD13";
                case UsageSemantic.Texcoord14: return "TEXCOORD14";
                case UsageSemantic.Texcoord15: return "TEXCOORD15";

                case UsageSemantic.Normal0: return "NORMAL0";
                case UsageSemantic.Normal1: return "NORMAL1";
                case UsageSemantic.Normal2: return "NORMAL2";
                case UsageSemantic.Normal3: return "NORMAL3";
                case UsageSemantic.Normal4: return "NORMAL4";
                case UsageSemantic.Normal5: return "NORMAL5";
                case UsageSemantic.Normal6: return "NORMAL6";
                case UsageSemantic.Normal7: return "NORMAL7";
                case UsageSemantic.Normal8: return "NORMAL8";
                case UsageSemantic.Normal9: return "NORMAL9";
                case UsageSemantic.Normal10: return "NORMAL10";
                case UsageSemantic.Normal11: return "NORMAL11";
                case UsageSemantic.Normal12: return "NORMAL12";
                case UsageSemantic.Normal13: return "NORMAL13";
                case UsageSemantic.Normal14: return "NORMAL14";
                case UsageSemantic.Normal15: return "NORMAL15";

                case UsageSemantic.Depth: return "DEPTH";
            }

            throw new SLSharpException("Usage semantic " + semantic + " currently not supported");
        }

        private static FunctionDescription VertexMain(this SourceDescription desc)
        {
            return desc.Functions.FirstOrDefault(f => f.EntryPoint && f.Type == ShaderType.VertexShader);
        }

        private static FunctionDescription FragmentMain(this SourceDescription desc)
        {
            return desc.Functions.FirstOrDefault(f => f.EntryPoint && f.Type == ShaderType.FragmentShader);
        }

        private static void GenerateVaryingStruct(StringBuilder s, SourceDescription desc)
        {
            var usedSemantics = new HashSet<UsageSemantic>();
            foreach (var x in desc.Varyings.Where(x => x.Semantic != UsageSemantic.Unknown))
            {
                s.AppendFormat("    {0} {1}: {2};", x.Type.ToHlsl(), x.Name, x.Semantic.ToHlsl()).AppendLine();
                if (!usedSemantics.Add(x.Semantic))
                    throw new SLSharpException(String.Format("Semantic {0} redefined with {1}", x.Semantic, x.Name));
            }
            foreach (var x in desc.Varyings.Where(x => x.Semantic == UsageSemantic.Unknown))
            {
                var t0 = UsageSemantic.Texcoord0;
                while (usedSemantics.Contains(t0))
                {
                    switch (t0)
                    {
                        case UsageSemantic.Texcoord15:
                            t0 = UsageSemantic.Color0;
                            break;
                        case UsageSemantic.Color15:
                            throw new SLSharpException("SLSharp does not support that many varyings for hlsl at the moment.");
                        default:
                            t0++;
                            break;
                    }
                    t0++;
                }
                s.AppendFormat("    {0} {1}: {2};", x.Type.ToHlsl(), x.Name, t0.ToHlsl()).AppendLine();
                usedSemantics.Add(t0);
            }
        }

        public static string ToHlsl(this SourceDescription desc)
        {
            var s = new StringBuilder();

            // define uniforms
            desc.Uniforms.ForEach(
                v =>
                {
                    var typ = v.Type.ToHlsl();
                    if (v.IsSampler() && v.DefaultRegister.HasValue)
                    {
                        // allocate a register for it
                        s.AppendFormat("uniform extern {0} {1} : register(s{3});{2}", typ, v.Name, v.Comment, v.DefaultRegister.Value).Append(Environment.NewLine);
                    } else
                        s.AppendFormat("uniform extern {0} {1};{2}", typ, v.Name, v.Comment).Append(Environment.NewLine);
                });

            // expose varyings inputs and outputs as globals for unified access
            // through all functions

            var statics = desc.Varyings.Concat(desc.VertexIns).Concat(desc.FragmentOuts);
            foreach (var v in statics)
                s.AppendFormat("static {0} {1};{2}", v.Type.ToHlsl(), v.Name, v.Comment).Append(Environment.NewLine);

            s.AppendLine();


            var vmain = desc.VertexMain();
            var fmain = desc.FragmentMain();

            desc.ForwardDecl.ForEach(v => s.AppendLine(v));
            s.AppendLine();
            desc.Functions.ForEach(v => s.AppendLine(v.Body));

            // generate vertex input struct
            if (vmain != null)
            {
                s.AppendLine("struct SLSharp_VertexIn");
                s.AppendLine("{");
                desc.VertexIns.ForEach(
                    v => s.AppendFormat("    {0} {1}: {2};", v.Type.ToHlsl(), v.Name, v.Semantic.ToHlsl()).AppendLine());
                s.AppendLine("};");
                s.AppendLine();

                s.AppendLine("struct SLSharp_VertexOut");
                s.AppendLine("{");
                GenerateVaryingStruct(s, desc);
                s.AppendLine("};");
                s.AppendLine();

                s.AppendLine("SLSharp_VertexOut SLSharp_VertexMain(SLSharp_VertexIn input)");
                s.AppendLine("{");
                s.AppendLine("    SLSharp_VertexOut output;");
                // initialize globals from input
                desc.VertexIns.ForEach(v => s.AppendFormat("    {0} = input.{1};", v.Name, v.Name).AppendLine());
                // call entrypoint
                s.AppendFormat("    {0}();", vmain.Name).AppendLine();
                // write back results from globals
                desc.Varyings.ForEach(v => s.AppendFormat("    output.{0} = {1};", v.Name, v.Name).AppendLine());
                s.AppendLine("    return output;");
                s.AppendLine("}");
            }

            if (fmain != null)
            {
                s.AppendLine("struct SLSharp_FragmentIn");
                s.AppendLine("{");
                GenerateVaryingStruct(s, desc);
                s.AppendLine("};");
                s.AppendLine();

                s.AppendLine("struct SLSharp_FragmentOut");
                s.AppendLine("{");
                desc.FragmentOuts.ForEach(
                    v => s.AppendFormat("    {0} {1}: {2};", v.Type.ToHlsl(), v.Name, v.Semantic.ToHlsl()).AppendLine());
                s.AppendLine("};");
                s.AppendLine();

                s.AppendLine("SLSharp_FragmentOut SLSharp_FragmentMain(SLSharp_FragmentIn input)");
                s.AppendLine("{");
                s.AppendLine("    SLSharp_FragmentOut output;");
                // initialize globals from input
                desc.Varyings.ForEach(v => s.AppendFormat("    {0} = input.{1};", v.Name, v.Name).AppendLine());
                // call entrypoint
                s.AppendFormat("    {0}();", fmain.Name).AppendLine();
                // write back results from globals
                desc.FragmentOuts.ForEach(v => s.AppendFormat("    output.{0} = {1};", v.Name, v.Name).AppendLine());
                s.AppendLine("    return output;");
                s.AppendLine("}");
            }
            return s.ToString();
        }

        public static string ToHlslFx(this SourceDescription desc)
        {
            var s = new StringBuilder(desc.ToHlsl());
            s.AppendLine(@"
technique t0
{
    pass p0
    {
        VertexShader = compile vs_2_0 SLSharp_VertexMain();
        PixelShader = compile ps_2_0 SLSharp_FragmentMain();
    }
}
");
            return s.ToString();
        }
    }
}
