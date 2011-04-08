using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Reflection;
using Mono.Cecil;

namespace IIS.SLSharp.Translation
{
    public sealed class GlslTransform
    {
        private readonly HashSet<string> _functions = new HashSet<string>();

        public IEnumerable<string> Functions
        {
            get { return _functions; }
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
    }
}
