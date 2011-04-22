namespace IIS.SLSharp.Descriptions
{
    public class FunctionDescription
    {
        public readonly string Name;
        public readonly string Body;

        public FunctionDescription(string name, string body)
        {
            Name = name;
            Body = body;
        }
    }
}
