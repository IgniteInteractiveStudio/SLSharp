using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Axiom.Graphics;
using IIS.SLSharp.Bindings.Axiom;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Examples.Axiom.GeoClipmap.GeoClipmap
{
    public class Patch : IDisposable
    {
        private HardwareVertexBuffer _vb;

        private HardwareIndexBuffer _ib;

        private VertexDeclaration _vertexDeclaration;

        internal VertexData VertexData { get; private set; }

        internal IndexData IndexData { get; private set; }

        public int Height { get; private set; }

        public int Width { get; private set; }


        private void CreateBuffers(ushort[] indices, short[] vertices)
        {
            var numIndices = indices.Length;
            var numVertices = vertices.Length;

            _vertexDeclaration = HardwareBufferManager.Instance.CreateVertexDeclaration();
            _vertexDeclaration.AddElement(0, 0, VertexElementType.Short2, VertexElementSemantic.Position);
            _ib = HardwareBufferManager.Instance.CreateIndexBuffer(IndexType.Size16, numIndices, BufferUsage.WriteOnly);
            _vb = HardwareBufferManager.Instance.CreateVertexBuffer(_vertexDeclaration, numVertices, BufferUsage.WriteOnly, false);

            _ib.WriteData(0, numIndices * sizeof(ushort), indices, true);
            _vb.WriteData(0, numVertices * sizeof(ushort), vertices, true);

            var binding = new VertexBufferBinding();
            binding.SetBinding(0, _vb);

            VertexData = new VertexData();
            VertexData.vertexDeclaration = _vertexDeclaration;
            VertexData.vertexBufferBinding = binding;
            VertexData.vertexCount = numVertices;
            VertexData.vertexStart = 0;

            IndexData = new IndexData();
            IndexData.indexBuffer = _ib;
            IndexData.indexCount = numIndices;
            IndexData.indexStart = 0;
        }


       
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

            CreateBuffers(indices, vertices);

            Width = m - 1;
            Height = n - 1;
        }

        protected internal Patch(int m, int n)
        {
            Generate(m, n);
        }

        protected internal Patch(int n)
        {
            // ib = (1 2 3) (3 4 5) (5 6 7) (7 8 9) (9 10 11) (11 12 13) (13 14 15)
            var indices = new ushort[(n / 2 * 3) * 4];
            var vertices = new short[(2 * n) * 4];
            var i = 0;
            var j = 0;

            // bottom
            for (var x = 0; x < n; x++)
            {
                vertices[i++] = (short)x;
                vertices[i++] = 0;
            }

            for (var x = 0; x < n - 1; x += 2)
            {
                indices[j++] = (ushort)(x + 2);
                indices[j++] = (ushort)(x + 1);
                indices[j++] = (ushort)x;
            }

            // top
            for (var x = 0; x < n; x++)
            {
                vertices[i++] = (short)x;
                vertices[i++] = (short)(n - 1);
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

            CreateBuffers(indices, vertices);

            Width = 0;
            Height = 0;
        }

        // cant override? well mogre wont be able to manage it! ...
        public virtual void Dispose()
        {
            _ib.Dispose();
            _vb.Dispose();
        }
    }
}
