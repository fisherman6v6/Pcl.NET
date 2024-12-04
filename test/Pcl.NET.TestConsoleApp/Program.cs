using Pcl.NET.Eigen;
using System.Numerics;

namespace Pcl.NET.TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var pc = IO.LoadPointCloudXYZ(@"C:\Users\alessandro.fici\Desktop\PointClouds\simpleXYZ.pcd");

            PointXYZ p = new Vector3(1, 2, 3);

            IO.SavePointCloudXYZAscii(@"C:\Users\alessandro.fici\Desktop\PointClouds\simpleXYZ-mod.pcd", pc);
            
        }
    }
}
