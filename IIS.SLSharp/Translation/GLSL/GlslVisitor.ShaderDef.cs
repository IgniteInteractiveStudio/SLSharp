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
            };
        }
    }
}
