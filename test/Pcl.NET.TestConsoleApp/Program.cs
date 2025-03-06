using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

namespace Pcl.NET.TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pointcloudxyz = Pcl.NET.IO.LoadPointCloudXYZ(@"C:\Users\alessandro.fici\Desktop\PointClouds\XYZ100.pcd");
            var pointcloudxyzrgba = new PointCloudXYZRGBA();
            var s = pointcloudxyz.Points.AsSpan(0, (int)pointcloudxyz.Points.Count);
            var bar = new PointXYZ[100];
            pointcloudxyz.Points.CopyTo(bar, 0, bar.Length);

            for (int i = 0; i < pointcloudxyz.Points.Count; i++)
            {
                var p = new PointXYZRGBA();
                p.X = pointcloudxyz.Points[i].X; 
                p.Y = pointcloudxyz.Points[i].Y;
                p.Z = pointcloudxyz.Points[i].Z;

                pointcloudxyzrgba.Add(p);
            }

            foreach (var item in pointcloudxyz.Points)
            {
                Console.WriteLine(item.V);
            }
        }
    }
}
