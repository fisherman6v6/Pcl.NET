using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public class SACSegmentationPointXYZI : SACSegmentation<PointXYZI>
    {
        private readonly VectorInt _indices;
        private PointCloud<PointXYZI>? _input = null;

        public SACSegmentationPointXYZI()
        {
            _indices = new VectorInt();
            _ptr = Invoke.sacsegmentation_pointxyzi_ctor();
        }

        public override SacModel ModelType
        {
            get
            {
                ThrowIfDisposed();
                return (SacModel)Invoke.sacsegmentation_pointxyzi_get_model_type(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.sacsegmentation_pointxyzi_set_model_type(_ptr, (int)value);
            }
        }

        public override SacMethod MethodType
        {
            get
            {
                ThrowIfDisposed();
                return (SacMethod)Invoke.sacsegmentation_pointxyzi_get_method_type(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.sacsegmentation_pointxyzi_set_method_type(_ptr, (int)value);
            }
        }

        public override double DistanceThreshold
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.sacsegmentation_pointxyzi_get_distance_threshold(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.sacsegmentation_pointxyzi_set_distance_threshold(_ptr, value);
            }
        }

        public override int MaxIterations
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.sacsegmentation_pointxyzi_get_max_iterations(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.sacsegmentation_pointxyzi_set_max_iterations(_ptr, value);
            }
        }

        public override bool OptimizeCoefficients
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.sacsegmentation_pointxyzi_get_optimize_coefficients(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.sacsegmentation_pointxyzi_set_optimize_coefficients(_ptr, value);
            }
        }

        public override void SetRadiusLimits(double minRadius, double maxRadius)
        {
            ThrowIfDisposed();
            Invoke.sacsegmentation_pointxyzi_set_radius_limits(_ptr, minRadius, maxRadius);
        }

        public override void GetRadiusLimits(ref double minRadius, ref double maxRadius)
        {
            ThrowIfDisposed();
            Invoke.sacsegmentation_pointxyzi_get_radius_limits(_ptr, ref minRadius, ref maxRadius);
        }

        /// <summary>
        /// Esegue la segmentazione recuperando gli inliers e i coefficienti del modello nativo.
        /// Nota: Puoi passare direttamente gli oggetti (es. VectorInt o PointIndices) se la tua architettura 
        /// prevede un operatore di conversione implicita a IntPtr, come accade per gli indici di CropBox.
        /// </summary>
        public override float[] Segment()
        {
            ThrowIfDisposed();

            float[] coefficients;
            using (var inliers = new VectorInt())
            using (var coeff = new VectorFloat())
            {
                Invoke.sacsegmentation_pointxyzi_segment(_ptr, inliers, coeff);
                coefficients = coeff.ToArray();
            }

            return coefficients;
        }

        public override PointCloud<PointXYZI>? Input
        {
            get
            {
                ThrowIfDisposed();
                return _input;
            }
            set
            {
                ThrowIfDisposed();
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                Invoke.sacsegmentation_pointxyzi_set_input_cloud(_ptr, value!);
                _input = value;
            }
        }

        /// <summary>
        /// Sets the indices of the crop box filter based on the specified starting row, column, number of rows, and number of columns.
        /// </summary>
        /// <param name="row_start"></param>
        /// <param name="col_start"></param>
        /// <param name="nb_rows"></param>
        /// <param name="nb_cols"></param>
        public override void SetIndices(long row_start, long col_start, long nb_rows, long nb_cols)
        {
            ThrowIfDisposed();
            ThrowIfBadIndices(row_start, col_start, nb_rows, nb_cols);
            Invoke.sacsegmentation_pointxyzi_set_indices(_ptr, (ulong)row_start, (ulong)col_start, (ulong)nb_rows, (ulong)nb_cols);
        }
        /// <summary>
        /// Gets or sets the indices of the crop box filter. This property allows you to specify which points in the input point cloud should be considered for filtering.
        /// </summary>
        public override VectorInt Indices
        {
            get
            {
                ThrowIfDisposed();
                Invoke.sacsegmentation_pointxyzi_get_indices_vector(_ptr, _indices);
                return _indices;
            }

            set
            {
                ThrowIfDisposed();
                Invoke.sacsegmentation_pointxyzi_set_indices_vector(_ptr, value);
            }
        }

        #region Dispose

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.sacsegmentation_pointxyzi_delete(ref _ptr);
            }
        }

        #endregion
    }
}