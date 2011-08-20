using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace IIS.SLSharp.Examples.Tests
{
    [TestFixture]
    public class GeometricTests : ShaderTest
    {
        private const int MaxErr = 10;

        #region CpuLength

        private double CpuLength(double x)
        {
            return Math.Abs(x);
        }

        private double CpuLength(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        private double CpuLength(double x, double y, double z)
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        private double CpuLength(double x, double y, double z, double w)
        {
            return Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        #endregion

        #region CpuNormalize

        private Vector4 CpuNormalize(double x)
        {
            return new Vector4(Math.Sign(x), 0.0f, 0.0f, 0.0f);
        }

        private Vector4 CpuNormalize(double x, double y)
        {
            var len = CpuLength(x, y);
            return new Vector4((float)(x / len), (float)(y / len), 0.0f, 0.0f);
        }

        private Vector4 CpuNormalize(double x, double y, double z)
        {
            var len = CpuLength(x, y, z);
            return new Vector4((float)(x / len), (float)(y / len), (float)(z / len), 0.0f);
        }

        private Vector4 CpuNormalize(double x, double y, double z, double w)
        {
            var len = CpuLength(x, y, z, w);
            return new Vector4((float)(x / len), (float)(y / len), (float)(z / len), (float)(w / len));
        }

        #endregion

        #region float Length(genType x)

        [Test]
        public void TestLengthSingle()
        {
            var outputs = Eval(() => Length(_float), V1fA);
            foreach (var x in outputs.Zip(V1fA, (x, y) => new Tuple<float, float>(x.X, (float)CpuLength(y))))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }


        [Test]
        public void TestLengthVec2()
        {
            var outputs = Eval(() => Length(vec2), V2fA);
            foreach (var x in outputs.Zip(V2fA, (x, y) => new Tuple<float, float>(x.X, (float)CpuLength(y.X, y.Y))))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }

        [Test]
        public void TestLengthVec3()
        {
            var outputs = Eval(() => Length(vec3), V3fA);
            foreach (var x in outputs.Zip(V3fA, (x, y) => new Tuple<float, float>(x.X, (float)CpuLength(y.X, y.Y, y.Z))))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }

        [Test]
        public void TestLengthVec4()
        {
            var outputs = Eval(() => Length(vec4), V4fA);
            foreach (var x in outputs.Zip(V4fA, (x, y) => new Tuple<float, float>(x.X, (float)CpuLength(y.X, y.Y, y.Z, y.W))))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }

        #endregion

        // double Length(genDType x) not tested yet

        #region float Distance(genType x, genType y)

        [Test]
        public void TestDistanceSingle()
        {
            var outputs = Eval(() => Distance(_float, _float), V1fA, V1fB);
            var expected = V1fA.Zip(V1fB, (x, y) => (float)CpuLength(x - y));
            foreach (var x in outputs.Zip(expected, (x, y) => new Tuple<float, float>(x.X, y)))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }


        [Test]
        public void TestDistanceVec2()
        {
            var outputs = Eval(() => Distance(vec2, vec2), V2fA, V2fB);
            var expected = V2fA.Zip(V2fB, (x, y) => (float)CpuLength(x.X - y.X, x.Y - y.Y));
            foreach (var x in outputs.Zip(expected, (x, y) => new Tuple<float, float>(x.X, y)))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }

        [Test]
        public void TestDistanceVec3()
        {
            var outputs = Eval(() => Distance(vec3, vec3), V3fA, V3fB);
            var expected = V3fA.Zip(V3fB, (x, y) => (float)CpuLength(x.X - y.X, x.Y - y.Y, x.Z - y.Z));
            foreach (var x in outputs.Zip(expected, (x, y) => new Tuple<float, float>(x.X, y)))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }

        [Test]
        public void TestDistanceVec4()
        {
            var outputs = Eval(() => Distance(vec4, vec4), V4fA, V4fB);
            var expected = V4fA.Zip(V4fB, (x, y) => (float)CpuLength(x.X - y.X, x.Y - y.Y, x.Z - y.Z, x.W - y.W));
            foreach (var x in outputs.Zip(expected, (x, y) => new Tuple<float, float>(x.X, y)))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }

        #endregion

        // double Distance(genDType x, genDType y) not tested yet

        #region float Dot(genType x, genType y)

        [Test]
        public void TestDotSingle()
        {
            var outputs = Eval(() => Dot(_float, _float), V1fA, V1fB);
            var expected = V1fA.Zip(V1fB, (x, y) => x*y);
            foreach (var x in outputs.Zip(expected, (x, y) => new Tuple<float, float>(x.X, y)))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }


        [Test]
        public void TestDotVec2()
        {
            var outputs = Eval(() => Dot(vec2, vec2), V2fA, V2fB);
            var expected = V2fA.Zip(V2fB, (x, y) => x.X * y.X + x.Y * y.Y);
            foreach (var x in outputs.Zip(expected, (x, y) => new Tuple<float, float>(x.X, y)))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }

        [Test]
        public void TestDotVec3()
        {
            var outputs = Eval(() => Dot(vec3, vec3), V3fA, V3fB);
            var expected = V3fA.Zip(V3fB, (x, y) => x.X * y.X + x.Y * y.Y + x.Z * y.Z);
            foreach (var x in outputs.Zip(expected, (x, y) => new Tuple<float, float>(x.X, y)))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }

        [Test]
        public void TestDotVec4()
        {
            var outputs = Eval(() => Dot(vec4, vec4), V4fA, V4fB);
            var expected = V4fA.Zip(V4fB, (x, y) => x.X * y.X + x.Y * y.Y + x.Z * y.Z + x.W * y.W);
            foreach (var x in outputs.Zip(expected, (x, y) => new Tuple<float, float>(x.X, y)))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }

        #endregion

        // double Dot(genDType x, genDType y) not tested yet

        #region vec3 Cross(vec3 x, vec3 y)

        [Test]
        public void TestCrossVec3()
        {
            var outputs = Eval(() => Cross(vec3, vec3), V3fA, V3fB);
            var expected = V3fA.Zip(V3fB, (a, b) => new Vector4(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X, 0.0f));
            foreach (var x in outputs.Zip(expected, (x, y) => new Tuple<Vector4, Vector4>(x, y)))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2.X).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item2.Y).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item2.Z).Within(MaxErr).Ulps);
            }
        }

        #endregion

        // dvec3 Cross(dvec3 x, dvec3 y) not tested yet

        #region genType Normalize(genType x)

        [Test]
        public void TestNormalizeSingle()
        {
            var outputs = Eval(() => Normalize(_float), V1fA);
            foreach (var x in outputs.Zip(V1fA, (x, y) => new Tuple<float, float>(x.X, CpuNormalize(y).X)))
                Assert.That(x.Item1, Is.EqualTo(x.Item2).Within(MaxErr).Ulps);
        }

        [Test]
        public void TestNormalizeVec2()
        {
            var outputs = Eval(() => Normalize(vec2), V2fA);
            foreach (var x in outputs.Zip(V2fA, (x, y) => new Tuple<Vector4, Vector4>(x, CpuNormalize(y.X, y.Y))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2.X).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item2.Y).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestNormalizeVec3()
        {
            var outputs = Eval(() => Normalize(vec3), V3fA);
            foreach (var x in outputs.Zip(V3fA, (x, y) => new Tuple<Vector4, Vector4>(x, CpuNormalize(y.X, y.Y, y.Z))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2.X).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item2.Y).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item2.Z).Within(MaxErr).Ulps);
            }
        }

        [Test]
        public void TestNormalizeVec4()
        {
            var outputs = Eval(() => Normalize(vec4), V4fA);
            foreach (var x in outputs.Zip(V4fA, (x, y) => new Tuple<Vector4, Vector4>(x, CpuNormalize(y.X, y.Y, y.Z, y.W))))
            {
                Assert.That(x.Item1.X, Is.EqualTo(x.Item2.X).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Y, Is.EqualTo(x.Item2.Y).Within(MaxErr).Ulps);
                Assert.That(x.Item1.Z, Is.EqualTo(x.Item2.Z).Within(MaxErr).Ulps);
                Assert.That(x.Item1.W, Is.EqualTo(x.Item2.W).Within(MaxErr).Ulps);
            }
        }

        #endregion

        // genType FaceForward (genType N, genType I, genType Nref) not tested yet (needs random unit vecs)

        // genDType FaceForward (genDType N, genDType I, genDType Nref) not tested yet

        // genType Reflect (genType I, genType N) not tested yet (needs random unit vecs)

        // genDType Reflect (genDType I, genDType N) not tested yet

        // genType Refract (genType I, genType N, float eta) not tested yet (needs random unit vecs)

        // genDType Refract (genDType I, genDType N, double eta) not tested yet
    }
}
