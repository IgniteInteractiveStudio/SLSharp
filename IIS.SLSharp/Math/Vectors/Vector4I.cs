using System;
using System.Runtime.InteropServices;

namespace IIS.SLSharp.Math.Vectors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector4I
    {
        public Vector4I(int[] arr)
        {
            if (arr.Length != 4)
                throw new ArgumentException("Array length must be 4.", "arr");

            _arr = arr;
            X = arr[0];
            Y = arr[1];
            Z = arr[2];
            W = arr[3];
        }

        public unsafe Vector4I(int* ptr)
        {
            _arr = null;
            X = *ptr;
            Y = *(ptr + 1);
            Z = *(ptr + 2);
            W = *(ptr + 3);
        }

        private int[] _arr;

        public int X;

        public int Y;

        public int Z;

        public int W;

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
            get { return _arr ?? (_arr = new[] { X, Y, Z, W }); }
        }
    }
}
