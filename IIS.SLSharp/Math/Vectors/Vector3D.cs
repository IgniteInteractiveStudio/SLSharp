using System;
using System.Runtime.InteropServices;

namespace IIS.SLSharp.Math.Vectors
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector3D
    {
        public Vector3D(double[] arr)
        {
            if (arr.Length != 3)
                throw new ArgumentException("Array length must be 3.", "arr");

            _arr = arr;
            X = arr[0];
            Y = arr[1];
            Z = arr[2];
        }

        public unsafe Vector3D(double* ptr)
        {
            _arr = null;
            X = *ptr;
            Y = *(ptr + 1);
            Z = *(ptr + 2);
        }

        private double[] _arr;

        public double X;

        public double Y;

        public double Z;

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
            get { return _arr ?? (_arr = new[] { X, Y, Z }); }
        }
    }
}
