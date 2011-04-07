using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.NRefactory.CSharp;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Shaders;
using Mono.Cecil;

namespace IIS.SLSharp.Translation
{
    internal sealed partial class GlslVisitor2 : IAstVisitor<int, StringBuilder>
    {
        private readonly HashSet<string> _functions = new HashSet<string>();


        private readonly IShaderAttribute _attr;

        public IEnumerable<string> Functions
        {
            get { return _functions; }
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

        public string Result { get; private set; }

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
                Shader.GetMethodName(m) + "(" +
                GetParameterString(m) + ")";
        }

        private void RegisterMethod(MethodDefinition m)
        {
            // generate signature
            var neededTyp = _attr.GetType();
            var attr = m.CustomAttributes.FirstOrDefault(a => a.AttributeType.FullName == neededTyp.FullName);

            if (attr == null)
                throw new Exception("Called shader method has no " + neededTyp.Name + Environment.NewLine + GetSignature(m));

            if ((bool)attr.ConstructorArguments[0].Value)
                throw new Exception("Cannot call shader entry point.");

            _functions.Add(GetSignature(m));
        }

        private StringBuilder ArgsToString(ICollection<Expression> args)
        {
            var result = new StringBuilder();
            if (args.Count <= 0)
                return result;

            foreach (var v in args.Take(args.Count - 1))
            {
                result.Append(v.AcceptVisitor(this, 0));
                result.Append(",");
            }

            result.Append(args.Last().AcceptVisitor(this, 0));
            return result;
        }

        private static StringBuilder Indent(StringBuilder b)
        {
            var res = new StringBuilder();
            res.Append("\t");
            res.Append(b.Replace(Environment.NewLine, "\t" + Environment.NewLine));
            return res;
        }

        public GlslVisitor2(BlockStatement block, IShaderAttribute attr)
        {
            _attr = attr;

            var trans1 = (IAstTransform)new ReplaceMethodCallsWithOperators();
            var trans2 = new RenameLocals();
            trans1.Run(block);
            trans2.Run(block);

            Result = block.AcceptVisitor(this, 0).ToString();
        }

        public StringBuilder VisitBlockStatement(BlockStatement blockStatement, int data)
        {
            var result = new StringBuilder();
            result.Append(Environment.NewLine).Append("{");
            foreach (var stm in blockStatement.Statements)
                result.Append(Environment.NewLine).Append(Indent(stm.AcceptVisitor(this, data)));
            result.Append(Environment.NewLine).Append("}");
            return result;
        }

        public StringBuilder VisitExpressionStatement(ExpressionStatement expressionStatement, int data)
        {
            return expressionStatement.Expression.AcceptVisitor(this, data).Append(";");
        }

        public StringBuilder VisitAssignmentExpression(AssignmentExpression assignmentExpression, int data)
        {
            var result = assignmentExpression.Left.AcceptVisitor(this, data);
            switch (assignmentExpression.Operator)
            {
                case AssignmentOperatorType.Assign: result.Append(" = "); break;
                case AssignmentOperatorType.Add: result.Append(" += "); break;
                case AssignmentOperatorType.BitwiseAnd: result.Append(" &= "); break;
                case AssignmentOperatorType.BitwiseOr: result.Append(" |= "); break;
                case AssignmentOperatorType.Divide: result.Append(" /= "); break;
                case AssignmentOperatorType.ExclusiveOr: result.Append(" ^= "); break;
                case AssignmentOperatorType.Modulus: result.Append(" %= "); break;
                case AssignmentOperatorType.Multiply: result.Append(" *= "); break;
                case AssignmentOperatorType.ShiftLeft: result.Append(" <<= "); break;
                case AssignmentOperatorType.ShiftRight: result.Append(" >>= "); break;
                case AssignmentOperatorType.Subtract: result.Append(" -= "); break;
                default:
                    throw new NotImplementedException();
            }
            
            result.Append(assignmentExpression.Right.AcceptVisitor(this, data));
            return result;
        }

        public StringBuilder VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, int data)
        {
            var result = new StringBuilder();
            if (!(memberReferenceExpression.Target is ThisReferenceExpression))
                result.Append(memberReferenceExpression.Target.AcceptVisitor(this, 0)).Append(".");

            // Annotation could be FieldReference which aint compatible to IMemberDefinition
           
            //if (fref != null)
            //    result.Append(Shader.ResolveName(fref));
            
            //Shader.ResolveName(mref);
            var def = memberReferenceExpression.Annotation<IMemberDefinition>();
            if (def != null)
                return result.Append(Shader.ResolveName(def));

            var fref = memberReferenceExpression.Annotation<FieldReference>();
            if (fref != null)
                return result.Append(Shader.ResolveName((IMemberDefinition)fref.Resolve()));
            
            throw new NotImplementedException();
        }

        public StringBuilder VisitInvocationExpression(InvocationExpression invocationExpression, int data)
        {
            //Console.WriteLine(invocationExpression.Target);

            var result = new StringBuilder();
            var mref = invocationExpression.Annotation<MethodReference>();
            var m = mref != null ? mref.Resolve() : invocationExpression.Annotation<MethodDefinition>();


            if (m.DeclaringType.MetadataToken.ToInt32() == typeof(ShaderDefinition).MetadataToken)
            {
                return result.Append(m.Name).Append("(").Append(ArgsToString(invocationExpression.Arguments)).Append(")");
            }

            if (m != null)
            {
                RegisterMethod(m);
                result.Append(Shader.GetMethodName(m));
                return result.Append("(").Append(ArgsToString(invocationExpression.Arguments)).Append(")");
            }
            throw new NotImplementedException();
        }

