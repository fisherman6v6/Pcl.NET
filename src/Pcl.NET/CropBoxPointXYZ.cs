using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public class CropBoxPointXYZ : UnmanagedObject
    {
        public CropBoxPointXYZ()
        {
            _ptr = Invoke.pcl_cropbox_pointxyz_ctor();
        }

        public Eigen.Vector4f Min
        {
            get
            {
                return Invoke.pcl_cropbox_pointxyz_get_min(_ptr);
            }
            set
            {
                Invoke.pcl_cropbox_pointxyz_set_min(_ptr, value);
            }
        }

        public Eigen.Vector4f Max
        {
            get
            {
                return Invoke.pcl_cropbox_pointxyz_get_max(_ptr);
            }
            set
            {
                Invoke.pcl_cropbox_pointxyz_set_max(_ptr, value);
            }
        }

        public Eigen.Vector3f Translation
        {
            get
            {
                return Invoke.cropbox_pointxyz_get_translation(_ptr);
            }
            set
            {
                Invoke.cropbox_pointxyz_set_translation(_ptr, value);
            }
        }

        public Eigen.Vector3f Rotation
        {
            get
            {
                return Invoke.cropbox_pointxyz_get_rotation(_ptr);
            }
            set
            {
                Invoke.cropbox_pointxyz_set_rotation(_ptr, value);
            }
        }

        public PointCloudXYZ Input
        {
            get
            {
                var ptr = Invoke.cropbox_pointxyz_get_input_cloud(_ptr);
                return new PointCloudXYZ(ptr, true);
            }
            set
            {
                Invoke.cropbox_pointxyz_set_input_cloud(_ptr, value);
            }
        }

        public PointCloudXYZ Filter()
        {
            PointCloudXYZ output = new PointCloudXYZ();
            Invoke.cropbox_pointxyz_filter(_ptr, output);
            return output;
        }

        public void SetIndices(long rowStart, long colStart, long nRows, long nCols)
        {
            Invoke.cropbox_pointxyz_set_indices(_ptr, (ulong)rowStart, (ulong)colStart, (ulong)nRows, (ulong)nCols);
        }

        #region Dispose
        
        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.pcl_cropbox_pointxyz_delete(ref _ptr);
            }
        } 

        #endregion
    }
}
