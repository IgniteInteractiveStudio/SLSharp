using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Bindings;
using IIS.SLSharp.Descriptions;
using Mono.Cecil;

namespace IIS.SLSharp.Shaders
{
    public abstract partial class Shader
    {
        /// <summary>
        /// This class collects and holds all Cecil related information about a shader
        /// <see cref="SourceDescription" /> is populated from this information.
        /// It basically is the same information plus one of the UnitContexts
        /// TODO: we can probably nicen things by sharing this
        /// </summary>
        private class ShaderContext
        {
            public struct UnitContext
            {
                public readonly List<FunctionDescription> Functions;
                public readonly List<string> ForwardDeclarations;
                public readonly List<Type> Dependencies; 

                public UnitContext(List<FunctionDescription> functions, List<string> forwardDeclarations,
                    List<Type> dependencies)
                {
                    Functions = functions;
                    ForwardDeclarations = forwardDeclarations;
                    Dependencies = dependencies;
                }
            }

            public List<VariableDescription> Uniforms { get; private set; }

            public List<VariableDescription> Varyings { get; private set; }

            public List<VariableDescription> Ins { get; private set; }

            public List<VariableDescription> Outs { get; private set; }

            public List<VariableDescription> Attribs { get; private set; }

            public UnitContext FragmentUnit { get; private set; }

            public UnitContext VertexUnit { get; private set; }

            private readonly TypeDefinition _shader;

            private readonly Type _shaderType;

            private TypeDefinition LoadReflection(Type t)
            {
                var resolver = new DefaultAssemblyResolver();
                resolver.AddSearchDirectory(Path.GetDirectoryName(t.Assembly.Location));
                resolver.AddSearchDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                /*
                resolver.ResolveFailure += (sender, args) =>
                {
                    Debug.WriteLine("Error with {0}", args.FullName);
                    return null;
                };*/
                var asm = AssemblyDefinition.ReadAssembly(t.Assembly.Location, new ReaderParameters { AssemblyResolver = resolver });

                var mod = asm.Modules.Single(x => x.MetadataToken.ToInt32() == t.Module.MetadataToken);
                return mod.Types.Single(x => x.MetadataToken.ToInt32() == t.MetadataToken);

            }

            /// <summary>
            /// Builds a string containing all uniform declarations.
            /// </summary>
            /// <returns>A string containing all uniform declarations.</returns>
            private List<VariableDescription> CollectUniforms()
            {
                return (from prop in _shader.Properties
                        let attrs = prop.CustomAttributes.Where(a => a.AttributeType.IsUniform())
                        where attrs.Count() != 0
                        let attr = attrs.First()
                        let type = TypeMap[prop.PropertyType.Resolve().MetadataToken.ToInt32()].Type
                        let name = GetUniformName(prop)
                        let comment = DebugMode ? " // " + prop.DeclaringType.FullName + "." + prop.Name : string.Empty
                        select new VariableDescription(type, name, UsageSemantic.Unknown, comment)).ToList();
            }

            /// <summary>
            /// Builds a string containing all varying declarations.
            /// </summary>
            /// <returns>A string containing all varying declarations.</returns>
            private List<VariableDescription> CollectVaryings()
            {
                return (from field in _shader.Fields
                        let attrs = field.CustomAttributes.Where(a => a.AttributeType.IsVarying())
                        where attrs.Count() != 0
                        let attr = attrs.First()
                        let type = TypeMap[field.FieldType.Resolve().MetadataToken.ToInt32()].Type
                        let name = GetVaryingName(field)
                        let comment = DebugMode ? " // " + field.DeclaringType.FullName + "." + field.Name : string.Empty
                        let semantic = attr.HasConstructorArguments ? (UsageSemantic)attr.ConstructorArguments[0].Value : UsageSemantic.Unknown
                        select new VariableDescription(type, name, semantic, comment)).ToList();
            }

