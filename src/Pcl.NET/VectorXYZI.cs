using System;
using System.Runtime.CompilerServices;

namespace Pcl.NET
{
    public class VectorXYZI : Vector<PointXYZI>
    {
        public VectorXYZI(IntPtr ptr)
        {
            _ptr = ptr;
            _suppressDispose = true;
        }
        public VectorXYZI()
        {
            _ptr = Invoke.std_vector_xyzi_ctor();
        }
        public VectorXYZI(long count)
        {
            _ptr = Invoke.std_vector_xyzi_ctor_count((ulong)count);
        }
        public unsafe VectorXYZI(PointXYZI[] arr)
        {
            _ptr = Invoke.std_vector_xyzi_ctor_count((ulong)arr.Length);
            CopyFromArray(arr, DataU);
        }

        public override long Count
        {
            get
            {
                ThrowIfDisposed();
                return (long)Invoke.std_vector_xyzi_size(_ptr);
            }
        }

        public override IntPtr Data
        {
            get
            {
                return Invoke.std_vector_xyzi_data(_ptr);
            }
        }

        public override void Add(PointXYZI item)
        {
            ThrowIfDisposed();
            Invoke.std_vector_xyzi_add(_ptr, item);
        }

        public override void At(long index, ref PointXYZI value)
        {
            ThrowIfDisposed();
            if ((ulong)index >= (ulong)Count)
            {
                ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
            }

            Invoke.std_vector_xyzi_at(_ptr, (ulong)index, ref value);
        }

        public override void Clear()
        {
            ThrowIfDisposed();
            Invoke.std_vector_xyzi_clear(_ptr);
        }

        public override void Insert(long index, PointXYZI item)
        {
            ThrowIfDisposed();
            if ((ulong)index >= (ulong)Count)
            {
                ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
            }

            Invoke.std_vector_xyzi_insert(_ptr, (ulong)index, item);
        }

        public override void Resize(long size)
        {
            ThrowIfDisposed();
            Invoke.std_vector_xyzi_resize(_ptr, (ulong)size);
        }

        public override IEnumerator<PointXYZI> GetEnumerator()
        {
            long count = Count;
            for (var i = 0; i < count; i++)
            {
                yield return this[i];
            }
        }

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.std_vector_xyzi_delete(ref _ptr);
            }
        }
    }
}
