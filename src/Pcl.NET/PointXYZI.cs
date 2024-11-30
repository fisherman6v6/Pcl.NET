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
    [DebuggerDisplay("{V}, {Label}")]
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public unsafe struct PointXYZI
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
        public uint Intensity;
    }
}
