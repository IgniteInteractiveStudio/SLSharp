using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using IIS.SLSharp.Descriptions;
using IIS.SLSharp.Shaders;
using Mono.Cecil;

namespace IIS.SLSharp.Translation.GLSL
{
    public sealed class GlslTransform: ITransform
    {
        private readonly HashSet<Tuple<string, string>> _functions = new HashSet<Tuple<string, string>>();

        private readonly HashSet<Type> _dependencies = new HashSet<Type>(); 

        public void ResetState()
        {
            _functions.Clear();
            _dependencies.Clear();
        }

        /// <summary>
        /// Public translation interface.
        /// Translates the given method to GLSL
        /// </summary>
        /// <param name="s">Shader type definition.</param>
        /// <param name="m">A method representing a shader to translate.</param>
        /// <param name="attr">The shader type as attribute (either FragmentShaderAttribute or VertexShaderAttribute</param>
        /// <param name="type">The shader type as ShaderType</param>
        /// <returns>The translated GLSL shader source</returns>
        public FunctionDescription Transform(TypeDefinition s, MethodDefinition m, CustomAttribute attr,
            ShaderType type)
        {
            if (s == null)
                throw new ArgumentNullException("s");

            if (m == null)
                throw new ArgumentNullException("m");

            if (attr == null)
                throw new ArgumentNullException("attr");

            var ctx = new DecompilerContext(s.Module)
            {
                CurrentType = s,
                CurrentMethod = m,
                CancellationToken = CancellationToken.None
            };

            var d = AstMethodBodyBuilder.CreateMethodBody(m, ctx);

            var glsl = new GlslVisitor(d, attr, ctx);

            _functions.UnionWith(glsl.Functions);

            var sig = GlslVisitor.GetSignature(m);
            var entry = (bool)attr.ConstructorArguments.FirstOrDefault().Value;
            var code = glsl.Result;
            var desc = new FunctionDescription(Shader.GetMethodName(m), sig + code, entry, type);

            _dependencies.UnionWith(glsl.Dependencies);

            return desc;
        }

        public List<string> ForwardDeclare(bool debugInfo)
        {
            return _functions.Select(f => f.Item1 + ";" + (debugInfo ? " // " + f.Item2 : string.Empty)).ToList();
        }

        private Shader[] _workaroundDependencies;

        public IEnumerable<Shader> WorkaroundDependencies
        {
            get
            {
                return _workaroundDependencies ?? (_workaroundDependencies = new Shader[]
                {
                    Shader.CreateInstance<Workarounds.Trigonometric>(),
                    Shader.CreateInstance<Workarounds.Exponential>()
                });
            }
        }

        public IEnumerable<Type> Dependencies
        {
            get { return _dependencies; }
        }
    }
}
