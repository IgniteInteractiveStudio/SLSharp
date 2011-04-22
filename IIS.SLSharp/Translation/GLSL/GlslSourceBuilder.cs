using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IIS.SLSharp.Descriptions;

namespace IIS.SLSharp.Translation.GLSL
{
    public static class GlslSourceBuilder
    {
        public static string ToGlsl(this SourceDescription desc, ShaderType type)
        {
            var s = new StringBuilder();

            s.AppendLine("#version 130");
            s.AppendLine("// " + type);
            
            desc.Uniforms.ForEach(
                v => s.AppendFormat("uniform {0} {1}{2};", v.Type, v.Name, v.Comment).Append(Environment.NewLine));

            var varyingDirection = type == ShaderType.VertexShader ? "out" : "in";
            desc.Varyings.ForEach(
                v =>
                s.AppendFormat("{0} {1} {2}{3};", varyingDirection, v.Type, v.Name, v.Comment).Append(
                    Environment.NewLine));


            if (type == ShaderType.VertexShader)
                desc.VertexIns.ForEach(
                    v => s.AppendFormat("in {0} {1}{2};", v.Type, v.Name, v.Comment).Append(Environment.NewLine));

            if (type == ShaderType.FragmentShader)
                desc.FragmentOuts.ForEach(
                    v => s.AppendFormat("out {0} {1}{2};", v.Type, v.Name, v.Comment).Append(Environment.NewLine));

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
