namespace Pcl.NET
{
    public abstract class PclBase<PointT> : UnmanagedObject where PointT : unmanaged
    {
        protected void ThrowIfInputNotSet()
        {
            if (Input == null)
            {
                ThrowHelper.ThrowInvalidOperation_PointCloudNotSetException();
            }
        }
        protected void ThrowIfBadIndices(long row_start, long col_start, long nb_rows, long nb_cols)
        {
            ThrowIfInputNotSet();

            if ((nb_rows > Input!.Height) || (row_start > Input.Height))
            {
                ThrowHelper.ThrowPclException($"[PCLBase::setIndices] cloud is only {Input.Height} height");
            }

            if ((nb_cols > Input.Width) || (col_start > Input.Width))
            {
                ThrowHelper.ThrowPclException($"[PCLBase::setIndices] cloud is only {Input.Width} width");
            }

            long row_end = row_start + nb_rows;
            if (row_end > Input.Height)
            {
                ThrowHelper.ThrowPclException($"[PCLBase::setIndices] {row_end} is out of rows range {Input.Height}");
            }

            long col_end = col_start + nb_cols;
            if (col_end > Input.Width)
            {
                ThrowHelper.ThrowPclException($"[PCLBase::setIndices] {col_end} is out of columns range {Input.Width}");
                return;
            }
        }
        /// <summary>
        /// The input point cloud. This must be set before applying the operation.
        /// </summary>
        public abstract PointCloud<PointT>? Input { get; set; }

        public abstract VectorInt Indices { get; set; }

        public abstract void SetIndices(long row_start, long col_start, long nb_rows, long nb_cols);
    }
}
