using System.Runtime.InteropServices;

namespace Pcl.NET.Eigen
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct Vector4f
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

        public Vector4f(float x, float y, float z, float w)
        {
            X = x; 
            Y = y; 
            Z = z; 
            W = w;
        }

        public Vector4f()
        {
            X = 0;
            Y = 0;
            Z = 0;
            W = 0;
        }

        public static implicit operator System.Numerics.Vector4(Vector4f v) => new(v.X, v.Y, v.Z, v.W);

        public static implicit operator Vector4f(System.Numerics.Vector4 v) => new(v.X, v.Y, v.Z, v.W);
    }
}
