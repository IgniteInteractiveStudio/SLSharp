using System.Linq;
using IIS.SLSharp.Annotations;
using Mono.Cecil;

namespace IIS.SLSharp.Shaders
{
    internal static class AttributeHelper
    {
        private static readonly int _uniformToken = typeof(UniformAttribute).MetadataToken;

        private static readonly int[] _attribToken = new[]
                                                         {
                                                             typeof(VaryingAttribute).MetadataToken,
                                                             typeof(VertexInAttribute).MetadataToken,
                                                             typeof(FragmentOutAttribute).MetadataToken,
                                                         };

        public static bool IsUniform(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == _uniformToken;
        }

        public static bool IsVarying(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == _attribToken[0];
        }

        public static bool IsVertexIn(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == _attribToken[1];
        }

        public static bool IsFragmentOut(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == _attribToken[2];
        }

        public static bool IsAttribute(this TypeReference t)
        {
            return _attribToken.Contains(t.Resolve().MetadataToken.ToInt32());
        }

        public static bool Is<T>(this TypeReference t)
        {
            return t.Resolve().MetadataToken.ToInt32() == typeof (T).MetadataToken;
        }
    }
}