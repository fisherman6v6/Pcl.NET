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
        public unsafe override int this[long index]
        {
            get
            {
                // Following trick can reduce the range check by one
                if ((ulong)index >= (ulong)Count)
                {
                    ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
                }

                return Data[index];
            }
            set
            {
                if ((ulong)index >= (ulong)Count)
                {
                    ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
                }

                Unsafe.Write(Data + index, value);
            }
        }

        public unsafe int* Data => (int*)Invoke.std_vector_int_data(_ptr);

        public override long Count => (long)Invoke.std_vector_int_size(_ptr);

        public VectorInt()
        {
            _ptr = Invoke.std_vector_int_ctor();
        }

        public VectorInt(long count)
        {
            _ptr = Invoke.std_vector_int_ctor_count((ulong)count);
        }

        public override void Add(int item)
        {
            Invoke.std_vector_int_add(_ptr, item);
        }

        public override void At(long index, ref int value)
        {
            Invoke.std_vector_int_at(_ptr, (ulong)index, ref value);
        }

        public override void Clear()
        {
            Invoke.std_vector_int_clear(_ptr);
        }

        public override void CopyTo(int[] arr, int index)
        {
            throw new NotImplementedException();
        }

        public override void Insert(long index, int item)
        {
            Invoke.std_vector_int_insert(_ptr, (ulong)index, item);
        }

        public override void Resize(long size)
        {
            Invoke.std_vector_int_resize(_ptr, (ulong)size);
        }

        public unsafe override int[] ToArray()
        {
            if (Count > Array.MaxLength)
            {
                throw new IndexOutOfRangeException($"{nameof(Array.MaxLength)} is {Array.MaxLength}");
            }
            int[] arr = new int[Count];
            fixed (int* aptr = arr)
            {
                Unsafe.CopyBlockUnaligned((void*)aptr, (void*)Data, (uint)(Unsafe.SizeOf<int>() * arr.Length));
            }
            return arr;
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
