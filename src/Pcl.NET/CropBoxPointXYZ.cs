using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public class CropBoxPointXYZ : CropBox<PointXYZ>
    {
        private readonly VectorInt _indices;
        private PointCloud<PointXYZ>? _input = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="CropBoxPointXYZ"/> class.
        /// </summary>
        public CropBoxPointXYZ()
        {
            _indices = new VectorInt();
            _ptr = Invoke.cropbox_pointxyz_ctor();
        }
        public override Eigen.Vector4f Min
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.cropbox_pointxyz_get_min(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.cropbox_pointxyz_set_min(_ptr, value);
            }
        }
        public override Eigen.Vector4f Max
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.cropbox_pointxyz_get_max(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.cropbox_pointxyz_set_max(_ptr, value);
            }
        }
        public override Eigen.Vector3f Translation
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.cropbox_pointxyz_get_translation(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.cropbox_pointxyz_set_translation(_ptr, value);
            }
        }
        public override Eigen.Vector3f Rotation
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.cropbox_pointxyz_get_rotation(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.cropbox_pointxyz_set_rotation(_ptr, value);
            }
        }
        public override bool KeepOrganized
        {
            get
            {
                ThrowIfDisposed();
                int val = Invoke.cropbox_pointxyz_get_keep_organized(_ptr);
                return val != 0;
            }
            set
            {
                ThrowIfDisposed();
                int ival = value ? 1 : 0;
                Invoke.cropbox_pointxyz_set_keep_organized(_ptr, ival);
            }
        }

        public override PointCloud<PointXYZ>? Input
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
                Invoke.cropbox_pointxyz_set_input_cloud(_ptr, value!);
                _input = value;
            }
        }
        public override PointCloud<PointXYZ> ApplyFilter()
        {
            ThrowIfDisposed();
            PointCloudXYZ output = new PointCloudXYZ();
            Invoke.cropbox_pointxyz_filter(_ptr, output);
            return output;
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

            if (_input == null)
            {
                ThrowHelper.ThrowInvalidOperation_PointCloudNotSetException();
            }

            if ((nb_rows > _input.Height) || (row_start > _input.Height))
            {
                ThrowHelper.ThrowPclException($"[PCLBase::setIndices] cloud is only {_input.Height} height");
            }

            if ((nb_cols > _input.Width) || (col_start > _input.Width))
            {
                ThrowHelper.ThrowPclException($"[PCLBase::setIndices] cloud is only {_input.Width} width");
            }

            long row_end = row_start + nb_rows;
            if (row_end > _input.Height)
            {
                ThrowHelper.ThrowPclException($"[PCLBase::setIndices] {row_end} is out of rows range {_input.Height}");
            }

            long col_end = col_start + nb_cols;
            if (col_end > _input.Width)
            {
                ThrowHelper.ThrowPclException($"[PCLBase::setIndices] {col_end} is out of columns range {_input.Width}");
                return;
            }

            Invoke.cropbox_pointxyz_set_filter_indices(_ptr, (ulong)row_start, (ulong)col_start, (ulong)nb_rows, (ulong)nb_cols);
        }
        /// <summary>
        /// Gets or sets the indices of the crop box filter. This property allows you to specify which points in the input point cloud should be considered for filtering.
        /// </summary>
        public override VectorInt Indices
        {
            get
            {
                ThrowIfDisposed();
                Invoke.cropbox_pointxyz_get_filter_indices_vector(_ptr, _indices);
                return _indices;
            }

            set
            {
                ThrowIfDisposed();
                Invoke.cropbox_pointxyz_set_filter_indices_vector(_ptr, value);
            }
        }

        #region Dispose

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.cropbox_pointxyz_delete(ref _ptr);
            }
        }

        #endregion
    }
}
