using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public class VectorXYZRGBA : Vector<PointXYZRGBA>
    {
        public VectorXYZRGBA()
        {
            _ptr = Invoke.std_vector_xyzrgba_ctor();
        }

        public VectorXYZRGBA(long count)
        {
            _ptr = Invoke.std_vector_xyzrgba_ctor_count((ulong)count);
        }

        /// <summary>
        /// construct as a copy of the list
        /// </summary>
        /// <param name="list"></param>
        public unsafe VectorXYZRGBA(PointXYZRGBA[] arr)
        {
            _ptr = Invoke.std_vector_xyzrgba_ctor_count((ulong)arr.Length);
            PointXYZRGBA* dptr = (PointXYZRGBA*)(void*)Data;
            for (int i = 0; i < arr.Length; i++)
            {
                System.Runtime.CompilerServices.Unsafe.Write(dptr + i, arr[i]);
            }
        }
        internal VectorXYZRGBA(IntPtr ptr)
        {
            _ptr = ptr;
            _suppressDispose = true;
        }

        public unsafe override PointXYZRGBA this[long index]
        {
            get
            {
                // Following trick can reduce the range check by one
                if ((ulong)index >= (ulong)Count)
                {
                    ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
                }

                return DataU[index];
            }
            set
            {
                if ((ulong)index >= (ulong)Count)
                {
                    ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
                }

                Unsafe.Write(DataU + index, value);
            }
        }

        public override IntPtr Data
        {
            get
            {
                return Invoke.std_vector_xyzrgba_data(_ptr);
            }
        }

        public override long Count
        {
            get
            {
                ThrowIfDisposed();
                return (long)Invoke.std_vector_xyzrgba_size(_ptr);
            }
        }

        public override void Add(PointXYZRGBA item)
        {
            ThrowIfDisposed();
            Invoke.std_vector_xyzrgba_add(_ptr, item);
        }

        public override void At(long index, ref PointXYZRGBA value)
        {
            ThrowIfDisposed();
            Invoke.std_vector_xyzrgba_at(_ptr, (ulong)index, ref value);
        }

        public override void Clear()
        {
            ThrowIfDisposed();
            Invoke.std_vector_xyzrgba_clear(_ptr);
        }

        public override void Insert(long index, PointXYZRGBA item)
        {
            ThrowIfDisposed();
            Invoke.std_vector_xyzrgba_insert(_ptr, (ulong)index, item);
        }

        public override void Resize(long size)
        {
            ThrowIfDisposed();
            Invoke.std_vector_xyzrgba_resize(_ptr, (ulong)size);
        }

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.std_vector_xyzrgba_delete(ref _ptr);
            }
        }
    }
}
