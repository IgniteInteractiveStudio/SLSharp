using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using IIS.SLSharp.Shaders;
using Mono.Cecil;
using InvocationExpression = ICSharpCode.NRefactory.CSharp.InvocationExpression;

namespace IIS.SLSharp.Translation.GLSL
{
    internal sealed partial class GlslVisitor
    {
        public GlslVisitor()
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

                { () => ShaderDefinition.SinCos(_float, out _float, out _float), Redirect<Workarounds.Trigonometric>()  },
                { () => ShaderDefinition.SinCos(vec2, out vec2, out vec2), Redirect<Workarounds.Trigonometric>() },
                { () => ShaderDefinition.SinCos(vec3, out vec3, out vec3), Redirect<Workarounds.Trigonometric>() },
                { () => ShaderDefinition.SinCos(vec4, out vec4, out vec4), Redirect<Workarounds.Trigonometric>() },

                #endregion

                #region Exponential

                { () => ShaderDefinition.Pow(_float, _float), ToLower },
                { () => ShaderDefinition.Pow(vec2, vec2), ToLower },
                { () => ShaderDefinition.Pow(vec3, vec3), ToLower },
                { () => ShaderDefinition.Pow(vec4, vec4), ToLower },

                { () => ShaderDefinition.Exp(_float), ToLower },
                { () => ShaderDefinition.Exp(vec2), ToLower },
                { () => ShaderDefinition.Exp(vec3), ToLower },
                { () => ShaderDefinition.Exp(vec4), ToLower },

                { () => ShaderDefinition.Log(_float), ToLower },
                { () => ShaderDefinition.Log(vec2), ToLower },
                { () => ShaderDefinition.Log(vec3), ToLower },
                { () => ShaderDefinition.Log(vec4), ToLower },

                { () => ShaderDefinition.Exp2(_float), ToLower },
                { () => ShaderDefinition.Exp2(vec2), ToLower },
                { () => ShaderDefinition.Exp2(vec3), ToLower },
                { () => ShaderDefinition.Exp2(vec4), ToLower },

                { () => ShaderDefinition.Log2(_float), ToLower },
                { () => ShaderDefinition.Log2(vec2), ToLower },
                { () => ShaderDefinition.Log2(vec3), ToLower },
                { () => ShaderDefinition.Log2(vec4), ToLower },

                { () => ShaderDefinition.Sqrt(_float), ToLower },
                { () => ShaderDefinition.Sqrt(vec2), ToLower },
                { () => ShaderDefinition.Sqrt(vec3), ToLower },
                { () => ShaderDefinition.Sqrt(vec4), ToLower },

                { () => ShaderDefinition.Sqrt(_double), ToLower },
                { () => ShaderDefinition.Sqrt(dvec2), ToLower },
                { () => ShaderDefinition.Sqrt(dvec3), ToLower },
                { () => ShaderDefinition.Sqrt(dvec4), ToLower },

                { () => ShaderDefinition.InverseSqrt(_float), ToLower },
                { () => ShaderDefinition.InverseSqrt(vec2), ToLower },
                { () => ShaderDefinition.InverseSqrt(vec3), ToLower },
                { () => ShaderDefinition.InverseSqrt(vec4), ToLower },

                { () => ShaderDefinition.InverseSqrt(_double), ToLower },
                { () => ShaderDefinition.InverseSqrt(dvec2), ToLower },
                { () => ShaderDefinition.InverseSqrt(dvec3), ToLower },
                { () => ShaderDefinition.InverseSqrt(dvec4), ToLower },

                { () => ShaderDefinition.Log10(_float), Redirect<Workarounds.Exponential>() },
                { () => ShaderDefinition.Log10(vec2), Redirect<Workarounds.Exponential>() },
                { () => ShaderDefinition.Log10(vec3), Redirect<Workarounds.Exponential>() },
                { () => ShaderDefinition.Log10(vec4), Redirect<Workarounds.Exponential>() },

                { () => ShaderDefinition.Exp10(_float), Redirect<Workarounds.Exponential>() },
                { () => ShaderDefinition.Exp10(vec2), Redirect<Workarounds.Exponential>() },
                { () => ShaderDefinition.Exp10(vec3), Redirect<Workarounds.Exponential>() },
                { () => ShaderDefinition.Exp10(vec4), Redirect<Workarounds.Exponential>() },

                #endregion

                #region Geometric

                { () => ShaderDefinition.Length(_float), ToLower },
                { () => ShaderDefinition.Length(vec2), ToLower },
                { () => ShaderDefinition.Length(vec3), ToLower },
                { () => ShaderDefinition.Length(vec4), ToLower },

