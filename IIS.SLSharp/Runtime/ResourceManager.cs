using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using IIS.SLSharp.Reflection;

namespace IIS.SLSharp.Runtime
{
    public static class ResourceManager
    {
        // derive a class T' of T that overrides Dispose() replacing it with a Release call

        private const BindingFlags BindingFlagsAny =
           BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        private sealed class AllocationKey
        {
            public object[] Args { get; set; }

            public object[] Types { get; set; }

            public int RefCount { get; set; }
        }

        private sealed class AllocationKeyComparer : IEqualityComparer<AllocationKey>
        {
            public bool Equals(AllocationKey x, AllocationKey y)
            {
                if (x == null)
                    throw new ArgumentNullException("x");

                if (y == null)
                    throw new ArgumentNullException("y");

                if (x.Args.Length != y.Args.Length)
                    return false;

                if (x.Types.Length != y.Types.Length)
                    return false;

                if (x.Args.Where((t, i) => !t.Equals(y.Args[i])).Any())
                    return false;

                if (x.Types.Where((t, i) => !t.Equals(y.Types[i])).Any())
                    return false;

                return true;
            }

            public int GetHashCode(AllocationKey obj)
            {
                if (obj == null)
                    throw new ArgumentNullException("obj");

                var hash = obj.Args.Aggregate(0, (current, x) => current ^ x.GetHashCode());
                return obj.Types.Aggregate(hash, (current, x) => current ^ x.GetHashCode());
            }
        }

        private sealed class ResourceRecord
        {
            public ResourceRecord()
            {
                Instances = new Dictionary<AllocationKey, object>(new AllocationKeyComparer());
            }

            public Type Implementation { get; set; }

            public Dictionary<AllocationKey, object> Instances { get; private set; }
        }

        private static readonly Dictionary<Type, ResourceRecord> _impls = new Dictionary<Type, ResourceRecord>();

        [ReflectionMarker(ReflectionToken.ResourceHelperRelease)]
        public static void Release(object instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            var type = instance.GetType();
            var rec = GetResource(type);
            var key = (AllocationKey)type.GetField("key").GetValue(instance);

            lock (rec.Instances)
            {
                key.RefCount--;
                if (key.RefCount != 0)
                    return;

                rec.Instances.Remove(key);
                var tDispose = type.GetMethod("DisposeBase", BindingFlags.Public | BindingFlags.Instance);
                tDispose.Invoke(instance, null);
            }
        }

        private static ResourceRecord GetResource(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            ResourceRecord result;
            if (_impls.TryGetValue(type, out result))
                return result;

            var assemblyName = new AssemblyName { Name = "tmp_" + type.Name };
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var module = assemblyBuilder.DefineDynamicModule("tmpModule");
            var typeBuilder = module.DefineType(type.Name + "SharedSingletonWrapper", TypeAttributes.Public | TypeAttributes.Class, type);

            var baseDispose = type.GetMethod("Dispose", BindingFlags.Public | BindingFlags.Instance);
            if (baseDispose.IsFinal)
                throw new Exception(type.Name + ".Dispose() is final");

            var disposeFun = typeBuilder.DefineMethod("Dispose", MethodAttributes.Virtual | MethodAttributes.Public, typeof(void), Type.EmptyTypes);
            var disposeBaseFun = typeBuilder.DefineMethod("DisposeBase", MethodAttributes.Public, typeof(void), Type.EmptyTypes);
            typeBuilder.DefineField("key", typeof(AllocationKey), FieldAttributes.Public);

            var ilDispose = disposeFun.GetILGenerator();

            var release = ReflectionMarkerAttribute.FindMethod(
                 typeof(ResourceManager), ReflectionToken.ResourceHelperRelease);

            ilDispose.Emit(OpCodes.Ldarg, 0);
            ilDispose.Emit(OpCodes.Call, release);
            ilDispose.Emit(OpCodes.Ret);

            var ilDisposeBase = disposeBaseFun.GetILGenerator();
            ilDisposeBase.Emit(OpCodes.Ldarg, 0);
            ilDisposeBase.Emit(OpCodes.Call, type.GetMethod("Dispose", BindingFlags.Public | BindingFlags.Instance));
            ilDisposeBase.Emit(OpCodes.Ret);
                
            foreach (var tctor in type.GetConstructors(BindingFlagsAny))
            {
                if (tctor.IsPrivate)
                    continue;

                // create a default ctor for T'
                var tparams = tctor.GetParameters();
                var nparams = new Type[tparams.Length];
                for (var i = 0; i < tparams.Length; i++)
                    nparams[i] = tparams[i].ParameterType;

                var ttctor = typeBuilder.DefineConstructor(MethodAttributes.Public, tctor.CallingConvention, nparams);
                var cil = ttctor.GetILGenerator();
                for (var i = 0; i < tparams.Length + 1; i++)
                    cil.Emit(OpCodes.Ldarg, i);

                cil.Emit(OpCodes.Call, tctor);
                cil.Emit(OpCodes.Ret);
            }

            result = new ResourceRecord
            {
                Implementation = typeBuilder.CreateType()
            };
            _impls[type] = result;

            return result;
        }

