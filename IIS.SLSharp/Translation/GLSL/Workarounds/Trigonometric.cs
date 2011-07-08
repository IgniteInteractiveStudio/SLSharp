using IIS.SLSharp.Annotations;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Translation.GLSL.Workarounds
{
    public class Trigonometric: Shader
    {
        [FragmentShader]
        [VertexShader]
        internal new void SinCos(float angle, out float s, out float c)
        {
            s = Sin(angle);
            c = Cos(angle);
        }

        [FragmentShader]
        [VertexShader]
        internal new void SinCos(vec2 angle, out vec2 s, out vec2 c)
        {
            s = Sin(angle);
            c = Cos(angle);
        }

        [FragmentShader]
        [VertexShader]
        internal new void SinCos(vec3 angle, out vec3 s, out vec3 c)
        {
            s = Sin(angle);
            c = Cos(angle);
        }

        [FragmentShader]
        [VertexShader]
        internal new void SinCos(vec4 angle, out vec4 s, out vec4 c)
        {
            s = Sin(angle);
            c = Cos(angle);
        }
    }
}