                { () => ShaderDefinition.Length(_double), ToLower },
                { () => ShaderDefinition.Length(dvec2), ToLower },
                { () => ShaderDefinition.Length(dvec3), ToLower },
                { () => ShaderDefinition.Length(dvec4), ToLower },

                { () => ShaderDefinition.Distance(_float, _float), ToLower },
                { () => ShaderDefinition.Distance(vec2, vec2), ToLower },
                { () => ShaderDefinition.Distance(vec3, vec3), ToLower },
                { () => ShaderDefinition.Distance(vec4, vec4), ToLower },

                { () => ShaderDefinition.Distance(_double, _double), ToLower },
                { () => ShaderDefinition.Distance(dvec2, dvec2), ToLower },
                { () => ShaderDefinition.Distance(dvec3, dvec3), ToLower },
                { () => ShaderDefinition.Distance(dvec4, dvec4), ToLower },

                { () => ShaderDefinition.Dot(_float, _float), ToLower },
                { () => ShaderDefinition.Dot(vec2, vec2), ToLower },
                { () => ShaderDefinition.Dot(vec3, vec3), ToLower },
                { () => ShaderDefinition.Dot(vec4, vec4), ToLower },

                { () => ShaderDefinition.Dot(_double, _double), ToLower },
                { () => ShaderDefinition.Dot(dvec2, dvec2), ToLower },
                { () => ShaderDefinition.Dot(dvec3, dvec3), ToLower },
                { () => ShaderDefinition.Dot(dvec4, dvec4), ToLower },

                { () => ShaderDefinition.Cross(vec3, vec3), ToLower },

                { () => ShaderDefinition.Cross(dvec3, dvec3), ToLower },

                { () => ShaderDefinition.Normalize(_float), ToLower },
                { () => ShaderDefinition.Normalize(vec2), ToLower },
                { () => ShaderDefinition.Normalize(vec3), ToLower },
                { () => ShaderDefinition.Normalize(vec4), ToLower },

                { () => ShaderDefinition.Normalize(_double), ToLower },
                { () => ShaderDefinition.Normalize(dvec2), ToLower },
                { () => ShaderDefinition.Normalize(dvec3), ToLower },
                { () => ShaderDefinition.Normalize(dvec4), ToLower },

                { () => ShaderDefinition.FaceForward(_float, _float, _float), ToLower },
                { () => ShaderDefinition.FaceForward(vec2, vec2, vec2), ToLower },
                { () => ShaderDefinition.FaceForward(vec3, vec3, vec3), ToLower },
                { () => ShaderDefinition.FaceForward(vec4, vec4, vec4), ToLower },

                { () => ShaderDefinition.FaceForward(_double, _double, _double), ToLower },
                { () => ShaderDefinition.FaceForward(dvec2, dvec2, dvec2), ToLower },
                { () => ShaderDefinition.FaceForward(dvec3, dvec3, dvec3), ToLower },
                { () => ShaderDefinition.FaceForward(dvec4, dvec4, dvec4), ToLower },

                { () => ShaderDefinition.Reflect(_float, _float), ToLower },
                { () => ShaderDefinition.Reflect(vec2, vec2), ToLower },
                { () => ShaderDefinition.Reflect(vec3, vec3), ToLower },
                { () => ShaderDefinition.Reflect(vec4, vec4), ToLower },

                { () => ShaderDefinition.Reflect(_double, _double), ToLower },
                { () => ShaderDefinition.Reflect(dvec2, dvec2), ToLower },
                { () => ShaderDefinition.Reflect(dvec3, dvec3), ToLower },
                { () => ShaderDefinition.Reflect(dvec4, dvec4), ToLower },

                { () => ShaderDefinition.Refract(_float, _float, _float), ToLower },
                { () => ShaderDefinition.Refract(vec2, vec2, _float), ToLower },
                { () => ShaderDefinition.Refract(vec3, vec3, _float), ToLower },
                { () => ShaderDefinition.Refract(vec4, vec4, _float), ToLower },

                { () => ShaderDefinition.Refract(_double, _double, _double), ToLower },
                { () => ShaderDefinition.Refract(dvec2, dvec2, _double), ToLower },
                { () => ShaderDefinition.Refract(dvec3, dvec3, _double), ToLower },
                { () => ShaderDefinition.Refract(dvec4, dvec4, _double), ToLower },

                #endregion
            };
        }
    }
}
