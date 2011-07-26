using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Examples.Tests
{
    public interface ITestRuntime
    {
        void Initialize();
        void Cleanup();
        Vector4 ProcessFragment();

        ShaderDefinition.vec2 Convert(Vector2 v);
        ShaderDefinition.vec3 Convert(Vector3 v);
        ShaderDefinition.vec4 Convert(Vector4 v);
    }
}
