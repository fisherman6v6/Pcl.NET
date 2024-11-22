using System.Runtime.InteropServices;

namespace Pcl.NET.Eigen
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct Quaternionf
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

        public Quaternionf(float x, float y, float z, float w)
        {
            X = x; 
            Y = y; 
            Z = z; 
            W = w;
        }

        public Quaternionf()
        {
            X = 0;
            Y = 0;
            Z = 0;
            W = 0;
        }

        public static implicit operator System.Numerics.Quaternion(Quaternionf qf) => new(qf.X, qf.Y, qf.Z, qf.W);

        public static implicit operator Quaternionf(System.Numerics.Quaternion q) => new(q.X, q.Y, q.Z, q.W); 
    }
}
