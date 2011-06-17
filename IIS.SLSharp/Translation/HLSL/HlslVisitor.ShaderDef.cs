using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ICSharpCode.Decompiler.Ast;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using IIS.SLSharp.Shaders;
using Mono.Cecil;
using Expression = ICSharpCode.NRefactory.CSharp.Expression;
using InvocationExpression = ICSharpCode.NRefactory.CSharp.InvocationExpression;
using LambdaExpression = ICSharpCode.NRefactory.CSharp.LambdaExpression;

namespace IIS.SLSharp.Translation.HLSL
{
    internal sealed partial class HlslVisitor
    {

// ReSharper disable InconsistentNaming
#pragma warning disable 649
        private static readonly ShaderDefinition.sampler2D sampler2D;
        private static readonly ShaderDefinition.vec2 vec2;
        private static readonly ShaderDefinition.vec3 vec3;
        private static readonly ShaderDefinition.vec4 vec4;
        private static float _float;
#pragma warning restore 649
// ReSharper restore InconsistentNaming

        private readonly Dictionary<Expression<Action>, Func<MethodDefinition, InvocationExpression, StringBuilder>> _handlers;

        internal sealed class HandlerComparer : IEqualityComparer<Expression<Action>>
        {
            private int IdFrom(Expression<Action> a)
            {
                
                var x = a.Body as MethodCallExpression;
                if (x != null)
                    return x.Method.MetadataToken;

                var c = (ConstantExpression)a.Body;
                return (int)c.Value;
            }

            public bool Equals(Expression<Action> x, Expression<Action> y)
            {
                return IdFrom(x) == IdFrom(y);
            }

            public int GetHashCode(Expression<Action> obj)
            {
                return IdFrom(obj);
            }
        }

        public HlslVisitor()
        {
            _handlers = new Dictionary<Expression<Action>, Func<MethodDefinition, InvocationExpression, StringBuilder>>(new HandlerComparer())
            {
                { () => ShaderDefinition.texture(sampler2D, vec2), Rename("tex2D") },

                { () => ShaderDefinition.mod(vec2, _float), (m, i) => ModFloat<ShaderDefinition.vec2>(m, i) },
                { () => ShaderDefinition.mod(vec3, _float), (m, i) => ModFloat<ShaderDefinition.vec2>(m, i) },
                { () => ShaderDefinition.mod(vec4, _float), (m, i) => ModFloat<ShaderDefinition.vec2>(m, i) },
                { () => ShaderDefinition.mod(_float, _float), Rename("fmod") },
                { () => ShaderDefinition.mod(vec2, vec2), Rename("fmod") },
                { () => ShaderDefinition.mod(vec3, vec3), Rename("fmod") },
                { () => ShaderDefinition.mod(vec4, vec4), Rename("fmod") },


                { () => ShaderDefinition.fract(_float), Rename("frac") },
                { () => ShaderDefinition.fract(vec2), Rename("frac") },
                { () => ShaderDefinition.fract(vec3), Rename("frac") },
                { () => ShaderDefinition.fract(vec4), Rename("frac") },

                { () => ShaderDefinition.dFdx(_float), Rename("ddx") },
                { () => ShaderDefinition.dFdx(vec2), Rename("ddx") },
                { () => ShaderDefinition.dFdx(vec3), Rename("ddx") },
                { () => ShaderDefinition.dFdx(vec4), Rename("ddx") },

                { () => ShaderDefinition.dFdy(_float), Rename("ddy") },
                { () => ShaderDefinition.dFdy(vec2), Rename("ddy") },
                { () => ShaderDefinition.dFdy(vec3), Rename("ddy") },
                { () => ShaderDefinition.dFdy(vec4), Rename("ddy") },

                { () => ShaderDefinition.textureGrad(sampler2D, vec2, vec2, vec2), Rename("tex2Dgrad") },
            };
        }

   
        private Expression WidenType<T>(Expression source)
        {        
#warning This badly needs refactoring!
            // optimally we'd either want to pull the information from the AST
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
            

            var tok = m.Resolve().MetadataToken.ToInt32();
            Func<MethodDefinition, InvocationExpression, StringBuilder> handler;
            var etok = System.Linq.Expressions.Expression.Lambda<Action>(System.Linq.Expressions.Expression.Constant(tok));

            return _handlers.TryGetValue(etok, out handler) ? 
                handler(m, invocationExpression) : PassThrough(m, invocationExpression);
        }
    }
}
