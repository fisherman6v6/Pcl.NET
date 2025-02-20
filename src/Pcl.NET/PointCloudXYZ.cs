namespace Pcl.NET
{
    public class PointCloudXYZ : PointCloud<PointXYZ>
    {
        private readonly VectorXYZ _points;

        public override int Width
        {
            get
            {
                return (int)Invoke.pointcloud_xyz_width(_ptr);
            }
            set
            {
                Invoke.pointcloud_xyz_width_set(_ptr, (uint)value);
            }
        }
        public override int Height
        {
            get
            {
                return (int)Invoke.pointcloud_xyz_height(_ptr);
            }
            set
            {
                Invoke.pointcloud_xyz_height_set(_ptr, (uint)value);
            }
        }
        public override bool IsDense
        {
            get
            {
                return Invoke.pointcloud_xyz_get_is_dense(_ptr);
            }
            set
            {
                Invoke.pointcloud_xyz_set_is_dense(_ptr, value);
            }
        }
        public override Vector<PointXYZ> Points => _points;
        public override long Count => (long)Invoke.pointcloud_xyz_size(_ptr);
        public override bool IsOrganized => Invoke.pointcloud_xyz_is_organized(_ptr);

        private PointCloudXYZ(IntPtr ptr)
        {
            _ptr = ptr;
            _points = new VectorXYZ(Invoke.pointcloud_xyz_points(_ptr));
        }

        internal PointCloudXYZ(IntPtr ptr, bool suppressDispose)
          : this(ptr)
        {
            _suppressDispose = suppressDispose;
        }

        public PointCloudXYZ()
          : this(Invoke.pointcloud_xyz_ctor())
        {
        }

        public PointCloudXYZ(int width, int height)
          : this(Invoke.pointcloud_xyz_ctor_wh((uint)width, (uint)height))
        {
        }

        public void Downsample(int factor, PointCloudXYZ output)
        {
            Invoke.pointcloud_xyz_downsample(_ptr, factor, output);
        }

        public unsafe override void Add(PointXYZ value)
        {
            Invoke.pointcloud_xyz_add(_ptr, &value);
        }

        public unsafe override ref PointXYZ At(ulong col, ulong row)
        {
            return ref System.Runtime.CompilerServices.Unsafe.AsRef<PointXYZ>(Invoke.pointcloud_xyz_at_colrow(_ptr, col, row));
        }

        public static PointCloudXYZ operator +(PointCloudXYZ a, PointCloudXYZ b)
        {
            return Concatenate(a, b);
        }

        #region Static

        public static PointCloudXYZ Concatenate(PointCloudXYZ a, PointCloudXYZ b)
        {
            PointCloudXYZ outpc = new PointCloudXYZ();

            Invoke.pointcloud_xyz_concatenate(a, b, outpc);

            return outpc;
        }

        #endregion

        #region Dispose

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.pointcloud_xyz_delete(ref _ptr);
            }
        }

        #endregion
    }
}
