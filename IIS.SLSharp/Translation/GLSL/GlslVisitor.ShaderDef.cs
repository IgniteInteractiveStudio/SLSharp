using System.Text;
using ICSharpCode.NRefactory.CSharp;
using Mono.Cecil;

namespace IIS.SLSharp.Translation.GLSL
{
    internal sealed partial class GlslVisitor
    {
        private StringBuilder VisitShaderDefCall(MethodDefinition m, InvocationExpression invocationExpression)
        {
            var result = new StringBuilder();
            return result.Append(m.Name).Append("(").Append(ArgsToString(invocationExpression.Arguments)).Append(")");
        }
    }
}
