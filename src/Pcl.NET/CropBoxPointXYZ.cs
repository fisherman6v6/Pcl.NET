using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public class CropBoxPointXYZ : Filter<PointXYZ>
    {
        private readonly VectorInt _indices;
        private PointCloud<PointXYZ>? _input = null;

        public CropBoxPointXYZ()
        {
            _indices = new VectorInt();
            _ptr = Invoke.cropbox_pointxyz_ctor();
        }

        public Eigen.Vector4f Min
        {
            get
            {
                return Invoke.cropbox_pointxyz_get_min(_ptr);
            }
            set
            {
                Invoke.cropbox_pointxyz_set_min(_ptr, value);
            }
        }

        public Eigen.Vector4f Max
        {
            get
            {
                return Invoke.cropbox_pointxyz_get_max(_ptr);
            }
            set
            {
                Invoke.cropbox_pointxyz_set_max(_ptr, value);
            }
        }

        public Eigen.Vector3f Translation
        {
            get
            {
                return Invoke.cropbox_pointxyz_get_translation(_ptr);
            }
            set
            {
                Invoke.cropbox_pointxyz_set_translation(_ptr, value);
            }
        }

        public Eigen.Vector3f Rotation
        {
            get
            {
                return Invoke.cropbox_pointxyz_get_rotation(_ptr);
            }
            set
            {
                Invoke.cropbox_pointxyz_set_rotation(_ptr, value);
            }
        }

        public override PointCloud<PointXYZ>? Input
        {
            get
            {
                return _input;
            }
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));

                Invoke.cropbox_pointxyz_set_input_cloud(_ptr, value!);

                _input = value;
            }
        }

        public override PointCloud<PointXYZ> ApplyFilter()
        {
            PointCloudXYZ output = new PointCloudXYZ();
            Invoke.cropbox_pointxyz_filter(_ptr, output);
            return output;
        }

        public override void SetIndices(long row_start, long col_start, long nb_rows, long nb_cols)
        {
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

        public override VectorInt Indices
        {
            get
            {
                Invoke.cropbox_pointxyz_get_filter_indices_vector(_ptr, _indices);
                return _indices;
            }

            set
            {
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
