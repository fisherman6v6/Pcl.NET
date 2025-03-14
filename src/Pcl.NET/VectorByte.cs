using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public class VectorByte : Vector<byte>
    {
        public override IntPtr Data
        {
            get
            {
                return Invoke.std_vector_byte_data(_ptr);
            }
        }

        public override long Count
        {
            get
            {
                ThrowIfDisposed();
                return (long)Invoke.std_vector_byte_size(_ptr);
            }
        }

        public unsafe VectorByte(byte[] arr)
        {
            _ptr = Invoke.std_vector_byte_ctor_count((ulong)arr.Length);
            CopyFromArray(arr, DataU);
        }

        internal VectorByte(IntPtr ptr)
        {
            _suppressDispose = true;
            _ptr = ptr;
        }

        public VectorByte()
        {
            _ptr = Invoke.std_vector_byte_ctor();
        }

        public VectorByte(long count)
        {
            _ptr = Invoke.std_vector_byte_ctor_count((ulong)count);
        }

        public override void Add(byte item)
        {
            ThrowIfDisposed();
            Invoke.std_vector_byte_add(_ptr, item);
        }

        public override void At(long index, ref byte value)
        {
            ThrowIfDisposed();
            Invoke.std_vector_byte_at(_ptr, (ulong)index, ref value);
        }

        public override void Clear()
        {
            ThrowIfDisposed();
            Invoke.std_vector_byte_clear(_ptr);
        }

        public override void Insert(long index, byte item)
        {
            ThrowIfDisposed();
            Invoke.std_vector_byte_insert(_ptr, (ulong)index, item);
        }

        public override void Resize(long size)
        {
            ThrowIfDisposed();
            Invoke.std_vector_byte_resize(_ptr, (ulong)size);
        }

        public override IEnumerator<byte> GetEnumerator()
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
                Invoke.std_vector_byte_delete(ref _ptr);
            }
        }
    }
}
