using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IIS.SLSharp.Descriptions;

namespace IIS.SLSharp.Translation.HLSL
{
    public static class HlslSourceBuilder
    {
        public static string ToHlsl(this SourceDescription desc)
        {
            var s = new StringBuilder();

            // define uniforms
            desc.Uniforms.ForEach(
                v => s.AppendFormat("uniform extern {0} {1}{2};", v.Type, v.Name, v.Comment).Append(Environment.NewLine));

            // expose varyings inputs and outputs as globals for unified access
            // through all functions
            var statics = desc.Varyings.Concat(desc.VertexIns).Concat(desc.FragmentOuts);
            foreach (var v in statics)
                s.AppendFormat("uniform static {0} {1}{2};", v.Type, v.Name, v.Comment).Append(Environment.NewLine);
            
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
