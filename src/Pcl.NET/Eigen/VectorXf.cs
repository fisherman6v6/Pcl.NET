namespace Pcl.NET.Eigen
{
    public class VectorXf : UnmanagedObject
    {

        public VectorXf()
        {
            _ptr = Invoke.eigen_vectorxf_ctor();
        }
        public VectorXf(long size)
        {
            _ptr = Invoke.eigen_vectorxf_ctor_size(size);
        }

        public long Count
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.eigen_vectorxf_size(_ptr);
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
                return Invoke.eigen_vectorxf_get_index(_ptr, index);
            }
            set
            {
                if ((ulong)index >= (ulong)Count)
                {
                    ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
                }
                Invoke.eigen_vectorxf_set_index(_ptr, index, value);
            }
        }
        #region Dispose
        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.eigen_vectorxf_delete(ref _ptr);
                _ptr = IntPtr.Zero;
            }
        }
        #endregion
    }
}
