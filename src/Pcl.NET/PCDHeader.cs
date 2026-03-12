using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    [DebuggerDisplay("width={width}, height={height}, point_step={point_step}, row_step={row_step}")]
    public struct PCDHeader
    {
        public uint width;
        public uint height;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public PclPointField[] fields;
        public uint point_step;
        public uint row_step;
        public uint is_dense;
        public DataType data_type;
        public uint data_idx;
    }
    [DebuggerDisplay("name={name}, offset={offset}, datatype={datatype}, count={count}")]
    public struct PclPointField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string name;
        public int offset;
        public PclPointFieldDataType datatype;
        public int count;
    }
    public enum PclPointFieldDataType : byte
    {
        INT8 = 1,
        UINT8 = 2,
        INT16 = 3,
        UINT16 = 4,
        INT32 = 5,
        UINT32 = 6,
        FLOAT32 = 7,
        FLOAT64 = 8,
        INT64 = 9,
        UINT64 = 10,
        BOOL = 11,
    }

    public enum DataType : int
    {
        Ascii,
        Binary,
        BinaryCompressed
    }
}
