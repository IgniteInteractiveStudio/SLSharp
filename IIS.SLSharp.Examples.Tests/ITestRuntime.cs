using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IIS.SLSharp.Examples.Tests
{
    public interface ITestRuntime
    {
        void Initialize();
        void Cleanup();
        Vector4 ProcessFragment();
    }
}
