using System.Text;
using ICSharpCode.NRefactory.CSharp;
using Mono.Cecil;

namespace IIS.SLSharp.Translation.HLSL
{
    internal sealed partial class HlslVisitor
    {
        private StringBuilder VisitShaderDefCall(MethodDefinition m, InvocationExpression invocationExpression)
        {
            var result = new StringBuilder();
            return result.Append(m.Name).Append("(").Append(ArgsToString(invocationExpression.Arguments)).Append(")");
        }
    }
}
