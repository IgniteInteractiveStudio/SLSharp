using System.Collections.Generic;
using System.Reflection;
using IIS.SLSharp.Reflection;

namespace IIS.SLSharp.Bindings
{
    public sealed class Binding
    {
        private static Dictionary<ReflectionToken, MethodInfo> Methods
        {
            get
            {
                if (_handlers == null)
                    throw new SLSharpException("SLSharp has not been initialized");
                return _handlers;
            }
        }

        private static Dictionary<ReflectionToken, MethodInfo> _handlers;

        public static void Register(ISLSharpBinding binding)
        {
            _handlers = binding.PassiveMethods;
            Active = binding;
        }

        public static MethodInfo Resolve(ReflectionToken token)
        {
            MethodInfo result;
            if (!Methods.TryGetValue(token, out result))
                    throw new SLSharpException("Binding does not support " + token);
            return result;
        }

        public static ISLSharpBinding Active;
    }
}
