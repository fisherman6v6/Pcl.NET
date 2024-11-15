using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
  public abstract class Vector<T> : UnmanagedObject, IEnumerable<T>
  {
    public abstract T this[ulong index] { get; set; }

    public abstract ulong Count { get; }

    public abstract void Add(T item);

    public abstract PointXYZ[] ToArray();

    public abstract void Clear();

    public abstract void Insert(ulong index, T item);

    public abstract void Resize(ulong size);

    public abstract void At(ulong idx, ref T value);

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
