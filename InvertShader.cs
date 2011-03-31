using System.Reflection;
using GeoClip.Shaders.Annotations;

namespace GeoClip.Shaders.Examples.Shaders
{
    public abstract class InvertShader : Shader
    {        
        [Obfuscation(Exclude = true)]
        [Uniform]
        public abstract vec4 Channels { get; set; }

        [VertexShader]
        [FragmentShader]
        // this library function is callable from both fragment and vertex shaders
        // if inverts the colors which are set to 1.0 in the Channels uniform
        // and leaves the colors which are set to 0.0 in the Channels uniform
        public vec4 Invert(vec4 v)
        {
            return Channels - Channels * v + (new vec4(1.0f) - Channels) * v;
        }
    }
}
