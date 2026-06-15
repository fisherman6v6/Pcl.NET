using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public abstract class Registration<PointSource, PointTarget> : PclBase<PointSource> where PointSource : unmanaged where PointTarget : unmanaged
    {
        /// <summary>
        /// /// <summary>
        /// Get or Set the maximum number of iterations the internal optimization should run for.
        /// </summary>
        public abstract int MaximumIterations { get; set; }
        /// <summary>
        /// Get or Set the maximum distance threshold between two correspondent points in source <-> target.
        /// </summary>
        public abstract double MaxCorrespondenceDistance { get; set; }
        /// <summary>
        /// Get or Set the number of iterations RANSAC should run for, as set by the user.
        /// </summary>
        public abstract double RANSACOutlierRejectionThreshold { get; set; }
        /// <summary>
        /// Get or Set the transformation epsilon 
        /// (maximum allowable translation squared difference between two consecutive transformations) 
        /// in order for an optimization to be considered as having converged to the final solution.
        /// </summary>
        public abstract double TransformationEpsilon { get; set; }
        /// <summary>
        /// Get or Set the transformation rotation epsilon 
        /// (maximum allowable rotation difference between two consecutive transformations) 
        /// in order for an optimization to be considered as having converged to the final solution.
        /// </summary>
        public abstract double TransformationRotationEpsilon { get; set; }
        /// <summary>
        /// Get or Set the maximum allowed Euclidean error between two consecutive steps in the ICP loop, before the algorithm is considered to have converged.
        /// </summary>
        public abstract double EuclideanFitnessEpsilon { get; set; }
        /// <summary>
        /// Get or set the input source (e.g., the point cloud that we want to align to the target)
        /// </summary>
        public abstract PointCloud<PointSource> InputSource { get; set; }
        /// <summary>
        /// Get or set the input target (e.g., the point cloud that we want to align the input source to)
        /// </summary>
        public abstract PointCloud<PointTarget> InputTarget { get; set; }
        /// <summary>
        /// Call the registration algorithm which estimates the transformation and returns the transformed source (input) as output.
        /// </summary>
        /// <param name="output">the resultant input transformed point cloud datase</param>
        public abstract void Align(PointCloud<PointSource> output);
        /// <summary>
        /// Call the registration algorithm which estimates the transformation and returns the transformed source (input) as output.
        /// </summary>
        /// <param name="output">the resultant input transformed point cloud datase</param>
        /// <param name="guess">the initial gross estimation of the transformation</param>
        public abstract void Align(PointCloud<PointSource> output, Eigen.Matrix4f guess);
    }
}
