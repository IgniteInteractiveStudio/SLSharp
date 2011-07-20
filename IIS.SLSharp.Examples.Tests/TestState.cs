using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IIS.SLSharp.Examples.Tests
{
    [TestClass]
    public sealed class TestState
    {
        public static readonly ITestRuntime Runtime = new OpenTKTestRuntime.OpenTKTestRuntime();

        private static bool _initialized;

        public static void Initialize()
        {
            if (_initialized)
                return;
            Runtime.Initialize();
            _initialized = true;
        }

        public static void Cleanup()
        {
            if (!_initialized)
                return;
            Runtime.Cleanup();
            _initialized = false;
        }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Initialize(); // first init
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
        }
    }
}