using System;
using System.Collections.Generic;
using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;

namespace IIS.SLSharp.Translation
{
    internal sealed class RenameLocals: IAstTransform
    {
        private int _ctr;

        private readonly Dictionary<string, string> _locals = new Dictionary<string, string>();

        public void Run(AstNode node)
        {
            if (node is VariableInitializer)
            {
                var n = (VariableInitializer) node;
                var newName = "_loc" + _ctr++;
                _locals[n.Name] = newName;
                n.ReplaceWith(new VariableInitializer(newName, n.Initializer));
            }

            if (node is IdentifierExpression)
            {
                var n = (IdentifierExpression)node;
                string newName;
                if (_locals.TryGetValue(n.Identifier, out newName))
                    n.ReplaceWith(new IdentifierExpression(newName));
            }

            foreach (var c in node.Children)
                Run(c);
        }
    }
}
