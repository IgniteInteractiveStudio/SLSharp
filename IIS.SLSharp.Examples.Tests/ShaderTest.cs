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
        protected static readonly List<Vector4> V4fA = GenerateValues(100).Select(x => x).ToList();
        protected static readonly List<Vector3> V3fA = GenerateValues(100).Select(x => new Vector3(x.X, x.Y, x.Z)).ToList();
        protected static readonly List<Vector2> V2fA = GenerateValues(100).Select(x => new Vector2(x.X, x.Y)).ToList();
        protected static readonly List<float> V1fA = GenerateValues(100).Select(x => x.X).ToList();
        protected static readonly List<Vector4> V4fB = GenerateValues(100).Select(x => new Vector4(x.Y, x.Z, x.W, x.X)).ToList();
        protected static readonly List<Vector3> V3fB = GenerateValues(100).Select(x => new Vector3(x.Y, x.Z, x.W)).ToList();
        protected static readonly List<Vector2> V2fB = GenerateValues(100).Select(x => new Vector2(x.Y, x.Z)).ToList();
        protected static readonly List<float> V1fB = GenerateValues(100).Select(x => x.Y).ToList();


        private static Type BuildShader(Expression exp)
        {
            //var binDir = Path.GetDirectoryName(typeof(Shader).Assembly.Location);
            var binDir = Directory.GetCurrentDirectory();
            
            var assemblyName = new AssemblyName("testcase") { Name = "testcase", CodeBase = Assembly.GetExecutingAssembly().Location };
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save, binDir);
            var module = assemblyBuilder.DefineDynamicModule("testcase", "testcase.dll");
            var shaderType = typeof(ExponentialTests); // TODO: supply from callee
            var typeBuilder = module.DefineType("testshader", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Abstract, shaderType);

            var builder = new ShaderBuilder(typeBuilder);
            builder.DefineVertexBody();
            builder.DefineFragmentBody(exp);

            var reflectType = typeBuilder.CreateType();
            assemblyBuilder.Save("testcase.dll");

            //var typ = Assembly.LoadFile(binDir + "\\testcase.dll").GetType("testshader");
            //return typ;

            return reflectType;
        }

        protected static IEnumerable<Vector4> Eval<T>(Expression<Action> x, List<T> inputs)
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
