using System.Linq.Expressions;

namespace IIS.SLSharp.Core.Expressions
{
    public class DualLogicalExpression : Expression
    {
        public Expression Primary { get; private set; }

        public Expression Dual { get; private set; }

        public DualLogicalExpression(Expression primary, Expression dual)
        {
            Primary = primary;
            Dual = dual;
        }
    }
}
