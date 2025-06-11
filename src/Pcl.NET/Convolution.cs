namespace Pcl.NET
{
    public abstract class Convolution<PointIn, PointOut> : UnmanagedObject where PointIn : unmanaged where PointOut : unmanaged
    {
        public abstract BordersPolicy BordersPolicy { get; set; }

        public abstract float DistanceThreshold { get; set; }

        public abstract int NumberOfThreads { get; set; }

        public abstract PointCloud<PointIn>? Input { get; set; }

        public abstract Eigen.ArrayXf? Kernel { get; set; }

        public abstract PointCloud<PointOut> ConvolveRows();

        public abstract PointCloud<PointOut> ConvolveColumns();

        public abstract PointCloud<PointOut> Convolve();
    }

    public enum BordersPolicy
    {
        BORDERS_POLICY_IGNORE = -1,
        BORDERS_POLICY_MIRROR = 0,
        BORDERS_POLICY_DUPLICATE = 1
    }
}
