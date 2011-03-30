using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IIS.SLSharp.Core.Expressions
{
    public class WhileExpression : Expression
    {
        private readonly List<Expression> _body;

        public IEnumerable<Expression> Body
        {
            get { return _body; }
        }

        public Expression Comperator { get; private set; }

        public WhileExpression(List<Expression> body, Expression comperator)
        {
            _body = body;
            Comperator = comperator;
        }

        public override Expression Reduce()
        {
            return this;
        }

        public override ExpressionType NodeType
        {
            get { return ExpressionType.Loop; }
        }

        public override Type Type
        {
            get { return typeof(WhileExpression); }
        }

        public override bool CanReduce
        {
            get { return false; }
        }
    }
}
