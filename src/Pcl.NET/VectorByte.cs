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
        public unsafe override byte this[long index]
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

        public unsafe byte* Data => (byte*)Invoke.std_vector_byte_data(_ptr);

        public override long Count => (long)Invoke.std_vector_byte_size(_ptr);

        public unsafe VectorByte(byte[] arr)
        {
            _ptr = Invoke.std_vector_byte_ctor_count((ulong)arr.Length);
            byte* dptr = (byte*)(void*)Data;
            for (int i = 0; i < arr.Length; i++)
            {
                System.Runtime.CompilerServices.Unsafe.Write(dptr + i, arr[i]);
            }
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
            Invoke.std_vector_byte_add(_ptr, item);
        }

        public override void At(long index, ref byte value)
        {
            Invoke.std_vector_byte_at(_ptr, (ulong)index, ref value);
        }

        public override void Clear()
        {
            Invoke.std_vector_byte_clear(_ptr);
        }

        public override void CopyTo(byte[] arr, int index)
        {
            throw new NotImplementedException();
        }

        public override void Insert(long index, byte item)
        {
            Invoke.std_vector_byte_insert(_ptr, (ulong)index, item);
        }

        public override void Resize(long size)
        {
            Invoke.std_vector_byte_resize(_ptr, (ulong)size);
        }

        public unsafe override byte[] ToArray()
        {
            if (Count > Array.MaxLength)
            {
                throw new IndexOutOfRangeException($"{nameof(Array.MaxLength)} is {Array.MaxLength}");
            }
            byte[] arr = new byte[Count];
            fixed (byte* aptr = arr)
            {
                Unsafe.CopyBlockUnaligned((void*)aptr, (void*)Data, (uint)(Unsafe.SizeOf<byte>() * arr.Length));
            }
            return arr;
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
