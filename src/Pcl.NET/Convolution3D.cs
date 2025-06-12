using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public abstract class Convolution3D<PointIn, PointOut, KernelT> : PclBase<PointIn> where PointOut : unmanaged where PointIn : unmanaged
    {
        /// <summary>
        /// Initialize the scheduler and set the number of threads to use (0 sets the value back to automatic)
        /// </summary>
        public abstract int NumberOfThreads { get; set; }
        /// <summary>
        /// Set convolving kernel
        /// </summary>
        public abstract KernelT? Kernel { get; set; }
        /// <summary>
        /// Convolve point cloud.
        /// </summary>
        /// <returns></returns>
        public abstract PointCloud<PointOut> Convolve();
    }
}
