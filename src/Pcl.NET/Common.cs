namespace Pcl.NET
{
    public static class Common
    {
        public static void GetMinMax3D(PointCloudXYZ cloud, out PointXYZ min_pt, out PointXYZ max_pt)
        {
            ArgumentNullException.ThrowIfNull(cloud, nameof(cloud));
            min_pt = new PointXYZ();
            max_pt = new PointXYZ();
            Invoke.common_get_min_max_3d_pointxyz(cloud, ref min_pt, ref max_pt);
        }

        public static void GetMinMax3D(PointCloudXYZI cloud, out PointXYZI min_pt, out PointXYZI max_pt)
        {
            ArgumentNullException.ThrowIfNull(cloud, nameof(cloud));
            min_pt = new PointXYZI();
            max_pt = new PointXYZI();
            Invoke.common_get_min_max_3d_pointxyzi(cloud, ref min_pt, ref max_pt);
        }

        public static void GetMinMax3D(PointCloudXYZRGBA cloud, out PointXYZRGBA min_pt, out PointXYZRGBA max_pt)
        {
            ArgumentNullException.ThrowIfNull(cloud, nameof(cloud));
            min_pt = new PointXYZRGBA();
            max_pt = new PointXYZRGBA();
            Invoke.common_get_min_max_3d_pointxyzrgba(cloud, ref min_pt, ref max_pt);
        }
    }
}
