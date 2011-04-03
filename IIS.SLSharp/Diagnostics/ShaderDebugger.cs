using System;

namespace IIS.SLSharp.Diagnostics
{
    public sealed class ShaderDebugger
    {
        private Shader _shader;

        public void BeginDebug(Shader shader)
        {
            if (_shader != null)
                throw new InvalidOperationException("This debugger object is already debugging a shader.");
        }

        public void EndDebug()
        {
            if (_shader == null)
                return;

            // readback results here
            _shader = null;
        }
    }
}
