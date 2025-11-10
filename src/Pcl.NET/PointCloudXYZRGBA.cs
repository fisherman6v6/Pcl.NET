namespace Pcl.NET
{

    public class PointCloudXYZRGBA : PointCloud<PointXYZRGBA>
    {
        private readonly VectorXYZRGBA _points;

        public override int Width
        {
            get
            {
                ThrowIfDisposed();
                return (int)Invoke.pointcloud_xyzrgba_get_width(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.pointcloud_xyzrgba_set_width(_ptr, (uint)value);
            }
        }
        public override int Height
        {
            get
            {
                ThrowIfDisposed();
                return (int)Invoke.pointcloud_xyzrgba_get_height(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.pointcloud_xyzrgba_set_height(_ptr, (uint)value);
            }
        }
        public override bool IsDense
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.pointcloud_xyzrgba_get_is_dense(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.pointcloud_xyzrgba_set_is_dense(_ptr, value);
            }
        }
        public override Vector<PointXYZRGBA> Points => _points;
        public override long Count
        {
            get
            {
                ThrowIfDisposed();
                return (long)Invoke.pointcloud_xyzrgba_size(_ptr);
            }
        }
        public override bool IsOrganized
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.pointcloud_xyzrgba_is_organized(_ptr);
            }
        }

        private PointCloudXYZRGBA(IntPtr ptr)
        {
            _ptr = ptr;
            _points = new VectorXYZRGBA(Invoke.pointcloud_xyzrgba_points(_ptr));
        }

        internal PointCloudXYZRGBA(IntPtr ptr, bool suppressDispose)
          : this(ptr)
        {
            _suppressDispose = suppressDispose;
        }

        public PointCloudXYZRGBA()
          : this(Invoke.pointcloud_xyzrgba_ctor())
        {
        }

        public PointCloudXYZRGBA(int width, int height)
          : this(Invoke.pointcloud_xyzrgba_ctor_wh((uint)width, (uint)height))
        {
        }

        public PointCloudXYZRGBA(PointCloudXYZRGBA other)
          : this(Invoke.pointcloud_xyzrgba_ctor_indices(other, IntPtr.Zero))
        {
        }

        public PointCloudXYZRGBA(PointCloudXYZRGBA other, VectorInt indices)
          : this(Invoke.pointcloud_xyzrgba_ctor_indices(other, indices))
        {
        }

        public unsafe override void Add(PointXYZRGBA value)
        {
            ThrowIfDisposed();
            Invoke.pointcloud_xyzrgba_add(_ptr, &value);
        }

        public unsafe override ref PointXYZRGBA At(int col, int row)
        {
            ThrowIfDisposed();
            ThrowHelper.ThrowUnorganizedPointCloudfCondition_CantUse2DIndexing(!IsOrganized);
            ThrowHelper.ThrowArgumentOutOfRangeIfCondition_IndexMustBeLessException(col >= Width, nameof(col));
            ThrowHelper.ThrowArgumentOutOfRangeIfCondition_IndexMustBeLessException(row >= Height, nameof(row));
            return ref System.Runtime.CompilerServices.Unsafe.AsRef<PointXYZRGBA>(Invoke.pointcloud_xyzi_at_colrow(_ptr, col, row));
        }

        public PointCloudXYZRGBA Downsample(int factor)
        {
            ThrowIfDisposed();
            PointCloudXYZRGBA output = new PointCloudXYZRGBA(this.Width, this.Height);
            Invoke.pointcloud_xyzrgba_downsample(_ptr, factor, output);
            return output;
        }

        public static PointCloudXYZRGBA operator +(PointCloudXYZRGBA a, PointCloudXYZRGBA b)
        {
            return Concatenate(a, b);
        }

        #region Static

        public static PointCloudXYZRGBA Concatenate(PointCloudXYZRGBA a, PointCloudXYZRGBA b)
        {
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();

            PointCloudXYZRGBA outpc = new PointCloudXYZRGBA();

            Invoke.pointcloud_xyzrgba_concatenate(a, b, outpc);

            return outpc;
        }

        public static PointCloudXYZRGBA Load(string filename)
        {
            return IO.LoadPointCloudXYZRGBA(filename);
        }

        #endregion

        #region Dispose
        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.pointcloud_xyzrgba_delete(ref _ptr);
            }
        }
        #endregion
    }
}
