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

        public Vector4f(System.Numerics.Vector4 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            W = v.W;
        }

        public Vector4f()
        {
            X = 0;
            Y = 0;
            Z = 0;
            W = 0;
        }
    }
}
