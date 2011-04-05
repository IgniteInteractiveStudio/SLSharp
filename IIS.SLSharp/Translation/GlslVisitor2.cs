using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
using IIS.SLSharp.Annotations;
using Mono.Cecil;
using Attribute = ICSharpCode.NRefactory.CSharp.Attribute;
using ConditionalExpression = ICSharpCode.NRefactory.CSharp.ConditionalExpression;
using Expression = ICSharpCode.NRefactory.CSharp.Expression;
using InvocationExpression = ICSharpCode.NRefactory.CSharp.InvocationExpression;
using LambdaExpression = ICSharpCode.NRefactory.CSharp.LambdaExpression;

namespace IIS.SLSharp.Translation
{
    internal sealed partial class GlslVisitor2 : IAstVisitor<int, int>
    {
        private readonly HashSet<string> _functions = new HashSet<string>();

        private readonly StringBuilder _s = new StringBuilder();

        private readonly IShaderAttribute _attr;

        public IEnumerable<string> Functions
        {
            get { return _functions; }
        }

        public string Result
        {
            get { return _s.ToString(); }
        }

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

        public static string ToGlslType(TypeReference t)
        {
            switch (t.FullName)
            {
                case "System.Single":
                    return "float";
                case "System.Double":
                    return "double";
                case "System.Void":
                    return "void";
                case "System.Int32":
                    return "int";
                case "System.UInt32":
                    return "uint";
                case "System.Boolean":
                    return "bool";
                default:
                    return t.Name;
            }
        }

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

        public static string GetMethodName(MethodDefinition m)
        {
            return Shader.GetMethodName(m);
        }

        public static string GetParameterString(MethodDefinition m)
        {
            var sig = string.Empty;

            var parameters = m.Parameters;
            if (parameters.Count > 0)
            {
                sig = parameters.Take(parameters.Count - 1).Aggregate(sig, (current, v) =>
                    current + ToGlslType(v.ParameterType) + " " + v.Name + ",");

                var l = parameters.Last();
                sig += ToGlslType(l.ParameterType) + " " + l.Name;
            }

            return sig;
        }

        private static string GetSignature(MethodDefinition m)
        {
            return ToGlslType(m.ReturnType) + " " +
                GetMethodName(m) + "(" +
                GetParameterString(m) + ")";
        }

        private void RegisterMethod(MethodDefinition m)
        {
            // generate signature
            var neededTyp = _attr.GetType();
            var attr = m.CustomAttributes.FirstOrDefault((a) => a.AttributeType.FullName == neededTyp.FullName);
            if (attr == null)
                throw new Exception("Called shader method has no " + neededTyp.Name + Environment.NewLine + GetSignature(m));

            if ((bool)attr.ConstructorArguments[0].Value)
                throw new Exception("Cannot call shader entry point.");

            _functions.Add(GetSignature(m));
        }

        private void ArgsToString(AstNodeCollection<Expression> args)
        {
            if (args.Count <= 0)
                return;

            foreach (var v in args.Take(args.Count - 1))
            {
                v.AcceptVisitor(this, 0);
                Append(",");
            }

            args.Last().AcceptVisitor(this, 0);
        }

        public GlslVisitor2(BlockStatement block, IShaderAttribute attr)
        {
            _attr = attr;
            block.AcceptVisitor(this, 0);
        }

        public int VisitBlockStatement(BlockStatement blockStatement, int data)
        {
            AppendLine(Environment.NewLine + "{");
            Indent++;

            foreach (var stm in blockStatement.Statements)
                stm.AcceptVisitor(this, data);

            Indent--;
            AppendLine("}");
            return 0;
        }

        public int VisitExpressionStatement(ExpressionStatement expressionStatement, int data)
        {
            expressionStatement.Expression.AcceptVisitor(this, data);
            Append(";");
            return 0;
        }

        public int VisitAssignmentExpression(AssignmentExpression assignmentExpression, int data)
        {
            assignmentExpression.Left.AcceptVisitor(this, data);
            Append(" = ");
            assignmentExpression.Right.AcceptVisitor(this, data);
            return 0;
        }

        public int VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, int data)
        {
            if (!(memberReferenceExpression.Target is ThisReferenceExpression))
            {
                memberReferenceExpression.Target.AcceptVisitor(this, 0);
                Append(".");
            }

            var anno = memberReferenceExpression.Annotation<FieldDefinition>();
            if (anno != null)
            {
                Append(Shader.ResolveName(anno));
                return 0;
            }

            var annop = memberReferenceExpression.Annotation<PropertyDefinition>();
            if (annop != null)
            {
                Append(Shader.ResolveName(annop));
                return 0;
            }

            throw new NotImplementedException();
        }

        public int VisitInvocationExpression(InvocationExpression invocationExpression, int data)
        {
            //Console.WriteLine(invocationExpression.Target);

            var anno = invocationExpression.Annotation<MethodDefinition>();
            RegisterMethod(anno);
            Append(GetMethodName(anno));
            //invocationExpression.Target.AcceptVisitor(this, 0);
            
            Append("(");
            ArgsToString(invocationExpression.Arguments);
            Append(")");
            return 0;
        }

        public int VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, int data)
        {
            objectCreateExpression.Type.AcceptVisitor(this, 0);
            Append("(");
            ArgsToString(objectCreateExpression.Arguments);
            Append(")");
            return 0;
        }

        public int VisitMemberType(MemberType memberType, int data)
        {
            Append(memberType.MemberName);
            return 0;
        }

        public int VisitPrimitiveExpression(PrimitiveExpression primitiveExpression, int data)
        {

            if (primitiveExpression.Value.GetType() == typeof(float))
            {
                var s = ((float)primitiveExpression.Value).ToString(CultureInfo.InvariantCulture.NumberFormat);
                if (!s.Contains("."))
                    s += ".0";

                Append(s);
            }
            else
                Append(primitiveExpression.Value.ToString());

            return 0;
        }
    }
}
