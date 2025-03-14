using System.Collections;
using System.Runtime.CompilerServices;

namespace Pcl.NET
{
    public abstract class Vector<T> : UnmanagedObject, IEnumerable<T> where T : unmanaged
    {
        public unsafe virtual T this[long index]
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

        public abstract long Count { get; }

        public abstract IntPtr Data { get; }

        public unsafe T* DataU => (T*)(void*)Data;

        public abstract void Add(T item);

        public virtual T[] ToArray(int start, int length)
        {
            var array = new T[length];
            CopyTo(array, start, length);
            return array;
        }

        public unsafe virtual void CopyTo(T[] arr, int start, int length)
        {
            ThrowIfDisposed();

            if (start + length > Count)
            {
                throw new IndexOutOfRangeException();
            }

            fixed (T* aptr = arr)
            {
                System.Runtime.CompilerServices.Unsafe.CopyBlockUnaligned((void*)aptr, (void*)(DataU + start), (uint)(System.Runtime.CompilerServices.Unsafe.SizeOf<T>() * (uint)length));
            }
        }

        public abstract void Clear();

        public abstract void Insert(long index, T item);

        public abstract void Resize(long size);

        public abstract void At(long index, ref T value);

        public unsafe virtual Span<T> AsSpan(int start, int length)
        {
            ThrowIfDisposed();

            if (start + length > Count)
            {
                throw new IndexOutOfRangeException();
            }

            Span<T> span = new Span<T>((DataU + start), length);

            return span;
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return this.Select(x => x)
              .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal unsafe static void CopyFromArray(T[] arr, T* dptr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Unsafe.Write(dptr + i, arr[i]);
            }
        }
    }
}
