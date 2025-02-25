namespace Pcl.NET
{
    public abstract class Filter<PointT> : PclBase<PointT> 
    {
        public abstract PointCloud<PointT> ApplyFilter();
    }
}
