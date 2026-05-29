using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public abstract class SACSegmentation<PointT> : PclBase<PointT> where PointT : unmanaged
    {
        /// <summary>
        /// Set the type of model to use
        /// </summary>
        public abstract SacModel ModelType { get; set; }
        /// <summary>
        /// Set the type of consensus method to use
        /// </summary>
        public abstract SacMethod MethodType { get; set; }
        /// <summary>
        /// Set the distance to the model threshold
        /// </summary>
        public abstract double DistanceThreshold { get; set; }
        /// <summary>
        /// Set the maximum number of iterations before giving up
        /// </summary>
        public abstract int MaxIterations { get; set; }
        /// <summary>
        /// Set if a coefficient refinement is required
        /// </summary>
        public abstract bool OptimizeCoefficients { get; set; }
        /// <summary>
        /// Set the minimum and maximum allowable radius limits for the model (applicable to models that estimate a radius)
        /// </summary>
        public abstract void SetRadiusLimits(double minRadius, double maxRadius);
        /// <summary>
        /// Get the minimum and maximum allowable radius limits for the model as set by the user
        /// </summary>
        public abstract void GetRadiusLimits(ref double minRadius, ref double maxRadius);
        /// <summary>
        /// Base method for segmentation of a model in a PointCloud given by <setInputCloud (), setIndices ()>
        /// </summary>
        public abstract float[] Segment();
    }

    public enum SacModel
    {
        SACMODEL_PLANE,
        SACMODEL_LINE,
        SACMODEL_CIRCLE2D,
        SACMODEL_CIRCLE3D,
        SACMODEL_SPHERE,
        SACMODEL_CYLINDER,
        SACMODEL_CONE,
        SACMODEL_TORUS,
        SACMODEL_PARALLEL_LINE,
        SACMODEL_PERPENDICULAR_PLANE,
        SACMODEL_PARALLEL_LINES,
        SACMODEL_NORMAL_PLANE,
        SACMODEL_NORMAL_SPHERE,
        SACMODEL_REGISTRATION,
        SACMODEL_REGISTRATION_2D,
        SACMODEL_PARALLEL_PLANE,
        SACMODEL_NORMAL_PARALLEL_PLANE,
        SACMODEL_STICK,
        SACMODEL_ELLIPSE3D
    }

    public enum SacMethod
    {
        SAC_RANSAC,
        SAC_LMEDS,
        SAC_MSAC,
        SAC_RRANSAC,
        SAC_RMSAC,
        SAC_MLESAC,
        SAC_PROSAC
    }
}
