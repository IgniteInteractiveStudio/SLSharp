using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using IIS.SLSharp.Descriptions;
using IIS.SLSharp.Shaders;
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
            if (s == null)
                throw new ArgumentNullException("s");

            if (m == null)
                throw new ArgumentNullException("m");

            if (attr == null)
                throw new ArgumentNullException("attr");

            var sbase = s.BaseType.Resolve();
            while (sbase.MetadataToken.ToInt32() != typeof(Shader).MetadataToken)
                sbase = sbase.BaseType.Resolve();

            var d = AstMethodBodyBuilder.CreateMethodBody(m, new DecompilerContext
            {
                CurrentType = s,
                CurrentMethod = m,
                CancellationToken = CancellationToken.None
            });

            //var ctx = new CecilTypeResolveContext(sbase.Module);

            var loader = new CecilLoader();
            var mscorlib = loader.LoadAssemblyFile(typeof(object).Assembly.Location);
            var slsharp = loader.LoadAssembly(sbase.Module.Assembly); 
            var project = loader.LoadAssembly(s.Module.Assembly);

            var ctx = new CompositeTypeResolveContext(new[] { project, slsharp, mscorlib });
            var resolver = new CSharpResolver(ctx, CancellationToken.None) {UsingScope = new UsingScope(project)};

            // TODO: need a more sane way to get the correct class + member
            var ss = ctx.GetAllClasses().First(c => c.FullName == s.FullName);
            resolver.CurrentTypeDefinition = ss;
            resolver.CurrentMember = ss.Members.First(n => m.Name == n.Name);

            var rv = new ResolveVisitor(resolver, null, null);
            
            var glsl = new HlslVisitor(d, attr, rv);

            _functions.UnionWith(glsl.Functions);

            var entry = (bool)attr.ConstructorArguments.FirstOrDefault().Value;
            var sig = HlslVisitor.GetSignature(m);

            var code = glsl.Result;
            var desc = new FunctionDescription(Shader.GetMethodName(m), sig + code, entry);

            return desc;
        }

        public List<string> ForwardDeclare(bool debugInfo)
        {
            return _functions.Select(f => f.Item1 + ";" + (debugInfo ? " // " + f.Item2 : string.Empty)).ToList();
        }
    }
}