            /// <summary>
            /// Builds a string containing all in declarations.
            /// </summary>
            /// <returns>A string containing all in declarations.</returns>
            private List<VariableDescription> CollectIns()
            {
                var s1 = (from field in _shader.Fields
                          let attrs = field.CustomAttributes.Where(a => a.AttributeType.IsVertexIn())
                          where attrs.Count() != 0
                          let attr = attrs.First()
                          let type = TypeMap[field.FieldType.Resolve().MetadataToken.ToInt32()].Type
                          let name = GetVaryingName(field)
                          let comment = DebugMode ? " // " + field.DeclaringType.FullName + "." + field.Name : string.Empty
                          let semantic = (UsageSemantic)attr.ConstructorArguments[0].Value
                          select new VariableDescription(type, name, semantic, comment));

                // TODO: what was this supposed to be good for?
                /*
                var s2 = (from prop in _shader.Properties
                          let attrs = prop.CustomAttributes.Where(a => a.AttributeType.IsVertexIn())
                          where attrs.Count() != 0
                          let attr = attrs.First()
                          let type = TypeMap[prop.PropertyType.Resolve().MetadataToken.ToInt32()].Type
                          let name = GetUniformName(prop)
                          let comment = DebugMode ? " // " + prop.DeclaringType.FullName + "." + prop.Name : string.Empty
                          let semantic = (UsageSemantic)attr.ConstructorArguments[0].Value
                          select new VariableDescription(type, name, semantic, comment)).ToList();

                return s1.Concat(s2).ToList();
                 */
                return s1.ToList();
            }

            /// <summary>
            /// Builds a string containing all out declarations.
            /// </summary>
            /// <returns>A string containing all out declarations.</returns>
            private List<VariableDescription> CollectOuts()
            {
                return (from field in _shader.Fields
                        let attrs = field.CustomAttributes.Where(a => a.AttributeType.IsFragmentOut())
                        where attrs.Count() != 0
                        let attr = attrs.First()
                        let type = TypeMap[field.FieldType.Resolve().MetadataToken.ToInt32()].Type
                        let name = GetVaryingName(field)
                        let comment = DebugMode ? " // " + field.DeclaringType.FullName + "." + field.Name : string.Empty
                        let semantic = (UsageSemantic)attr.ConstructorArguments[0].Value
                        select new VariableDescription(type, name, semantic, comment)).ToList();
            }

            /// <summary>
            /// Collects the sources of all functions within this shader
            /// </summary>
            /// <param name="type">The shadertype currently being collected for</param>
            /// <returns>A string containing the GLSL code for all collected functions</returns>
            private UnitContext CollectFuncs<T>(ShaderType type)
            {
                var desc = new List<FunctionDescription>();
                var hasEntry = false;

                var trans = Binding.Active.Transform;
                trans.ResetState();
                foreach (var m in _shader.Methods)
                {
                    var attr = m.CustomAttributes.Where(a => a.AttributeType.Is<T>()).FirstOrDefault();
                    if (attr == null)
                        continue;

                    if ((bool)attr.ConstructorArguments.FirstOrDefault().Value)
                    {
                        if (hasEntry)
                            throw new Exception("Shader cannot have two entry points.");

                        if (m.Parameters.Count() != 0)
                            throw new Exception("Entry point must not have parameters.");

                        hasEntry = true;
                    }


                    desc.Add(trans.Transform(_shader, m, attr, type));
                }

                var forwardDecl = trans.ForwardDeclare(DebugMode);
                var deps = trans.Dependencies.Except(new [] { _shaderType }).ToList();

                return new UnitContext(desc, forwardDecl, deps);
            }

            // shaderType = GetShaderType()
            public ShaderContext(Type shaderType)
            {
                _shader = LoadReflection(shaderType);
                _shaderType = shaderType;

                Varyings = CollectVaryings();
                Uniforms = CollectUniforms();
                Ins = CollectIns();
                Outs = CollectOuts();
                Attribs = new List<VariableDescription>();

                FragmentUnit = CollectFuncs<FragmentShaderAttribute>(ShaderType.FragmentShader);
                VertexUnit = CollectFuncs<VertexShaderAttribute>(ShaderType.VertexShader);

                _shader = null;
            }
        }
    }
}
