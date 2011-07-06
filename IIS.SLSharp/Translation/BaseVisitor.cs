using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;

namespace IIS.SLSharp.Translation
{
    internal class BaseVisitor
    {
        protected void Warn(string message, params object[] args)
        {
            var msg = String.Format(message, args);
            Console.WriteLine("Warning: " + msg);
        }

        protected void Error(string message, params object[] args)
        {
            var msg = String.Format(message, args);
            Console.WriteLine("Error: " + msg);
        }

        private int _tempCounter;

        protected VariableDeclarationStatement ToTemp(Expression e)
        {
            return new VariableDeclarationStatement(null, "__tmp" + _tempCounter++, e.Clone());
        }
    }
}
