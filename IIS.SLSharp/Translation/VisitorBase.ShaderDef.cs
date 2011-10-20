using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Shaders;
using Mono.Cecil;
using InvocationExpression = ICSharpCode.NRefactory.CSharp.InvocationExpression;

namespace IIS.SLSharp.Translation
{
    internal abstract partial class VisitorBase
    {
        // ReSharper disable InconsistentNaming
        // ReSharper disable UnusedMember.Local
#pragma warning disable 649
        protected static readonly ShaderDefinition.sampler1D sampler1D;
        protected static readonly ShaderDefinition.isampler1D isampler1D;
        protected static readonly ShaderDefinition.usampler1D usampler1D;
        protected static readonly ShaderDefinition.sampler2D sampler2D;
        protected static readonly ShaderDefinition.isampler2D isampler2D;
        protected static readonly ShaderDefinition.usampler2D usampler2D;
        protected static readonly ShaderDefinition.sampler3D sampler3D;
        protected static readonly ShaderDefinition.isampler3D isampler3D;
        protected static readonly ShaderDefinition.usampler3D usampler3D;
        protected static readonly ShaderDefinition.samplerCube samplerCube;
        protected static readonly ShaderDefinition.isamplerCube isamplerCube;
        protected static readonly ShaderDefinition.usamplerCube usamplerCube;
        protected static readonly ShaderDefinition.sampler1DShadow sampler1DShadow;
        protected static readonly ShaderDefinition.sampler2DShadow sampler2DShadow;
        protected static readonly ShaderDefinition.samplerCubeShadow samplerCubeShadow;
        protected static readonly ShaderDefinition.sampler2DRect sampler2DRect;
        protected static readonly ShaderDefinition.isampler2DRect isampler2DRect;
        protected static readonly ShaderDefinition.usampler2DRect usampler2DRect;
        protected static readonly ShaderDefinition.sampler2DRectShadow sampler2DRectShadow;
        protected static ShaderDefinition.vec2 vec2;
        protected static ShaderDefinition.vec3 vec3;
        protected static ShaderDefinition.vec4 vec4;
        protected static float _float;
        protected static ShaderDefinition.dvec2 dvec2;
        protected static ShaderDefinition.dvec3 dvec3;
        protected static ShaderDefinition.dvec4 dvec4;
        protected static double _double;
        protected static ShaderDefinition.ivec2 ivec2;
        protected static ShaderDefinition.ivec3 ivec3;
        protected static ShaderDefinition.ivec4 ivec4;
        protected static int _int;
        protected static ShaderDefinition.uvec2 uvec2;
        protected static ShaderDefinition.uvec3 uvec3;
        protected static ShaderDefinition.uvec4 uvec4;
        protected static uint _uint;
        protected static ShaderDefinition.bvec2 bvec2;
        protected static ShaderDefinition.bvec3 bvec3;
        protected static ShaderDefinition.bvec4 bvec4;
        protected static bool _bool;
#pragma warning restore 649
        // ReSharper restore InconsistentNaming
        // ReSharper restore UnusedMember.Local

        protected Dictionary<Expression<Action>, Func<MethodDefinition, InvocationExpression, StringBuilder>> Handlers { private get; set; }

        internal sealed class HandlerComparer : IEqualityComparer<Expression<Action>>
        {
            private int IdFrom(Expression<Action> a)
            {

                var x = a.Body as MethodCallExpression;
                if (x != null)
                    return x.Method.MetadataToken;

                var c = (ConstantExpression)a.Body;
                return (int)c.Value;
            }

            public bool Equals(Expression<Action> x, Expression<Action> y)
            {
                return IdFrom(x) == IdFrom(y);
            }

            public int GetHashCode(Expression<Action> obj)
            {
                return IdFrom(obj);
            }
        }


