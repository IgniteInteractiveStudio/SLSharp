using System;
using System.Runtime.InteropServices;

namespace IIS.SLSharp.Math.Vectors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector4F
    {
        public Vector4F(float[] arr)
        {
            if (arr.Length != 4)
                throw new ArgumentException("Array length must be 4.", "arr");

            _arr = arr;
            X = arr[0];
            Y = arr[1];
            Z = arr[2];
            W = arr[3];
        }

        public unsafe Vector4F(float* ptr)
        {
            _arr = null;
            X = *ptr;
            Y = *(ptr + 1);
            Z = *(ptr + 2);
            W = *(ptr + 3);
        }

        private float[] _arr;

        public float X;

        public float Y;

        public float Z;

        public float W;

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
            get { return _arr ?? (_arr = new[] { X, Y, Z, W }); }
        }
    }
}
