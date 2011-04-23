using System;

namespace IIS.SLSharp.Descriptions
{
    public enum VariableSemantic
    {
        Unspecified
    }

    public class VariableDescription
    {
        public readonly Type Type;
        public readonly string Name;
        public readonly VariableSemantic Semantic;
        public readonly string Comment;

        public VariableDescription(Type type, string name, VariableSemantic semantic = VariableSemantic.Unspecified, string comment = "")
        {
            Type = type;
            Comment = comment;
            Semantic = semantic;
            Name = name;
        }
    }
}
