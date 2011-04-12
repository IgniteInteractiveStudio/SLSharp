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
        void TexReset();

        object Compile(ShaderType typ, string source);
        IProgram Link(IEnumerable<object> units);

        /// <summary>
        /// Called back as resources are needed.
        /// This happens when the first shader gets created
        /// </summary>
        void Initialize();

        /// <summary>
        /// Signals that resources are not needed anymore
        /// This happens when the last shader got disposed
        /// Note: another Initialize() may follow at any time after Cleanup call
        /// </summary>
        void Cleanup();

        void FullscreenQuad(int vertexLocation, bool positive);
    }
}