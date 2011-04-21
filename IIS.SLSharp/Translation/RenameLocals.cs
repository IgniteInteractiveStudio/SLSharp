using System;
using System.Collections.Generic;
using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.NRefactory.CSharp;

namespace IIS.SLSharp.Translation
{
    internal sealed class RenameLocals : IAstTransform
    {
        private int _ctr;

        private readonly Dictionary<string, string> _locals = new Dictionary<string, string>();

        public void Run(AstNode node)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            var initializer = node as VariableInitializer;
            if (initializer != null)
            {
                var newName = "_loc" + _ctr++;
                _locals[initializer.Name] = newName;
                initializer.ReplaceWith(new VariableInitializer(newName, initializer.Initializer));
            }
            else
            {
                var identifier = node as IdentifierExpression;
                if (identifier != null)
                {
                    string newName;
                    if (_locals.TryGetValue(identifier.Identifier, out newName))
                        identifier.ReplaceWith(new IdentifierExpression(newName));
                }
            }

            foreach (var c in node.Children)
                Run(c);
        }
    }
}
