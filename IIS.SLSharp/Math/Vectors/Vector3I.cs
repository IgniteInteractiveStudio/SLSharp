using System;
using System.Runtime.InteropServices;

namespace IIS.SLSharp.Math.Vectors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector3I
    {
        public Vector3I(int[] arr)
        {
            if (arr.Length != 3)
                throw new ArgumentException("Array length must be 3.", "arr");

            _arr = arr;
            X = arr[0];
            Y = arr[1];
            Z = arr[2];
        }

        public unsafe Vector3I(int* ptr)
        {
            _arr = null;
            X = *ptr;
            Y = *(ptr + 1);
            Z = *(ptr + 2);
        }

        private int[] _arr;

        public int X;

        public int Y;

        public int Z;

        internal unsafe int* Pointer
        {
            get
            {
                fixed (int* x = &X)
                    return x;
            }
        }

        internal int[] Array
        {
            get { return _arr ?? (_arr = new[] { X, Y, Z }); }
        }
    }
}
