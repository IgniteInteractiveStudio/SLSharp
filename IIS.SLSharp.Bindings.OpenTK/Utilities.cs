using System;
using System.Linq;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp
{
    public static class Utilities
    {
        public static bool IsVersion(int major, int minor = 0)
        {
            var s = GL.GetString(StringName.Version);

            var idx = s.IndexOf(' ');
            if (idx != -1)
                s = s.Substring(0, idx);

            var v = s.Split('.').Select(x => int.Parse(x)).ToArray();

            if (v[0] > major)
                return true;

            if (v[0] < major)
                return false;

            return v[1] >= minor;
        }
        
        public static bool HasExtension(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");

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

        internal static void ThrowGLError(ErrorCode error)
        {
            var lastError = string.Format("{0} [{1}]", error.ToString("f"), (int)error);
            throw new SLSharpException("GL Error: " + lastError);
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
