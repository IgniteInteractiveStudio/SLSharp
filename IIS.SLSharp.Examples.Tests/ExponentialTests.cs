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
        #region genType Sqrt(genType x)

        [Test]
        public void TestSqrtSingle() 
        {
            var outputs = Eval(() => Sqrt(_float), V1fA);
            foreach (var x in outputs.Zip(V1fA, (x, y) => new Tuple<float, float>(x.X, (float)Math.Sqrt(y))))
                Assert.AreEqual(x.Item1, x.Item2, 0.00001f);
        }


        [Test]
        public void TestSqrtVec2()
        {
            var outputs = Eval(() => Sqrt(vec2), V2fA);
            foreach (var x in outputs.Zip(V2fA, (x, y) => new Tuple<Vector4, float, float>(x, (float)Math.Sqrt(y.X), (float)Math.Sqrt(y.Y))))
            {
                Assert.AreEqual(x.Item1.X, x.Item2, 0.00001f);
                Assert.AreEqual(x.Item1.Y, x.Item3, 0.00001f);
            }
        }

        #endregion
    }
}