using System;
using System.Linq;
using System.Reflection;

namespace IIS.SLSharp.Reflection
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
            if (t == null)
                throw new ArgumentNullException("t");

            return (from p in t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                    let attr = p.GetCustomAttributes(typeof(ReflectionMarkerAttribute), false)
                    where attr.Length != 0
                    let att = (ReflectionMarkerAttribute)attr[0]
                    where att.Token == token
                    select p).Single();
        }

        public static MethodInfo FindMethod(Type t, ReflectionToken token)
        {
            if (t == null)
                throw new ArgumentNullException("t");

            return (from m in t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                    let attr = m.GetCustomAttributes(typeof(ReflectionMarkerAttribute), false)
                    where attr.Length != 0
                    let att = (ReflectionMarkerAttribute)attr[0]
                    where att.Token == token
                    select m).Single();
        }
    }
}
