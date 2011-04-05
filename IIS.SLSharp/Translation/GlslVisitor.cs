using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Translation
{
    /// <summary>
    /// Visitor used to translate an Expression tree to GLSL source
    /// This is internally used by GlslTransform.Transform()
    /// </summary>
    internal sealed class GlslVisitor : ExpressionVisitor
    {
        private readonly HashSet<string> _functions = new HashSet<string>();

        public IEnumerable<string> Functions
        {
            get { return _functions; }
        }

        private readonly StringBuilder _s = new StringBuilder();

        private readonly IShaderAttribute _attr;

        private int _indent;

        private int Indent
        {
            get { return _indent; } 
            set
            {
                if (value == _indent)
                    return;
                
                var ds = string.Empty;
                if (value > _indent)
                {
                    var d = value - _indent;
                    for (var i = 0; i < d; i++)
                        ds += "    ";

                    _s.Append(ds);
                    _indentString += ds;
                }
                else
                {
                    var d = (_indent - value) * 4;
                    if (_s.ToString().EndsWith(_indentString))
                        _s.Remove(_s.Length - d, d);

                    _indentString = _indentString.Remove(0, d);
                }
                
                _indent = value;
            }
        }

        private string _indentString = string.Empty;

        private string DoIndent(string s)
        {
            return s.Replace(Environment.NewLine, Environment.NewLine + _indentString);
        }

        private void Append(string s)
        {
            _s.Append(DoIndent(s));
        }

        private void AppendLine(string s)
        {
            _s.AppendLine(DoIndent(s));
            _s.Append(_indentString);
        }

        private void AppendFormat(string s, params object[] args)
        {
            _s.AppendFormat(DoIndent(s), args);
        }

        public static string ToGlslType(Type t)
        {
            if (t == typeof(float))
                return "float";

            if (t == typeof(double))
                return "double";

            if (t == typeof(void))
                return "void";

            if (t == typeof(int))
                return "int";

            if (t == typeof(uint))
                return "uint";

            if (t == typeof(bool))
                return "bool";

            return t.Name;
        }

        private static bool IsTernaryConditional(ConditionalExpression node)
        {
            return node.Type != typeof(void) && (node.IfTrue.NodeType != ExpressionType.Block
                || node.IfFalse.NodeType != ExpressionType.Block);
        }

        private static bool IsActualStatement(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Label:
                    return false;
                case ExpressionType.Conditional:
                    return IsTernaryConditional((ConditionalExpression) expression);
                case ExpressionType.Try:
                case ExpressionType.Loop:
                case ExpressionType.Switch:
                    return false;
                default:
                    return true;
            }
        }

        private static bool RequiresExplicitReturn(BlockExpression node, int index, bool returnLast)
        {
            if (!returnLast)
                return false;

            var lastIndex = node.Expressions.Count - 1;
            if (index != lastIndex)
                return false;

            var last = node.Expressions[lastIndex];
            return last.NodeType != ExpressionType.Goto || ((GotoExpression)last).Kind != GotoExpressionKind.Return;
        }

        public string Result
        {
            get { return _s.ToString(); }
        }

        public GlslVisitor(Expression block, IShaderAttribute attr)
        {
            _attr = attr;

            //try
            //{
                Visit(block);
            //} 
            /*catch (Exception e)
            {
                //Console.WriteLine(block.ToCSharpCode());
                Console.WriteLine("Expression translation failed:{0}{1}", Environment.NewLine, e.Message);
            }*/
        }

        public override Expression Visit(Expression node)
        {
            return /*node.Type == typeof(WhileExpression) ? VisitFor((WhileExpression) node) : */base.Visit(node);
        }

        private Expression VisitFor(/*WhileExpression node*/)
        {
            /*
            Append("while (");
            Visit(node.Comperator);
            Append(")" + Environment.NewLine + "{" + Environment.NewLine);
            Indent++;

            foreach (var e in node.Body)
            {
                Visit(e);
                AppendLine(";");
            }

            Indent--;
            Append("}" + Environment.NewLine);

            return node;
            */
            throw new NotImplementedException();
        }

        private readonly Dictionary<ExpressionType, string> _expToStr = new Dictionary<ExpressionType, string>
        {
            // Note: we only list binary operators here, see VisitUnary for unary operators
            // arithmetic
            { ExpressionType.Add, " + " },
            { ExpressionType.Subtract, " - " },
            { ExpressionType.Multiply, " * " },
            { ExpressionType.Divide, " / " },
            { ExpressionType.Modulo, " % " },
            // bitwise
            { ExpressionType.Or, " | " },
            { ExpressionType.And, " & " },
            { ExpressionType.ExclusiveOr, " ^ " },
            { ExpressionType.LeftShift, " << " },
            { ExpressionType.RightShift, " >> " },
            // equivalence and comparison
            { ExpressionType.LessThan, " < " },
            { ExpressionType.LessThanOrEqual, " <= " },
            { ExpressionType.GreaterThan, " > " },
            { ExpressionType.GreaterThanOrEqual, " >= " },
            { ExpressionType.Equal, " == " },
            { ExpressionType.NotEqual, " != " },
        };

        protected override Expression VisitBinary(BinaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.ArrayIndex:
                    Visit(node.Left);
                    Append("[");
                    Visit(node.Right);
                    Append("]");
                    break;
                case ExpressionType.Assign:
                    Visit(node.Left);
                    Append(" = ");
                    Visit(node.Right);
                    break;
                default:
                    Append("(");
                    Visit(node.Left);
                    Append(_expToStr[node.NodeType]);
                    Visit(node.Right);
                    Append(")");
                    break;
            }
            
            return node;
        }

        protected override Expression VisitBlock(BlockExpression node)
        {
            AppendLine(Environment.NewLine + "{");
            Indent++;

            foreach (var v in node.Variables)
            {
                var t = ToGlslType(v.Type);
                AppendFormat("{0} {1};" + Environment.NewLine, t, v.Name);
            }

            for (var i = 0; i < node.Expressions.Count; i++)
            {
                var e = node.Expressions[i];
                if (IsActualStatement(e) && RequiresExplicitReturn(node, i, node.Type != typeof(void)))
                    Append("return ");

                Visit(e);

                if (!IsActualStatement(e))
                    continue;

                AppendLine(";");
            }

            Indent--;
            AppendLine("}");

            return node;
        }

        protected override Expression VisitConditional(ConditionalExpression node)
        {
            Append("if (");
            Visit(node.Test);
            Append(")");
            Visit(node.IfTrue);

            if (node.IfFalse.NodeType != ExpressionType.Default)
            {
                Append("else");
                Visit(node.IfFalse);
            }

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Type == typeof(float))
            {
                var s = ((float)node.Value).ToString(CultureInfo.InvariantCulture.NumberFormat);
                if (!s.Contains("."))
                    s += ".0";

                Append(s);
            }
            else
                Append(node.Value.ToString());

            return node;
        }

        protected override Expression VisitDebugInfo(DebugInfoExpression node)
        {
            throw new NotSupportedException("Debugging info is not supported in GLSL.");
        }

        protected override Expression VisitDynamic(DynamicExpression node)
        {
            throw new NotSupportedException("Dynamic code is not supported in GLSL.");
        }

        protected override Expression VisitDefault(DefaultExpression node)
        {
            var type = node.Type;
            object value;

            if (type == typeof(float))
                value = default(float);
            else if (type == typeof(double))
                value = default(double);
            else if (type == typeof(int))
                value = default(int);
            else if (type == typeof(uint))
                value = default(uint);
            else if (type == typeof(bool))
                value = default(bool);
            else
                throw new NotSupportedException("Unsupported default type " + node.Type);

            return VisitConstant(Expression.Constant(value));
        }

        protected override Expression VisitExtension(Expression node)
        {
            throw new NotImplementedException();
        }

        protected override Expression VisitGoto(GotoExpression node)
        {
            throw new NotSupportedException("Gotos and labels are not allowed in shaders.");
        }

        protected override Expression VisitInvocation(InvocationExpression node)
        {
            throw new NotSupportedException();
        }

        protected override LabelTarget VisitLabelTarget(LabelTarget node)
        {
            throw new NotSupportedException("Gotos and labels are not allowed in shaders.");
        }

        protected override Expression VisitLabel(LabelExpression node)
        {
            throw new NotSupportedException("Gotos and labels are not allowed in shaders.");
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            throw new NotSupportedException();
        }

        protected override Expression VisitLoop(LoopExpression node)
        {
            // TODO: decompose the node body and turn it into a while (true) (WhileExpression)
            throw new NotImplementedException();
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            //if (node.Expression.Name != "this")
            if (node.Member.DeclaringType != typeof(ShaderDefinition))
            {
                //if (node.Expression)
                var pe = node.Expression as ParameterExpression;
                if (pe == null || pe.Name != "this")
                {
                    Visit(node.Expression);
                    Append(".");
                }
            }

            Append(Shader.ResolveName(node.Member));
            return node;
        }

        protected override Expression VisitIndex(IndexExpression node)
        {
            throw new NotSupportedException("Indexing custom types is not allowed in GLSL.");
        }

        private readonly Dictionary<string, Tuple<string, bool>> _unaryOpMapping = new Dictionary<string, Tuple<string, bool>>
        {
            // name -> (op, shouldPrepend)
            { "op_UnaryPlus", Tuple.Create("+", true) },
            { "op_UnaryNegation", Tuple.Create("-", true) },
            { "op_LogicalNot", Tuple.Create("!", true) },
            { "op_OnesComplement", Tuple.Create("~", true) },
            // since compilers usually don't emit separate methods for pre/post-inc/dec, we use post-inc/dec by default
            { "op_Increment", Tuple.Create("++", false) },
            { "op_Decrement", Tuple.Create("--", false) },
        };

        private readonly Dictionary<string, string> _binaryOpMapping = new Dictionary<string, string>
        {
            { "op_Multiply", " * " },
            { "op_Division", " / " },
            { "op_Addition", " + " },
            { "op_Subtraction", " - " },
            { "op_Modulus", " % " },
            { "op_BitwiseOr", " | " },
            { "op_BitwiseAnd", " & " },
            { "op_ExclusiveOr", " ^ " },
            { "op_LeftShift", " << " },
            { "op_RightShift", " >> " },
        };

        private void ArgsToString(ICollection<Expression> args)
        {
            if (args.Count <= 0)
                return;

            foreach (var v in args.Take(args.Count - 1))
            {
                Visit(v);
                Append(",");
            }

            Visit(args.Last());
        }

        public static string GetMethodName(MethodInfo m)
        {
            return Shader.ResolveName(m);
        }

        public static string GetParameterString(MethodInfo m)
        {
            var sig = string.Empty;
            var parameters = m.GetParameters();

            if (parameters.Length > 0)
            {
                sig = parameters.Take(parameters.Length - 1).Aggregate(sig, (current, v) =>
                    current + ToGlslType(v.ParameterType) + " " + v.Name + ",");

                var l = parameters.Last();
                sig += ToGlslType(l.ParameterType) + " " + l.Name;
            }

            return sig;
        }

        public static string GetSignature(MethodInfo m)
        {
            return ToGlslType(m.ReturnType) + " " +
                GetMethodName(m) + "(" +
                GetParameterString(m) + ")";
        }

        private void RegisterMethod(MethodInfo m)
        {
            // generate signature
            var neededTyp = _attr.GetType();
            var attr = m.GetCustomAttributes(neededTyp, false); 
            if (attr.Length == 0)
                throw new Exception("Called shader method has no " + neededTyp.Name + Environment.NewLine + GetSignature(m));

            if (((IShaderAttribute)attr[0]).EntryPoint)
                throw new Exception("Cannot call shader entrypoint.");

            _functions.Add(GetSignature(m));
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var m = node.Method;
            var args = node.Arguments;

            // the method must be either within ShaderDefinition
            // or an "external" lib func

            if (m.IsSpecialName && m.Name.StartsWith("op_"))
            {
                if (m.Name == "op_Implicit")
                    return Visit(node.Arguments[0]);

                switch (args.Count)
                {
                    case 2: // binary operator
                        Append("(");
                        Visit(args[0]);
                        Append(_binaryOpMapping[m.Name]);
                        Visit(args[1]);
                        Append(")");
                        break;
                    case 1: // unary operator
                        var unary = _unaryOpMapping[m.Name];

                        // should we prepend the operator? (+, -, !, ~)
                        if (unary.Item2)
                            Append(unary.Item1);

                        Visit(args[0]);

                        // should we append the operator? (++, --)
                        if (!unary.Item2)
                            Append(unary.Item1);

                        break;
                    default:
                        throw new NotImplementedException();
                }

                return node;
            }

            if (node.Object != null)
            {
                if (m.IsSpecialName)
                {
                    if (m.Name.StartsWith("get_") && args.Count == 0)
                    {
                        var uniform = m.Name.Remove(0, 4);
                        uniform = Shader.ResolveName(m.DeclaringType, uniform);

                        // TODO: translate uniform to shared name
                        Append(uniform);
                        return node;
                    }
                }

                // must be either a getter or a lib invocation
                //Visit(node.Object);
                //Append(".");
                RegisterMethod(m);
                Append(GetMethodName(m));
            }
            else
                Append(m.Name);

            AppendFormat("(");
            ArgsToString(args);
            Append(")");

            return node;
        }

        protected override Expression VisitNewArray(NewArrayExpression node)
        {
            throw new NotSupportedException();
        }

        protected override Expression VisitNew(NewExpression node)
        {
            Append(node.Type.Name + "(");
            ArgsToString(node.Arguments);
            Append(")");

            return node;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            Append(node.Name);
            return node;
        }

        protected override Expression VisitRuntimeVariables(RuntimeVariablesExpression node)
        {
            throw new NotImplementedException();
        }

        protected override SwitchCase VisitSwitchCase(SwitchCase node)
        {
            throw new NotImplementedException("Switch tables are not supported yet.");
        }

        protected override Expression VisitSwitch(SwitchExpression node)
        {
            // TODO: implement switches
            throw new NotImplementedException("Switch tables are not supported yet.");
        }

        protected override CatchBlock VisitCatchBlock(CatchBlock node)
        {
            throw new NotSupportedException("GLSL does not support exceptions.");
        }

        protected override Expression VisitTry(TryExpression node)
        {
            throw new NotSupportedException("GLSL does not support exceptions.");
        }

        protected override Expression VisitTypeBinary(TypeBinaryExpression node)
        {
            throw new NotSupportedException("GLSL does not support any kind of reflection.");
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Negate:
                    Append("-");
                    Visit(node.Operand);
                    break;
                case ExpressionType.UnaryPlus:
                    Append("+");
                    Visit(node.Operand);
                    break;
                case ExpressionType.Not:
                    Append("!");
                    Visit(node.Operand);
                    break;
                case ExpressionType.OnesComplement:
                    Append("~");
                    Visit(node.Operand);
                    break;
                case ExpressionType.PreIncrementAssign:
                    Append("++");
                    Visit(node.Operand);
                    break;
                case ExpressionType.PostIncrementAssign:
                    Visit(node.Operand);
                    Append("++");
                    break;
                case ExpressionType.PreDecrementAssign:
                    Append("--");
                    Visit(node.Operand);
                    break;
                case ExpressionType.PostDecrementAssign:
                    Visit(node.Operand);
                    Append("--");
                    break;
                case ExpressionType.Convert:
                    Append(ToGlslType(node.Type) + "(");
                    Visit(node.Operand);
                    Append(")");
                    break;
                default:
                    throw new NotImplementedException();
            }

            //Append(node.Method);
            //Visit(node.Operand);

            return node;
        }

        protected override Expression VisitMemberInit(MemberInitExpression node)
        {
            throw new NotSupportedException();
        }

        protected override Expression VisitListInit(ListInitExpression node)
        {
            throw new NotSupportedException();
        }

        protected override ElementInit VisitElementInit(ElementInit node)
        {
            throw new NotSupportedException();
        }

        protected override MemberBinding VisitMemberBinding(MemberBinding node)
        {
            throw new NotSupportedException();
        }

        protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
        {
            throw new NotSupportedException();
        }

        protected override MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding node)
        {
            throw new NotSupportedException();
        }

        protected override MemberListBinding VisitMemberListBinding(MemberListBinding node)
        {
            throw new NotSupportedException();
        }
    }
}
