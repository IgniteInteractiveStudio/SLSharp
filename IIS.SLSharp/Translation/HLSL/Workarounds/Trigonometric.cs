using IIS.SLSharp.Annotations;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Translation.HLSL.Workarounds
{
    public class Trigonometric: Shader
    {
        #region genType Asinh(genType x)

        [FragmentShader]
        [VertexShader]
        [Warning("HLSL does not support a native Asinh, emulating with precision loss.")]
        protected new float Asinh(float x)
        {
            return log(x + sqrt(1 + x * x));
        }

        [FragmentShader]
        [VertexShader]
        [Warning("HLSL does not support a native Asinh, emulating with precision loss.")]
        protected new vec2 Asinh(vec2 x)
        {
            return log(x + sqrt(new vec2(1.0f) + x * x));
        }

        [FragmentShader]
        [VertexShader]
        [Warning("HLSL does not support a native Asinh, emulating with precision loss.")]
        protected new vec3 Asinh(vec3 x)
        {
            return log(x + sqrt(new vec3(1.0f) + x * x));
        }

        [FragmentShader]
        [VertexShader]
        [Warning("HLSL does not support a native Asinh, emulating with precision loss.")]
        protected new vec4 Asinh(vec4 x)
        {
            return log(x + sqrt(new vec4(1.0f) + x * x));
        }

        #endregion

        #region genType Acosh(genType x)

        [FragmentShader]
        [VertexShader]
        [Warning("HLSL does not support a native Acosh, emulating with precision loss.")]
        protected new float Acosh(float x)
        {
            return log(x + sqrt(x + 1.0f) * sqrt(x - 1.0f));
        }

        [FragmentShader]
        [VertexShader]
        [Warning("HLSL does not support a native Acosh, emulating with precision loss.")]
        protected new vec2 Acosh(vec2 x)
        {
            return log(x + sqrt(x + new vec2(1.0f)) * sqrt(x - new vec2(1.0f)));
        }

        [FragmentShader]
        [VertexShader]
        [Warning("HLSL does not support a native Acosh, emulating with precision loss.")]
        protected new vec3 Acosh(vec3 x)
        {
            return log(x + sqrt(x + new vec3(1.0f)) * sqrt(x - new vec3(1.0f)));
        }

        [FragmentShader]
        [VertexShader]
        [Warning("HLSL does not support a native Acosh, emulating with precision loss.")]
        protected new vec4 Acosh(vec4 x)
        {
            return log(x + sqrt(x + new vec4(1.0f)) * sqrt(x - new vec4(1.0f)));
        }

        #endregion

        #region genType Atanh(genType x)

        [FragmentShader]
        [VertexShader]
        [Warning("HLSL does not support a native Atanh, emulating with precision loss.")]
        protected new float Atanh(float x)
        {
            return log((1.0f + x) / (1.0f - x)) * 0.5f;
            //return (log(1.0f + x) - log(1.0f - x)) * 0.5f;
        }

        [FragmentShader]
        [VertexShader]
        [Warning("HLSL does not support a native Atanh, emulating with precision loss.")]
        protected new vec2 Atanh(vec2 x)
        {
            return log((new vec2(1.0f) + x) / (new vec2(1.0f) - x)) * 0.5f;
            //return (log(new vec2(1.0f) + x) - log(new vec2(1.0f) - x)) * 0.5f;
        }

        [FragmentShader]
        [VertexShader]
        [Warning("HLSL does not support a native Atanh, emulating with precision loss.")]
        protected new vec3 Atanh(vec3 x)
        {
            return log((new vec3(1.0f) + x) / (new vec3(1.0f) - x)) * 0.5f;
            //return (log(new vec3(1.0f) + x) - log(new vec3(1.0f) - x)) * 0.5f;
        }

        [FragmentShader]
        [VertexShader]
        [Warning("HLSL does not support a native Atanh, emulating with precision loss.")]
        protected new vec4 Atanh(vec4 x)
        {
            return log((new vec4(1.0f) + x) / (new vec4(1.0f) - x)) * 0.5f;
            //return (log(new vec4(1.0f) + x) - log(new vec4(1.0f) - x)) * 0.5f;
        }

        #endregion
    }
}
