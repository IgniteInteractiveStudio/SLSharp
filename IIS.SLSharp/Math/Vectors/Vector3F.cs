using System;
using System.Runtime.InteropServices;

namespace IIS.SLSharp.Math.Vectors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector3F
    {
        public Vector3F(float[] arr)
        {
            if (arr.Length != 3)
                throw new ArgumentException("Array length must be 3.", "arr");

            _arr = arr;
            X = arr[0];
            Y = arr[1];
            Z = arr[2];
        }

        public unsafe Vector3F(float* ptr)
        {
            _arr = null;
            X = *ptr;
            Y = *(ptr + 1);
            Z = *(ptr + 2);
        }

        private float[] _arr;

        public float X;

        public float Y;

        public float Z;

        internal unsafe float* Pointer
        {
            get
            {
                fixed (float* x = &X)
                    return x;
            }
        }

        internal float[] Array
        {
            get { return _arr ?? (_arr = new[] { X, Y, Z }); }
        }
    }
}
