using System;
using System.Runtime.InteropServices;

namespace IIS.SLSharp.Math.Vectors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector4U
    {
        public Vector4U(uint[] arr)
        {
            if (arr.Length != 4)
                throw new ArgumentException("Array length must be 4.", "arr");

            _arr = arr;
            X = arr[0];
            Y = arr[1];
            Z = arr[2];
            W = arr[3];
        }

        public unsafe Vector4U(uint* ptr)
        {
            _arr = null;
            X = *ptr;
            Y = *(ptr + 1);
            Z = *(ptr + 2);
            W = *(ptr + 3);
        }

        private uint[] _arr;

        public uint X;

        public uint Y;

        public uint Z;

        public uint W;

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
            get { return _arr ?? (_arr = new[] { X, Y, Z, W }); }
        }
    }
}
