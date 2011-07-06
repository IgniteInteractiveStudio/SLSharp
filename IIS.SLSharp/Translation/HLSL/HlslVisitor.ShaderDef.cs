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
        private static ShaderDefinition.vec2 vec2;
        private static ShaderDefinition.vec3 vec3;
        private static ShaderDefinition.vec4 vec4;
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
#region Trigonometry
                { () => ShaderDefinition.Radians(_float), ToLower },
                { () => ShaderDefinition.Radians(vec2), ToLower },
                { () => ShaderDefinition.Radians(vec3), ToLower },
                { () => ShaderDefinition.Radians(vec4), ToLower },

                { () => ShaderDefinition.Degrees(_float), ToLower },
                { () => ShaderDefinition.Degrees(vec2), ToLower },
                { () => ShaderDefinition.Degrees(vec3), ToLower },
                { () => ShaderDefinition.Degrees(vec4), ToLower },

                { () => ShaderDefinition.Sin(_float), ToLower },
                { () => ShaderDefinition.Sin(vec2), ToLower },
                { () => ShaderDefinition.Sin(vec3), ToLower },
                { () => ShaderDefinition.Sin(vec4), ToLower },

                { () => ShaderDefinition.Cos(_float), ToLower },
                { () => ShaderDefinition.Cos(vec2), ToLower },
                { () => ShaderDefinition.Cos(vec3), ToLower },
                { () => ShaderDefinition.Cos(vec4), ToLower },

                { () => ShaderDefinition.Tan(_float), ToLower },
                { () => ShaderDefinition.Tan(vec2), ToLower },
                { () => ShaderDefinition.Tan(vec3), ToLower },
                { () => ShaderDefinition.Tan(vec4), ToLower },

                { () => ShaderDefinition.Asin(_float), ToLower },
                { () => ShaderDefinition.Asin(vec2), ToLower },
                { () => ShaderDefinition.Asin(vec3), ToLower },
                { () => ShaderDefinition.Asin(vec4), ToLower },

                { () => ShaderDefinition.Acos(_float), ToLower },
                { () => ShaderDefinition.Acos(vec2), ToLower },
                { () => ShaderDefinition.Acos(vec3), ToLower },
                { () => ShaderDefinition.Acos(vec4), ToLower },

                { () => ShaderDefinition.Atan2(_float, _float), ToLower },
                { () => ShaderDefinition.Atan2(vec2, vec2), ToLower },
                { () => ShaderDefinition.Atan2(vec3, vec3), ToLower },
                { () => ShaderDefinition.Atan2(vec4, vec4), ToLower },

                { () => ShaderDefinition.Atan(_float), ToLower },
                { () => ShaderDefinition.Atan(vec2), ToLower },
                { () => ShaderDefinition.Atan(vec3), ToLower },
                { () => ShaderDefinition.Atan(vec4), ToLower },

                { () => ShaderDefinition.Sinh(_float), ToLower },
                { () => ShaderDefinition.Sinh(vec2), ToLower },
                { () => ShaderDefinition.Sinh(vec3), ToLower },
                { () => ShaderDefinition.Sinh(vec4), ToLower },

                { () => ShaderDefinition.Cosh(_float), ToLower },
                { () => ShaderDefinition.Cosh(vec2), ToLower },
                { () => ShaderDefinition.Cosh(vec3), ToLower },
                { () => ShaderDefinition.Cosh(vec4), ToLower },

                { () => ShaderDefinition.Tanh(_float), ToLower },
                { () => ShaderDefinition.Tanh(vec2), ToLower },
                { () => ShaderDefinition.Tanh(vec3), ToLower },
                { () => ShaderDefinition.Tanh(vec4), ToLower },

                { () => ShaderDefinition.Asinh(_float), EmulateAsinh },
                { () => ShaderDefinition.Asinh(vec2), EmulateAsinh },
                { () => ShaderDefinition.Asinh(vec3), EmulateAsinh },
                { () => ShaderDefinition.Asinh(vec4), EmulateAsinh },

                { () => ShaderDefinition.Acosh(_float), EmulateAcosh },
                { () => ShaderDefinition.Acosh(vec2), EmulateAcosh },
                { () => ShaderDefinition.Acosh(vec3), EmulateAcosh },
                { () => ShaderDefinition.Acosh(vec4), EmulateAcosh },

                { () => ShaderDefinition.Atanh(_float), EmulateAtanh },
                { () => ShaderDefinition.Atanh(vec2), EmulateAtanh },
                { () => ShaderDefinition.Atanh(vec3), EmulateAtanh },
                { () => ShaderDefinition.Atanh(vec4), EmulateAtanh },

                { () => ShaderDefinition.SinCos(_float, out _float, out _float), ToLower },
                { () => ShaderDefinition.SinCos(vec2, out vec2, out vec2), ToLower },
                { () => ShaderDefinition.SinCos(vec3, out vec3, out vec3), ToLower },
                { () => ShaderDefinition.SinCos(vec4, out vec4, out vec4), ToLower },
#endregion


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

        private StringBuilder EmulateAsinh(MethodDefinition m, InvocationExpression i)
        {
            Warn("HLSL does not support a native Asinh, emulating with precision loss.");
            // TODO: emulate as ln(x + sqrt(1 + x*x))
            throw new NotImplementedException();
        }

        private StringBuilder EmulateAcosh(MethodDefinition m, InvocationExpression i)
        {
            Warn("HLSL does not support a native Acosh, emulating with precision loss.");
            // TODO: emulate as 2*ln(sqrt((x+1)/2) + sqrt((x-1)/2))
            throw new NotImplementedException();
        }

        private StringBuilder EmulateAtanh(MethodDefinition m, InvocationExpression i)
        {
            Warn("HLSL does not support a native Atanh, emulating with precision loss.");
            // TODO: emulate as (ln(1+x) - ln(1-x))/2
            throw new NotImplementedException();
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

        private StringBuilder ToLower(MethodDefinition m, InvocationExpression i)
        {
            var result = new StringBuilder();
            return result.Append(m.Name.ToLowerInvariant()).Append("(").Append(ArgsToString(i.Arguments)).Append(")");
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
