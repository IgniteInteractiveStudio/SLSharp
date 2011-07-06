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

namespace IIS.SLSharp.Translation.GLSL
{
    internal sealed partial class GlslVisitor
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

        public GlslVisitor()
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

                { () => ShaderDefinition.Atan2(_float, _float), Rename("atan") },
                { () => ShaderDefinition.Atan2(vec2, vec2), Rename("atan") },
                { () => ShaderDefinition.Atan2(vec3, vec3), Rename("atan") },
                { () => ShaderDefinition.Atan2(vec4, vec4), Rename("atan") },

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

                { () => ShaderDefinition.Asinh(_float), ToLower },
                { () => ShaderDefinition.Asinh(vec2), ToLower },
                { () => ShaderDefinition.Asinh(vec3), ToLower },
                { () => ShaderDefinition.Asinh(vec4), ToLower },

                { () => ShaderDefinition.Acosh(_float), ToLower },
                { () => ShaderDefinition.Acosh(vec2), ToLower },
                { () => ShaderDefinition.Acosh(vec3), ToLower },
                { () => ShaderDefinition.Acosh(vec4), ToLower },

                { () => ShaderDefinition.Atanh(_float), ToLower },
                { () => ShaderDefinition.Atanh(vec2), ToLower },
                { () => ShaderDefinition.Atanh(vec3), ToLower },
                { () => ShaderDefinition.Atanh(vec4), ToLower },

                { () => ShaderDefinition.SinCos(_float, out _float, out _float), 
                    EmulateSinCos(() => ShaderDefinition.Sin(_float), () => ShaderDefinition.Cos(_float)) },
                { () => ShaderDefinition.SinCos(vec2, out vec2, out vec2), 
                    EmulateSinCos(() => ShaderDefinition.Sin(vec2), () => ShaderDefinition.Cos(vec2)) },
                { () => ShaderDefinition.SinCos(vec3, out vec3, out vec3), 
                    EmulateSinCos(() => ShaderDefinition.Sin(vec3), () => ShaderDefinition.Cos(vec3)) },
                { () => ShaderDefinition.SinCos(vec4, out vec4, out vec4), 
                    EmulateSinCos(() => ShaderDefinition.Sin(vec4), () => ShaderDefinition.Cos(vec4)) },

#endregion
            };
        }


        private Func<MethodDefinition, InvocationExpression, StringBuilder> Rename(string newName)
        {
            return (m, i) =>
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

        private int _tempCounter;

        private Func<MethodDefinition, InvocationExpression, StringBuilder>
            EmulateSinCos(Expression<Action> sinf, Expression<Action> cosf)
        {
            return (m, i) =>
            {
                // cache angle in a temporary var
                var tmp = ToTemp(i.Arguments.First());
                var result = tmp.AcceptVisitor(this, 0);

                var sinb = ((MethodCallExpression)sinf.Body).Method;
                var cosb = ((MethodCallExpression)cosf.Body).Method;

                // ... create a call to Cos/Sin here ...
                var sin = new InvocationExpression(null, new Expression[] { });


                throw new NotImplementedException();
                return result;
            };
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
