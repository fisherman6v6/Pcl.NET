using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public static class IO
    {
        public static PointCloudXYZ LoadPointCloudXYZ(string filename)
        {
            PointCloudXYZ cloud = new();
            using var reader = new PCDReader();
            reader.Read(filename, cloud);
            return cloud;
        }

        public static void SavePointCloudXYZ(string filename, PointCloudXYZ cloud)
        {
            using var writer = new PCDWriter();
            writer.Write(filename, cloud);
        }
    }
}
