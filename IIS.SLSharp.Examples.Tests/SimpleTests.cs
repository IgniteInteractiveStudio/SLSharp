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
    public class StaticTests : ShaderTest
    {
        [TestMethod]
        public void Test()
        {
            var outputs = Eval(x => Sqrt(x), V1fA);
            foreach (var x in outputs.Zip(V1fA, (x, y) => new Tuple<float, float>(x.X, (float)Math.Sqrt(y))))
                Assert.AreEqual(x.Item1, x.Item2, 0.00001f);
        }
    }
}