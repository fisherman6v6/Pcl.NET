using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public abstract class CropBox<PointT> : Filter<PointT> where PointT : unmanaged
    {
        /// <summary>
        /// Set the minimum point of the box
        /// </summary>
        public abstract Eigen.Vector4f Min { get; set; }
        /// <summary>
        /// Set the maximum point of the box
        /// </summary>
        public abstract Eigen.Vector4f Max { get; set; }
        /// <summary>
        /// Set a translation value for the box. The (tx,ty,tz) values that the box should be translated by
        /// </summary>
        public abstract Eigen.Vector3f Translation { get; set; }
        /// <summary>
        /// Set a rotation value for the box. The (rx,ry,rz) values that the box should be rotated by
        /// </summary>
        public abstract Eigen.Vector3f Rotation { get; set; }
        /// <summary>
        /// Set whether the output point cloud should be organized or not. If set to true, the output will have the same structure as the input point cloud with filtered points having the value (NaN,NaN,NaN)
        /// </summary>
        public abstract bool KeepOrganized { get; set; }
    }
}
