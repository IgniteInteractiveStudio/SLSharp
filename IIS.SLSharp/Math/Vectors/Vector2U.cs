using System;
using System.Runtime.InteropServices;

namespace IIS.SLSharp.Math.Vectors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector2U
    {
        public Vector2U(uint[] arr)
        {
            if (arr.Length != 2)
                throw new ArgumentException("Array length must be 2.", "arr");

            _arr = arr;
            X = arr[0];
            Y = arr[1];
        }

        public unsafe Vector2U(uint* ptr)
        {
            _arr = null;
            X = *ptr;
            Y = *(ptr + 1);
        }

        private uint[] _arr;

        public uint X;

        public uint Y;

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
            get { return _arr ?? (_arr = new[] { X, Y }); }
        }
    }
}
