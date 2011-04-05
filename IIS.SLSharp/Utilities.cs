using System;
using System.Linq;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Core
{
    public static class Utilities
    {
        public static float Fract(float f)
        {
            var fout = (float)Math.Floor(f);
            return f - fout;
        }

        public static float Squared(float x)
        {
            return x * x;
        }

        public static bool IsVersion(int major, int minor = 0)
        {
            var v = GL.GetString(StringName.Version).Split('.').Select(x => int.Parse(x)).ToArray();

            if (v[0] > major)
                return true;

            if (v[0] < major)
                return false;

            return v[1] >= minor;
        }
        
        public static bool HasExtension(string name)
        {
            if (IsVersion(3, 1))
            {
                int numExt;
                GL.GetInteger(GetPName.NumExtensions, out numExt);

                for (var i = 0; i < numExt; i++)
                    if (GL.GetString(StringName.Extensions, 1) == name)
                        return true;

                return false;
            }

            return GL.GetString(StringName.Extensions).Contains(name);
        }

        public static void ThrowGLError(ErrorCode error)
        {
            var lastError = string.Format("{0} [{1}]", error.ToString("f"), (int)error);
            throw new Exception("GL Error: " + lastError);
        }

        public static void CheckGL()
        {
            var err = GL.GetError();
            if (err == ErrorCode.NoError)
                return;

            ThrowGLError(err);
        }
    }
}
