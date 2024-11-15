using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Pcl.NET
{
  [StructLayout(LayoutKind.Explicit, Size = 16)]
  [DebuggerDisplay("{V}")]
  public struct PointXYZ
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
