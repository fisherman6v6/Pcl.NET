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
            Pcl.NET.PointCloudXYZ pc = new(2,2);
            pc.Points[0] = new Pcl.NET.PointXYZ(1.0f, 2.0f, 3.0f);

            var p = pc.At(0, 0);
        }
    }
}
