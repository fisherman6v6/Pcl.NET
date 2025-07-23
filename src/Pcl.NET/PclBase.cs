namespace Pcl.NET
{
    public abstract class PclBase<PointT> : UnmanagedObject where PointT : unmanaged
    {
        /// <summary>
        /// The input point cloud. This must be set before applying the operation.
        /// </summary>
        public abstract PointCloud<PointT>? Input { get; set; }

        public abstract VectorInt Indices { get; set; }

        public abstract void SetIndices(long row_start, long col_start, long nb_rows, long nb_cols);
    }
}
