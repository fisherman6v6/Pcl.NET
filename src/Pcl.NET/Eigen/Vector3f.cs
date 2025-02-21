﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET.Eigen
{
    [DebuggerDisplay("{X}, {Y}, {Z}")]
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public unsafe struct Vector3f
    {
        [FieldOffset(0)]
        public float X;
        [FieldOffset(4)]
        public float Y;
        [FieldOffset(8)]
        public float Z;

        [FieldOffset(0)]
        public fixed int data[4];
    }
}
