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
    }
}
