using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using ICSharpCode.NRefactory.CSharp;
using IIS.SLSharp.Core.Expressions;
using Mono.Cecil;

namespace IIS.SLSharp.Core.Reflection
{
    public sealed class Decompiler
    {
        public static BlockStatement DecompileMethod(MethodInfo methodInfo)
        {
            var asm = AssemblyDefinition.ReadAssembly(methodInfo.DeclaringType.Assembly.Location);
            var mod = asm.Modules.Single(x => x.MetadataToken.ToInt32() == methodInfo.Module.MetadataToken);
            var type = mod.Types.Single(x => x.MetadataToken.ToInt32() == methodInfo.DeclaringType.MetadataToken);
            var method = type.Methods.Single(x => x.MetadataToken.ToInt32() == methodInfo.MetadataToken);

            return AstMethodBodyBuilder.CreateMethodBody(method, new DecompilerContext
            {
                CurrentType = type,
                CurrentMethod = method,
            });
        }
    }
}
