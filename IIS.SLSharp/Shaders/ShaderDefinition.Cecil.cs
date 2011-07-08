using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Mono.Cecil;

namespace IIS.SLSharp.Shaders
{
    partial class ShaderDefinition
    {
        private static readonly Dictionary<int, TypeDefinition> _types = new Dictionary<int, TypeDefinition>();

        private static readonly Dictionary<int, MethodDefinition> _methods = new Dictionary<int, MethodDefinition>();

        static ShaderDefinition()
        {
            InitCecil();
        }

        private static void InitCecil()
        {
            var typ = typeof(ShaderDefinition);
            var asm = AssemblyDefinition.ReadAssembly(typ.Assembly.Location);
            var mod = asm.Modules.Single(x => x.MetadataToken.ToInt32() == typ.Module.MetadataToken);
            foreach (var t in mod.Types)
                InitCecilType(t);
        }

        private static void InitCecilType(TypeDefinition typeDef)
        {
            _types.Add(typeDef.MetadataToken.ToInt32(), typeDef);

            foreach (var nested in typeDef.NestedTypes)
                InitCecilType(nested);
            foreach (var method in typeDef.Methods)
                _methods.Add(method.MetadataToken.ToInt32(), method);
        }

        internal static TypeDefinition ToCecil(Type t)
        {
            return _types[t.MetadataToken];
        }

        internal static MethodDefinition ToCecil(MethodInfo method)
        {
            return _methods[method.MetadataToken];
        }
    }
}
