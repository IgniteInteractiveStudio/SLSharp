using System;
using System.Runtime.InteropServices;

namespace IIS.SLSharp.Math.Vectors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector3B
    {
        public Vector3B(bool[] arr)
        {
            if (arr.Length != 3)
                throw new ArgumentException("Array length must be 3.", "arr");

            _arr = arr;
            X = arr[0];
            Y = arr[1];
            Z = arr[2];
        }

        public unsafe Vector3B(bool* ptr)
        {
            _arr = null;
            X = *ptr;
            Y = *(ptr + 1);
            Z = *(ptr + 2);
        }

        private bool[] _arr;

        public bool X;

        public bool Y;

        public bool Z;

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
            get { return _arr ?? (_arr = new[] { X, Y, Z }); }
        }
    }
}
