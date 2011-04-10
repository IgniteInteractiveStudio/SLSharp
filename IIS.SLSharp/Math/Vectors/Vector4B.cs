using System;
using System.Runtime.InteropServices;

namespace IIS.SLSharp.Math.Vectors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector4B
    {
        public Vector4B(bool[] arr)
        {
            if (arr.Length != 4)
                throw new ArgumentException("Array length must be 4.", "arr");

            _arr = arr;
            X = arr[0];
            Y = arr[1];
            Z = arr[2];
            W = arr[3];
        }

        public unsafe Vector4B(bool* ptr)
        {
            _arr = null;
            X = *ptr;
            Y = *(ptr + 1);
            Z = *(ptr + 2);
            W = *(ptr + 3);
        }

        private bool[] _arr;

        public bool X;

        public bool Y;

        public bool Z;

        public bool W;

        internal unsafe bool* Pointer
        {
            get
            {
                fixed (bool* x = &X)
                    return x;
            }
        }

        internal bool[] Array
        {
            get { return _arr ?? (_arr = new[] { X, Y, Z, W }); }
        }
    }
}
