using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
  public class PCDReader : UnmanagedObject
  {
    public PCDReader()
    {
      _ptr = Invoke.io_pcdreader_ctor();
    }

    public void Read(string fileName, PointCloudXYZ cloud, int offset = 0)
    {
      int err = Invoke.io_pcdreader_read_xyz(_ptr, fileName, cloud.Ptr, offset);
#warning TODO check err
    }

    protected override void DisposeObject()
    {
      Invoke.io_pcdreader_delete(ref _ptr);
    }
  }
}
