using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET.Eigen
{
    [DebuggerDisplay("{X}, {Y}, {Z}")]
    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public unsafe struct Vector3f : IEquatable<Vector3f>
    {
        [FieldOffset(0)]
        public float X;
        [FieldOffset(4)]
        public float Y;
        [FieldOffset(8)]
        public float Z;

        [FieldOffset(0)]
        public fixed int data[3];

        public Vector3f(float x, float y, float z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override readonly bool Equals(object? obj)
        {
            return obj is Vector3f f && Equals(f);
        }

        public readonly bool Equals(Vector3f other)
        {
            return X == other.X &&
                   Y == other.Y &&
                   Z == other.Z;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public static bool operator ==(Vector3f left, Vector3f right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector3f left, Vector3f right)
        {
            return !(left == right);
        }
    }
}
