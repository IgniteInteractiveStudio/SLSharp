using System;
using IIS.SLSharp.Annotations;

namespace IIS.SLSharp.Descriptions
{
    public class VariableDescription
    {
        public readonly Type Type;
        public readonly string Name;
        public readonly UsageSemantic Semantic;
        public readonly string Comment;

        public VariableDescription(Type type, string name, UsageSemantic semantic = UsageSemantic.Unknown, string comment = "")
        {
            Type = type;
            Comment = comment;
            Semantic = semantic;
            Name = name;
        }
    }
}
