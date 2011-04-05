using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
using IIS.SLSharp.Annotations;
using Mono.Cecil;
using Attribute = ICSharpCode.NRefactory.CSharp.Attribute;
using ConditionalExpression = ICSharpCode.NRefactory.CSharp.ConditionalExpression;
using InvocationExpression = ICSharpCode.NRefactory.CSharp.InvocationExpression;
using LambdaExpression = ICSharpCode.NRefactory.CSharp.LambdaExpression;

namespace IIS.SLSharp.Translation
{
    internal sealed partial class GlslVisitor2: ICSharpCode.NRefactory.CSharp.IAstVisitor<int, int>
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
                case "float":
                    return "float";
                case "double":
                    return "double";
                case "void":
                    return "void";
                case "int":
                    return "int";
                case "uint":
                    return "uint";
                case "bool":
                    return "bool";
                default:
                    return t.Name;
            }
        }

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


            throw new NotImplementedException();
            //if (((IShaderAttribute)attr[0]).EntryPoint)
            //    throw new Exception("Cannot call shader entrypoint.");
            //_functions.Add(GetSignature(m));
        }


        public GlslVisitor2(BlockStatement block, IShaderAttribute attr)
        {
            block.AcceptVisitor(this, 0);
            _attr = attr;
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
            var anno = memberReferenceExpression.Annotation<FieldDefinition>();

            if (!(memberReferenceExpression.Target is ThisReferenceExpression))
            {
                memberReferenceExpression.Target.AcceptVisitor(this, 0);
                Append(".");
            }

            Append(Shader.ResolveName(anno));            
            return 0;
        }

        public int VisitInvocationExpression(InvocationExpression invocationExpression, int data)
        {

            // Annotations[0] <--
            var m = invocationExpression.Target;
            var args = invocationExpression.Arguments;

            Console.WriteLine(invocationExpression.Target);
            //RegisterMethod(invocationExpression.Target);
            //    Append(GetMethodName(m));
          

            throw new NotImplementedException();
        }
        
    }
}
