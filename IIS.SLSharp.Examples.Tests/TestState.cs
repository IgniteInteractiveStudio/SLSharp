using NUnit.Framework;

namespace IIS.SLSharp.Examples.Tests
{
    [SetUpFixture]
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

        [SetUp]
        public static void AssemblyInit()
        {
            Initialize(); // first init
        }

        [TearDown]
        public static void AssemblyCleanup()
        {
        }
    }
}