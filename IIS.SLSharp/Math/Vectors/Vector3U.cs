using System;
using System.Runtime.InteropServices;

namespace IIS.SLSharp.Math.Vectors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector3U
    {
        public Vector3U(uint[] arr)
        {
            if (arr.Length != 3)
                throw new ArgumentException("Array length must be 3.", "arr");

            _arr = arr;
            X = arr[0];
            Y = arr[1];
            Z = arr[2];
        }

        public unsafe Vector3U(uint* ptr)
        {
            _arr = null;
            X = *ptr;
            Y = *(ptr + 1);
            Z = *(ptr + 2);
        }

        private uint[] _arr;

        public uint X;

        public uint Y;

        public uint Z;

        internal unsafe uint* Pointer
        {
            get
            {
                fixed (uint* x = &X)
                    return x;
            }
        }

        internal uint[] Array
        {
            get { return _arr ?? (_arr = new[] { X, Y, Z }); }
        }
    }
}
