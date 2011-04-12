using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Bindings.OpenTK
{
    class Quad: IDisposable
    {
        private int _vbo;

        public Quad()
        {
            var data = new[]
            {
                new Vector2(-1.0f, -1.0f),
                new Vector2(1.0f, -1.0f),
                new Vector2(1.0f, 1.0f),
                new Vector2(-1.0f, 1.0f),
                new Vector2(0.0f, 0.0f),
                new Vector2(1.0f, 0.0f),
                new Vector2(1.0f, 1.0f),
                new Vector2(0.0f, 1.0f),
            };

            GL.GenBuffers(1, out _vbo);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(Marshal.SizeOf(typeof(Vector2)) * data.Length),
                data, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void Dispose()
        {
            if (_vbo != 0)
            {
                GL.DeleteBuffers(1, ref _vbo);
                _vbo = 0;
            }
        }

        public void Render(int posLocation, bool positive)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.VertexAttribPointer(posLocation, 2, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(posLocation);
            GL.DrawArrays(BeginMode.Quads, positive ? 4 : 0, 4);
            GL.DisableVertexAttribArray(posLocation);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
    }
}
