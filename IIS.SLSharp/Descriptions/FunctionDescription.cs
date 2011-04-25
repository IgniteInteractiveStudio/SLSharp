namespace IIS.SLSharp.Descriptions
{
    public class FunctionDescription
    {
        public readonly string Name;
        public readonly string Body;
        public readonly bool EntryPoint;
        public readonly ShaderType Type;

        public FunctionDescription(string name, string body, bool entryPoint, ShaderType type)
        {
            Name = name;
            EntryPoint = entryPoint;
            Body = body;
            Type = type;
        }
    }
}
