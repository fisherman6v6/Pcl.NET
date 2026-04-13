namespace Pcl.NET
{
    /// <summary>
    /// Removes points whose mean distance to their k nearest neighbors is beyond a standard deviation threshold.
    /// General-purpose noise removal, lidar scans, structured point clouds.
    /// </summary>
    public class StatisticalOutlierRemovalPointXYZ : Filter<PointXYZ>
    {
        private PointCloud<PointXYZ>? _input;
        private VectorInt _indices = new VectorInt();

        public StatisticalOutlierRemovalPointXYZ()
        {
            _ptr = Invoke.statistical_outlier_removal_pointxyz_ctor();
        }

        public override PointCloud<PointXYZ>? Input
        {
            get => _input;
            set
            {
                _input = value;
                Invoke.statistical_outlier_removal_pointxyz_set_input_cloud(_ptr, value);
            }
        }

        public override VectorInt Indices
        {
            get
            {
                ThrowIfDisposed();
                Invoke.statistical_outlier_removal_pointxyz_get_filter_indices_vector(_ptr, _indices);
                return _indices;
            }
            set
            {
                ThrowIfDisposed();
                _indices = value;
                Invoke.statistical_outlier_removal_pointxyz_set_filter_indices_vector(_ptr, value);
            }
        }

        /// <summary>
        /// Get or Set the number of nearest neighbors to use for mean distance estimation. Higher K → more stable, slower
        /// </summary>
        public int MeanK
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.statistical_outlier_removal_pointxyz_get_mean_k(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.statistical_outlier_removal_pointxyz_set_mean_k(_ptr, value);
            }
        }
        /// <summary>
        /// Get or Set the standard deviation multiplier for the distance threshold calculation.
        /// The distance threshold will be equal to: mean + stddev_mult* stddev.
        /// Points will be classified as inlier or outlier if their average neighbor distance is below or above this threshold respectively.
        /// Lower → more aggressive removal
        /// </summary>
        public float StddevMulThresh
        {
            get
            {
                ThrowIfDisposed();
                return (float)Invoke.statistical_outlier_removal_pointxyz_get_stddev_mul_thresh(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.statistical_outlier_removal_pointxyz_set_stddev_mul_thresh(_ptr, value);
            }
        }

        public override void SetIndices(long row_start, long col_start, long nb_rows, long nb_cols)
        {
            ThrowIfDisposed();

            ThrowIfBadIndices(row_start, col_start, nb_rows, nb_cols);

            Invoke.statistical_outlier_removal_pointxyz_set_filter_indices(_ptr, (ulong)row_start, (ulong)col_start, (ulong)nb_rows, (ulong)nb_cols);
        }

        public override PointCloud<PointXYZ> ApplyFilter()
        {
            ThrowIfDisposed();
            ThrowIfInputNotSet();
            var output = new PointCloudXYZ();
            Invoke.statistical_outlier_removal_pointxyz_filter(_ptr, output);
            return output;
        }

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.statistical_outlier_removal_pointxyz_delete(ref _ptr);
                _ptr = IntPtr.Zero;
            }
        }
    }
}
