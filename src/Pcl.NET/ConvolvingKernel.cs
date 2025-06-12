using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public abstract class ConvolvingKernel<PointIn, PointOut> : UnmanagedObject where PointIn : unmanaged where PointOut : unmanaged
    {
        /// <summary>
        /// Input source point cloud
        /// </summary>
        public abstract PointCloud<PointIn>? Input { get; set; }

        public abstract void InitCompute();
    }
}
