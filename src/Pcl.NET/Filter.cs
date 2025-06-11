namespace Pcl.NET
{
    public abstract class Filter<PointT> : PclBase<PointT> where PointT : unmanaged
    {
        /// <summary>
        /// Apply the filter to the input point cloud and return the filtered point cloud.
        /// </summary>
        /// <returns></returns>
        public abstract PointCloud<PointT> ApplyFilter();
    }
}
