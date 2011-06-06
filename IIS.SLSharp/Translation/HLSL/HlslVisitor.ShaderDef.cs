using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using IIS.SLSharp.Shaders;
using Mono.Cecil;
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
#pragma warning restore 649
// ReSharper restore InconsistentNaming

        private readonly Dictionary<int, Func<MethodDefinition, InvocationExpression, StringBuilder>> _handlers;
        
        public HlslVisitor()
        {
            _handlers = new Dictionary<int, Func<MethodDefinition, InvocationExpression, StringBuilder>>
            {
                {
                    MetaToken(() => ShaderDefinition.texture(sampler2D, vec2)), Rename("tex2D")
                },

            };
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
            return _handlers[m.Resolve().MetadataToken.ToInt32()](m, invocationExpression);
        }
    }
}
