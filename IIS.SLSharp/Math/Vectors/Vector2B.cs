using System;
using System.Runtime.InteropServices;

namespace IIS.SLSharp.Math.Vectors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector2B
    {
        public Vector2B(bool[] arr)
        {
            if (arr.Length != 2)
                throw new ArgumentException("Array length must be 2.", "arr");

            _arr = arr;
            X = arr[0];
            Y = arr[1];
        }

        public unsafe Vector2B(bool* ptr)
        {
            _arr = null;
            X = *ptr;
            Y = *(ptr + 1);
        }

        private bool[] _arr;

        public bool X;

        public bool Y;

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
            get { return _arr ?? (_arr = new[] { X, Y }); }
        }
    }
}
