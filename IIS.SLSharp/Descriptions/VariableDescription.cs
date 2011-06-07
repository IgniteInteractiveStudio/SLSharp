using System;
using System.Collections.Generic;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Descriptions
{
    public class VariableDescription
    {
        public readonly Type Type;
        public readonly string Name;
        public readonly UsageSemantic Semantic;
        public readonly string Comment;
        public int? DefaultRegister { get; set; }

        public VariableDescription(Type type, string name, UsageSemantic semantic = UsageSemantic.Unknown, string comment = "")
        {
            Type = type;
            Comment = comment;
            Semantic = semantic;
            Name = name;
        }

        public bool IsSampler()
        {
            return Type.BaseType == typeof(ShaderDefinition.Sampler);
        }
    }
}
