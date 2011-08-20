using System;
using System.Diagnostics.Contracts;

namespace IIS.SLSharp.Examples.MOGRE.GeoClipmap.GeoClipmap
{
    public struct IntFloatVector2 : IEquatable<IntFloatVector2>
    {
        public readonly IntFloat X;

        public readonly IntFloat Y;

        public IntFloatVector2(IntFloat x, IntFloat y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(IntFloatVector2 lhs, IntFloatVector2 rhs)
        {
            return (lhs.X == rhs.X) && (lhs.Y == rhs.Y);
        }

        public static bool operator !=(IntFloatVector2 lhs, IntFloatVector2 rhs)
        {
            return (lhs.X != rhs.X) || (lhs.Y != rhs.Y);
        }

        [Pure]
        public IntFloatVector2 MoveBy(int dx, int dy)
        {
            return new IntFloatVector2(X + dx, Y + dy);
        }

        [Pure]
        public IntFloatVector2 MoveBy(float dx, float dy)
        {
            return MoveBy(new IntFloat(dx), new IntFloat(dy));
        }

        [Pure]
        public IntFloatVector2 MoveBy(IntFloat dx, IntFloat dy)
        {
            return new IntFloatVector2(X + dx, Y + dy);
        }

        [Pure]
        public IntFloatVector2 Div2()
        {
            return new IntFloatVector2(X.Div2(), Y.Div2());
        }

        [Pure]
        public IntFloatVector2 Mul2()
        {
            return new IntFloatVector2(X.Mul2(), Y.Mul2());
        }

        public bool Equals(IntFloatVector2 other)
        {
            return other.X.Equals(X) && other.Y.Equals(Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is IntFloatVector2 && Equals((IntFloatVector2)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 419) ^ Y.GetHashCode();
            }
        }

        
    }
}
