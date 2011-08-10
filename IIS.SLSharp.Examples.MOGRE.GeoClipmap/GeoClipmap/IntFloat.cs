using System;
using System.Diagnostics.Contracts;

namespace IIS.SLSharp.Examples.MOGRE.GeoClipmap.GeoClipmap
{
    /// <summary>
    /// Utility struct to encode high precision map locations
    /// Data is stored as lossless integral part and lossy (due to rounding precision)
    /// fractional part.
    /// The fractional part is always kept in range [0..1)
    /// This implies that rounding realted logic is always towards +inf
    /// -0.4 for example will be encoded as -1 + 0.6 rather than 0 + -0.4
    /// Also notice that there is no way to encode -0 as you can do with floats.
    /// </summary>
    public struct IntFloat: IEquatable<IntFloat>
    {
        private const float Epsilon = 5.96e-08f;

        /// <summary>
        /// 32bit Integral part of the IntFloat 
        /// </summary>
        public readonly int Integer;

        /// <summary>
        /// Fractional part [0..1) of the IntFloat
        /// </summary>
        public readonly float Fraction;

        public IntFloat(float f)
        {
            var integral = (float)Math.Floor(f);
            Fraction = f - integral;
            Integer = (int)integral;
        }

        public IntFloat(int i)
        {
            Integer = i;
            Fraction = 0.0f;
        }

        public IntFloat(int i, float f) : this(f)
        {
            Integer += i;
        }


        public static IntFloat operator +(IntFloat lhs, IntFloat rhs)
        {
            return new IntFloat(lhs.Integer + rhs.Integer, lhs.Fraction + rhs.Fraction);
        }

        public static IntFloat operator +(IntFloat lhs, int rhs)
        {
            return new IntFloat(lhs.Integer + rhs, lhs.Fraction);
        }


        public static IntFloat operator -(IntFloat lhs, IntFloat rhs)
        {
            return new IntFloat(lhs.Integer - rhs.Integer, lhs.Fraction - rhs.Fraction);
        }

        public static IntFloat operator -(IntFloat lhs, int rhs)
        {
            return new IntFloat(lhs.Integer - rhs, lhs.Fraction);
        }

        public static bool operator ==(IntFloat lhs, IntFloat rhs)
        {
            return (lhs.Integer == rhs.Integer) && (Math.Abs(lhs.Fraction - rhs.Fraction) < Epsilon);
        }

        public static bool operator !=(IntFloat lhs, IntFloat rhs)
        {
            return (lhs.Integer != rhs.Integer) || (Math.Abs(lhs.Fraction - rhs.Fraction) > Epsilon);
        }

        /// <summary>
        /// Shorthand version for x = y+y
        /// </summary>
        [Pure]
        public IntFloat Mul2()
        {
            return this + this;
        }

        /// <summary>
        /// Calculates 0.5 * this
        /// </summary>
        [Pure]
        public IntFloat Div2()
        {
            // sign extended carry (+1 or -1 iff lowest bit is set, 0 otherwise)
            var carry = Math.Sign(Integer) * (Integer & 1);
 

            var integral = Integer / 2;
            var fraction = (Fraction + carry) * 0.5f;

            // use the safe ctor here in order to avoid 2 compares
            return new IntFloat(integral, fraction);
        }

        public bool Equals(IntFloat other)
        {
            return other.Integer == Integer && other.Fraction.Equals(Fraction);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is IntFloat && Equals((IntFloat)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Integer * 397) ^ Fraction.GetHashCode();
            }
        }
    }
}
