using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using ICSharpCode.Decompiler.Ast;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using IIS.SLSharp.Shaders;
using Mono.Cecil;
using Expression = ICSharpCode.NRefactory.CSharp.Expression;
using InvocationExpression = ICSharpCode.NRefactory.CSharp.InvocationExpression;

namespace IIS.SLSharp.Translation.HLSL
{
    internal sealed partial class HlslVisitor
    {
        public static int MetaToken<T>(Expression<Func<T>> x)
        {
            return ((MethodCallExpression)x.Body).Method.MetadataToken;
        }

// ReSharper disable InconsistentNaming
#pragma warning disable 649
        private static readonly ShaderDefinition.sampler2D sampler2D;
        private static readonly ShaderDefinition.vec2 vec2;
        private static readonly ShaderDefinition.vec3 vec3;
        private static readonly ShaderDefinition.vec4 vec4;
        private static float _float;
#pragma warning restore 649
// ReSharper restore InconsistentNaming

        private readonly Dictionary<int, Func<MethodDefinition, InvocationExpression, StringBuilder>> _handlers;
        
        public HlslVisitor()
        {
            _handlers = new Dictionary<int, Func<MethodDefinition, InvocationExpression, StringBuilder>>
            {
                { MetaToken(() => ShaderDefinition.texture(sampler2D, vec2)), Rename("tex2D") },

                { MetaToken(() => ShaderDefinition.mod(vec2, _float)), (m, i) => ModFloat<ShaderDefinition.vec2>(m, i) },
                { MetaToken(() => ShaderDefinition.mod(vec3, _float)), (m, i) => ModFloat<ShaderDefinition.vec2>(m, i) },
                { MetaToken(() => ShaderDefinition.mod(vec4, _float)), (m, i) => ModFloat<ShaderDefinition.vec2>(m, i) },
                { MetaToken(() => ShaderDefinition.mod(_float, _float)), Rename("fmod") },
                { MetaToken(() => ShaderDefinition.mod(vec2, vec2)), Rename("fmod") },
                { MetaToken(() => ShaderDefinition.mod(vec3, vec3)), Rename("fmod") },
                { MetaToken(() => ShaderDefinition.mod(vec4, vec4)), Rename("fmod") },


                { MetaToken(() => ShaderDefinition.fract(_float)), Rename("frac") },
                { MetaToken(() => ShaderDefinition.fract(vec2)), Rename("frac") },
                { MetaToken(() => ShaderDefinition.fract(vec3)), Rename("frac") },
                { MetaToken(() => ShaderDefinition.fract(vec4)), Rename("frac") },

                { MetaToken(() => ShaderDefinition.dFdx(_float)), Rename("ddx") },
                { MetaToken(() => ShaderDefinition.dFdx(vec2)), Rename("ddx") },
                { MetaToken(() => ShaderDefinition.dFdx(vec3)), Rename("ddx") },
                { MetaToken(() => ShaderDefinition.dFdx(vec4)), Rename("ddx") },

                { MetaToken(() => ShaderDefinition.dFdy(_float)), Rename("ddy") },
                { MetaToken(() => ShaderDefinition.dFdy(vec2)), Rename("ddy") },
                { MetaToken(() => ShaderDefinition.dFdy(vec3)), Rename("ddy") },
                { MetaToken(() => ShaderDefinition.dFdy(vec4)), Rename("ddy") },

                { MetaToken(() => ShaderDefinition.textureGrad(sampler2D, vec2, vec2, vec2)), Rename("tex2Dgrad") },
            };
        }

   
        private Expression WidenType<T>(Expression source)
        {        
#warning This badly needs refactoring!
            // optimally we'd want either want to pull the information from the AST
            // via _resolver.Resolve(nodeWithTargetType)
            // however this yields an IType and i've no idea how to pull off an TypeReference from that
            var t = typeof(T);
            var asm = AssemblyDefinition.ReadAssembly(t.Assembly.Location);
            var mod = asm.Modules.Single(x => x.MetadataToken.ToInt32() == t.Module.MetadataToken);
            var sdef = mod.Types.Single(x => x.MetadataToken.ToInt32() == typeof(ShaderDefinition).MetadataToken);
            var tref = sdef.NestedTypes.Single(x => x.MetadataToken.ToInt32() == t.MetadataToken);
            
            var n = new ObjectCreateExpression( AstBuilder.ConvertType(tref), new[] { source.Clone() });
            
            return n;
        }

        private StringBuilder ModFloat<T>(MethodDefinition m, InvocationExpression i)
        {
            // mod() will have 2 args we need to widen the rhs to a T1 however

            Debug.Assert(i.Arguments.Count == 2);
            var result = new StringBuilder();

            var lhs = i.Arguments.Take(1);
            var rhs = i.Arguments.Skip(1).Take(1);
            var widen = rhs.Select(WidenType<T>);
            var args = lhs.Concat(widen);

            result.Append("fmod(").Append(ArgsToString(args)).Append(")");

            return result;

        }


        private Func<MethodDefinition, InvocationExpression, StringBuilder> Rename(string newName)
        {
            return (m,i) =>
            {
                var result = new StringBuilder();
                return result.Append(newName).Append("(").Append(ArgsToString(i.Arguments)).Append(")");
            };
        }

        private StringBuilder PassThrough(MethodDefinition m, InvocationExpression i)
        {
            var result = new StringBuilder();
            return result.Append(m.Name).Append("(").Append(ArgsToString(i.Arguments)).Append(")");
        }

        // Dispatcher
        private StringBuilder VisitShaderDefCall(MethodDefinition m, InvocationExpression invocationExpression)
        {
            Func<MethodDefinition, InvocationExpression, StringBuilder> handler;
            return _handlers.TryGetValue(m.Resolve().MetadataToken.ToInt32(), out handler) ? 
                handler(m, invocationExpression) : PassThrough(m, invocationExpression);
        }
    }
}
