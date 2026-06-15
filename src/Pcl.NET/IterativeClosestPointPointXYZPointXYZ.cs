using Pcl.NET.Eigen;

namespace Pcl.NET
{
    public class IterativeClosestPointPointXYZPointXYZ : Registration<PointXYZ, PointXYZ>
    {
        private PointCloudXYZ? _source;
        private PointCloudXYZ? _target;
        private VectorInt? _indices;

        public override int MaximumIterations
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.iterative_closest_point_xyz_xyz_get_maximum_iterations(this);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.iterative_closest_point_xyz_xyz_set_maximum_iterations(this, value);
            }
        }
        public override double MaxCorrespondenceDistance
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.iterative_closest_point_xyz_xyz_get_max_correspondence_distance(this);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.iterative_closest_point_xyz_xyz_set_max_correspondence_distance(this, value);
            }
        }
        public override double RANSACOutlierRejectionThreshold
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.iterative_closest_point_xyz_xyz_get_ransac_outlier_rejection_threshold(this);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.iterative_closest_point_xyz_xyz_set_ransac_outlier_rejection_threshold(this, value);
            }
        }
        public override double TransformationEpsilon
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.iterative_closest_point_xyz_xyz_get_transformation_epsilon(this);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.iterative_closest_point_xyz_xyz_set_transformation_epsilon(this, value);
            }
        }
        public override double TransformationRotationEpsilon
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.iterative_closest_point_xyz_xyz_get_transformation_rotation_epsilon(this);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.iterative_closest_point_xyz_xyz_set_transformation_rotation_epsilon(this, value);
            }
        }
        public override double EuclideanFitnessEpsilon
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.iterative_closest_point_xyz_xyz_get_euclidean_fitness_epsilon(this);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.iterative_closest_point_xyz_xyz_set_euclidean_fitness_epsilon(this, value);
            }
        }
        public override PointCloud<PointXYZ> InputSource
        {
            get
            {
                ThrowIfDisposed();
                return _source!;
            }

            set
            {
                ThrowIfDisposed();
                ArgumentNullException.ThrowIfNull(value);
                _source = (PointCloudXYZ)value;
                Invoke.iterative_closest_point_xyz_xyz_set_input_source(this, _source);
            }
        }
        public override PointCloud<PointXYZ> InputTarget
        {
            get
            {
                ThrowIfDisposed();
                return _target!;
            }

            set
            {
                ThrowIfDisposed();
                ArgumentNullException.ThrowIfNull(value);
                _target = (PointCloudXYZ)value;
                Invoke.iterative_closest_point_xyz_xyz_set_input_target(this, _target);
            }
        }
        public override PointCloud<PointXYZ>? Input
        {
            get
            {
                return InputSource;
            }
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                InputSource = value;
            }
        }
        public override VectorInt Indices
        {
            get
            {
                ThrowIfDisposed();
                return _indices;
            }
            set
            {
                ThrowIfDisposed();
                ArgumentNullException.ThrowIfNull(value);
                _indices = value;
                Invoke.iterative_closest_point_xyz_xyz_set_indices_vector(this, _indices);

            }
        }
        public override void Align(PointCloud<PointXYZ> output)
        {
            ThrowIfDisposed();
            Invoke.iterative_closest_point_xyz_xyz_align(this, output);
        }
        public override void Align(PointCloud<PointXYZ> output, Matrix4f guess)
        {
            ThrowIfDisposed();
            Invoke.iterative_closest_point_xyz_xyz_align_guess(this, output, guess);
        }
        public override void SetIndices(long row_start, long col_start, long nb_rows, long nb_cols)
        {
            ThrowIfBadIndices(row_start, col_start, nb_rows, nb_cols);
            Invoke.iterative_closest_point_xyz_xyz_set_indices(this, row_start, col_start, nb_rows, nb_cols);
        }

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.iterative_closest_point_xyz_xyz_delete(ref _ptr);
            }
        }
    }
}
