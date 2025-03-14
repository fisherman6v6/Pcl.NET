using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Pcl.NET.Eigen
{
    [DebuggerDisplay("{X}, {Y}, {Z}, {W}")]
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct Vector4f : IEquatable<Vector4f>
    {
        [FieldOffset(0)]
        public float X;

        [FieldOffset(4)]
        public float Y;

        [FieldOffset(8)]
        public float Z;

        [FieldOffset(12)]
        public float W;

        [FieldOffset(0)]
        public unsafe fixed float data[4];

        public Vector4f(float x, float y, float z, float w) : this()
        {
            X = x; 
            Y = y; 
            Z = z; 
            W = w;
        }

        public override readonly bool Equals(object? obj)
        {
            return obj is Vector4f f && Equals(f);
        }

        public readonly bool Equals(Vector4f other)
        {
            return X == other.X &&
                   Y == other.Y &&
                   Z == other.Z &&
                   W == other.W;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z, W);
        }

        public static bool operator ==(Vector4f left, Vector4f right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector4f left, Vector4f right)
        {
            return !(left == right);
        }

        public static implicit operator System.Numerics.Vector4(Vector4f v) => new(v.X, v.Y, v.Z, v.W);

        public static implicit operator Vector4f(System.Numerics.Vector4 v) => new(v.X, v.Y, v.Z, v.W);
    }
}
