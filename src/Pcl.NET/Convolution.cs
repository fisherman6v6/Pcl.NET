using System.Reflection;
using System.Threading;

namespace Pcl.NET
{
    public abstract class Convolution<PointIn, PointOut> : UnmanagedObject where PointIn : unmanaged where PointOut : unmanaged
    {
        /// <summary>
        /// Defines the policy for handling borders during convolution.
        /// </summary>
        public abstract BordersPolicy BordersPolicy { get; set; }
        /// <summary>
        /// In 3D the next point in (u,v) coordinate can be really far so a distance threshold is used to keep us from ghost points. The value you set here is strongly related to the sensor.
        /// </summary>
        public abstract float DistanceThreshold { get; set; }
        /// <summary>
        /// Initialize the scheduler and set the number of threads to use (0 sets the value back to automatic)
        /// </summary>
        public abstract int NumberOfThreads { get; set; }
        /// <summary>
        /// The input point cloud to be convolved.
        /// </summary>
        public abstract PointCloud<PointIn>? Input { get; set; }
        /// <summary>
        /// Set convolving kernel
        /// </summary>
        public abstract Eigen.ArrayXf? Kernel { get; set; }
        /// <summary>
        /// Convolve a float image rows by a given kernel. if output doesn't fit in input i.e. output.rows () < input.rows () or output.cols() < input.cols() then output is resized to input sizes.
        /// </summary>
        /// <returns></returns>
        public abstract PointCloud<PointOut> ConvolveRows();
        /// <summary>
        /// /** Convolve a float image columns by a given kernel. if output doesn't fit in input i.e. output.rows () < input.rows () or output.cols() < input.cols() then output is resized to input sizes.
        /// </summary>
        /// <returns></returns>
        public abstract PointCloud<PointOut> ConvolveColumns();
        /// <summary>
        /// Convolve point cloud with same kernel along rows and columns separately.
        /// </summary>
        /// <returns></returns>
        public abstract PointCloud<PointOut> Convolve();
    }

    public enum BordersPolicy
    {
        BORDERS_POLICY_IGNORE = -1,
        BORDERS_POLICY_MIRROR = 0,
        BORDERS_POLICY_DUPLICATE = 1
    }
}
