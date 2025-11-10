using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    /// <summary>
    /// Represents a three-dimensional point with an associated intensity value
    /// data processing.
    /// </summary>
    /// <remarks>The PointXYZI structure stores the X, Y, and Z coordinates along with an intensity value,
    /// allowing efficient access to both individual components and the combined vector representation.</remarks>
    [DebuggerDisplay("{V}, {Label}")]
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public unsafe struct PointXYZI : IEquatable<PointXYZI>
    {
        [FieldOffset(0)]
        public float X;
        [FieldOffset(4)]
        public float Y;
        [FieldOffset(8)]
        public float Z;

        [FieldOffset(0)]
        public fixed float data[4];
        [FieldOffset(0)]
        public Vector3 V;

        [FieldOffset(16)]
        public float Intensity;

        public PointXYZI(float x, float y, float z, float intensity) : this()
        {
            X = x;
            Y = y;
            Z = z;
            Intensity = intensity;
        }

        public override readonly bool Equals(object? obj)
        {
            return obj is PointXYZI xyzi && Equals(xyzi);
        }

        public readonly bool Equals(PointXYZI other)
        {
            return X == other.X &&
                   Y == other.Y &&
                   Z == other.Z &&
                   Intensity == other.Intensity;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z, Intensity);
        }

        public static bool operator ==(PointXYZI left, PointXYZI right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PointXYZI left, PointXYZI right)
        {
            return !(left == right);
        }
    }
}
