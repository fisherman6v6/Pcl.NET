namespace Pcl.NET
{
    public class PointCloudXYZI : PointCloud<PointXYZI>
    {
        private readonly VectorXYZI _points;

        public override int Width
        {
            get
            {
                return (int)Invoke.pointcloud_xyzi_get_width(_ptr);
            }
            set
            {
                Invoke.pointcloud_xyzi_set_width(_ptr, (uint)value);
            }
        }
        public override int Height
        {
            get
            {
                return (int)Invoke.pointcloud_xyzi_get_height(_ptr);
            }
            set
            {
                Invoke.pointcloud_xyzi_set_height(_ptr, (uint)value);
            }
        }
        public override bool IsDense
        {
            get
            {
                return Invoke.pointcloud_xyzi_get_is_dense(_ptr);
            }
            set
            {
                Invoke.pointcloud_xyzi_set_is_dense(_ptr, value);
            }
        }
        public override Vector<PointXYZI> Points => _points;
        public override long Count => (long)Invoke.pointcloud_xyzi_size(_ptr);
        public override bool IsOrganized => Invoke.pointcloud_xyz_is_organized(_ptr);

        private PointCloudXYZI(IntPtr ptr)
        {
            _ptr = ptr;
            _points = new VectorXYZI(Invoke.pointcloud_xyzi_points(_ptr));
        }

        internal PointCloudXYZI(IntPtr ptr, bool suppressDispose) : this(ptr)
        {
            _suppressDispose = suppressDispose;
        }

        public PointCloudXYZI() : this(Invoke.pointcloud_xyzi_ctor())
        {

        }

        public PointCloudXYZI(int width, int height) : this(Invoke.pointcloud_xyzi_ctor_wh((uint)width, (uint)height))
        {
        }

        public unsafe override void Add(PointXYZI value)
        {
            Invoke.pointcloud_xyzi_add(_ptr, &value);
        }

        public unsafe override ref PointXYZI At(ulong col, ulong row)
        {
            return ref System.Runtime.CompilerServices.Unsafe.AsRef<PointXYZI>(Invoke.pointcloud_xyzi_at_colrow(_ptr, col, row));
        }

        public void Downsample(int factor, PointCloudXYZI output)
        {
            Invoke.pointcloud_xyzi_downsample(_ptr, factor, output);
        }

        public static PointCloudXYZI operator +(PointCloudXYZI a, PointCloudXYZI b)
        {
            return Concatenate(a, b);
        }

        #region Static

        public static PointCloudXYZI Concatenate(PointCloudXYZI a, PointCloudXYZI b)
        {
            PointCloudXYZI outpc = new PointCloudXYZI();

            Invoke.pointcloud_xyzi_concatenate(a, b, outpc);

            return outpc;
        }

        #endregion

        #region Dispose

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.pointcloud_xyzi_delete(ref _ptr);
            }
        }

        #endregion
    }
}
