namespace Pcl.NET.Eigen
{
    public class ArrayXf : UnmanagedObject
    {
        /// <summary>
        /// Constructor with size parameter.
        /// </summary>
        /// <param name="size"></param>
        public ArrayXf(long size)
        {
            _ptr = Invoke.eigen_arrayxf_ctor_size(size);
        }
        /// <summary>
        /// Constructor with size and initial value parameters.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="value"></param>
        public ArrayXf(long size, float value)
        {
            _ptr = Invoke.eigen_arrayxf_ctor_size(size);
            for (long i = 0; i < size; i++)
            {
                this[i] = value;
            }
        }
        /// <summary>
        /// Constructor with an array of float values.
        /// </summary>
        /// <param name="values"></param>
        public ArrayXf(float[] values)
        {
            _ptr = Invoke.eigen_arrayxf_ctor_size(values.Length);
            for (int i = 0; i < values.Length; i++)
            {
                this[i] = values[i];
            }
        }
        /// <summary>
        /// Constructor that takes a pointer to an existing Eigen ArrayXf   object.
        /// </summary>
        /// <param name="ptr"></param>
        private ArrayXf(IntPtr ptr)
        {
            _ptr = ptr;
        }
        /// <summary>
        /// Constructor that takes a pointer to an existing Eigen ArrayXf object and suppresses disposal of the pointer.
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="suppressDispose"></param>
        internal ArrayXf(IntPtr ptr, bool suppressDispose)
          : this(ptr)
        {
            _suppressDispose = suppressDispose;
        }
        /// <summary>
        /// Gets the number of elements in the array.
        /// </summary>
        public long Count
        {
            get
            {
                return Invoke.eigen_arrayxf_size(_ptr);
            }
        }
        /// <summary>
        /// Gets or sets the value at the specified index in the array.
        /// </summary>
        /// <param name="index"></param>
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
        /// <summary>
        /// Coefficient wise sine of the array elements.
        /// </summary>
        /// <returns>An expression of the coefficient-wise sine of *this. </returns>
        public ArrayXf Sin()
        {
            ThrowIfDisposed();
            return new ArrayXf(Invoke.eigen_arrayxf_sin(_ptr));
        }
        /// <summary>
        /// Coefficient wise cosine of the array elements.
        /// </summary>
        /// <returns>An expression of the coefficient-wise cosine of *this.</returns>
        public ArrayXf Cos()
        {
            ThrowIfDisposed();
            return new ArrayXf(Invoke.eigen_arrayxf_cos(_ptr));
        }
        /// <summary>
        /// Coefficient wise tangent of the array elements.
        /// </summary>
        /// <returns> An expression of the coefficient-wise tangent of *this. </returns>
        public ArrayXf Tan()
        {
            ThrowIfDisposed();
            return new ArrayXf(Invoke.eigen_arrayxf_tan(_ptr));
        }
        /// <summary>
        /// Coefficient wise exponential of the array elements.
        /// </summary>
        /// <returns> An expression of the coefficient-wise exponential of *this.
        /// </returns>
        public ArrayXf Exp()
        {
            ThrowIfDisposed();
            return new ArrayXf(Invoke.eigen_arrayxf_exp(_ptr));
        }
        /// <summary>
        /// Coefficient wise logarithm of the array elements.
        /// </summary>
        /// <returns> An expression of the coefficient-wise logarithm of *this.</returns>
        public ArrayXf Log()
        {
            ThrowIfDisposed();
            return new ArrayXf(Invoke.eigen_arrayxf_log(_ptr));
        }
        /// <summary>
        /// Coefficient wise square root of the array elements.
        /// </summary>
        /// <returns> An expression of the coefficient-wise square root of *this.</returns>
        public ArrayXf Sqrt()
        {
            ThrowIfDisposed();
            return new ArrayXf(Invoke.eigen_arrayxf_sqrt(_ptr));
        }
        /// <summary>
        /// Coefficient wise absolute value of the array elements.
        /// </summary>
        /// <returns> An expression of the coefficient-wise absolute value of *this.
        /// </returns>
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
