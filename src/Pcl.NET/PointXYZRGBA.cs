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
    [DebuggerDisplay("{V}, {RGBA.ToString(\"X8\")}")]
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public unsafe struct PointXYZRGBA
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
    }
}
