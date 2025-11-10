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
    /// Represents a three-dimensional point with single-precision coordinates and an associated RGBA color value.
    /// </summary>
    /// <remarks>This structure is commonly used in point cloud processing and 3D graphics to store both
    /// spatial position and color information for a point. The X, Y, and Z fields specify the position in 3D space,
    /// while the RGBA value encodes the color using red, green, blue, and alpha (transparency) components. Equality and
    /// hash code operations are based on both position and color values.</remarks>
    [DebuggerDisplay("{V}, {RGBA.ToString(\"X8\")}")]
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public unsafe struct PointXYZRGBA : IEquatable<PointXYZRGBA>
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
        public fixed float data[4];

        [FieldOffset(16)]
        public byte B;
        [FieldOffset(17)]
        public byte G;
        [FieldOffset(18)]
        public byte R;
        [FieldOffset(19)]
        public byte A;

        [FieldOffset(16)]
        public uint RGBA;
        [FieldOffset(16)]
        public fixed float data_c[4];

        public override readonly bool Equals(object? obj)
        {
            return obj is PointXYZRGBA xYZRGBA && Equals(xYZRGBA);
        }

        public readonly bool Equals(PointXYZRGBA other)
        {
            return X == other.X &&
                   Y == other.Y &&
                   Z == other.Z &&
                   B == other.B &&
                   G == other.G &&
                   R == other.R &&
                   A == other.A;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z, B, G, R, A);
        }

        public static bool operator ==(PointXYZRGBA left, PointXYZRGBA right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PointXYZRGBA left, PointXYZRGBA right)
        {
            return !(left == right);
        }
    }
}
