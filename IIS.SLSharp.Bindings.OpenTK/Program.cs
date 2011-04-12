using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Bindings.OpenTK
{
    sealed class Program: IProgram
    {
        private int _name;

        public Program(IEnumerable<object> units)
        {
            _name = GL.CreateProgram();

            foreach (var unit in units)
                GL.AttachShader(_name, (int)unit);
            GL.LinkProgram(_name);
            Utilities.CheckGL();
        }

        public void Dispose()
        {
            if (_name != 0)
                GL.DeleteProgram(_name);
            _name = 0;
        }

        public void Activate()
        {
            GL.UseProgram(_name);
            Utilities.CheckGL();
        }

        public int GetUniformIndex(string name)
        {
            var result = GL.GetUniformLocation(_name, name);
            Utilities.CheckGL();
            return result;
        }

        public int GetAttributeIndex(string name)
        {
            var result = GL.GetAttribLocation(_name, name);
            Utilities.CheckGL();
            return result;
        }
    }
}