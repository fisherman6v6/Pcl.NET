using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
  internal class PCDWriter : UnmanagedObject
  {
    public PCDWriter()
    {
      _ptr = Invoke.io_pcdwriter_ctor();
    }

    public void Write(string fileName, PointCloud<PointXYZ> cloud, bool binary = true)
    {
      int err = Invoke.io_pcdwriter_write_xyz(_ptr, fileName, cloud, binary ? 1 : 0);

#warning TODO check err
    }

    protected override void DisposeObject()
    {
      Invoke.io_pcdreader_delete(ref _ptr);
    }
  }
}
