using System;
using System.Collections.Generic;
using IIS.SLSharp.Descriptions;
using OpenTK.Graphics.OpenGL;
using System.Linq;

namespace IIS.SLSharp.Bindings.OpenTK
{
    sealed class Program: IProgram
    {
        public int Name { get; private set; }

        public List<VariableDescription> VertexIns { get; private set; }

        public Program(IEnumerable<Tuple<int, SourceDescription>> units)
        {
            Name = GL.CreateProgram();

            var merged = SourceDescription.Empty;
            foreach (var unit in units)
            {
                GL.AttachShader(Name, unit.Item1);
                merged = merged.Merge(unit.Item2);
            }
            VertexIns = merged.VertexIns;

            GL.LinkProgram(Name);
            Utilities.CheckGL();
        }

        public void Dispose()
        {
            if (Name != 0)
                GL.DeleteProgram(Name);
            Name = 0;
        }

        public void Activate()
        {
            GL.UseProgram(Name);
            Utilities.CheckGL();
        }

        public void Finish()
        {
            GL.UseProgram(0);
        }

        public int GetUniformIndex(string name)
        {
            var result = GL.GetUniformLocation(Name, name);
            Utilities.CheckGL();
            return result;
        }

        public int GetAttributeIndex(string name)
        {
            var result = GL.GetAttribLocation(Name, name);
            Utilities.CheckGL();
            return result;
        }

        public Tuple<byte[], BinaryFormat> GetBinary()
        {
            int length;
            GL.GetProgram(Name, ProgramParameter.ProgramBinaryLength, out length);

            var bin = new byte[length];
            BinaryFormat format;
            int numRead;
            GL.GetProgramBinary(Name, length, out numRead, out format, bin);
            if (numRead < length)
                bin = bin.Take(length).ToArray();

            return new Tuple<byte[], BinaryFormat>(bin, format);
        }
    }
}