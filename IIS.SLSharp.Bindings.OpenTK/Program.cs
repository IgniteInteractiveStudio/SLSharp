using System;
using System.Collections.Generic;
using IIS.SLSharp.Descriptions;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Bindings.OpenTK
{
    sealed class Program: IProgram
    {
        private int _name;

        public List<VariableDescription> VertexIns { get; private set; }

        public Program(IEnumerable<Tuple<int, SourceDescription>> units)
        {
            _name = GL.CreateProgram();

            var merged = SourceDescription.Empty;
            foreach (var unit in units)
            {
                GL.AttachShader(_name, unit.Item1);
                merged = merged.Merge(unit.Item2);
            }
            VertexIns = merged.VertexIns;

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

        public void Finish()
        {
            GL.UseProgram(0);
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