using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using IIS.SLSharp.Shaders;
using NUnit.Framework;

namespace IIS.SLSharp.Examples.Tests
{
    public struct Vector4
    {
        public float X, Y, Z, W;

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }

    public struct Vector3
    {
        public float X, Y, Z;

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public struct Vector2
    {
        public float X, Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    public class ShaderTest : Shader
    {
        // ReSharper disable InconsistentNaming
        // ReSharper disable UnusedMember.Local
#pragma warning disable 649
        protected new static readonly sampler2D sampler2D;
        protected new static vec2 vec2;
        protected new static vec3 vec3;
        protected new static vec4 vec4;
        protected static float _float;
        protected new static dvec2 dvec2;
        protected new static dvec3 dvec3;
        protected new static dvec4 dvec4;
        protected static double _double;
#pragma warning restore 649
        // ReSharper restore InconsistentNaming
        // ReSharper restore UnusedMember.Local

        /// <summary>
        /// Generates a vec4 by shearing the input value
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        private static Vector4 GenerateVec4(double f)
        {
            var x = f;
            var y = f + 0.25;
            var z = f + 0.5;
            var w = f + 0.75;

            if (w < 1.0)
                return new Vector4((float)x, (float)y, (float)z, (float)w);
            w = f - 0.25; // w -= 1.0;

            if (z < 1.0)
                return new Vector4((float)x, (float)y, (float)z, (float)w);
            z = f - 0.5; // z -= 1.0;

            if (y < 1.0)
                return new Vector4((float)x, (float)y, (float)z, (float)w);
            y = f - 0.75; // y -= 1.0f;

            if (x < 1.0)
                return new Vector4((float)x, (float)y, (float)z, (float)w);
            x -= 1.0;

            return new Vector4((float)x, (float)y, (float)z, (float)w);
        }

        private static IEnumerable<Vector4> GenerateValues(int num)
        {
            var values = new List<Vector4>();
            for (var i = 0; i < num; i++)
                values.Add(GenerateVec4((double)i / num));
            return values;
        }

        // float test values
        protected static readonly List<Vector4> V4fA = GenerateValues(100).Select(x => x).ToList();
        protected static readonly List<Vector3> V3fA = GenerateValues(100).Select(x => new Vector3(x.X, x.Y, x.Z)).ToList();
        protected static readonly List<Vector2> V2fA = GenerateValues(100).Select(x => new Vector2(x.X, x.Y)).ToList();
        protected static readonly List<float> V1fA = GenerateValues(100).Select(x => x.X).ToList();
        protected static readonly List<Vector4> V4fB = GenerateValues(100).Select(x => new Vector4(x.Y, x.Z, x.W, x.X)).ToList();
        protected static readonly List<Vector3> V3fB = GenerateValues(100).Select(x => new Vector3(x.Y, x.Z, x.W)).ToList();
        protected static readonly List<Vector2> V2fB = GenerateValues(100).Select(x => new Vector2(x.Y, x.Z)).ToList();
        protected static readonly List<float> V1fB = GenerateValues(100).Select(x => x.Y).ToList();


        private static Type BuildShader(Expression exp, Type shaderType)
        {
            //var binDir = Path.GetDirectoryName(typeof(Shader).Assembly.Location);
            var binDir = Directory.GetCurrentDirectory();

            var call = (MethodCallExpression)exp;
            var testName = string.Format("{0}_{1}", call.Method.Name, call.Method.MetadataToken);
            var testDll = testName + ".dll";

            var assemblyName = new AssemblyName(testName) { Name = testName, CodeBase = Assembly.GetExecutingAssembly().Location };
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save, binDir);
            var module = assemblyBuilder.DefineDynamicModule(testName, testDll);
            //var shaderType = typeof(ExponentialTests); // TODO: supply from callee
            var typeBuilder = module.DefineType("testshader", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Abstract, shaderType);

            var builder = new ShaderBuilder(typeBuilder);
            builder.DefineVertexBody();
            builder.DefineFragmentBody(exp);

            var reflectType = typeBuilder.CreateType();
            assemblyBuilder.Save(testDll);

            //var typ = Assembly.LoadFile(binDir + "\\testcase.dll").GetType("testshader");
            //return typ;

            return reflectType;
        }


        private static Action<T> GetInputSetter<T>(Shader shader, int index)
        {
            var setInput0Func = shader.GetType().GetProperty("input" + index).GetSetMethod();
            
            if (typeof(T) == typeof(float))
                return v => setInput0Func.Invoke(shader, new object[] { v });
            if (typeof(T) == typeof(Vector2))
                return v => setInput0Func.Invoke(shader, new object[] { TestState.Runtime.Convert((Vector2)(object)v) });
            if (typeof(T) == typeof(Vector3))
                return v => setInput0Func.Invoke(shader, new object[] { TestState.Runtime.Convert((Vector3)(object)v) });
            if (typeof(T) == typeof(Vector4))
               return v => setInput0Func.Invoke(shader, new object[] { TestState.Runtime.Convert((Vector4)(object)v) });
            
            throw new NotImplementedException();
        }

        protected IEnumerable<Vector4> Eval<T>(Expression<Action> x, List<T> inputs)
        {
            // * build a shader that evaluates x() and compile it
            // * upload inputs to the GPU via shadertype to test (Vertex => VBO, Fragment => Texture)
            // * run the shader
            // * collect the outputs and pass them back

            var results = new List<Vector4>(inputs.Count);

            var shaderType = BuildShader(x.Body, GetType());
            using (var shader = CreateInstance(shaderType))
            {
                var setInput = GetInputSetter<T>(shader, 0);
                shader.Begin();
                // for each input: set uniforms + draw a one fragment size point
                foreach (var input in inputs)
                {
                    setInput(input);
                    var res = TestState.Runtime.ProcessFragment();
                    results.Add(res);
                }
                shader.End();
            }

            return results;
        }


        protected IEnumerable<Vector4> Eval<T1,T2>(Expression<Action> x, List<T1> input0, List<T2> input1)
        {
            var results = new List<Vector4>(input0.Count);

            var shaderType = BuildShader(x.Body, GetType());
            using (var shader = CreateInstance(shaderType))
            {
                var setInput0 = GetInputSetter<T1>(shader, 0);
                var setInput1 = GetInputSetter<T2>(shader, 1);
                shader.Begin();
                // for each input: set uniforms + draw a one fragment size point
                //foreach (var input in inputs)
                for (var i = 0; i < input0.Count; i++)
                {
                    setInput0(input0[i]);
                    setInput1(input1[i]);
                    var res = TestState.Runtime.ProcessFragment();
                    results.Add(res);
                }
                shader.End();
            }

            return results;
        }

        [SetUp]
        public void Initialize()
        {
            TestState.Initialize();
        }

        [TearDown]
        public void Cleanup()
        {
            TestState.Cleanup();
        }
    }
}
