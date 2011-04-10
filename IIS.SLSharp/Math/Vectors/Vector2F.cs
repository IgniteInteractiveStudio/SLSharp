using System;
using System.Runtime.InteropServices;

namespace IIS.SLSharp.Math.Vectors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector2F
    {
        public Vector2F(float[] arr)
        {
            if (arr.Length != 2)
                throw new ArgumentException("Array length must be 2.", "arr");

            _arr = arr;
            X = arr[0];
            Y = arr[1];
        }

        public unsafe Vector2F(float* ptr)
        {
            _arr = null;
            X = *ptr;
            Y = *(ptr + 1);
        }

        private float[] _arr;

        public float X;

        public float Y;

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
            get { return _arr ?? (_arr = new[] { X, Y }); }
        }
    }
}
