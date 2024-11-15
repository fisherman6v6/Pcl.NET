using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
  public abstract class PointCloud<PointT> : UnmanagedObject
  {
    public abstract uint Width { get; set; }

    public abstract uint Height { get; set; }

    public abstract bool IsDense { get; set; }

    public abstract Vector<PointT> Points { get; }

    public abstract ulong Count { get; }

    public abstract bool IsOrganized { get; }

    public abstract ref PointT At(ulong col, ulong row);

    public abstract void Add(PointT value);
  }
}
