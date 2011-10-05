using System;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace IIS.SLSharp.Translation.HLSL
{
    internal sealed partial class HlslVisitor
    {
        public override StringBuilder VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression, int data)
        {
            throw new NotImplementedException();
        }

        public override StringBuilder VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression, int data)
        {
            throw new NotImplementedException();
        }

        public override StringBuilder VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression, int data)
        {
            return null;
        }

        public override StringBuilder VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression, int data)
        {
            throw new NotImplementedException();
        }

        public override StringBuilder VisitIndexerExpression(IndexerExpression indexerExpression, int data)
        {
            throw new NotImplementedException();
        }

        public override StringBuilder VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression, int data)
        {
            throw new NotImplementedException();
        }

        public override StringBuilder VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression, int data)
        {
            return null;
        }

        public override StringBuilder VisitUncheckedExpression(UncheckedExpression uncheckedExpression, int data)
        {
            return new StringBuilder();
        }

        public override StringBuilder VisitEmptyExpression(EmptyExpression emptyExpression, int data)
        {
            throw new NotImplementedException();
        }

        public override StringBuilder VisitEmptyStatement(EmptyStatement emptyStatement, int data)
        {
            return new StringBuilder();
        }

        public override StringBuilder VisitForeachStatement(ForeachStatement foreachStatement, int data)
        {
            throw new NotImplementedException();
        }

        public override StringBuilder VisitUncheckedStatement(UncheckedStatement uncheckedStatement, int data)
        {
            return new StringBuilder();
        }

        public override StringBuilder VisitComposedType(ComposedType composedType, int data)
        {
            throw new NotImplementedException();
        }

        public override StringBuilder VisitArraySpecifier(ArraySpecifier arraySpecifier, int data)
        {
            throw new NotImplementedException();
        }

        public override StringBuilder VisitCSharpTokenNode(CSharpTokenNode cSharpTokenNode, int data)
        {
            throw new NotImplementedException();
        }

        public override StringBuilder VisitIdentifier(Identifier identifier, int data)
        {
            throw new NotImplementedException();
        }
    }
}
