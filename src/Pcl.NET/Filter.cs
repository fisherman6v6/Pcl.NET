namespace Pcl.NET
{
    public abstract class Filter<PointT> : PclBase<PointT> where PointT : unmanaged
    {
        public abstract PointCloud<PointT> ApplyFilter();
    }
}
