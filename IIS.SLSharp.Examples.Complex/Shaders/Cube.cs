using System;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Examples.Complex.Shaders
{
    public sealed class Cube : IDisposable
    {
        private int _vbo;

        private int _ibo;

        private readonly int _numIndices;

        public Cube()
        {
            GL.GenBuffers(1, out _vbo);
            GL.GenBuffers(1, out _ibo);

            var vertices = new[]
            {
                new Vector3(-1.0f, -1.0f, -1.0f),
                new Vector3(1.0f, -1.0f, -1.0f),
                new Vector3(-1.0f, 1.0f, -1.0f),
                new Vector3(1.0f, 1.0f, -1.0f),
                new Vector3(-1.0f, -1.0f, 1.0f),
                new Vector3(1.0f, -1.0f, 1.0f),
                new Vector3(-1.0f, 1.0f, 1.0f),
                new Vector3(1.0f, 1.0f, 1.0f),
            };

            var indices = new short[]
            {
                2, 3, 1, 0, // back
                4, 6, 2, 0, // left
                1, 3, 7, 5, // right
                4, 5, 7, 6, // front
                0, 1, 5, 4, // bottom
                6, 7, 3, 2, // top
            };

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(Marshal.SizeOf(typeof(Vector3)) * vertices.Length), 
                vertices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _ibo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(sizeof(short) * indices.Length),
                indices, BufferUsageHint.StaticDraw);
            _numIndices = indices.Length;
        }

        public void Dispose()
        {
            GL.DeleteBuffers(1, ref _vbo);
            GL.DeleteBuffers(1, ref _ibo);
        }

        public void Render(int vertexLocation)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _ibo);
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.DrawElements(BeginMode.Quads, _numIndices, DrawElementsType.UnsignedShort, 0);            
            GL.DisableVertexAttribArray(vertexLocation);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }
    }
}
