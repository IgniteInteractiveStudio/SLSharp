using System.Collections.Generic;
using IIS.SLSharp.Descriptions;
using Mono.Cecil;

namespace IIS.SLSharp.Translation
{
    public interface ITransform
    {
        /// <summary>
        /// Resets the internal state for reuse
        /// </summary>
        void ResetState();

        /// <summary>
        /// Translates a single shader method 
        /// </summary>
        /// <param name="s">The shader defining the method</param>
        /// <param name="m">The method to translate</param>
        /// <param name="attr">The shader type either (FragmentShaderAttribute or VertexShaderAttribute</param>
        /// <returns>The source for the translated function</returns>
        FunctionDescription Transform(TypeDefinition s, MethodDefinition m, CustomAttribute attr);

        /// <summary>
        /// Generates a string that forward declarates all functions used within a shader.
        /// </summary>
        /// <param name="debugInfo">Include descriptive elements</param>
        /// <returns></returns>
        List<string> ForwardDeclare(bool debugInfo);
    }
}
