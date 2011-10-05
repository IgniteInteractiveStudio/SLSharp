using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using ICSharpCode.NRefactory.CSharp;
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

        private readonly HashSet<Type> _dependencies = new HashSet<Type>(); 

        public void ResetState()
        {
            _functions.Clear();
            _dependencies.Clear();
        }

        private bool SameMethod(MethodDefinition m, IMethod n, ITypeResolveContext ctx)
        {
            if (m.Name != n.Name)
                return false;

            if (n.ReturnType.Resolve(ctx).FullName != m.ReturnType.FullName.Replace('/', '.'))
                return false;

            if (n.Parameters.Count != m.Parameters.Count)
                return false;

            for (var i = 0; i < n.Parameters.Count; i++)
            {
                var pn = n.Parameters[i];
                var pm = m.Parameters[i];
                if (pn.Type.Resolve(ctx).FullName != pm.ParameterType.FullName.Replace('/', '.'))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Public translation interface.
        /// Translates the given method to HLSL
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

            var sbase = s.BaseType.Resolve();
            while (sbase.MetadataToken.ToInt32() != typeof(Shader).MetadataToken)
                sbase = sbase.BaseType.Resolve();

            var dctx = new DecompilerContext(s.Module)
            {
                CurrentType = s,
                CurrentMethod = m,
                CancellationToken = CancellationToken.None
            };
            var d = AstMethodBodyBuilder.CreateMethodBody(m, dctx);

            //var ctx = new CecilTypeResolveContext(sbase.Module);

            var loader = new CecilLoader();
            var mscorlib = loader.LoadAssemblyFile(typeof(object).Assembly.Location);
            var slsharp = loader.LoadAssembly(sbase.Module.Assembly); 
            var project = loader.LoadAssembly(s.Module.Assembly);

            var ctx = new CompositeTypeResolveContext(new[] { project, slsharp, mscorlib });
            var resolver = new CSharpResolver(ctx, CancellationToken.None) {UsingScope = new UsingScope(project)};

            /*
            foreach (var v in m.Body.Variables)
            {
                resolver.AddVariable(v.VariableType, null, v.Name)
            }*/
            
            //resolver.AddVariable()
            
            //resolver.LocalVariables = m.Body.Variables;
            

            // TODO: need a more sane way to get the correct class + member
            var ss = ctx.GetAllTypes().First(c => c.FullName == s.FullName);
            resolver.CurrentTypeDefinition = ss;
            resolver.CurrentMember = ss.Methods.First(n => SameMethod(m, n, ctx));

            var rv = new ResolveVisitor(resolver, new ParsedFile("memory", resolver.UsingScope), null);
            
            var glsl = new HlslVisitor(d, attr, rv, dctx);

            _functions.UnionWith(glsl.Functions);

            var entry = (bool)attr.ConstructorArguments.FirstOrDefault().Value;
            var sig = HlslVisitor.GetSignature(m);

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
