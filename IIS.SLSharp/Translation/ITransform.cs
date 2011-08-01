using System;
using System.Collections;
using System.Collections.Generic;
using IIS.SLSharp.Descriptions;
using IIS.SLSharp.Shaders;
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
        /// <param name="attr">The shader type as attribute (either FragmentShaderAttribute or VertexShaderAttribute</param>
        /// <param name="type">The shader type as ShaderType</param>
        /// <returns>The source for the translated function</returns>
        FunctionDescription Transform(TypeDefinition s, MethodDefinition m, CustomAttribute attr, ShaderType type);

        /// <summary>
        /// Generates a string that forward declarates all functions used within a shader.
        /// </summary>
        /// <param name="debugInfo">Include descriptive elements</param>
        /// <returns></returns>
        List<string> ForwardDeclare(bool debugInfo);

        /// <summary>
        /// Returns a list of possible workaround libraries
        /// TODO: this shall become obsolete when auto determining depdendencies
        /// </summary>
        IEnumerable<Shader> WorkaroundDependencies { get; }

        IEnumerable<Type> Dependencies { get; }
    }
}
