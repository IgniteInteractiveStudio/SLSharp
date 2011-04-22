using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using IIS.SLSharp.Descriptions;
using Mono.Cecil;

namespace IIS.SLSharp.Translation.HLSL
{
    public sealed class HlslTransform: ITransform
    {
        private readonly HashSet<Tuple<string, string>> _functions = new HashSet<Tuple<string, string>>();

        public void ResetState()
        {
            _functions.Clear();
        }

        /// <summary>
        /// Public translation interface.
        /// Translates the given method to HLSL
        /// </summary>
        /// <param name="s">Shader type definition.</param>
        /// <param name="m">A method representing a shader to translate.</param>
        /// <param name="attr">The shader type pass either (FragmentShaderAttribute or VertexShaderAttribute) </param>
        /// <returns>The translated GLSL shader source</returns>
        public FunctionDescription Transform(TypeDefinition s, MethodDefinition m, CustomAttribute attr)
        {
            throw new NotImplementedException();
            /*
            if (s == null)
                throw new ArgumentNullException("s");

            if (m == null)
                throw new ArgumentNullException("m");

            if (attr == null)
                throw new ArgumentNullException("attr");

            var d = AstMethodBodyBuilder.CreateMethodBody(m, new DecompilerContext
            {
                CurrentType = s,
                CurrentMethod = m,
            });

            var hlsl = new HlslVisitor(d, attr);

            _functions.UnionWith(hlsl.Functions);

            var entry = (bool)attr.ConstructorArguments.FirstOrDefault().Value;
            var sig = entry ? "void main()" : HlslVisitor.GetSignature(m);
            var code = hlsl.Result;
            return sig + code;
             */
        }

        public List<string> ForwardDeclare(bool debugInfo)
        {
            return _functions.Select(f => f.Item1 + ";" + (debugInfo ? " // " + f.Item2 : string.Empty)).ToList();
        }
    }
}
