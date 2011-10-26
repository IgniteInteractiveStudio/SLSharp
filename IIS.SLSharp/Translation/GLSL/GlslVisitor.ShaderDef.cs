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
                { () => ShaderDefinition.Discard(), KeywordDiscard },

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

                #region Common

                { () => ShaderDefinition.Abs(_float), ToLower },
                { () => ShaderDefinition.Abs(vec2), ToLower },
                { () => ShaderDefinition.Abs(vec3), ToLower },
                { () => ShaderDefinition.Abs(vec4), ToLower },

                { () => ShaderDefinition.Abs(_int), ToLower },
                { () => ShaderDefinition.Abs(ivec2), ToLower },
                { () => ShaderDefinition.Abs(ivec3), ToLower },
                { () => ShaderDefinition.Abs(ivec4), ToLower },

                { () => ShaderDefinition.Abs(_double), ToLower },
                { () => ShaderDefinition.Abs(dvec2), ToLower },
                { () => ShaderDefinition.Abs(dvec3), ToLower },
                { () => ShaderDefinition.Abs(dvec4), ToLower },

                { () => ShaderDefinition.Sign(_float), ToLower },
                { () => ShaderDefinition.Sign(vec2), ToLower },
                { () => ShaderDefinition.Sign(vec3), ToLower },
                { () => ShaderDefinition.Sign(vec4), ToLower },

                { () => ShaderDefinition.Sign(_int), ToLower },
                { () => ShaderDefinition.Sign(ivec2), ToLower },
                { () => ShaderDefinition.Sign(ivec3), ToLower },
                { () => ShaderDefinition.Sign(ivec4), ToLower },

                { () => ShaderDefinition.Sign(_double), ToLower },
                { () => ShaderDefinition.Sign(dvec2), ToLower },
                { () => ShaderDefinition.Sign(dvec3), ToLower },
                { () => ShaderDefinition.Sign(dvec4), ToLower },

                { () => ShaderDefinition.Floor(_float), ToLower },
                { () => ShaderDefinition.Floor(vec2), ToLower },
                { () => ShaderDefinition.Floor(vec3), ToLower },
                { () => ShaderDefinition.Floor(vec4), ToLower },

                { () => ShaderDefinition.Floor(_double), ToLower },
                { () => ShaderDefinition.Floor(dvec2), ToLower },
                { () => ShaderDefinition.Floor(dvec3), ToLower },
                { () => ShaderDefinition.Floor(dvec4), ToLower },

                { () => ShaderDefinition.Trunc(_float), ToLower },
                { () => ShaderDefinition.Trunc(vec2), ToLower },
                { () => ShaderDefinition.Trunc(vec3), ToLower },
                { () => ShaderDefinition.Trunc(vec4), ToLower },

                { () => ShaderDefinition.Trunc(_double), ToLower },
                { () => ShaderDefinition.Trunc(dvec2), ToLower },
                { () => ShaderDefinition.Trunc(dvec3), ToLower },
                { () => ShaderDefinition.Trunc(dvec4), ToLower },

                { () => ShaderDefinition.Round(_float), ToLower },
                { () => ShaderDefinition.Round(vec2), ToLower },
                { () => ShaderDefinition.Round(vec3), ToLower },
                { () => ShaderDefinition.Round(vec4), ToLower },

                { () => ShaderDefinition.Round(_double), ToLower },
                { () => ShaderDefinition.Round(dvec2), ToLower },
                { () => ShaderDefinition.Round(dvec3), ToLower },
                { () => ShaderDefinition.Round(dvec4), ToLower },

                { () => ShaderDefinition.RoundEven(_float), ToLower },
                { () => ShaderDefinition.RoundEven(vec2), ToLower },
                { () => ShaderDefinition.RoundEven(vec3), ToLower },
                { () => ShaderDefinition.RoundEven(vec4), ToLower },

                { () => ShaderDefinition.RoundEven(_double), ToLower },
                { () => ShaderDefinition.RoundEven(dvec2), ToLower },
                { () => ShaderDefinition.RoundEven(dvec3), ToLower },
                { () => ShaderDefinition.RoundEven(dvec4), ToLower },

                { () => ShaderDefinition.Ceiling(_float), Rename("ceil") },
                { () => ShaderDefinition.Ceiling(vec2), Rename("ceil") },
                { () => ShaderDefinition.Ceiling(vec3), Rename("ceil") },
                { () => ShaderDefinition.Ceiling(vec4), Rename("ceil") },

                { () => ShaderDefinition.Ceiling(_double), Rename("ceil") },
                { () => ShaderDefinition.Ceiling(dvec2), Rename("ceil") },
                { () => ShaderDefinition.Ceiling(dvec3), Rename("ceil") },
                { () => ShaderDefinition.Ceiling(dvec4), Rename("ceil") },

                { () => ShaderDefinition.Fraction(_float), Rename("fract") },
                { () => ShaderDefinition.Fraction(vec2), Rename("fract") },
                { () => ShaderDefinition.Fraction(vec3), Rename("fract") },
                { () => ShaderDefinition.Fraction(vec4), Rename("fract") },

                { () => ShaderDefinition.Fraction(_double), Rename("fract") },
                { () => ShaderDefinition.Fraction(dvec2), Rename("fract") },
                { () => ShaderDefinition.Fraction(dvec3), Rename("fract") },
                { () => ShaderDefinition.Fraction(dvec4), Rename("fract") },

                { () => ShaderDefinition.Min(_float, _float), ToLower },
                { () => ShaderDefinition.Min(vec2, _float), ToLower },
                { () => ShaderDefinition.Min(vec3, _float), ToLower },
                { () => ShaderDefinition.Min(vec4, _float), ToLower },

                { () => ShaderDefinition.Min(vec2, vec2), ToLower },
                { () => ShaderDefinition.Min(vec3, vec3), ToLower },
                { () => ShaderDefinition.Min(vec4, vec4), ToLower },

                { () => ShaderDefinition.Min(_double, _double), ToLower },
                { () => ShaderDefinition.Min(dvec2, _double), ToLower },
                { () => ShaderDefinition.Min(dvec3, _double), ToLower },
                { () => ShaderDefinition.Min(dvec4, _double), ToLower },

                { () => ShaderDefinition.Min(dvec2, dvec2), ToLower },
                { () => ShaderDefinition.Min(dvec3, dvec3), ToLower },
                { () => ShaderDefinition.Min(dvec4, dvec4), ToLower },

                { () => ShaderDefinition.Min(_int, _int), ToLower },
                { () => ShaderDefinition.Min(ivec2, _int), ToLower },
                { () => ShaderDefinition.Min(ivec3, _int), ToLower },
                { () => ShaderDefinition.Min(ivec4, _int), ToLower },

                { () => ShaderDefinition.Min(ivec2, ivec2), ToLower },
                { () => ShaderDefinition.Min(ivec3, ivec3), ToLower },
                { () => ShaderDefinition.Min(ivec4, ivec4), ToLower },

                { () => ShaderDefinition.Min(_uint, _uint), ToLower },
                { () => ShaderDefinition.Min(uvec2, _uint), ToLower },
                { () => ShaderDefinition.Min(uvec3, _uint), ToLower },
                { () => ShaderDefinition.Min(uvec4, _uint), ToLower },

                { () => ShaderDefinition.Min(uvec2, uvec2), ToLower },
                { () => ShaderDefinition.Min(uvec3, uvec3), ToLower },
                { () => ShaderDefinition.Min(uvec4, uvec4), ToLower },

                { () => ShaderDefinition.Max(_float, _float), ToLower },
                { () => ShaderDefinition.Max(vec2, _float), ToLower },
                { () => ShaderDefinition.Max(vec3, _float), ToLower },
                { () => ShaderDefinition.Max(vec4, _float), ToLower },

                { () => ShaderDefinition.Max(vec2, vec2), ToLower },
                { () => ShaderDefinition.Max(vec3, vec3), ToLower },
                { () => ShaderDefinition.Max(vec4, vec4), ToLower },

                { () => ShaderDefinition.Max(_double, _double), ToLower },
                { () => ShaderDefinition.Max(dvec2, _double), ToLower },
                { () => ShaderDefinition.Max(dvec3, _double), ToLower },
                { () => ShaderDefinition.Max(dvec4, _double), ToLower },

                { () => ShaderDefinition.Max(dvec2, dvec2), ToLower },
                { () => ShaderDefinition.Max(dvec3, dvec3), ToLower },
                { () => ShaderDefinition.Max(dvec4, dvec4), ToLower },

                { () => ShaderDefinition.Max(_int, _int), ToLower },
                { () => ShaderDefinition.Max(ivec2, _int), ToLower },
                { () => ShaderDefinition.Max(ivec3, _int), ToLower },
                { () => ShaderDefinition.Max(ivec4, _int), ToLower },

                { () => ShaderDefinition.Max(ivec2, ivec2), ToLower },
                { () => ShaderDefinition.Max(ivec3, ivec3), ToLower },
                { () => ShaderDefinition.Max(ivec4, ivec4), ToLower },

                { () => ShaderDefinition.Max(_uint, _uint), ToLower },
                { () => ShaderDefinition.Max(uvec2, _uint), ToLower },
                { () => ShaderDefinition.Max(uvec3, _uint), ToLower },
                { () => ShaderDefinition.Max(uvec4, _uint), ToLower },

                { () => ShaderDefinition.Max(uvec2, uvec2), ToLower },
                { () => ShaderDefinition.Max(uvec3, uvec3), ToLower },
                { () => ShaderDefinition.Max(uvec4, uvec4), ToLower },

  
                { () => ShaderDefinition.Clamp(_float, _float, _float), ToLower },
                { () => ShaderDefinition.Clamp(vec2, _float, _float), ToLower },
                { () => ShaderDefinition.Clamp(vec3, _float, _float), ToLower },
                { () => ShaderDefinition.Clamp(vec4, _float, _float), ToLower },

                { () => ShaderDefinition.Clamp(vec2, vec2, vec2), ToLower },
                { () => ShaderDefinition.Clamp(vec3, vec3, vec3), ToLower },
                { () => ShaderDefinition.Clamp(vec4, vec4, vec4), ToLower },

                { () => ShaderDefinition.Clamp(_double, _double, _double), ToLower },
                { () => ShaderDefinition.Clamp(dvec2, _double, _double), ToLower },
                { () => ShaderDefinition.Clamp(dvec3, _double, _double), ToLower },
                { () => ShaderDefinition.Clamp(dvec4, _double, _double), ToLower },

                { () => ShaderDefinition.Clamp(dvec2, dvec2, dvec2), ToLower },
                { () => ShaderDefinition.Clamp(dvec3, dvec3, dvec3), ToLower },
                { () => ShaderDefinition.Clamp(dvec4, dvec4, dvec4), ToLower },

                { () => ShaderDefinition.Clamp(_int, _int, _int), ToLower },
                { () => ShaderDefinition.Clamp(ivec2, _int, _int), ToLower },
                { () => ShaderDefinition.Clamp(ivec3, _int, _int), ToLower },
                { () => ShaderDefinition.Clamp(ivec4, _int, _int), ToLower },

                { () => ShaderDefinition.Clamp(ivec2, ivec2, ivec2), ToLower },
                { () => ShaderDefinition.Clamp(ivec3, ivec3, ivec3), ToLower },
                { () => ShaderDefinition.Clamp(ivec4, ivec4, ivec4), ToLower },

                { () => ShaderDefinition.Clamp(_uint, _uint, _uint), ToLower },
                { () => ShaderDefinition.Clamp(uvec2, _uint, _uint), ToLower },
                { () => ShaderDefinition.Clamp(uvec3, _uint, _uint), ToLower },
                { () => ShaderDefinition.Clamp(uvec4, _uint, _uint), ToLower },

                { () => ShaderDefinition.Clamp(uvec2, uvec2, uvec2), ToLower },
                { () => ShaderDefinition.Clamp(uvec3, uvec3, uvec3), ToLower },
                { () => ShaderDefinition.Clamp(uvec4, uvec4, uvec4), ToLower },

                { () => ShaderDefinition.Lerp(_float, _float, _float), Rename("mix") },
                { () => ShaderDefinition.Lerp(vec2, vec2, _float), Rename("mix") },
                { () => ShaderDefinition.Lerp(vec3, vec3, _float), Rename("mix") },
                { () => ShaderDefinition.Lerp(vec4, vec4, _float), Rename("mix") },

                { () => ShaderDefinition.Lerp(vec2, vec2, vec2), Rename("mix") },
                { () => ShaderDefinition.Lerp(vec3, vec3, vec3), Rename("mix") },
                { () => ShaderDefinition.Lerp(vec4, vec4, vec4), Rename("mix") },

                { () => ShaderDefinition.Lerp(_double, _double, _double), Rename("mix") },
                { () => ShaderDefinition.Lerp(dvec2, dvec2, _double), Rename("mix") },
                { () => ShaderDefinition.Lerp(dvec3, dvec3, _double), Rename("mix") },
                { () => ShaderDefinition.Lerp(dvec4, dvec4, _double), Rename("mix") },

                { () => ShaderDefinition.Lerp(dvec2, dvec2, dvec2), Rename("mix") },
                { () => ShaderDefinition.Lerp(dvec3, dvec3, dvec3), Rename("mix") },
                { () => ShaderDefinition.Lerp(dvec4, dvec4, dvec4), Rename("mix") },

                { () => ShaderDefinition.Lerp(_float, _float, _bool), Rename("mix") },
                { () => ShaderDefinition.Lerp(vec2, vec2, bvec2), Rename("mix") },
                { () => ShaderDefinition.Lerp(vec3, vec3, bvec3), Rename("mix") },
                { () => ShaderDefinition.Lerp(vec4, vec4, bvec4), Rename("mix") },

                { () => ShaderDefinition.Lerp(_double, _double, _bool), Rename("mix") },
                { () => ShaderDefinition.Lerp(dvec2, dvec2, bvec2), Rename("mix") },
                { () => ShaderDefinition.Lerp(dvec3, dvec3, bvec3), Rename("mix") },
                { () => ShaderDefinition.Lerp(dvec4, dvec4, bvec4), Rename("mix") },

                { () => ShaderDefinition.Step(_float, _float), ToLower },
                { () => ShaderDefinition.Step(_float, vec2), ToLower },
                { () => ShaderDefinition.Step(_float, vec3), ToLower },
                { () => ShaderDefinition.Step(_float, vec4), ToLower },

                { () => ShaderDefinition.Step(vec2, vec2), ToLower },
                { () => ShaderDefinition.Step(vec3, vec3), ToLower },
                { () => ShaderDefinition.Step(vec4, vec4), ToLower },

                { () => ShaderDefinition.Step(_double, _double), ToLower },
                { () => ShaderDefinition.Step(_double, dvec2), ToLower },
                { () => ShaderDefinition.Step(_double, dvec3), ToLower },
                { () => ShaderDefinition.Step(_double, dvec4), ToLower },

                { () => ShaderDefinition.Step(dvec2, dvec2), ToLower },
                { () => ShaderDefinition.Step(dvec3, dvec3), ToLower },
                { () => ShaderDefinition.Step(dvec4, dvec4), ToLower },

                { () => ShaderDefinition.SmoothStep(_float, _float, _float), ToLower },
                { () => ShaderDefinition.SmoothStep(_float, _float, vec2), ToLower },
                { () => ShaderDefinition.SmoothStep(_float, _float, vec3), ToLower },
                { () => ShaderDefinition.SmoothStep(_float, _float, vec4), ToLower },

                { () => ShaderDefinition.SmoothStep(vec2, vec2, vec2), ToLower },
                { () => ShaderDefinition.SmoothStep(vec3, vec3, vec3), ToLower },
                { () => ShaderDefinition.SmoothStep(vec4, vec4, vec4), ToLower },

                { () => ShaderDefinition.SmoothStep(_double, _double, _double), ToLower },
                { () => ShaderDefinition.SmoothStep(_double, _double, dvec2), ToLower },
                { () => ShaderDefinition.SmoothStep(_double, _double, dvec3), ToLower },
                { () => ShaderDefinition.SmoothStep(_double, _double, dvec4), ToLower },

                { () => ShaderDefinition.SmoothStep(dvec2, dvec2, dvec2), ToLower },
                { () => ShaderDefinition.SmoothStep(dvec3, dvec3, dvec3), ToLower },
                { () => ShaderDefinition.SmoothStep(dvec4, dvec4, dvec4), ToLower },

                { () => ShaderDefinition.IsNaN(_float), ToLower },
                { () => ShaderDefinition.IsNaN(vec2), ToLower },
                { () => ShaderDefinition.IsNaN(vec3), ToLower },
                { () => ShaderDefinition.IsNaN(vec4), ToLower },

                { () => ShaderDefinition.IsNaN(_double), ToLower },
                { () => ShaderDefinition.IsNaN(dvec2), ToLower },
                { () => ShaderDefinition.IsNaN(dvec3), ToLower },
                { () => ShaderDefinition.IsNaN(dvec4), ToLower },

                { () => ShaderDefinition.IsInfinity(_float), ToLower },
                { () => ShaderDefinition.IsInfinity(vec2), ToLower },
                { () => ShaderDefinition.IsInfinity(vec3), ToLower },
                { () => ShaderDefinition.IsInfinity(vec4), ToLower },

                { () => ShaderDefinition.IsInfinity(_double), ToLower },
                { () => ShaderDefinition.IsInfinity(dvec2), ToLower },
                { () => ShaderDefinition.IsInfinity(dvec3), ToLower },
                { () => ShaderDefinition.IsInfinity(dvec4), ToLower },

                { () => ShaderDefinition.FusedMultiplyAdd(_float, _float, _float), Rename("fma") },
                { () => ShaderDefinition.FusedMultiplyAdd(vec2, vec2, vec2), Rename("fma") },
                { () => ShaderDefinition.FusedMultiplyAdd(vec3, vec3, vec3), Rename("fma") },
                { () => ShaderDefinition.FusedMultiplyAdd(vec4, vec4, vec4), Rename("fma") },

                { () => ShaderDefinition.FusedMultiplyAdd(_double, _double, _double), Rename("fma") },
                { () => ShaderDefinition.FusedMultiplyAdd(dvec2, dvec2, dvec2), Rename("fma") },
                { () => ShaderDefinition.FusedMultiplyAdd(dvec3, dvec3, dvec3), Rename("fma") },
                { () => ShaderDefinition.FusedMultiplyAdd(dvec4, dvec4, dvec4), Rename("fma") },

                #endregion

                #region Derivative

                { () => ShaderDefinition.DeriveTowardsX(_float), Rename("dFdx") },
                { () => ShaderDefinition.DeriveTowardsX(vec2), Rename("dFdx") },
                { () => ShaderDefinition.DeriveTowardsX(vec3), Rename("dFdx") },
                { () => ShaderDefinition.DeriveTowardsX(vec4), Rename("dFdx") },

                { () => ShaderDefinition.DeriveTowardsY(_float), Rename("dFdy") },
                { () => ShaderDefinition.DeriveTowardsY(vec2), Rename("dFdy") },
                { () => ShaderDefinition.DeriveTowardsY(vec3), Rename("dFdy") },
                { () => ShaderDefinition.DeriveTowardsY(vec4), Rename("dFdy") },
                
                #endregion

                #region Noise

                { () => ShaderDefinition.Noise1(_float), ToLower },
                { () => ShaderDefinition.Noise1(vec2), ToLower },
                { () => ShaderDefinition.Noise1(vec3), ToLower },
                { () => ShaderDefinition.Noise1(vec4), ToLower },

                { () => ShaderDefinition.Noise2(_float), ToLower },
                { () => ShaderDefinition.Noise2(vec2), ToLower },
                { () => ShaderDefinition.Noise2(vec3), ToLower },
                { () => ShaderDefinition.Noise2(vec4), ToLower },

                { () => ShaderDefinition.Noise3(_float), ToLower },
                { () => ShaderDefinition.Noise3(vec2), ToLower },
                { () => ShaderDefinition.Noise3(vec3), ToLower },
                { () => ShaderDefinition.Noise3(vec4), ToLower },

                { () => ShaderDefinition.Noise4(_float), ToLower },
                { () => ShaderDefinition.Noise4(vec2), ToLower },
                { () => ShaderDefinition.Noise4(vec3), ToLower },
                { () => ShaderDefinition.Noise4(vec4), ToLower },
                
                #endregion

                #region Texture

                { () => ShaderDefinition.TextureSize(sampler1D, _int), ToLower },
                { () => ShaderDefinition.TextureSize(isampler1D, _int), ToLower },
                { () => ShaderDefinition.TextureSize(usampler1D, _int), ToLower },

                { () => ShaderDefinition.TextureSize(sampler2D, _int), ToLower },
                { () => ShaderDefinition.TextureSize(isampler2D, _int), ToLower },
                { () => ShaderDefinition.TextureSize(usampler2D, _int), ToLower },

                { () => ShaderDefinition.TextureSize(sampler3D, _int), ToLower },
                { () => ShaderDefinition.TextureSize(isampler3D, _int), ToLower },
                { () => ShaderDefinition.TextureSize(usampler3D, _int), ToLower },

                { () => ShaderDefinition.TextureSize(samplerCube, _int), ToLower },
                { () => ShaderDefinition.TextureSize(isamplerCube, _int), ToLower },
                { () => ShaderDefinition.TextureSize(usamplerCube, _int), ToLower },

                { () => ShaderDefinition.TextureSize(sampler1DShadow, _int), ToLower },
                { () => ShaderDefinition.TextureSize(sampler2DShadow, _int), ToLower },
                { () => ShaderDefinition.TextureSize(samplerCubeShadow, _int), ToLower },

                { () => ShaderDefinition.TextureSize(sampler2DRect), ToLower },
                { () => ShaderDefinition.TextureSize(isampler2DRect), ToLower },
                { () => ShaderDefinition.TextureSize(usampler2DRect), ToLower },

                { () => ShaderDefinition.TextureQueryLod(sampler1D, _float), ToLower },
                { () => ShaderDefinition.TextureQueryLod(isampler1D, _float), ToLower },
                { () => ShaderDefinition.TextureQueryLod(usampler1D, _float), ToLower },

                { () => ShaderDefinition.TextureQueryLod(sampler2D, vec2), ToLower },
                { () => ShaderDefinition.TextureQueryLod(isampler2D, vec2), ToLower },
                { () => ShaderDefinition.TextureQueryLod(usampler2D, vec2), ToLower },

                { () => ShaderDefinition.TextureQueryLod(sampler3D, vec3), ToLower },
                { () => ShaderDefinition.TextureQueryLod(isampler3D, vec3), ToLower },
                { () => ShaderDefinition.TextureQueryLod(usampler3D, vec3), ToLower },

                { () => ShaderDefinition.TextureQueryLod(samplerCube, vec3), ToLower },
                { () => ShaderDefinition.TextureQueryLod(isamplerCube, vec3), ToLower },
                { () => ShaderDefinition.TextureQueryLod(usamplerCube, vec3), ToLower },

                { () => ShaderDefinition.TextureQueryLod(sampler1DShadow, _float), ToLower },
                { () => ShaderDefinition.TextureQueryLod(sampler2DShadow, vec2), ToLower },
                { () => ShaderDefinition.TextureQueryLod(samplerCubeShadow, vec3), ToLower },

                { () => ShaderDefinition.Texture(sampler1D, _float), ToLower },
                { () => ShaderDefinition.Texture(sampler1D, _float, _float), ToLower },
                { () => ShaderDefinition.Texture(isampler1D, _float), ToLower },
                { () => ShaderDefinition.Texture(isampler1D, _float, _float), ToLower },
                { () => ShaderDefinition.Texture(usampler1D, _float), ToLower },
                { () => ShaderDefinition.Texture(usampler1D, _float, _float), ToLower },

                { () => ShaderDefinition.Texture(sampler2D, vec2), ToLower },
                { () => ShaderDefinition.Texture(sampler2D, vec2, _float), ToLower },
                { () => ShaderDefinition.Texture(isampler2D, vec2), ToLower },
                { () => ShaderDefinition.Texture(isampler2D, vec2, _float), ToLower },
                { () => ShaderDefinition.Texture(usampler2D, vec2), ToLower },
                { () => ShaderDefinition.Texture(usampler2D, vec2, _float), ToLower },

                { () => ShaderDefinition.Texture(sampler3D, vec3), ToLower },
                { () => ShaderDefinition.Texture(sampler3D, vec3, _float), ToLower },
                { () => ShaderDefinition.Texture(isampler3D, vec3), ToLower },
                { () => ShaderDefinition.Texture(isampler3D, vec3, _float), ToLower },
                { () => ShaderDefinition.Texture(usampler3D, vec3), ToLower },
                { () => ShaderDefinition.Texture(usampler3D, vec3, _float), ToLower },

                { () => ShaderDefinition.Texture(samplerCube, vec3), ToLower },
                { () => ShaderDefinition.Texture(samplerCube, vec3, _float), ToLower },
                { () => ShaderDefinition.Texture(isamplerCube, vec3), ToLower },
                { () => ShaderDefinition.Texture(isamplerCube, vec3, _float), ToLower },
                { () => ShaderDefinition.Texture(usamplerCube, vec3), ToLower },
                { () => ShaderDefinition.Texture(usamplerCube, vec3, _float), ToLower },

                { () => ShaderDefinition.Texture(sampler1DShadow, vec3), ToLower },
                { () => ShaderDefinition.Texture(sampler1DShadow, vec3, _float), ToLower },
                { () => ShaderDefinition.Texture(sampler2DShadow, vec3), ToLower },
                { () => ShaderDefinition.Texture(sampler2DShadow, vec3, _float), ToLower },
                { () => ShaderDefinition.Texture(samplerCubeShadow, vec4), ToLower },
                { () => ShaderDefinition.Texture(samplerCubeShadow, vec4, _float), ToLower },

                { () => ShaderDefinition.Texture(sampler2DRect, vec2), ToLower },
                { () => ShaderDefinition.Texture(isampler2DRect, vec2), ToLower },
                { () => ShaderDefinition.Texture(usampler2DRect, vec2), ToLower },

                { () => ShaderDefinition.TextureProj(sampler1D, vec2), ToLower },
                { () => ShaderDefinition.TextureProj(sampler1D, vec2, _float), ToLower },
                { () => ShaderDefinition.TextureProj(isampler1D, vec2), ToLower },
                { () => ShaderDefinition.TextureProj(isampler1D, vec2, _float), ToLower },
                { () => ShaderDefinition.TextureProj(usampler1D, vec2), ToLower },
                { () => ShaderDefinition.TextureProj(usampler1D, vec2, _float), ToLower },

                { () => ShaderDefinition.TextureProj(sampler1D, vec4), ToLower },
                { () => ShaderDefinition.TextureProj(sampler1D, vec4, _float), ToLower },
                { () => ShaderDefinition.TextureProj(isampler1D, vec4), ToLower },
                { () => ShaderDefinition.TextureProj(isampler1D, vec4, _float), ToLower },
                { () => ShaderDefinition.TextureProj(usampler1D, vec4), ToLower },
                { () => ShaderDefinition.TextureProj(usampler1D, vec4, _float), ToLower },

                { () => ShaderDefinition.TextureProj(sampler2D, vec3), ToLower },
                { () => ShaderDefinition.TextureProj(sampler2D, vec3, _float), ToLower },
                { () => ShaderDefinition.TextureProj(isampler2D, vec3), ToLower },
                { () => ShaderDefinition.TextureProj(isampler2D, vec3, _float), ToLower },
                { () => ShaderDefinition.TextureProj(usampler2D, vec3), ToLower },
                { () => ShaderDefinition.TextureProj(usampler2D, vec3, _float), ToLower },

                { () => ShaderDefinition.TextureProj(sampler2D, vec4), ToLower },
                { () => ShaderDefinition.TextureProj(sampler2D, vec4, _float), ToLower },
                { () => ShaderDefinition.TextureProj(isampler2D, vec4), ToLower },
                { () => ShaderDefinition.TextureProj(isampler2D, vec4, _float), ToLower },
                { () => ShaderDefinition.TextureProj(usampler2D, vec4), ToLower },
                { () => ShaderDefinition.TextureProj(usampler2D, vec4, _float), ToLower },

                { () => ShaderDefinition.TextureProj(sampler3D, vec4), ToLower },
                { () => ShaderDefinition.TextureProj(sampler3D, vec4, _float), ToLower },
                { () => ShaderDefinition.TextureProj(isampler3D, vec4), ToLower },
                { () => ShaderDefinition.TextureProj(isampler3D, vec4, _float), ToLower },
                { () => ShaderDefinition.TextureProj(usampler3D, vec4), ToLower },
                { () => ShaderDefinition.TextureProj(usampler3D, vec4, _float), ToLower },

                { () => ShaderDefinition.TextureProj(sampler1DShadow, vec4), ToLower },
                { () => ShaderDefinition.TextureProj(sampler1DShadow, vec4, _float), ToLower },
                { () => ShaderDefinition.TextureProj(sampler2DShadow, vec4), ToLower },
                { () => ShaderDefinition.TextureProj(sampler2DShadow, vec4, _float), ToLower },

                { () => ShaderDefinition.TextureProj(sampler2DRect, vec3), ToLower },
                { () => ShaderDefinition.TextureProj(isampler2DRect, vec3), ToLower },
                { () => ShaderDefinition.TextureProj(usampler2DRect, vec3), ToLower },

                { () => ShaderDefinition.TextureProj(sampler2DRect, vec4), ToLower },
                { () => ShaderDefinition.TextureProj(isampler2DRect, vec4), ToLower },
                { () => ShaderDefinition.TextureProj(usampler2DRect, vec4), ToLower },

                { () => ShaderDefinition.TextureProj(sampler2DRectShadow, vec4), ToLower },

                { () => ShaderDefinition.TextureLod(sampler1D, _float, _float), ToLower },
                { () => ShaderDefinition.TextureLod(isampler1D, _float, _float), ToLower },
                { () => ShaderDefinition.TextureLod(usampler1D, _float, _float), ToLower },

                { () => ShaderDefinition.TextureLod(sampler2D, vec2, _float), ToLower },
                { () => ShaderDefinition.TextureLod(isampler2D, vec2, _float), ToLower },
                { () => ShaderDefinition.TextureLod(usampler2D, vec2, _float), ToLower },

                { () => ShaderDefinition.TextureLod(sampler3D, vec3, _float), ToLower },
                { () => ShaderDefinition.TextureLod(isampler3D, vec3, _float), ToLower },
                { () => ShaderDefinition.TextureLod(usampler3D, vec3, _float), ToLower },

                { () => ShaderDefinition.TextureLod(samplerCube, vec3, _float), ToLower },
                { () => ShaderDefinition.TextureLod(isamplerCube, vec3, _float), ToLower },
                { () => ShaderDefinition.TextureLod(usamplerCube, vec3, _float), ToLower },

                { () => ShaderDefinition.TextureLod(sampler1DShadow, vec3, _float), ToLower },
                { () => ShaderDefinition.TextureLod(sampler2DShadow, vec3, _float), ToLower },

                { () => ShaderDefinition.TextureOffset(sampler1D, _float, _int), ToLower },
                { () => ShaderDefinition.TextureOffset(sampler1D, _float, _int, _float), ToLower },
                { () => ShaderDefinition.TextureOffset(isampler1D, _float, _int), ToLower },
                { () => ShaderDefinition.TextureOffset(isampler1D, _float, _int, _float), ToLower },
                { () => ShaderDefinition.TextureOffset(usampler1D, _float, _int), ToLower },
                { () => ShaderDefinition.TextureOffset(usampler1D, _float, _int, _float), ToLower },

                { () => ShaderDefinition.TextureOffset(sampler2D, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureOffset(sampler2D, vec2, ivec2, _float), ToLower },
                { () => ShaderDefinition.TextureOffset(isampler2D, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureOffset(isampler2D, vec2, ivec2, _float), ToLower },
                { () => ShaderDefinition.TextureOffset(usampler2D, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureOffset(usampler2D, vec2, ivec2, _float), ToLower },

                { () => ShaderDefinition.TextureOffset(sampler3D, vec3, ivec3), ToLower },
                { () => ShaderDefinition.TextureOffset(sampler3D, vec3, ivec3, _float), ToLower },
                { () => ShaderDefinition.TextureOffset(isampler3D, vec3, ivec3), ToLower },
                { () => ShaderDefinition.TextureOffset(isampler3D, vec3, ivec3, _float), ToLower },
                { () => ShaderDefinition.TextureOffset(usampler3D, vec3, ivec3), ToLower },
                { () => ShaderDefinition.TextureOffset(usampler3D, vec3, ivec3, _float), ToLower },

                { () => ShaderDefinition.TextureOffset(sampler2DRect, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureOffset(isampler2DRect, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureOffset(usampler2DRect, vec2, ivec2), ToLower },

                { () => ShaderDefinition.TextureOffset(sampler2DRectShadow, vec3, ivec2), ToLower },

                { () => ShaderDefinition.TextureOffset(sampler1DShadow, vec3, _int, _float), ToLower },
                { () => ShaderDefinition.TextureOffset(sampler2DShadow, vec3, ivec2, _float), ToLower },

                { () => ShaderDefinition.TexelFetch(sampler1D, _int, _int), ToLower },
                { () => ShaderDefinition.TexelFetch(isampler1D, _int, _int), ToLower },
                { () => ShaderDefinition.TexelFetch(usampler1D, _int, _int), ToLower },

                { () => ShaderDefinition.TexelFetch(sampler2D, ivec2, _int), ToLower },
                { () => ShaderDefinition.TexelFetch(isampler2D, ivec2, _int), ToLower },
                { () => ShaderDefinition.TexelFetch(usampler2D, ivec2, _int), ToLower },

                { () => ShaderDefinition.TexelFetch(sampler3D, ivec3, _int), ToLower },
                { () => ShaderDefinition.TexelFetch(isampler3D, ivec3, _int), ToLower },
                { () => ShaderDefinition.TexelFetch(usampler3D, ivec3, _int), ToLower },

                { () => ShaderDefinition.TexelFetch(sampler2DRect, ivec2), ToLower },
                { () => ShaderDefinition.TexelFetch(isampler2DRect, ivec2), ToLower },
                { () => ShaderDefinition.TexelFetch(usampler2DRect, ivec2), ToLower },

                { () => ShaderDefinition.TexelFetchOffset(sampler1D, _int, _int, _int), ToLower },
                { () => ShaderDefinition.TexelFetchOffset(isampler1D, _int, _int, _int), ToLower },
                { () => ShaderDefinition.TexelFetchOffset(usampler1D, _int, _int, _int), ToLower },

                { () => ShaderDefinition.TexelFetchOffset(sampler2D, ivec2, _int, ivec2), ToLower },
                { () => ShaderDefinition.TexelFetchOffset(isampler2D, ivec2, _int, ivec2), ToLower },
                { () => ShaderDefinition.TexelFetchOffset(usampler2D, ivec2, _int, ivec2), ToLower },

                { () => ShaderDefinition.TexelFetchOffset(sampler3D, ivec3, _int, ivec3), ToLower },
                { () => ShaderDefinition.TexelFetchOffset(isampler3D, ivec3, _int, ivec3), ToLower },
                { () => ShaderDefinition.TexelFetchOffset(usampler3D, ivec3, _int, ivec3), ToLower },

                { () => ShaderDefinition.TexelFetchOffset(sampler2DRect, ivec2, ivec2), ToLower },
                { () => ShaderDefinition.TexelFetchOffset(isampler2DRect, ivec2, ivec2), ToLower },
                { () => ShaderDefinition.TexelFetchOffset(usampler2DRect, ivec2, ivec2), ToLower },

                { () => ShaderDefinition.TextureProjOffset(sampler1D, vec2, _int), ToLower },
                { () => ShaderDefinition.TextureProjOffset(sampler1D, vec2, _int, _float), ToLower },
                { () => ShaderDefinition.TextureProjOffset(isampler1D, vec2, _int), ToLower },
                { () => ShaderDefinition.TextureProjOffset(isampler1D, vec2, _int, _float), ToLower },
                { () => ShaderDefinition.TextureProjOffset(usampler1D, vec2, _int), ToLower },
                { () => ShaderDefinition.TextureProjOffset(usampler1D, vec2, _int, _float), ToLower },

                { () => ShaderDefinition.TextureProjOffset(sampler1D, vec4, _int), ToLower },
                { () => ShaderDefinition.TextureProjOffset(sampler1D, vec4, _int, _float), ToLower },
                { () => ShaderDefinition.TextureProjOffset(isampler1D, vec4, _int), ToLower },
                { () => ShaderDefinition.TextureProjOffset(isampler1D, vec4, _int, _float), ToLower },
                { () => ShaderDefinition.TextureProjOffset(usampler1D, vec4, _int), ToLower },
                { () => ShaderDefinition.TextureProjOffset(usampler1D, vec4, _int, _float), ToLower },

                { () => ShaderDefinition.TextureProjOffset(sampler2D, vec3, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjOffset(sampler2D, vec3, ivec2, _float), ToLower },
                { () => ShaderDefinition.TextureProjOffset(isampler2D, vec3, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjOffset(isampler2D, vec3, ivec2, _float), ToLower },
                { () => ShaderDefinition.TextureProjOffset(usampler2D, vec3, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjOffset(usampler2D, vec3, ivec2, _float), ToLower },

                { () => ShaderDefinition.TextureProjOffset(sampler2D, vec4, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjOffset(sampler2D, vec4, ivec2, _float), ToLower },
                { () => ShaderDefinition.TextureProjOffset(isampler2D, vec4, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjOffset(isampler2D, vec4, ivec2, _float), ToLower },
                { () => ShaderDefinition.TextureProjOffset(usampler2D, vec4, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjOffset(usampler2D, vec4, ivec2, _float), ToLower },

                { () => ShaderDefinition.TextureProjOffset(sampler3D, vec4, ivec3), ToLower },
                { () => ShaderDefinition.TextureProjOffset(sampler3D, vec4, ivec3, _float), ToLower },
                { () => ShaderDefinition.TextureProjOffset(isampler3D, vec4, ivec3), ToLower },
                { () => ShaderDefinition.TextureProjOffset(isampler3D, vec4, ivec3, _float), ToLower },
                { () => ShaderDefinition.TextureProjOffset(usampler3D, vec4, ivec3), ToLower },
                { () => ShaderDefinition.TextureProjOffset(usampler3D, vec4, ivec3, _float), ToLower },

                { () => ShaderDefinition.TextureProjOffset(sampler1DShadow, vec4, _int), ToLower },
                { () => ShaderDefinition.TextureProjOffset(sampler1DShadow, vec4, _int, _float), ToLower },
                { () => ShaderDefinition.TextureProjOffset(sampler2DShadow, vec4, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjOffset(sampler2DShadow, vec4, ivec2, _float), ToLower },

                { () => ShaderDefinition.TextureProjOffset(sampler2DRect, vec3, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjOffset(isampler2DRect, vec3, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjOffset(usampler2DRect, vec3, ivec2), ToLower },

                { () => ShaderDefinition.TextureProjOffset(sampler2DRect, vec4, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjOffset(isampler2DRect, vec4, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjOffset(usampler2DRect, vec4, ivec2), ToLower },

                { () => ShaderDefinition.TextureProjOffset(sampler2DRectShadow, vec4, ivec2), ToLower },

                { () => ShaderDefinition.TextureLodOffset(sampler1D, _float, _float, _int), ToLower },
                { () => ShaderDefinition.TextureLodOffset(isampler1D, _float, _float, _int), ToLower },
                { () => ShaderDefinition.TextureLodOffset(usampler1D, _float, _float, _int), ToLower },

                { () => ShaderDefinition.TextureLodOffset(sampler2D, vec2, _float, ivec2), ToLower },
                { () => ShaderDefinition.TextureLodOffset(isampler2D, vec2, _float, ivec2), ToLower },
                { () => ShaderDefinition.TextureLodOffset(usampler2D, vec2, _float, ivec2), ToLower },

                { () => ShaderDefinition.TextureLodOffset(sampler3D, vec3, _float, ivec3), ToLower },
                { () => ShaderDefinition.TextureLodOffset(isampler3D, vec3, _float, ivec3), ToLower },
                { () => ShaderDefinition.TextureLodOffset(usampler3D, vec3, _float, ivec3), ToLower },

                { () => ShaderDefinition.TextureLodOffset(sampler1DShadow, vec3, _float, _int), ToLower },
                { () => ShaderDefinition.TextureLodOffset(sampler2DShadow, vec3, _float, ivec2), ToLower },

                { () => ShaderDefinition.TextureProjLod(sampler1D, vec2, _float), ToLower },
                { () => ShaderDefinition.TextureProjLod(isampler1D, vec2, _float), ToLower },
                { () => ShaderDefinition.TextureProjLod(usampler1D, vec2, _float), ToLower },

                { () => ShaderDefinition.TextureProjLod(sampler1D, vec4, _float), ToLower },
                { () => ShaderDefinition.TextureProjLod(isampler1D, vec4, _float), ToLower },
                { () => ShaderDefinition.TextureProjLod(usampler1D, vec4, _float), ToLower },

                { () => ShaderDefinition.TextureProjLod(sampler2D, vec3, _float), ToLower },
                { () => ShaderDefinition.TextureProjLod(isampler2D, vec3, _float), ToLower },
                { () => ShaderDefinition.TextureProjLod(usampler2D, vec3, _float), ToLower },

                { () => ShaderDefinition.TextureProjLod(sampler2D, vec4, _float), ToLower },
                { () => ShaderDefinition.TextureProjLod(isampler2D, vec4, _float), ToLower },
                { () => ShaderDefinition.TextureProjLod(usampler2D, vec4, _float), ToLower },

                { () => ShaderDefinition.TextureProjLod(sampler3D, vec4, _float), ToLower },
                { () => ShaderDefinition.TextureProjLod(isampler3D, vec4, _float), ToLower },
                { () => ShaderDefinition.TextureProjLod(usampler3D, vec4, _float), ToLower },

                { () => ShaderDefinition.TextureProjLod(sampler1DShadow, vec4, _float), ToLower },
                { () => ShaderDefinition.TextureProjLod(sampler2DShadow, vec4, _float), ToLower },

                { () => ShaderDefinition.TextureProjLodOffset(sampler1D, vec2, _float, _int), ToLower },
                { () => ShaderDefinition.TextureProjLodOffset(isampler1D, vec2, _float, _int), ToLower },
                { () => ShaderDefinition.TextureProjLodOffset(usampler1D, vec2, _float, _int), ToLower },

                { () => ShaderDefinition.TextureProjLodOffset(sampler1D, vec4, _float, _int), ToLower },
                { () => ShaderDefinition.TextureProjLodOffset(isampler1D, vec4, _float, _int), ToLower },
                { () => ShaderDefinition.TextureProjLodOffset(usampler1D, vec4, _float, _int), ToLower },

                { () => ShaderDefinition.TextureProjLodOffset(sampler2D, vec3, _float, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjLodOffset(isampler2D, vec3, _float, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjLodOffset(usampler2D, vec3, _float, ivec2), ToLower },

                { () => ShaderDefinition.TextureProjLodOffset(sampler2D, vec4, _float, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjLodOffset(isampler2D, vec4, _float, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjLodOffset(usampler2D, vec4, _float, ivec2), ToLower },

                { () => ShaderDefinition.TextureProjLodOffset(sampler3D, vec4, _float, ivec3), ToLower },
                { () => ShaderDefinition.TextureProjLodOffset(isampler3D, vec4, _float, ivec3), ToLower },
                { () => ShaderDefinition.TextureProjLodOffset(usampler3D, vec4, _float, ivec3), ToLower },

                { () => ShaderDefinition.TextureProjLodOffset(sampler1DShadow, vec4, _float, _int), ToLower },
                { () => ShaderDefinition.TextureProjLodOffset(sampler2DShadow, vec4, _float, ivec2), ToLower },

                { () => ShaderDefinition.TextureGrad(sampler1D, _float, _float, _float), ToLower },
                { () => ShaderDefinition.TextureGrad(isampler1D, _float, _float, _float), ToLower },
                { () => ShaderDefinition.TextureGrad(usampler1D, _float, _float, _float), ToLower },

                { () => ShaderDefinition.TextureGrad(sampler2D, vec2, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureGrad(isampler2D, vec2, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureGrad(usampler2D, vec2, vec2, vec2), ToLower },

                { () => ShaderDefinition.TextureGrad(sampler3D, vec3, vec3, vec3), ToLower },
                { () => ShaderDefinition.TextureGrad(isampler3D, vec3, vec3, vec3), ToLower },
                { () => ShaderDefinition.TextureGrad(usampler3D, vec3, vec3, vec3), ToLower },

                { () => ShaderDefinition.TextureGrad(samplerCube, vec3, vec3, vec3), ToLower },
                { () => ShaderDefinition.TextureGrad(isamplerCube, vec3, vec3, vec3), ToLower },
                { () => ShaderDefinition.TextureGrad(usamplerCube, vec3, vec3, vec3), ToLower },

                { () => ShaderDefinition.TextureGrad(sampler2DRect, vec2, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureGrad(isampler2DRect, vec2, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureGrad(usampler2DRect, vec2, vec2, vec2), ToLower },

                { () => ShaderDefinition.TextureGrad(sampler2DRectShadow, vec3, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureGrad(sampler1DShadow, vec3, _float, _float), ToLower },
                { () => ShaderDefinition.TextureGrad(sampler2DShadow, vec3, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureGrad(samplerCubeShadow, vec4, vec3, vec3), ToLower },

                { () => ShaderDefinition.TextureGradOffset(sampler1D, _float, _float, _float, _int), ToLower },
                { () => ShaderDefinition.TextureGradOffset(isampler1D, _float, _float, _float, _int), ToLower },
                { () => ShaderDefinition.TextureGradOffset(usampler1D, _float, _float, _float, _int), ToLower },

                { () => ShaderDefinition.TextureGradOffset(sampler2D, vec2, vec2, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureGradOffset(isampler2D, vec2, vec2, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureGradOffset(usampler2D, vec2, vec2, vec2, ivec2), ToLower },

                { () => ShaderDefinition.TextureGradOffset(sampler3D, vec3, vec3, vec3, ivec3), ToLower },
                { () => ShaderDefinition.TextureGradOffset(isampler3D, vec3, vec3, vec3, ivec3), ToLower },
                { () => ShaderDefinition.TextureGradOffset(usampler3D, vec3, vec3, vec3, ivec3), ToLower },

                { () => ShaderDefinition.TextureGradOffset(sampler2DRect, vec2, vec2, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureGradOffset(isampler2DRect, vec2, vec2, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureGradOffset(usampler2DRect, vec2, vec2, vec2, ivec2), ToLower },

                { () => ShaderDefinition.TextureGradOffset(sampler2DRectShadow, vec3, vec2, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureGradOffset(sampler1DShadow, vec3, _float, _float, _int), ToLower },
                { () => ShaderDefinition.TextureGradOffset(sampler2DShadow, vec3, vec2, vec2, ivec2), ToLower },

                { () => ShaderDefinition.TextureProjGrad(sampler1D, vec2, _float, _float), ToLower },
                { () => ShaderDefinition.TextureProjGrad(isampler1D, vec2, _float, _float), ToLower },
                { () => ShaderDefinition.TextureProjGrad(usampler1D, vec2, _float, _float), ToLower },

                { () => ShaderDefinition.TextureProjGrad(sampler1D, vec4, _float, _float), ToLower },
                { () => ShaderDefinition.TextureProjGrad(isampler1D, vec4, _float, _float), ToLower },
                { () => ShaderDefinition.TextureProjGrad(usampler1D, vec4, _float, _float), ToLower },

                { () => ShaderDefinition.TextureProjGrad(sampler2D, vec3, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureProjGrad(isampler2D, vec3, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureProjGrad(usampler2D, vec3, vec2, vec2), ToLower },

                { () => ShaderDefinition.TextureProjGrad(sampler2D, vec4, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureProjGrad(isampler2D, vec4, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureProjGrad(usampler2D, vec4, vec2, vec2), ToLower },

                { () => ShaderDefinition.TextureProjGrad(sampler3D, vec4, vec3, vec3), ToLower },
                { () => ShaderDefinition.TextureProjGrad(isampler3D, vec4, vec3, vec3), ToLower },
                { () => ShaderDefinition.TextureProjGrad(usampler3D, vec4, vec3, vec3), ToLower },

                { () => ShaderDefinition.TextureProjGrad(sampler2DRect, vec3, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureProjGrad(isampler2DRect, vec3, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureProjGrad(usampler2DRect, vec3, vec2, vec2), ToLower },

                { () => ShaderDefinition.TextureProjGrad(sampler2DRect, vec4, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureProjGrad(isampler2DRect, vec4, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureProjGrad(usampler2DRect, vec4, vec2, vec2), ToLower },

                { () => ShaderDefinition.TextureProjGrad(sampler2DRectShadow, vec4, vec2, vec2), ToLower },
                { () => ShaderDefinition.TextureProjGrad(sampler1DShadow, vec4, _float, _float), ToLower },
                { () => ShaderDefinition.TextureProjGrad(sampler2DShadow, vec4, vec2, vec2), ToLower },

                { () => ShaderDefinition.TextureProjGradOffset(sampler1D, vec2, _float, _float, _int), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(isampler1D, vec2, _float, _float, _int), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(usampler1D, vec2, _float, _float, _int), ToLower },

                { () => ShaderDefinition.TextureProjGradOffset(sampler1D, vec4, _float, _float, _int), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(isampler1D, vec4, _float, _float, _int), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(usampler1D, vec4, _float, _float, _int), ToLower },

                { () => ShaderDefinition.TextureProjGradOffset(sampler2D, vec3, vec2, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(isampler2D, vec3, vec2, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(usampler2D, vec3, vec2, vec2, ivec2), ToLower },

                { () => ShaderDefinition.TextureProjGradOffset(sampler2D, vec4, vec2, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(isampler2D, vec4, vec2, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(usampler2D, vec4, vec2, vec2, ivec2), ToLower },

                { () => ShaderDefinition.TextureProjGradOffset(sampler3D, vec4, vec3, vec3, ivec3), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(isampler3D, vec4, vec3, vec3, ivec3), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(usampler3D, vec4, vec3, vec3, ivec3), ToLower },

                { () => ShaderDefinition.TextureProjGradOffset(sampler2DRect, vec3, vec2, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(isampler2DRect, vec3, vec2, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(usampler2DRect, vec3, vec2, vec2, ivec2), ToLower },

                { () => ShaderDefinition.TextureProjGradOffset(sampler2DRect, vec4, vec2, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(isampler2DRect, vec4, vec2, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(usampler2DRect, vec4, vec2, vec2, ivec2), ToLower },

                { () => ShaderDefinition.TextureProjGradOffset(sampler2DRectShadow, vec4, vec2, vec2, ivec2), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(sampler1DShadow, vec4, _float, _float, _int), ToLower },
                { () => ShaderDefinition.TextureProjGradOffset(sampler2DShadow, vec4, vec2, vec2, ivec2), ToLower },

                #endregion

                #region Interpolation

                { () => ShaderDefinition.InterpolateAtCentroid(_float), ToLower },
                { () => ShaderDefinition.InterpolateAtCentroid(vec2), ToLower },
                { () => ShaderDefinition.InterpolateAtCentroid(vec3), ToLower },
                { () => ShaderDefinition.InterpolateAtCentroid(vec4), ToLower },

                { () => ShaderDefinition.InterpolateAtSample(_float, _int), ToLower },
                { () => ShaderDefinition.InterpolateAtSample(vec2, _int), ToLower },
                { () => ShaderDefinition.InterpolateAtSample(vec3, _int), ToLower },
                { () => ShaderDefinition.InterpolateAtSample(vec4, _int), ToLower },
                
                { () => ShaderDefinition.InterpolateAtOffset(_float, vec2), ToLower },
                { () => ShaderDefinition.InterpolateAtOffset(vec2, vec2), ToLower },
                { () => ShaderDefinition.InterpolateAtOffset(vec3, vec2), ToLower },
                { () => ShaderDefinition.InterpolateAtOffset(vec4, vec2), ToLower },

                #endregion
            };
        }

        private StringBuilder KeywordDiscard(MethodDefinition unused1, InvocationExpression unused2)
        {
            return new StringBuilder("discard");
        }
    }
}
