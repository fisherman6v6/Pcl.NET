using System;
using System.Runtime.CompilerServices;

namespace Pcl.NET
{
    internal class VectorXYZI : Vector<PointXYZI>
    {
        public VectorXYZI(IntPtr ptr)
        {
            _ptr = ptr;
        }

        public unsafe override PointXYZI this[long index]
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

        public unsafe PointXYZI* DataU => (PointXYZI*)(void*)Data;

        public override long Count => (long)Invoke.std_vector_xyzi_size(_ptr);

        public IntPtr Data => Invoke.std_vector_xyzi_data(_ptr);

        public override void Add(PointXYZI item)
        {
            Invoke.std_vector_xyzi_add(_ptr, item);
        }

        public override void At(long index, ref PointXYZI value)
        {
            if ((ulong)index >= (ulong)Count)
            {
                ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
            }

            Invoke.std_vector_xyzi_at(_ptr, (ulong)index, ref value);
        }

        public override void Clear()
        {
            Invoke.std_vector_xyzi_clear(_ptr);
        }

        public unsafe override void CopyTo(PointXYZI[] arr, int index)
        {
            if (Count > Array.MaxLength)
            {
                throw new IndexOutOfRangeException($"{nameof(Array.MaxLength)} is {Array.MaxLength}");
            }
            fixed (PointXYZI* aptr = arr)
            {
                System.Runtime.CompilerServices.Unsafe.CopyBlockUnaligned((void*)aptr, (void*)DataU, (uint)(System.Runtime.CompilerServices.Unsafe.SizeOf<PointXYZ>() * (uint)Count));
            }
        }

        public override void Insert(long index, PointXYZI item)
        {
            if ((ulong)index >= (ulong)Count)
            {
                ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
            }

            Invoke.std_vector_xyzi_insert(_ptr, (ulong)index, item);
        }

        public override void Resize(long size)
        {
            Invoke.std_vector_xyzi_resize(_ptr, (ulong)size);
        }

        public unsafe override PointXYZI[] ToArray()
        {
            if (Count > Array.MaxLength)
            {
                throw new IndexOutOfRangeException($"{nameof(Array.MaxLength)} is {Array.MaxLength}");
            }
            PointXYZI[] arr = new PointXYZI[Count];
            fixed (PointXYZI* aptr = arr)
            {
                Unsafe.CopyBlockUnaligned((void*)aptr, (void*)DataU, (uint)(Unsafe.SizeOf<PointXYZI>() * arr.Length));
            }
            return arr;
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
