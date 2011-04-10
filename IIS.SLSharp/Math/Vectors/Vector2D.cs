using System;
using System.Runtime.InteropServices;

namespace IIS.SLSharp.Math.Vectors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector2D
    {
        public Vector2D(double[] arr)
        {
            if (arr.Length != 2)
                throw new ArgumentException("Array length must be 2.", "arr");

            _arr = arr;
            X = arr[0];
            Y = arr[1];
        }

        public unsafe Vector2D(double* ptr)
        {
            _arr = null;
            X = *ptr;
            Y = *(ptr + 1);
        }

        private double[] _arr;

        public double X;

        public double Y;

        internal unsafe double* Pointer
        {
            get
            {
                fixed (double* x = &X)
                    return x;
            }
        }

        internal double[] Array
        {
            get { return _arr ?? (_arr = new[] { X, Y }); }
        }
    }
}
