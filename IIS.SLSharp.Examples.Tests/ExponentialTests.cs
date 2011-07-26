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
using IIS.SLSharp.Shaders;
using NUnit.Framework;

namespace IIS.SLSharp.Examples.Tests
{
    [TestFixture]
    public class ExponentialTests : ShaderTest
    {
        private const int MaxErr = 60;

        #region genType Pow(genType x, genType y)

        [Test]
        public void TestPowSingle()
        {
            var outputs = Eval(() => Pow(_float, _float), V1fA, V1fB);
            var expected = V1fA.Zip(V1fB, (a, b) => (float)Math.Pow(a, b));

            foreach (var x in outputs.Zip(expected, (x, y) => new Tuple<float, float>(x.X, y)))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }

        [Test]
        public void TestPowVec2()
        {
            var outputs = Eval(() => Pow(vec2, vec2), V2fA, V2fB);
            var expected = V2fA.Zip(V2fB, (a, b) => new Tuple<float, float>((float)Math.Pow(a.X, b.X), (float)Math.Pow(a.Y, b.Y)));

            foreach (var x in outputs.Zip(expected, (x, y) => new Tuple<Vector4, float, float>(x, y.Item1, y.Item2)))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestPowVec3()
        {
            var outputs = Eval(() => Pow(vec3, vec3), V3fA, V3fB);
            var expected = V3fA.Zip(V3fB, (a, b) => new Tuple<float, float, float>((float)Math.Pow(a.X, b.X), (float)Math.Pow(a.Y, b.Y), (float)Math.Pow(a.Z, b.Z)));

            foreach (var x in outputs.Zip(expected, (x, y) => new Tuple<Vector4, float, float, float>(x, y.Item1, y.Item2, y.Item3)))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestPowVec4()
        {
            var outputs = Eval(() => Pow(vec4, vec4), V4fA, V4fB);
            var expected = V4fA.Zip(V4fB, (a, b) => new Tuple<float, float, float, float>((float)Math.Pow(a.X, b.X), (float)Math.Pow(a.Y, b.Y), (float)Math.Pow(a.Z, b.Z), (float)Math.Pow(a.W, b.W)));

            foreach (var x in outputs.Zip(expected, (x, y) => new Tuple<Vector4, float, float, float, float>(x, y.Item1, y.Item2, y.Item3, y.Item4)))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
                Assert.That(x.Item1.W, Is.EqualTo(x.Item5).Within(MaxErr).Ulps);
            }
        }

        #endregion

        #region genType Exp(genType x)

        [Test]
        public void TestExpSingle()
        {
            var outputs = Eval(() => Exp(_float), V1fA);
            foreach (var x in outputs.Zip(V1fA, (x, y) => new Tuple<float, float>(x.X, (float)Math.Exp(y))))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }


        [Test]
        public void TestExpVec2()
        {
            var outputs = Eval(() => Exp(vec2), V2fA);
            foreach (var x in outputs.Zip(V2fA, (x, y) => new Tuple<Vector4, float, float>(x, (float)Math.Exp(y.X), (float)Math.Exp(y.Y))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestExpVec3()
        {
            var outputs = Eval(() => Exp(vec3), V3fA);
            foreach (var x in outputs.Zip(V3fA, (x, y) => new Tuple<Vector4, float, float, float>(x, (float)Math.Exp(y.X), (float)Math.Exp(y.Y), (float)Math.Exp(y.Z))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestExpVec4()
        {
            var outputs = Eval(() => Exp(vec4), V4fA);
            foreach (var x in outputs.Zip(V4fA, (x, y) => new Tuple<Vector4, float, float, float, float>(x, (float)Math.Exp(y.X), (float)Math.Exp(y.Y), (float)Math.Exp(y.Z), (float)Math.Exp(y.W))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
                Assert.That(x.Item1.W, Is.EqualTo(x.Item5).Within(MaxErr).Ulps);
            }
        }

        #endregion

        #region genType Log(genType x)

        [Test]
        public void TestLogSingle()
        {
            var outputs = Eval(() => Log(_float), V1fA);
            foreach (var x in outputs.Zip(V1fA, (x, y) => new Tuple<float, float>(x.X, (float)Math.Log(y))))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }


        [Test]
        public void TestLogVec2()
        {
            var outputs = Eval(() => Log(vec2), V2fA);
            foreach (var x in outputs.Zip(V2fA, (x, y) => new Tuple<Vector4, float, float>(x, (float)Math.Log(y.X), (float)Math.Log(y.Y))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestLogVec3()
        {
            var outputs = Eval(() => Log(vec3), V3fA);
            foreach (var x in outputs.Zip(V3fA, (x, y) => new Tuple<Vector4, float, float, float>(x, (float)Math.Log(y.X), (float)Math.Log(y.Y), (float)Math.Log(y.Z))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestLogVec4()
        {
            var outputs = Eval(() => Log(vec4), V4fA);
            foreach (var x in outputs.Zip(V4fA, (x, y) => new Tuple<Vector4, float, float, float, float>(x, (float)Math.Log(y.X), (float)Math.Log(y.Y), (float)Math.Log(y.Z), (float)Math.Log(y.W))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
                Assert.That(x.Item1.W, Is.EqualTo(x.Item5).Within(MaxErr).Ulps);
            }
        }

        #endregion

        #region genType Exp2(genType x)

        [Test]
        public void TestExp2Single()
        {
            var outputs = Eval(() => Exp2(_float), V1fA);
            foreach (var x in outputs.Zip(V1fA, (x, y) => new Tuple<float, float>(x.X, (float)Math.Pow(2.0, y))))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }


        [Test]
        public void TestExp2Vec2()
        {
            var outputs = Eval(() => Exp2(vec2), V2fA);
            foreach (var x in outputs.Zip(V2fA, (x, y) => new Tuple<Vector4, float, float>(x, (float)Math.Pow(2.0, y.X), (float)Math.Pow(2.0, y.Y))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestExp2Vec3()
        {
            var outputs = Eval(() => Exp2(vec3), V3fA);
            foreach (var x in outputs.Zip(V3fA, (x, y) => new Tuple<Vector4, float, float, float>(x, (float)Math.Pow(2.0, y.X), (float)Math.Pow(2.0, y.Y), (float)Math.Pow(2.0, y.Z))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestExp2Vec4()
        {
            var outputs = Eval(() => Exp2(vec4), V4fA);
            foreach (var x in outputs.Zip(V4fA, (x, y) => new Tuple<Vector4, float, float, float, float>(x, (float)Math.Pow(2.0, y.X), (float)Math.Pow(2.0, y.Y), (float)Math.Pow(2.0, y.Z), (float)Math.Pow(2.0, y.W))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
                Assert.That(x.Item1.W, Is.EqualTo(x.Item5).Within(MaxErr).Ulps);
            }
        }

        #endregion

        #region genType Log2(genType x)

        [Test]
        public void TestLog2Single()
        {
            var outputs = Eval(() => Log2(_float), V1fA);
            foreach (var x in outputs.Zip(V1fA, (x, y) => new Tuple<float, float>(x.X, (float)Math.Log(y, 2.0))))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }


        [Test]
        public void TestLog2Vec2()
        {
            var outputs = Eval(() => Log2(vec2), V2fA);
            foreach (var x in outputs.Zip(V2fA, (x, y) => new Tuple<Vector4, float, float>(x, (float)Math.Log(y.X, 2.0), (float)Math.Log(y.Y, 2.0))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestLog2Vec3()
        {
            var outputs = Eval(() => Log2(vec3), V3fA);
            foreach (var x in outputs.Zip(V3fA, (x, y) => new Tuple<Vector4, float, float, float>(x, (float)Math.Log(y.X, 2.0), (float)Math.Log(y.Y, 2.0), (float)Math.Log(y.Z, 2.0))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestLog2Vec4()
        {
            var outputs = Eval(() => Log2(vec4), V4fA);
            foreach (var x in outputs.Zip(V4fA, (x, y) => new Tuple<Vector4, float, float, float, float>(x, (float)Math.Log(y.X, 2.0), (float)Math.Log(y.Y, 2.0), (float)Math.Log(y.Z, 2.0), (float)Math.Log(y.W, 2.0))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
                Assert.That(x.Item1.W, Is.EqualTo(x.Item5).Within(MaxErr).Ulps);
            }
        }

        #endregion

        #region genType Sqrt(genType x)

        [Test]
        public void TestSqrtSingle() 
        {
            var outputs = Eval(() => Sqrt(_float), V1fA);
            foreach (var x in outputs.Zip(V1fA, (x, y) => new Tuple<float, float>(x.X, (float)Math.Sqrt(y))))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }


        [Test]
        public void TestSqrtVec2()
        {
            var outputs = Eval(() => Sqrt(vec2), V2fA);
            foreach (var x in outputs.Zip(V2fA, (x, y) => new Tuple<Vector4, float, float>(x, (float)Math.Sqrt(y.X), (float)Math.Sqrt(y.Y))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestSqrtVec3()
        {
            var outputs = Eval(() => Sqrt(vec3), V3fA);
            foreach (var x in outputs.Zip(V3fA, (x, y) => new Tuple<Vector4, float, float, float>(x, (float)Math.Sqrt(y.X), (float)Math.Sqrt(y.Y), (float)Math.Sqrt(y.Z))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestSqrtVec4()
        {
            var outputs = Eval(() => Sqrt(vec4), V4fA);
            foreach (var x in outputs.Zip(V4fA, (x, y) => new Tuple<Vector4, float, float, float, float>(x, (float)Math.Sqrt(y.X), (float)Math.Sqrt(y.Y), (float)Math.Sqrt(y.Z), (float)Math.Sqrt(y.W))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
                Assert.That(x.Item1.W, Is.EqualTo(x.Item5).Within(MaxErr).Ulps);
            }
        }

        #endregion

        // genDType Sqrt(genDType x) not tested yet

        #region genType InverseSqrt(genType x)

        [Test]
        public void TestInverseSqrtSingle()
        {
            var outputs = Eval(() => InverseSqrt(_float), V1fA);
            foreach (var x in outputs.Zip(V1fA, (x, y) => new Tuple<float, float>(x.X, (float)(1.0/Math.Sqrt(y)))))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }


        [Test]
        public void TestInverseSqrtVec2()
        {
            var outputs = Eval(() => InverseSqrt(vec2), V2fA);
            foreach (var x in outputs.Zip(V2fA, (x, y) => new Tuple<Vector4, float, float>(x, (float)(1.0/Math.Sqrt(y.X)), (float)(1.0/Math.Sqrt(y.Y)))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestInverseSqrtVec3()
        {
            var outputs = Eval(() => InverseSqrt(vec3), V3fA);
            foreach (var x in outputs.Zip(V3fA, (x, y) => new Tuple<Vector4, float, float, float>(x, (float)(1.0/Math.Sqrt(y.X)), (float)(1.0/Math.Sqrt(y.Y)), (float)(1.0/Math.Sqrt(y.Z)))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestInverseSqrtVec4()
        {
            var outputs = Eval(() => InverseSqrt(vec4), V4fA);
            foreach (var x in outputs.Zip(V4fA, (x, y) => new Tuple<Vector4, float, float, float, float>(x, (float)(1.0/Math.Sqrt(y.X)), (float)(1.0/Math.Sqrt(y.Y)), (float)(1.0/Math.Sqrt(y.Z)), (float)(1.0/Math.Sqrt(y.W)))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
                Assert.That(x.Item1.W, Is.EqualTo(x.Item5).Within(MaxErr).Ulps);
            }
        }

        #endregion

        // genDType InverseSqrt(genDType x) not tested yet

        #region genType Exp10(genType x)

        [Test]
        public void TestExp10Single()
        {
            var outputs = Eval(() => Exp10(_float), V1fA);
            foreach (var x in outputs.Zip(V1fA, (x, y) => new Tuple<float, float>(x.X, (float)Math.Pow(10.0, y))))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }


        [Test]
        public void TestExp10Vec2()
        {
            var outputs = Eval(() => Exp10(vec2), V2fA);
            foreach (var x in outputs.Zip(V2fA, (x, y) => new Tuple<Vector4, float, float>(x, (float)Math.Pow(10.0, y.X), (float)Math.Pow(10.0, y.Y))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestExp10Vec3()
        {
            var outputs = Eval(() => Exp10(vec3), V3fA);
            foreach (var x in outputs.Zip(V3fA, (x, y) => new Tuple<Vector4, float, float, float>(x, (float)Math.Pow(10.0, y.X), (float)Math.Pow(10.0, y.Y), (float)Math.Pow(10.0, y.Z))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestExp10Vec4()
        {
            var outputs = Eval(() => Exp10(vec4), V4fA);
            foreach (var x in outputs.Zip(V4fA, (x, y) => new Tuple<Vector4, float, float, float, float>(x, (float)Math.Pow(10.0, y.X), (float)Math.Pow(10.0, y.Y), (float)Math.Pow(10.0, y.Z), (float)Math.Pow(10.0, y.W))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
                Assert.That(x.Item1.W, Is.EqualTo(x.Item5).Within(MaxErr).Ulps);
            }
        }

        #endregion

        #region genType Log10(genType x)

        [Test]
        public void TestLog10Single()
        {
            var outputs = Eval(() => Log10(_float), V1fA);
            foreach (var x in outputs.Zip(V1fA, (x, y) => new Tuple<float, float>(x.X, (float)Math.Log10(y))))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }


        [Test]
        public void TestLog10Vec2()
        {
            var outputs = Eval(() => Log10(vec2), V2fA);
            foreach (var x in outputs.Zip(V2fA, (x, y) => new Tuple<Vector4, float, float>(x, (float)Math.Log10(y.X), (float)Math.Log10(y.Y))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestLog10Vec3()
        {
            var outputs = Eval(() => Log10(vec3), V3fA);
            foreach (var x in outputs.Zip(V3fA, (x, y) => new Tuple<Vector4, float, float, float>(x, (float)Math.Log10(y.X), (float)Math.Log10(y.Y), (float)Math.Log10(y.Z))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestLog10Vec4()
        {
            var outputs = Eval(() => Log10(vec4), V4fA);
            foreach (var x in outputs.Zip(V4fA, (x, y) => new Tuple<Vector4, float, float, float, float>(x, (float)Math.Log10(y.X), (float)Math.Log10(y.Y), (float)Math.Log10(y.Z), (float)Math.Log10(y.W))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item3).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item4).Within(MaxErr).Ulps);
                Assert.That(x.Item1.W, Is.EqualTo(x.Item5).Within(MaxErr).Ulps);
            }
        }

        #endregion
    }
}