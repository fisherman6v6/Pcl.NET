using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public class VectorFloat : Vector<float>
    {
        public VectorFloat()
        {
            _ptr = Invoke.std_vector_float_ctor();
        }

        internal VectorFloat(IntPtr ptr)
        {
            _ptr = ptr;
            _suppressDispose = true;
        }

        public VectorFloat(long count)
        {
            _ptr = Invoke.std_vector_float_ctor_count((ulong)count);
        }

        public unsafe VectorFloat(float[] array)
        {
            _ptr = Invoke.std_vector_float_ctor_count((ulong)array.Length);
            CopyFromArray(array, DataU);
        }

        public override long Count => (long)Invoke.std_vector_float_size(_ptr);

        public override IntPtr Data => Invoke.std_vector_float_data(_ptr);

        public override void Add(float item)
        {
            ThrowIfDisposed();
            Invoke.std_vector_float_add(_ptr, item);
        }

        public override void At(long index, ref float value)
        {
            ThrowIfDisposed();
            Invoke.std_vector_float_at(_ptr, (ulong)index, ref value);
        }

        public override void Clear()
        {
            ThrowIfDisposed();
            Invoke.std_vector_float_clear(_ptr);
        }

        public override void Insert(long index, float item)
        {
            ThrowIfDisposed();
            Invoke.std_vector_float_insert(_ptr, (ulong)index, item);
        }

        public override void Resize(long size)
        {
            ThrowIfDisposed();
            Invoke.std_vector_float_resize(_ptr, (ulong)size);
        }

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.std_vector_float_delete(ref _ptr);
            }
        }
    }
}