        /// <summary>
        /// Completeley renamed the invocated method to the given name
        /// </summary>
        protected Func<MethodDefinition, InvocationExpression, StringBuilder> Rename(string newName)
        {
            return (m, i) =>
            {
                var result = new StringBuilder();
                return result.Append(newName).Append("(").Append(ArgsToString(i.Arguments)).Append(")");
            };
        }

        /// <summary>
        /// Translates the invocated name without any modifications
        /// </summary>
        protected StringBuilder PassThrough(MethodDefinition m, InvocationExpression i)
        {
            var result = new StringBuilder();
            return result.Append(m.Name).Append("(").Append(ArgsToString(i.Arguments)).Append(")");
        }

        /// <summary>
        /// Translates the invocated name to lower case
        /// </summary>
        protected StringBuilder ToLower(MethodDefinition m, InvocationExpression i)
        {
            var result = new StringBuilder();
            var lowerName = Char.ToLowerInvariant(m.Name[0]) + m.Name.Substring(1);
            return result.Append(lowerName).Append("(").Append(ArgsToString(i.Arguments)).Append(")");
        }

        private void CheckWarnings(MethodDefinition def)
        {
            var warn = def.CustomAttributes.FirstOrDefault(a => a.AttributeType.Resolve().MetadataToken.ToInt32() == typeof(WarningAttribute).MetadataToken);
            if (warn == null)
                return;
            var warning = (string)warn.ConstructorArguments.First().Value;
            Warn(warning);
        }

        /// <summary>
        /// Redirects the invocation to the explicitly specified method
        /// </summary>
        protected Func<MethodDefinition, InvocationExpression, StringBuilder> Redirect(Expression<Action> wrapper)
        {
            var fun = ShaderDefinition.ToCecil(((MethodCallExpression)wrapper.Body).Method);
            CheckWarnings(fun);
            return (m, i) =>
            {
                // replace the current node with a call to fun and process again
                i.RemoveAnnotations(typeof(MethodDefinition));
                i.RemoveAnnotations(typeof(MethodReference));
                i.AddAnnotation(fun);
                return i.AcceptVisitor(this, 0);
            };
        }


        private bool SameSignature(MethodDefinition a, MethodDefinition b)
        {
            if (a.ReturnType.Resolve().MetadataToken != b.ReturnType.Resolve().MetadataToken)
                return false;

            if (a.Parameters.Count != b.Parameters.Count)
                return false;

            for (var i = 0; i < a.Parameters.Count; i++)
            {
                var pa = a.Parameters[i].ParameterType;
                var pb = b.Parameters[i].ParameterType;
                if (pa.Resolve().MetadataToken != pb.Resolve().MetadataToken)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Redirects the invocation to the specified class, by searching for a
        /// method with the specified name if given or same name otherwise
        /// matching the original method signature.
        /// </summary>
        /// <returns></returns>
        protected Func<MethodDefinition, InvocationExpression, StringBuilder> Redirect<T>(string name = null)
        {
            var t = ShaderDefinition.ToCecil(typeof(T));
            return (m, i) =>
            {
                var redirected = t.Methods.Single(j => j.Name == (name ?? m.Name)
                                                       && SameSignature(j, m));
                CheckWarnings(redirected);
                i.RemoveAnnotations(typeof(MethodDefinition));
                i.RemoveAnnotations(typeof(MethodReference));
                i.AddAnnotation(redirected);
                return i.AcceptVisitor(this, 0);
            };
        }


        // Dispatcher
        protected StringBuilder VisitShaderDefCall(MethodDefinition m, InvocationExpression invocationExpression)
        {
            var tok = m.Resolve().MetadataToken.ToInt32();
            Func<MethodDefinition, InvocationExpression, StringBuilder> handler;
            var etok = Expression.Lambda<Action>(Expression.Constant(tok));

            return Handlers.TryGetValue(etok, out handler) ?
                handler(m, invocationExpression) : PassThrough(m, invocationExpression);
        }
    }
}