        public static object Instance(Type t, object[] args, Type[] types)
        {
            if (t == null)
                throw new ArgumentNullException("t");

            var res = GetResource(t);

            if (types == null)
                types = Type.EmptyTypes;

            if (args == null)
                args = new object[0];

            var k = new AllocationKey
            {
                Args = args,
                Types = types
            };

            object instance;

            lock (res.Instances)
            {
                if (res.Instances.TryGetValue(k, out instance))
                {
                    k = (AllocationKey)instance.GetType().GetField("key").GetValue(instance);
                    k.RefCount++;
                    return instance;
                }
            }

            var ctor = res.Implementation.GetConstructor(types);

            // ReSharper disable ConditionIsAlwaysTrueOrFalse
            // ReSharper disable HeuristicUnreachableCode
            if (ctor == null)
            {
                var s = types.Aggregate(string.Empty, (acc, current) => acc += current.ToString() + ", ").TrimEnd(new[] { ' ', ',' });
                throw new ArgumentException(t.Name + "." + t.Name + "(" + s + ") is not defined");
            }
            // ReSharper restore HeuristicUnreachableCode
            // ReSharper restore ConditionIsAlwaysTrueOrFalse

            var recf = res.Implementation.GetField("key");

            instance = ctor.Invoke(args);
            recf.SetValue(instance, k);

            lock (res.Instances)
            {
                k.RefCount = 1;
                res.Instances[k] = instance;
            }

            return instance;
        }

        public static T Instance<T>(object[] args, Type[] types)
        {
            return (T)Instance(typeof(T), args, types);
        }

        public static T Instance<T>()
            where T : IDisposable
        {
            return Instance<T>(null, Type.EmptyTypes);
        }

        public static T Instance<T, T1>(T1 t1)
            where T : IDisposable
        {
            var args = new[] { t1 };
            var types = new[] { typeof(T1) };
            return Instance<T>(args, types);
        }

        public static T Instance<T>(object t1)
            where T: IDisposable
        {
            var args = new[] { t1 };
            var types = new[] { t1.GetType() };
            return Instance<T>(args, types);
        }

        public static T Instance<T, T1, T2>(T1 t1, T2 t2)
            where T : IDisposable
        {
            var args = new object[] { t1, t2 };
            var types = new[] { typeof(T1), typeof(T2) };
            return Instance<T>(args, types);
        }

        public static T Instance<T>(object t1, object t2)
            where T : IDisposable
        {
            var args = new[] { t1, t2 };
            var types = new[] { t1.GetType(), t2.GetType() };
            return Instance<T>(args, types);
        }


        public static T Instance<T, T1, T2, T3>(T1 t1, T2 t2, T3 t3)
            where T : IDisposable
        {
            var args = new object[] { t1, t2, t3 };
            var types = new[] { typeof(T1), typeof(T2), typeof(T3) };
            return Instance<T>(args, types);
        }

        public static T Instance<T>(object t1, object t2, object t3)
            where T : IDisposable
        {
            var args = new[] { t1, t2, t3 };
            var types = new[] { t1.GetType(), t2.GetType(), t3.GetType() };
            return Instance<T>(args, types);
        }
    }
}
