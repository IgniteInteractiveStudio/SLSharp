using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using ICSharpCode.NRefactory.CSharp;
using Mono.Cecil;

namespace IIS.SLSharp.Reflection
{
    public sealed class Decompiler
    {
        public static BlockStatement DecompileMethod(TypeDefinition shader, MethodDefinition method)
        {
            return AstMethodBodyBuilder.CreateMethodBody(method, new DecompilerContext
            {
                CurrentType = shader,
                CurrentMethod = method,
            });
        }
    }
}
