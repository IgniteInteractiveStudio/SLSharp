namespace IIS.SLSharp.Descriptions
{
    public class FunctionDescription
    {
        public readonly string Name;
        public readonly string Body;
        public readonly bool EntryPoint;

        public FunctionDescription(string name, string body, bool entryPoint)
        {
            Name = name;
            EntryPoint = entryPoint;
            Body = body;
        }
    }
}
