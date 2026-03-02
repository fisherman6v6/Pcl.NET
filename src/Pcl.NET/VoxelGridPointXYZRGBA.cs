using Pcl.NET.Eigen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public class VoxelGridPointXYZRGBA : VoxelGrid<PointXYZRGBA>
    {
        private PointCloud<PointXYZRGBA>? _input = null;
        private readonly VectorInt _indices;
        public VoxelGridPointXYZRGBA()
        {
            _ptr = Invoke.voxelgrid_pointxyzrgba_ctor();
            _indices = new VectorInt();
        }
        public override string FilterFieldName
        {
            get
            {
                StringBuilder sb = new(128);
                Invoke.voxelgrid_pointxyzrgba_get_filter_field_name(this, sb, sb.Length);
                return sb.ToString();
            }
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                Invoke.voxelgrid_pointxyzrgba_set_filter_field_name(this, value);
            }
        }
        public override Vector3f LeafSize
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.voxelgrid_pointxyzrgba_get_leaf_size(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.voxelgrid_pointxyzrgba_set_leaf_size(_ptr, value.X, value.Y, value.Z);
            }
        }
        public override bool DownSampleAllData
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.voxelgrid_pointxyzrgba_get_downsample_all_data(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.voxelgrid_pointxyzrgba_set_downsample_all_data(_ptr, value);
            }
        }
        public override uint MinimumPointsNumberPerVoxel
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.voxelgrid_pointxyzrgba_get_min_points_per_voxel(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.voxelgrid_pointxyzrgba_set_min_points_per_voxel(_ptr, value);
            }
        }
        public override bool SaveLeafLayout
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.voxelgrid_pointxyzrgba_get_save_leaf_layout(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.voxelgrid_pointxyzrgba_set_save_leaf_layout(_ptr, value);
            }
        }
        public override Vector3i MaxBoxCoordinates
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.voxelgrid_pointxyzrgba_get_max_box_coordinates(_ptr);
            }
        }
        public override Vector3i MinBoxCoordinates
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.voxelgrid_pointxyzrgba_get_min_box_coordinates(_ptr);
            }
        }
        public override Vector3i NrDivisions
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.voxelgrid_pointxyzrgba_get_nr_divisions(_ptr);
            }
        }
        public override Vector3i DivisionMultiplier
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.voxelgrid_pointxyzrgba_get_division_multiplier(_ptr);
            }
        }
        public override bool FilterLimitsNegative
        {
            get
            {
                ThrowIfDisposed();
                Invoke.voxelgrid_pointxyzrgba_get_filter_limits_negative(_ptr, out var ret);
                return ret;
            }
            set
            {
                ThrowIfDisposed();
                Invoke.voxelgrid_pointxyzrgba_set_filter_limits_negative(_ptr, value);
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
                _input = value;
                Invoke.voxelgrid_pointxyzrgba_set_input_cloud(_ptr, _input);
            }
        }
        public override VectorInt Indices
        {
            get
            {
                ThrowIfDisposed();
                Invoke.voxelgrid_pointxyzrgba_get_indices_vector(_ptr, _indices);
                return _indices;
            }
            set
            {
                ThrowIfDisposed();
                Invoke.voxelgrid_pointxyzrgba_set_indices_vector(_ptr, value);
            }
        }
        public override PointCloud<PointXYZRGBA> ApplyFilter()
        {
            ThrowIfDisposed();
            PointCloudXYZRGBA output = new();
            Invoke.voxelgrid_pointxyzrgba_filter(_ptr, output);
            return output;
        }
        public override int GetCentroidIndex(PointXYZ p)
        {
            ThrowIfDisposed();
            var index = Invoke.voxelgrid_pointxyzrgba_get_centroid_index(_ptr, ref p);
            return index;
        }
        public override int GetCentroidIndexAt(Vector3i v)
        {
            ThrowIfDisposed();
            var index = Invoke.voxelgrid_pointxyzrgba_get_centroid_index_at(_ptr, v.X, v.Y, v.Z);
            return index;
        }
        public override Vector3i GetGridCoordinates(float x, float y, float z)
        {
            ThrowIfDisposed();
            return Invoke.voxelgrid_pointxyzrgba_get_grid_coordinates(_ptr, x, y, z);
        }
        public override void SetFilterLimits(float limitMin, float limitMax)
        {
            ThrowIfDisposed();
            Invoke.voxelgrid_pointxyzrgba_set_filter_limits(_ptr, limitMin, limitMax);
        }
        public override void SetIndices(long row_start, long col_start, long nb_rows, long nb_cols)
        {
            ThrowIfDisposed();
            Invoke.voxelgrid_pointxyzrgba_set_indices(_ptr, row_start, col_start, nb_rows, nb_cols);
        }
        public override void SetLeafSize(float sizeX, float sizeY, float sizeZ)
        {
            ThrowIfDisposed();
            Invoke.voxelgrid_pointxyzrgba_set_leaf_size(_ptr, sizeX, sizeY, sizeZ);
        }
        protected override void DisposeObject()
        {
            if (_suppressDispose)
            {
                Invoke.voxelgrid_pointxyzrgba_delete(ref _ptr);
            }
        }
    }
}
