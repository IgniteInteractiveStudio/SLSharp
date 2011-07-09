using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using Attribute = System.Attribute;

namespace IIS.SLSharp.Translation
{
    internal abstract partial class VisitorBase
    {
        public abstract StringBuilder VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression, int data);
        public abstract StringBuilder VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression, int data);
        public abstract StringBuilder VisitAssignmentExpression(AssignmentExpression assignmentExpression, int data);
        public abstract StringBuilder VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression, int data);
        public abstract StringBuilder VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, int data);
        public abstract StringBuilder VisitCastExpression(CastExpression castExpression, int data);
        public abstract StringBuilder VisitConditionalExpression(ConditionalExpression conditionalExpression, int data);
        public abstract StringBuilder VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression, int data);
        public abstract StringBuilder VisitDirectionExpression(DirectionExpression directionExpression, int data);
        public abstract StringBuilder VisitIdentifierExpression(IdentifierExpression identifierExpression, int data);
        public abstract StringBuilder VisitIndexerExpression(IndexerExpression indexerExpression, int data);
        public abstract StringBuilder VisitInvocationExpression(InvocationExpression invocationExpression, int data);
        public abstract StringBuilder VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, int data);
        public abstract StringBuilder VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, int data);
        public abstract StringBuilder VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression, int data);
        public abstract StringBuilder VisitPrimitiveExpression(PrimitiveExpression primitiveExpression, int data);
        public abstract StringBuilder VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression, int data);
        public abstract StringBuilder VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression, int data);
        public abstract StringBuilder VisitUncheckedExpression(UncheckedExpression uncheckedExpression, int data);
        public abstract StringBuilder VisitEmptyExpression(EmptyExpression emptyExpression, int data);
        public abstract StringBuilder VisitBlockStatement(BlockStatement blockStatement, int data);
        public abstract StringBuilder VisitBreakStatement(BreakStatement breakStatement, int data);
        public abstract StringBuilder VisitContinueStatement(ContinueStatement continueStatement, int data);
        public abstract StringBuilder VisitDoWhileStatement(DoWhileStatement doWhileStatement, int data);
        public abstract StringBuilder VisitEmptyStatement(EmptyStatement emptyStatement, int data);
        public abstract StringBuilder VisitExpressionStatement(ExpressionStatement expressionStatement, int data);
        public abstract StringBuilder VisitForeachStatement(ForeachStatement foreachStatement, int data);
        public abstract StringBuilder VisitForStatement(ForStatement forStatement, int data);
        public abstract StringBuilder VisitIfElseStatement(IfElseStatement ifElseStatement, int data);
        public abstract StringBuilder VisitReturnStatement(ReturnStatement returnStatement, int data);
        public abstract StringBuilder VisitSwitchStatement(SwitchStatement switchStatement, int data);
        public abstract StringBuilder VisitSwitchSection(SwitchSection switchSection, int data);
        public abstract StringBuilder VisitCaseLabel(CaseLabel caseLabel, int data);
        public abstract StringBuilder VisitUncheckedStatement(UncheckedStatement uncheckedStatement, int data);
        public abstract StringBuilder VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, int data);
        public abstract StringBuilder VisitWhileStatement(WhileStatement whileStatement, int data);
        public abstract StringBuilder VisitVariableInitializer(VariableInitializer variableInitializer, int data);
        public abstract StringBuilder VisitSimpleType(SimpleType simpleType, int data);
        public abstract StringBuilder VisitMemberType(MemberType memberType, int data);
        public abstract StringBuilder VisitComposedType(ComposedType composedType, int data);
        public abstract StringBuilder VisitArraySpecifier(ArraySpecifier arraySpecifier, int data);
        public abstract StringBuilder VisitPrimitiveType(PrimitiveType primitiveType, int data);
        public abstract StringBuilder VisitCSharpTokenNode(CSharpTokenNode cSharpTokenNode, int data);
        public abstract StringBuilder VisitIdentifier(Identifier identifier, int data);
    }
}
