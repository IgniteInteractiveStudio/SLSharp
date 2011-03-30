using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace IIS.SLSharp.Core.Expressions
{
    public sealed class LoopReducer
    {
        private readonly List<Expression> _result = new List<Expression>();

        public IEnumerable<Expression> Result
        {
            get { return _result; }
        }
        
        private readonly Dictionary<LabelTarget, int> _labels = new Dictionary<LabelTarget, int>();

        private readonly Dictionary<int, ParameterExpression> _locals;

        private void ResolveLabels(IList<Expression> exp)
        {
            for (var i = 0; i < exp.Count; i++)
            {
                var e = exp[i];
                if (e.NodeType == ExpressionType.Label)
                    _labels[((LabelExpression) e).Target] = i;
            }
        }

        private int GotoTarget(Expression e)
        {
            int res;
            if (e.NodeType != ExpressionType.Goto)
                return -1;

            if (_labels.TryGetValue(((GotoExpression) e).Target, out res))
                return res + 1;

            return -1;
        }

        private LoopReducer(List<Expression> expressions, Dictionary<int, ParameterExpression> locals)
        {
            _locals = locals;
            ResolveLabels(expressions);
            Simplify(expressions);
            _result = expressions;
        }

        private void Simplify(List<Expression> exp)
        {
            //ResolveTernary(exp);
            ResolveLoop(exp);
        }

        private void ResolveLoop(List<Expression> exp)
        {
            // scan for for() loops
            for (var i = 0; i < exp.Count; i++)
            {
                var e = exp[i];
                var target = GotoTarget(e);

                if (target < i || target >= exp.Count)
                    continue;

                var cond = exp[target] as ConditionalExpression;
                var boolAssignment = exp[target] as BinaryExpression;

                if (cond == null)
                {
                    // in debug mode an additional temporary is used
                    if (boolAssignment == null)
                        continue;

                    if (boolAssignment.NodeType != ExpressionType.Assign)
                        continue;

                    if (target + 1 >= exp.Count)
                        continue;

                    cond = exp[target + 1] as ConditionalExpression;
                    if (cond == null)
                        continue;
                    
                    cond = Expression.Condition(boolAssignment.Right, cond.IfTrue, cond.IfFalse);
                    var left = (ParameterExpression) boolAssignment.Left;

                    foreach (var idx in _locals.Keys.Where(idx => _locals[idx].Name == left.Name))
                    {
                        _locals.Remove(idx);
                        break;
                    }

                    // we MUST remove the var out of the locals
                    // if we fail to do so it is a complex condition we cannot reduce
                    //boolAssignment.Left;
                    //boolAssignment.Left
                    //_locals[]
                }

                var entry = i + 2;
                if (GotoTarget(cond.IfFalse) != entry && GotoTarget(cond.IfTrue) != entry)
                    continue;

                var bodyEnd = target - 2;
                var pre = new List<Expression>(exp.Take(i));
                var body = new List<Expression>(exp.Skip(entry).Take(bodyEnd - i - 1));
                var post = new List<Expression>(exp.Skip(target + (boolAssignment == null ? 1 : 2)));

                ResolveLoop(body);
                ResolveLoop(post);

                exp.Clear();
                exp.AddRange(pre);
                exp.Add(new WhileExpression(body, cond.Test));
                exp.AddRange(post);
            }
        }

        public static IEnumerable<Expression> Reduce(List<Expression> expression, Dictionary<int, ParameterExpression> locals)
        {
            return new LoopReducer(expression, locals).Result;
        }
    }
}
