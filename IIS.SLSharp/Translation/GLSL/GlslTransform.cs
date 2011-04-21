using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using Mono.Cecil;

namespace IIS.SLSharp.Translation.GLSL
{
    public sealed class GlslTransform: ITransform
    {
        private readonly HashSet<Tuple<string, string>> _functions = new HashSet<Tuple<string, string>>();

        public void ResetState()
        {
            _functions.Clear();
        }

        /// <summary>
        /// Public translation interface.
        /// Translates the given method to GLSL
        /// </summary>
        /// <param name="s">Shader type definition.</param>
        /// <param name="m">A method representing a shader to translate.</param>
        /// <param name="attr">The shader type pass either (FragmentShaderAttribute or VertexShaderAttribute) </param>
        /// <returns>The translated GLSL shader source</returns>
        public string Transform(TypeDefinition s, MethodDefinition m, CustomAttribute attr)
        {
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

            var glsl = new GlslVisitor(d, attr);

            _functions.UnionWith(glsl.Functions);

            var entry = (bool)attr.ConstructorArguments.FirstOrDefault().Value;
            var sig = entry ? "void main()" : GlslVisitor.GetSignature(m);
            var code = glsl.Result;
            return sig + code;
        }

        public string ForwardDeclare(bool debugInfo)
        {
            return _functions.Aggregate(string.Empty, (a, b) =>
                a + b.Item1 + ";" +
                (debugInfo ? " // " + b.Item2 : string.Empty) +
                Environment.NewLine) + Environment.NewLine;
        }
    }
}
