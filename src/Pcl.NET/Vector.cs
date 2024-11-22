using System.Collections;

namespace Pcl.NET
{
    public abstract class Vector<T> : UnmanagedObject, IEnumerable<T>
    {
        public abstract T this[long index] { get; set; }

        public abstract long Count { get; }

        public abstract void Add(T item);

        public abstract PointXYZ[] ToArray();

        public abstract void CopyTo(PointXYZ[] arr, int idx);

        public abstract void Clear();

        public abstract void Insert(long index, T item);

        public abstract void Resize(long size);

        public abstract void At(long idx, ref T value);

        public virtual IEnumerator<T> GetEnumerator()
        {
            return this.Select(x => x)
              .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
