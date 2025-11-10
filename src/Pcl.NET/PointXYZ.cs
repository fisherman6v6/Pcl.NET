using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Pcl.NET
{
    /// <summary>
    /// Represents a three-dimensional point or vector with single-precision floating-point X, Y, and Z components.
    /// </summary>
    /// <remarks>The PointXYZ struct provides multiple ways to access its components, including individual X,
    /// Y, and Z fields, a Vector3 view, and a fixed-size float array. It supports value equality comparison and
    /// implicit conversions to and from Vector3</remarks>
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    [DebuggerDisplay("{V}")]
    public struct PointXYZ : IEquatable<PointXYZ>
    {
        [FieldOffset(0)]
        public float X;

        [FieldOffset(4)]
        public float Y;

        [FieldOffset(8)]
        public float Z;

        [FieldOffset(0)]
        public Vector3 V;

        [FieldOffset(0)]
        public unsafe fixed float data[4];

        public PointXYZ(float x, float y, float z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override readonly bool Equals(object? obj)
        {
            return obj is PointXYZ xyz && Equals(xyz);
        }

        public readonly bool Equals(PointXYZ other)
        {
            return X == other.X &&
                   Y == other.Y &&
                   Z == other.Z;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public static bool operator ==(PointXYZ left, PointXYZ right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PointXYZ left, PointXYZ right)
        {
            return !(left == right);
        }

        public static implicit operator PointXYZ(Vector3 v)
        {
            PointXYZ result = default;
            result.V = v;
            return result;
        }

        public static implicit operator Vector3(PointXYZ v)
        {
            return v.V;
        }
    }
}
