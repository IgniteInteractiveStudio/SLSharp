using System;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Examples.GeoClipmap.Clipmap
{
    // Managed Resource:
    // Dispose() must be virtual and the class may not be sealed
    public abstract class Patch : IDisposable
    {
        private int _vb, _ib;

        private int _indexCount;

        private int _vertexCount;

        public int Height { get; private set; }

        public int Width { get; private set; }

        private static int _currentIndexBuffer;

        private static int _currentVertexBuffer;

        private void Generate(int m, int n)
        {
            // TODO: optimize patches for vertex caching!

            var indices = new ushort[2 * 3 * (m - 1) * (n - 1)];
            var vertices = new short[2 * m * n];

            var i = 0;
            for (var y = 0; y < n; y++)
            {
                for (var x = 0; x < m; x++)
                {
                    vertices[i++] = (short)x;
                    vertices[i++] = (short)y;
                }
            }

            i = 0;
            for (var y = 0; y < n - 1; y++)
            {
                for (var x = 0; x < m - 1; x++)
                {
                    var current = x + y * m;

                    indices[i++] = (ushort)current;
                    indices[i++] = (ushort)(current + 1);
                    indices[i++] = (ushort)(current + m);

                    indices[i++] = (ushort)(current + 1);
                    indices[i++] = (ushort)(current + m + 1);
                    indices[i++] = (ushort)(current + m);
                }
            }

            // TODO: permutate indices here to optimize vertex caching
            // it would theoretically be possible to share a single
            // vertex buffer as well if vertex caching can still be maintained
            // with this

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _ib);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indices.Length * sizeof(ushort)),
                          indices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            _indexCount = indices.Length;

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vb);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Length * sizeof(ushort)),
                          vertices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            _vertexCount = vertices.Length;

            Width = m - 1;
            Height = n - 1;
        }

        // this creates the degenerated patch
        protected Patch(int n)
        {
            GL.GenBuffers(1, out _ib);
            GL.GenBuffers(1, out _vb);

            // ib = (1 2 3) (3 4 5) (5 6 7) (7 8 9) (9 10 11) (11 12 13) (13 14 15)
            var indices = new ushort[(n/2*3) * 4];
            var vertices = new short[(2*n) * 4];
            var i = 0;
            var j = 0;

            // bottom
            for (var x = 0; x < n; x++ )
            {
                vertices[i++] = (short)x;
                vertices[i++] = 0;
            }

            for (var x = 0; x < n-1; x += 2)
            {                
                indices[j++] = (ushort)(x + 2);
                indices[j++] = (ushort)(x + 1);
                indices[j++] = (ushort)x;
            }

            // top
            for (var x = 0; x < n; x++)
            {
                vertices[i++] = (short)x;
                vertices[i++] = (short)(n-1);
            }

            var start = n;
            for (var x = 0; x < n - 1; x += 2)
            {
                indices[j++] = (ushort)(start + x);
                indices[j++] = (ushort)(start + x + 1);
                indices[j++] = (ushort)(start + x + 2);
            }

            // left
            for (var x = 0; x < n; x++)
            {
                vertices[i++] = 0;
                vertices[i++] = (short)x;
            }

            start = n * 2;
            for (var x = 0; x < n - 1; x += 2)
            {
                indices[j++] = (ushort)(start + x);
                indices[j++] = (ushort)(start + x + 1);
                indices[j++] = (ushort)(start + x + 2);
            }

            // right
            for (var x = 0; x < n; x++)
            {
                vertices[i++] = (short)(n - 1);
                vertices[i++] = (short)x;
            }

            start = n * 3;
            for (var x = 0; x < n - 1; x += 2)
            {
                indices[j++] = (ushort)(start + x + 2);
                indices[j++] = (ushort)(start + x + 1);
                indices[j++] = (ushort)(start + x);
            }

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _ib);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indices.Length * sizeof(ushort)),
                          indices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            _indexCount = indices.Length;

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vb);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Length * sizeof(ushort)),
                          vertices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            _vertexCount = vertices.Length;

            Width = 0;
            Height = 0;
        }

        protected Patch(int m, int n)
        {
            GL.GenBuffers(1, out _ib);
            GL.GenBuffers(1, out _vb);
            Generate(m, n);
        }

        public virtual void Dispose()
        {
            if (_ib != 0)
                GL.DeleteBuffers(1, ref _ib);

            if (_vb != 0)
                GL.DeleteBuffers(1, ref _vb);

            _ib = 0;
            _vb = 0;
        }

        public static void ResetBinding()
        {
            GL.GetInteger(GetPName.ElementArrayBufferBinding, out _currentIndexBuffer);
            GL.GetInteger(GetPName.ArrayBufferBinding, out _currentVertexBuffer);
        }

        public void Activate(int vertexLocation)
        {
            if (_ib != _currentIndexBuffer)
            {
                _currentIndexBuffer = _ib;
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, _ib);
            }

            if (_vb != _currentVertexBuffer)
            {
                _currentVertexBuffer = _vb;
                GL.BindBuffer(BufferTarget.ArrayBuffer, _vb);
            }

            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 2, VertexAttribPointerType.Short, false, 0, 0);
        }

        public void Draw(int vertexLocation)
        {
            Activate(vertexLocation);
            GL.DrawRangeElements(BeginMode.Triangles, 0, _vertexCount, _indexCount,
                                 DrawElementsType.UnsignedShort, IntPtr.Zero);
        }
    }
}
