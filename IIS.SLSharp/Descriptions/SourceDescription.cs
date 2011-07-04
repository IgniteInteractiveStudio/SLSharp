using System;
using System.Collections.Generic;
using System.Linq;

namespace IIS.SLSharp.Descriptions
{
    // TODO: we might want to use IEnumerable<FunctionDescription> rather than lists
    // everywhere to improve performance
    public class SourceDescription
    {
        public List<FunctionDescription> Functions { get; private set; }

        public List<VariableDescription> Uniforms { get; private set; }

        public List<VariableDescription> Attributes { get; private set; }

        public List<VariableDescription> Varyings { get; private set; }

        public List<VariableDescription> VertexIns { get; private set; }

        public List<VariableDescription> FragmentOuts { get; private set; }

        public List<string> ForwardDecl { get; private set; }

        public static SourceDescription Empty
        {
            get
            {
                return new SourceDescription(
                    new List<FunctionDescription>(), new List<VariableDescription>(),
                    new List<VariableDescription>(), new List<VariableDescription>(),
                    new List<VariableDescription>(), new List<VariableDescription>(),
                    new List<string>());
            }
        }

        public SourceDescription(List<FunctionDescription> functions, 
            List<VariableDescription> uniforms, List<VariableDescription> attributes, 
            List<VariableDescription> varyings, List<VariableDescription> vertexIns, 
            List<VariableDescription> fragmentOuts, List<string> forwardDecl)
        {
            Functions = functions;
            ForwardDecl = forwardDecl;
            FragmentOuts = fragmentOuts;
            VertexIns = vertexIns;
            Varyings = varyings;
            Attributes = attributes;
            Uniforms = uniforms;
        }

        private class Comparer<T>: IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> _predicate;
            
            public Comparer(Func<T, T, bool> predicate)
            {
                _predicate = predicate;
            }

            public bool Equals(T x, T y)
            {
                return _predicate(x, y);
            }

            public int GetHashCode(T obj)
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Merges two sourcedescriptions to a single description
        /// This is required for HLSL for example as it allows only
        /// compiling + linking one file
        /// </summary>
        public SourceDescription Merge(SourceDescription other)
        {
            //var funs = Functions.Union(other.Functions, Compare<FunctionDescription>((a, b) => a.Name == b.Name)).ToList();
            //Functions.Except(other.Functions, )

            var funcComparer = new Comparer<FunctionDescription>(
                (a, b) =>
                    {
                        if (a.Name != b.Name)
                            return false;
                        if (a.Body != b.Body)
                            throw new SLSharpException(a.Name + " has been redeclared with different body");
                        return true;
                    });
            var variableComparer = new Comparer<VariableDescription>(
                (a, b) =>
                {
                    if (a != b)
                        return false;
                    if (a.Type != b.Type)
                        throw new SLSharpException("Type mismatch during variable merge");
                    if (a.Semantic != b.Semantic)
                        throw new SLSharpException("Semantic mismatch during variable merge");
                    return true;
                });
            
            
            // duplicate def actually occurs when a func has been defined as
            // vertex as well as fragment code
            //
            //var doubles = Functions.Except(other.Functions, funcComparer);
            //if (doubles.Count() != 0)
            //    throw new SLSharpException("Method declared twice: " + doubles.First().Name);
            //var funcs = Functions.Concat(other.Functions).ToList();

            var funcs = Functions.Union(other.Functions, funcComparer).ToList();

            // union global vars
            var uniforms = Uniforms.Union(other.Uniforms, variableComparer).ToList();
            var varyings = Varyings.Union(other.Varyings, variableComparer).ToList();
            var attribs = Attributes.Union(other.Attributes, variableComparer).ToList();
            var ins = VertexIns.Union(other.VertexIns, variableComparer).ToList();
            var outs = FragmentOuts.Union(other.FragmentOuts, variableComparer).ToList();
            
            // union forward declartations
            var fdecl = ForwardDecl.Union(other.ForwardDecl).ToList();

            return new SourceDescription(funcs, uniforms, attribs, varyings, ins, outs, fdecl);
        }
    }
}
