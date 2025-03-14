using System.Runtime.CompilerServices;

namespace Pcl.NET
{
    public class VectorXYZ : Vector<PointXYZ>
    {
        public VectorXYZ()
        {
            _ptr = Invoke.std_vector_xyz_ctor();
        }

        public VectorXYZ(long count)
        {
            _ptr = Invoke.std_vector_xyz_ctor_count((ulong)count);
        }

        /// <summary>
        /// construct as a copy of the list
        /// </summary>
        /// <param name="list"></param>
        public unsafe VectorXYZ(PointXYZ[] arr)
        {
            _ptr = Invoke.std_vector_xyz_ctor_count((ulong)arr.Length);
            CopyFromArray(arr, DataU);
        }

        internal VectorXYZ(IntPtr ptr)
        {
            _suppressDispose = true;
            _ptr = ptr;
        }

        public override long Count
        {
            get
            {
                ThrowIfDisposed();
                return (long)Invoke.std_vector_xyz_size(_ptr);
            }
        }

        public override IntPtr Data
        {
            get
            {
                return Invoke.std_vector_xyz_data(_ptr);
            }
        }

        public override void Add(PointXYZ item)
        {
            ThrowIfDisposed();
            Invoke.std_vector_xyz_add(_ptr, item);
        }

        public override void At(long index, ref PointXYZ value)
        {
            ThrowIfDisposed();
            if ((ulong)index >= (ulong)Count)
            {
                ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
            }

            Invoke.std_vector_xyz_at(_ptr, (ulong)index, ref value);
        }

        public override void Clear()
        {
            ThrowIfDisposed();
            Invoke.std_vector_xyz_clear(_ptr);
        }

        public override void Insert(long index, PointXYZ item)
        {
            ThrowIfDisposed();
            if ((ulong)index >= (ulong)Count)
            {
                ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
            }

            Invoke.std_vector_xyz_insert(_ptr, (ulong)index, item);
        }

        public override void Resize(long size)
        {
            ThrowIfDisposed();
            Invoke.std_vector_xyz_resize(_ptr, (ulong)size);
        }

        public override IEnumerator<PointXYZ> GetEnumerator()
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
                Invoke.std_vector_xyz_delete(ref _ptr);
            }
        }
    }
}
