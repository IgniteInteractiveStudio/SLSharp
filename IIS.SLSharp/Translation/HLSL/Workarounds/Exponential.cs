using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Translation.HLSL.Workarounds
{
    public class Exponential: Shader
    {
        #region genType Exp10(genType x)

        [FragmentShader]
        [VertexShader]
        internal new float Exp10(float x)
        {
            return Pow(10.0f, x);
        }

        [FragmentShader]
        [VertexShader]
        internal new vec2 Exp10(vec2 x)
        {
            return Pow(new vec2(10.0f), x);
        }

        [FragmentShader]
        [VertexShader]
        internal new vec3 Exp10(vec3 x)
        {
            return Pow(new vec3(10.0f), x);
        }

        [FragmentShader]
        [VertexShader]
        internal new vec4 Exp10(vec4 x)
        {
            return Pow(new vec4(10.0f), x);
        }

        #endregion
    }
}
