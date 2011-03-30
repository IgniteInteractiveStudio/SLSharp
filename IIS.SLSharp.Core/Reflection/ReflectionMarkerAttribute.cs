using System;
using System.Reflection;

namespace IIS.SLSharp.Core.Reflection
{
    public sealed class ReflectionMarkerAttribute : Attribute
    {
        public ReflectionToken Token { get; private set; }

        public ReflectionMarkerAttribute(ReflectionToken token)
        {
            Token = token;
        }

        public static PropertyInfo FindProperty(Type t, ReflectionToken token)
        {
            foreach (var p in t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            {
                var attr = p.GetCustomAttributes(typeof (ReflectionMarkerAttribute), false);
                if (attr.Length == 0)
                    continue;

                var att = (ReflectionMarkerAttribute)attr[0];
                if (att.Token == token)
                    return p;
            }

            throw new Exception();
        }

        public static MethodInfo FindMethod(Type t, ReflectionToken token)
        {
            // typeof(Shader).GetMethod("Activate", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], null)
            foreach (var m in t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            {
                var attr = m.GetCustomAttributes(typeof(ReflectionMarkerAttribute), false);
                if (attr.Length == 0)
                    continue;

                var att = (ReflectionMarkerAttribute)attr[0];
                if (att.Token == token)
                    return m;
            }

            throw new Exception();
        }
    }
}
