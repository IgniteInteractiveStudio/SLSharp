using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace IIS.SLSharp.Core.Expressions
{
    /// <summary>
    /// Utility class that trys to find calls within an AST that corresponded to
    /// indexers, replacing them with proper expressions.
    /// </summary>

    public sealed class IndexReducer
    {
        internal sealed class IndexReducerVisitor: ExpressionVisitor
        {
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                var m = node.Method;
                var cls = m.DeclaringType;

                // iterate over all props and check if the method in question was defined
                // as a getter or setter

                var props = cls.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (var p in props)
                {
                    var g = p.GetGetMethod(true);
                    var s = p.GetSetMethod(true);
                    
                    if (g == m)
                    {
                        // method was a getter, we can simply return an index expression here
                        if (node.Object == null)
                            throw new Exception();
                        return Expression.MakeIndex(node.Object, p, node.Arguments);
                    } 
                    
                    if (s == m)
                    {
                        // method was a setter
                        break;
                    }
                }

                Console.WriteLine("Call");
                return base.VisitMethodCall(node);
            }
        }

        private static readonly IndexReducerVisitor _reducer = new IndexReducerVisitor();

        public static IEnumerable<Expression> Reduce(List<Expression> expression)
        {
            for (var i = 0; i < expression.Count; i++)
                expression[i] = _reducer.VisitAndConvert(expression[i], "");
            return expression;
        }
    }
}
