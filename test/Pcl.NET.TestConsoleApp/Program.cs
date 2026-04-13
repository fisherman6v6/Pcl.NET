using ComputeSharp;
using System.Collections;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Loader;

namespace Pcl.NET.TestConsoleApp
{
    internal unsafe partial class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\alessandro.fici\Desktop\pc\table_scene_lms400.pcd";
            var cloud = PointCloudXYZ.Load(path);

            StatisticalOutlierRemovalPointXYZ so = new();
            so.Input = cloud;
            so.MeanK = 50;
            so.StddevMulThresh = 1;
            var filtered = so.ApplyFilter() as PointCloudXYZ;

            IO.SavePointCloudXYZBinary(@"C:\Users\alessandro.fici\Desktop\pc\filtered.pcd", filtered);

            //var array = cloud.Points.ToGpuArray();

            //using ReadWriteBuffer<PointXYZGpu> gpuBuffer = GraphicsDevice.GetDefault().AllocateReadWriteBuffer(array);
            //var shader = new DivideZByTwo(gpuBuffer);

            //GraphicsDevice.GetDefault().For((int)cloud.Count, shader);

            //gpuBuffer.CopyTo(array);

        }

        [ThreadGroupSize(DefaultThreadGroupSizes.X)]
        [GeneratedComputeShaderDescriptor]
        internal readonly partial struct DivideZByTwo(ReadWriteBuffer<PointXYZGpu> buffer) : IComputeShader
        {
            /// <inheritdoc/>
            public void Execute()
            {
                var p = buffer[ThreadIds.X];
                var np = new PointXYZGpu();
                np.X = p.X;
                np.Y = p.Y;
                np.Z = p.Z * 2;
                buffer[ThreadIds.X] = np;
            }
        }

    }

    internal static class Extensions
    {
        public static PointXYZGpu[] ToGpuArray(this Vector<PointXYZ> @this)
        {
            PointXYZGpu[] arr = new PointXYZGpu[@this.Count];
            for (int i = 0; i < @this.Count; i++)
            {
                arr[i] = new PointXYZGpu
                {
                    X = @this[i].X,
                    Y = @this[i].Y,
                    Z = @this[i].Z
                };
            }

            return arr;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PointXYZGpu
    {
        public float X;
        public float Y;
        public float Z;
        // aling to 16 byte
        public float Padding;

        public PointXYZGpu(float x, float y, float z) : this()
        {
            X = x;
            Y = y;
            Z = z;
            Padding = 0;
        }
    }
}
