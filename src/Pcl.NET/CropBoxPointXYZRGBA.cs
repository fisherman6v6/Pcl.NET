using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public class CropBoxPointXYZRGBA : CropBox<PointXYZRGBA>
    {
        private readonly VectorInt _indices;
        private PointCloud<PointXYZRGBA>? _input = null;
        public CropBoxPointXYZRGBA()
        {
            _indices = new VectorInt();
            _ptr = Invoke.cropbox_pointxyzrgba_ctor();
        }
        public override Eigen.Vector4f Min
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.cropbox_pointxyzrgba_get_min(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.cropbox_pointxyzrgba_set_min(_ptr, value);
            }
        }
        public override Eigen.Vector4f Max
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.cropbox_pointxyzrgba_get_max(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.cropbox_pointxyzrgba_set_max(_ptr, value);
            }
        }
        public override Eigen.Vector3f Translation
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.cropbox_pointxyzrgba_get_translation(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.cropbox_pointxyzrgba_set_translation(_ptr, value);
            }
        }
        public override Eigen.Vector3f Rotation
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.cropbox_pointxyzrgba_get_rotation(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.cropbox_pointxyzrgba_set_rotation(_ptr, value);
            }
        }
        public override bool KeepOrganized
        {
            get
            {
                ThrowIfDisposed();
                int val = Invoke.cropbox_pointxyzrgba_get_keep_organized(_ptr);
                return val != 0;
            }
            set
            {
                ThrowIfDisposed();
                int ival = value ? 1 : 0;
                Invoke.cropbox_pointxyzrgba_set_keep_organized(_ptr, ival);
            }
        }
        public override PointCloud<PointXYZRGBA>? Input
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
                Invoke.cropbox_pointxyzrgba_set_input_cloud(_ptr, value!);
                _input = value;
            }
        }
        public override PointCloud<PointXYZRGBA> ApplyFilter()
        {
            ThrowIfDisposed();
            ThrowIfInputNotSet();
            PointCloudXYZRGBA output = new PointCloudXYZRGBA();
            Invoke.cropbox_pointxyzrgba_filter(_ptr, output);
            return output;
        }
        public override void SetIndices(long row_start, long col_start, long nb_rows, long nb_cols)
        {
            ThrowIfDisposed();
            ThrowIfBadIndices(row_start, col_start, nb_rows, nb_cols);
            Invoke.cropbox_pointxyzrgba_set_filter_indices(_ptr, (ulong)row_start, (ulong)col_start, (ulong)nb_rows, (ulong)nb_cols);
        }
        public override VectorInt Indices
        {
            get
            {
                ThrowIfDisposed();
                Invoke.cropbox_pointxyzrgba_get_filter_indices_vector(_ptr, _indices);
                return _indices;
            }
            set
            {
                ThrowIfDisposed();
                Invoke.cropbox_pointxyzrgba_set_filter_indices_vector(_ptr, value);
            }
        }
        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.cropbox_pointxyzrgba_delete(ref _ptr);
            }
        }
    }
}