        public StringBuilder VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, int data)
        {
            return
                objectCreateExpression.Type.AcceptVisitor(this, 0).Append("(").Append(
                    ArgsToString(objectCreateExpression.Arguments)).Append(")");
        }

        public StringBuilder VisitMemberType(MemberType memberType, int data)
        {
                return new StringBuilder(memberType.MemberName);
        }

        public StringBuilder VisitPrimitiveExpression(PrimitiveExpression primitiveExpression, int data)
        {
            var result = new StringBuilder();
            if (primitiveExpression.Value.GetType() == typeof(float))
            {
                var s = ((float)primitiveExpression.Value).ToString(CultureInfo.InvariantCulture.NumberFormat);
                result.Append(s);
                if (!s.Contains("."))
                   result.Append(".0");

                return result;
            }
            
            return result.Append(primitiveExpression.Value.ToString());
        }

        public StringBuilder VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, int data)
        {
            var result = binaryOperatorExpression.Left.AcceptVisitor(this, 0);
            switch (binaryOperatorExpression.Operator)
            {
                case BinaryOperatorType.Multiply: result.Append(" * "); break;
                case BinaryOperatorType.Divide: result.Append(" / "); break;
                case BinaryOperatorType.Add: result.Append(" + "); break;
                case BinaryOperatorType.Subtract: result.Append(" - "); break;
                case BinaryOperatorType.Modulus: result.Append(" % "); break;
                case BinaryOperatorType.BitwiseOr: result.Append(" | "); break;
                case BinaryOperatorType.BitwiseAnd: result.Append(" & "); break;
                case BinaryOperatorType.ExclusiveOr: result.Append(" ^ "); break;
                case BinaryOperatorType.ShiftLeft: result.Append(" << "); break;
                case BinaryOperatorType.ShiftRight: result.Append(" >> "); break;
                case BinaryOperatorType.LessThan: result.Append(" < "); break;
                case BinaryOperatorType.GreaterThan: result.Append(" > "); break;
                case BinaryOperatorType.LessThanOrEqual: result.Append(" <= "); break;
                case BinaryOperatorType.GreaterThanOrEqual: result.Append(" >= "); break;
                case BinaryOperatorType.Equality: result.Append(" == "); break;
                case BinaryOperatorType.InEquality: result.Append(" != "); break;
                default:
                    throw new NotImplementedException();
            }
            return result.Append(binaryOperatorExpression.Right.AcceptVisitor(this, 0));
        }

        public StringBuilder VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression, int data)
        {
            var result = new StringBuilder();
            var exp = unaryOperatorExpression.Expression.AcceptVisitor(this, 0);
            switch (unaryOperatorExpression.Operator)
            {
                case UnaryOperatorType.Decrement: return result.Append("--").Append(exp);
                case UnaryOperatorType.Increment: return result.Append("++").Append(exp);
                case UnaryOperatorType.Minus: return result.Append("-").Append(exp);
                case UnaryOperatorType.Plus: return result.Append("+").Append(exp);
                case UnaryOperatorType.BitNot: return result.Append("~").Append(exp);
                case UnaryOperatorType.Not: return result.Append("!").Append(exp);
                case UnaryOperatorType.PostDecrement: return result.Append(exp).Append("--");
                case UnaryOperatorType.PostIncrement: return result.Append(exp).Append("++");
            }
            throw new NotImplementedException();
        }

        public StringBuilder VisitReturnStatement(ReturnStatement returnStatement, int data)
        {
            var result = new StringBuilder();
            result.Append("return");
            var exp = returnStatement.Expression.AcceptVisitor(this, 0);
            if (exp.Length > 0)
                result.Append(" ").Append(exp);
            result.Append(";");
            return result;
        }

        public StringBuilder VisitIdentifierExpression(IdentifierExpression identifierExpression, int data)
        {
            return new StringBuilder(identifierExpression.Identifier);
        }

        public StringBuilder VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, int data)
        {
            var result = new StringBuilder();
            var typ = variableDeclarationStatement.Type.AcceptVisitor(this, 0);
            foreach (var v in variableDeclarationStatement.Variables)
                result.Append(typ).Append(" ").Append(v.AcceptVisitor(this, 0)).Append(";");

            return result;
        }

        public StringBuilder VisitVariableInitializer(VariableInitializer variableInitializer, int data)
        {
            var result = new StringBuilder(variableInitializer.Name);
            if (!variableInitializer.Initializer.IsNull)
                result.Append(" = ").Append(variableInitializer.Initializer.AcceptVisitor(this, 0));
            return result;
        }

        public StringBuilder VisitPrimitiveType(PrimitiveType primitiveType, int data)
        {
            return new StringBuilder(primitiveType.Keyword);
        }

        public StringBuilder VisitWhileStatement(WhileStatement whileStatement, int data)
        {
            var result = new StringBuilder("while (").Append(whileStatement.Condition.AcceptVisitor(this, 0)).Append(")");
            result.Append(Environment.NewLine + "{");
            result.Append(Indent(whileStatement.EmbeddedStatement.AcceptVisitor(this, 0)));
            result.Append(Environment.NewLine + "}");
            return result;
        }
    }
}
