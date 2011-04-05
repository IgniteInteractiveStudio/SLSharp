using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Core.Reflection;

namespace IIS.SLSharp.Translation
{
    public sealed class GlslTransform
    {
        private readonly HashSet<string> _functions = new HashSet<string>();

        public IEnumerable<string> Functions
        {
            get { return _functions; }
        }

        /// <summary>
        /// Debugging function that reflects a type, searching for methods with DebugTranslatorAttribute.
        /// Translates every found method.
        /// This is an internal func used to debug the translator.
        /// </summary>
        /// <param name="typ"></param>
        private void ProcessType(IReflect typ)
        {
            var transforms = from m in typ.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                             let attrs = m.GetCustomAttributes(typeof(DebugTranslatorAttribute), false)
                             where attrs.Length != 0
                             let allAttr = m.GetCustomAttributes(false)
                             let styp = allAttr.First(f => typeof(IShaderAttribute).IsAssignableFrom(f.GetType())) as IShaderAttribute
                             select Transform(m, styp);

            foreach (var s in transforms)
                Console.WriteLine("=== DEBUG ===\n{0}\n=============\n", s);
        }

        /// <summary>
        /// Debugging function.
        /// Invocation will collect and transform all methods flagged with DebugTranslatorAttribute
        /// </summary>
        public static void Test()
        {
            var t = new GlslTransform();
            foreach (var typ in AppDomain.CurrentDomain.GetAssemblies().SelectMany(asm => asm.GetModules().SelectMany(mod => mod.GetTypes())))
                t.ProcessType(typ);
        }

        /// <summary>
        /// Public translation interface.
        /// Translates the given method to GLSL
        /// </summary>
        /// <param name="m">A method representing a shader to translate.</param>
        /// <param name="attr">The shader type pass either (FragmentShaderAttribute or VertexShaderAttribute) </param>
        /// <returns>The translated GLSL shader source</returns>
        public string Transform(MethodInfo m, IShaderAttribute attr)
        {
            var d = Decompiler.DecompileMethod(m);
            var glsl = new GlslVisitor2(d, attr);

            _functions.UnionWith(glsl.Functions);

            var sig = attr.EntryPoint ? "void main()" : GlslVisitor.GetSignature(m);
            var code = glsl.Result;
            return sig + code;
        }
    }
}
