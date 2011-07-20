using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Bindings.OpenTK;
using IIS.SLSharp.Examples.Simple.Shaders;
using IIS.SLSharp.Shaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;
using OpenTK.Graphics;

namespace IIS.SLSharp.Examples.Tests
{
    [TestClass]
    public sealed class State
    {
        public static readonly ITestRuntime Runtime = new OpenTKTestRuntime.OpenTKTestRuntime();

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        { 

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
        }
    }

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

    internal struct Vector3
    {
        public float X, Y, Z;

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    internal struct Vector2
    {
        public float X, Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    public class StaticTests : Shader
    {
        /// <summary>
        /// Generates a vec4 by shearing the input value
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        private static Vector4 GenerateVec4(float f)
        {
            var result = new Vector4(f, f + 0.25f, f + 0.5f, f + 0.75f);

            if (result.W < 1.0f)
                return result;
            result.W -= 1.0f;

            if (result.Z < 1.0f)
                return result;
            result.Z -= 1.0f;

            if (result.Y < 1.0f)
                return result;
            result.Y -= 1.0f;

            if (result.X < 1.0f)
                return result;
            result.X -= 1.0f;

            return result;
        }

        private static IEnumerable<Vector4> GenerateValues(int num)
        {
            var values = new List<Vector4>();
            for (var i = 0; i < num; i++)
                values.Add(GenerateVec4((float)i / num));
            return values;
        }

        // float test values
        private static readonly List<Vector4> _v4fA = GenerateValues(100).Select(x => x).ToList();
        private static readonly List<Vector3> _v3fA = GenerateValues(100).Select(x => new Vector3(x.X, x.Y, x.Z)).ToList();
        private static readonly List<Vector2> _v2fA = GenerateValues(100).Select(x => new Vector2(x.X, x.Y)).ToList();
        private static readonly List<float> _v1fA = GenerateValues(100).Select(x => x.X).ToList();
        private static readonly List<Vector4> _v4fB = GenerateValues(100).Select(x => new Vector4(x.Y, x.Z, x.W, x.X)).ToList();
        private static readonly List<Vector3> _v3fB = GenerateValues(100).Select(x => new Vector3(x.Y, x.Z, x.W)).ToList();
        private static readonly List<Vector2> _v2fB = GenerateValues(100).Select(x => new Vector2(x.Y, x.Z)).ToList();
        private static readonly List<float> _v1fB = GenerateValues(100).Select(x => x.Y).ToList();


        private static Type BuildShader(Expression exp)
        {
            var binDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var assemblyName = new AssemblyName("testcase") { Name = "testcase", CodeBase = Assembly.GetExecutingAssembly().Location };
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save, binDir);
            var module = assemblyBuilder.DefineDynamicModule("testcase", "testcase.dll");
            var shaderType = typeof(StaticTests);
            var typeBuilder = module.DefineType("testshader", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Abstract, shaderType);

            var builder = new ShaderBuilder(typeBuilder);
            builder.DefineVertexBody();
            builder.DefineFragmentBody(exp);

            typeBuilder.CreateType();
            assemblyBuilder.Save("testcase.dll");

            var typ = Assembly.LoadFile(binDir + "\\testcase.dll").GetType("testshader");

            return typ;
        }

        private static IEnumerable<Vector4> Eval<T>(Expression<Func<T, T>> x, List<T> inputs)
        {
            // * build a shader that evaluates x() and compile it
            // * upload inputs to the GPU via shadertype to test (Vertex => VBO, Fragment => Texture)
            // * run the shader
            // * collect the outputs and pass them back

            var results = new List<Vector4>(inputs.Count);

            var shaderType = BuildShader(x.Body);
            using (var shader = CreateInstance(shaderType))
            {
                var setInput0Func = shader.GetType().GetProperty("input0").GetSetMethod();
                Action<T> setInput = v => setInput0Func.Invoke(shader, new object[] { v });
                shader.Begin();
                // for each input: set uniforms + draw a one fragment size point
                foreach (var input in inputs)
                {
                    setInput(input);
                    var res = State.Runtime.ProcessFragment();
                    results.Add(res);
                }
                shader.End();
            }

            return results;
        }

        public static void Test()
        {
            var outputs = Eval(x => Sqrt(x), _v1fA);
            foreach (var x in outputs.Zip(_v1fA, (x, y) => new Tuple<float, float>(x.X, (float)Math.Sqrt(y))))
                Assert.AreEqual(x.Item1, x.Item2, 0.00001f);
        }
    }


    [TestClass]
    public class SimpleTests
    {        
        [TestInitialize]
        public void Initialize()
        {
            State.Runtime.Initialize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            State.Runtime.Cleanup();
        }


       

        [TestMethod]
        public void Test()
        {
            StaticTests.Test();


        }
    }
}
