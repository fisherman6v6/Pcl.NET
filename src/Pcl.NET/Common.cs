namespace Pcl.NET
{
    public static class Common
    {
        /// <summary>
        /// Compute Axis-Aligned Bounding Box (AABB) for PointCloudXYZ
        /// </summary>
        /// <param name="cloud"></param>
        /// <param name="min_pt"></param>
        /// <param name="max_pt"></param>
        public static void GetMinMax3D(PointCloudXYZ cloud, out PointXYZ min_pt, out PointXYZ max_pt)
        {
            ArgumentNullException.ThrowIfNull(cloud, nameof(cloud));
            min_pt = new PointXYZ();
            max_pt = new PointXYZ();
            Invoke.common_get_min_max_3d_pointxyz(cloud, ref min_pt, ref max_pt);
        }
        /// <summary>
        /// Compute Axis-Aligned Bounding Box (AABB) for PointCloudXYZI
        /// </summary>
        /// <param name="cloud"></param>
        /// <param name="min_pt"></param>
        /// <param name="max_pt"></param>
        public static void GetMinMax3D(PointCloudXYZI cloud, out PointXYZI min_pt, out PointXYZI max_pt)
        {
            ArgumentNullException.ThrowIfNull(cloud, nameof(cloud));
            min_pt = new PointXYZI();
            max_pt = new PointXYZI();
            Invoke.common_get_min_max_3d_pointxyzi(cloud, ref min_pt, ref max_pt);
        }
        /// <summary>
        /// Compute Axis-Aligned Bounding Box (AABB) for PointCloudXYZRGBA
        /// </summary>
        /// <param name="cloud"></param>
        /// <param name="min_pt"></param>
        /// <param name="max_pt"></param>
        public static void GetMinMax3D(PointCloudXYZRGBA cloud, out PointXYZRGBA min_pt, out PointXYZRGBA max_pt)
        {
            ArgumentNullException.ThrowIfNull(cloud, nameof(cloud));
            min_pt = new PointXYZRGBA();
            max_pt = new PointXYZRGBA();
            Invoke.common_get_min_max_3d_pointxyzrgba(cloud, ref min_pt, ref max_pt);
        }
        /// <summary>
        /// Remove NaN points from PointCloudXYZ
        /// </summary>
        /// <param name="input">Input point cloud</param>
        /// <param name="indices">Stores the indices of the points that were kept (not removed) when NaNs are filtered out.</param>
        /// <returns>Filtered point cloud</returns>
        public static PointCloudXYZ RemoveNaNFromPointCloud(PointCloudXYZ input, out int[] indices)
        {
            int[] intIndices = new int[input.Count];
            PointCloudXYZ output = new PointCloudXYZ();

            int n = Invoke.common_remove_nan_pointxyz(input, output, intIndices);
            indices = intIndices[..n];
            return output;
        }
        /// <summary>
        /// Remove NaN points from PointCloudXYZI
        /// </summary>
        /// <param name="input">Input point cloud</param>
        /// <param name="indices">Stores the indices of the points that were kept (not removed) when NaNs are filtered out.</param>
        /// <returns>Filtered point cloud</returns>
        public static PointCloudXYZI RemoveNaNFromPointCloud(PointCloudXYZI input, out int[] indices)
        {
            int[] intIndices = new int[input.Count];
            PointCloudXYZI output = new PointCloudXYZI();

            int n = Invoke.common_remove_nan_pointxyzi(input, output, intIndices);
            indices = intIndices[..n];
            return output;
        }
        /// <summary>
        /// Remove NaN points from PointCloudXYZRGBA
        /// </summary>
        /// <param name="input">Input point cloud</param>
        /// <param name="indices">Stores the indices of the points that were kept (not removed) when NaNs are filtered out.</param>
        /// <returns>Filtered point cloud</returns>
        public static PointCloudXYZRGBA RemoveNaNFromPointCloud(PointCloudXYZRGBA input, out int[] indices)
        {
            int[] intIndices = new int[input.Count];
            PointCloudXYZRGBA output = new PointCloudXYZRGBA();

            int n = Invoke.common_remove_nan_pointxyzi(input, output, intIndices);
            indices = intIndices[..n];
            return output;
        }
    }
}
