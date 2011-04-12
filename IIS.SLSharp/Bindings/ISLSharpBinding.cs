using System.Collections.Generic;
using System.Reflection;
using IIS.SLSharp.Reflection;

namespace IIS.SLSharp.Bindings
{
    public interface ISLSharpBinding
    {
        Dictionary<ReflectionToken, MethodInfo> PassiveMethods { get; }

        void TexActivate(int textureUnit, object tex);
        void TexFinish(int textureUnit, object tex);

        object Compile(ShaderType typ, string source);
        IProgram Link(IEnumerable<object> units);
    }
}