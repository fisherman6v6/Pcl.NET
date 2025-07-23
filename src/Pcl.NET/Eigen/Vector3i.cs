using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Pcl.NET.Eigen
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    [DebuggerDisplay("{X}, {Y}, {Z}")]
    public struct Vector3i : IEquatable<Vector3i>
    {
        [FieldOffset(0)]
        public int X;

        [FieldOffset(4)]
        public int Y;

        [FieldOffset(8)]
        public int Z;

        [FieldOffset(0)]
        public unsafe fixed int data[4];

        public override bool Equals(object? obj)
        {
            return obj is Vector3i i && Equals(i);
        }

        public readonly bool Equals(Vector3i other)
        {
            return X == other.X &&
                   Y == other.Y &&
                   Z == other.Z;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public static bool operator ==(Vector3i left, Vector3i right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector3i left, Vector3i right)
        {
            return !(left == right);
        }
    }
}
