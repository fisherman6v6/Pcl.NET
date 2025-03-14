using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public class VectorInt : Vector<int>
    {
        public override IntPtr Data
        {
            get
            {
                return Invoke.std_vector_int_data(_ptr);
            }
        }
        public override long Count
        {
            get
            {
                ThrowIfDisposed();
                return (long)Invoke.std_vector_int_size(_ptr);
            }
        }

        public VectorInt()
        {
            _ptr = Invoke.std_vector_int_ctor();
        }

        public VectorInt(long count)
        {
            _ptr = Invoke.std_vector_int_ctor_count((ulong)count);
        }
        internal VectorInt(IntPtr ptr)
        {
            _ptr = ptr;
            _suppressDispose = true;
        }
        public unsafe VectorInt(int[] array)
        {
            _ptr = Invoke.std_vector_int_ctor_count((ulong)array.Length);
            CopyFromArray(array, DataU);
        }
        public override void Add(int item)
        {
            ThrowIfDisposed();
            Invoke.std_vector_int_add(_ptr, item);
        }

        public override void At(long index, ref int value)
        {
            ThrowIfDisposed();
            Invoke.std_vector_int_at(_ptr, (ulong)index, ref value);
        }

        public override void Clear()
        {
            ThrowIfDisposed();
            Invoke.std_vector_int_clear(_ptr);
        }

        public override void Insert(long index, int item)
        {
            ThrowIfDisposed();
            Invoke.std_vector_int_insert(_ptr, (ulong)index, item);
        }

        public override void Resize(long size)
        {
            ThrowIfDisposed();
            Invoke.std_vector_int_resize(_ptr, (ulong)size);
        }

        public override IEnumerator<int> GetEnumerator()
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
                Invoke.std_vector_int_delete(ref _ptr);
            }
        }

    }
}
