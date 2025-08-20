namespace Pcl.NET
{
    public static class PointCloudExtensions
    {
        public static void Save(this PointCloudXYZ @this, string filename, bool ascii = false)
        {
            if (ascii)
            {
                IO.SavePointCloudXYZAscii(filename, @this);
            }
            else
            {
                IO.SavePointCloudXYZBinary(filename, @this);
            }
        }

        public static void Save(this PointCloudXYZI @this, string filename, bool ascii = false)
        {
            if (ascii)
            {
                IO.SavePointCloudXYZIAscii(filename, @this);
            }
            else
            {
                IO.SavePointCloudXYZIBinary(filename, @this);
            }
        }
    }
}
