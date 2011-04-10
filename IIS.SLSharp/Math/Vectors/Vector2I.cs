using System;
using System.Runtime.InteropServices;

namespace IIS.SLSharp.Math.Vectors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector2I
    {
        public Vector2I(int[] arr)
        {
            if (arr.Length != 2)
                throw new ArgumentException("Array length must be 2.", "arr");

            _arr = arr;
            X = arr[0];
            Y = arr[1];
        }

        public unsafe Vector2I(int* ptr)
        {
            _arr = null;
            X = *ptr;
            Y = *(ptr + 1);
        }

        private int[] _arr;

        public int X;

        public int Y;

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
            get { return _arr ?? (_arr = new[] { X, Y }); }
        }
    }
}
