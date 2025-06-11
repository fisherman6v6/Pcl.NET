namespace Pcl.NET.Eigen
{
    public class ArrayXf : UnmanagedObject
    {
        public ArrayXf(long size)
        {
            _ptr = Invoke.eigen_arrayxf_ctor_size(size);
        }

        public ArrayXf(long size, float value)
        {
            _ptr = Invoke.eigen_arrayxf_ctor_size(size);
            for (long i = 0; i < size; i++)
            {
                this[i] = value;
            }
        }

        private ArrayXf(IntPtr ptr)
        {
            _ptr = ptr;
        }

        internal ArrayXf(IntPtr ptr, bool suppressDispose)
          : this(ptr)
        {
            _suppressDispose = suppressDispose;
        }

        public long Count
        {
            get
            {
                return Invoke.eigen_arrayxf_size(_ptr);
            }
        }

        public ArrayXf(float[] values)
        {
            _ptr = Invoke.eigen_arrayxf_ctor_size(values.Length);
            for (int i = 0; i < values.Length; i++)
            {
                this[i] = values[i];
            }
        }

        public float this[long index]
        {
            get
            {
                if ((ulong)index >= (ulong)Count)
                {
                    ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
                }
                return Invoke.eigen_arrayxf_get_index(_ptr, index);
            }
            set
            {
                if ((ulong)index >= (ulong)Count)
                {
                    ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
                }
                Invoke.eigen_arrayxf_set_index(_ptr, index, value);
            }
        }

        public ArrayXf Sin()
        {
            ThrowIfDisposed();
            return new ArrayXf(Invoke.eigen_arrayxf_sin(_ptr));
        }

        public ArrayXf Cos()
        {
            ThrowIfDisposed();
            return new ArrayXf(Invoke.eigen_arrayxf_cos(_ptr));
        }

        public ArrayXf Tan()
        {
            ThrowIfDisposed();
            return new ArrayXf(Invoke.eigen_arrayxf_tan(_ptr));
        }

        public ArrayXf Exp()
        {
            ThrowIfDisposed();
            return new ArrayXf(Invoke.eigen_arrayxf_exp(_ptr));
        }

        public ArrayXf Log()
        {
            ThrowIfDisposed();
            return new ArrayXf(Invoke.eigen_arrayxf_log(_ptr));
        }

        public ArrayXf Sqrt()
        {
            ThrowIfDisposed();
            return new ArrayXf(Invoke.eigen_arrayxf_sqrt(_ptr));
        }

        public ArrayXf Abs()
        {
            ThrowIfDisposed();
            return new ArrayXf(Invoke.eigen_arrayxf_abs(_ptr));
        }

        #region Dispose
        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.eigen_arrayxf_delete(ref _ptr);
                _ptr = IntPtr.Zero;
            }
        }
        #endregion
    }
}
