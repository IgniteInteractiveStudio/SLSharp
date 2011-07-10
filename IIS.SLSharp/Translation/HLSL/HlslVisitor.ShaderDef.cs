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
        public HlslVisitor()
        {
            Handlers = new Dictionary<Expression<Action>, Func<MethodDefinition, InvocationExpression, StringBuilder>>(new HandlerComparer())
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

                { () => ShaderDefinition.Asinh(_float), Redirect<Workarounds.Trigonometric>() },
                { () => ShaderDefinition.Asinh(vec2), Redirect<Workarounds.Trigonometric>() },
                { () => ShaderDefinition.Asinh(vec3), Redirect<Workarounds.Trigonometric>() },
                { () => ShaderDefinition.Asinh(vec4), Redirect<Workarounds.Trigonometric>() },

                { () => ShaderDefinition.Acosh(_float), Redirect<Workarounds.Trigonometric>() },
                { () => ShaderDefinition.Acosh(vec2), Redirect<Workarounds.Trigonometric>() },
                { () => ShaderDefinition.Acosh(vec3), Redirect<Workarounds.Trigonometric>() },
                { () => ShaderDefinition.Acosh(vec4), Redirect<Workarounds.Trigonometric>() },

                { () => ShaderDefinition.Atanh(_float), Redirect<Workarounds.Trigonometric>() },
                { () => ShaderDefinition.Atanh(vec2), Redirect<Workarounds.Trigonometric>() },
                { () => ShaderDefinition.Atanh(vec3), Redirect<Workarounds.Trigonometric>() },
                { () => ShaderDefinition.Atanh(vec4), Redirect<Workarounds.Trigonometric>() },

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
            var tref = ShaderDefinition.ToCecil(typeof(T));
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
            var args = lhs.Concat(widen).ToList();

            result.Append("fmod(").Append(ArgsToString(args)).Append(")");

            return result;
        }
    }
}
