namespace Pcl.NET
{
    public abstract class GaussianKernel<PointIn, PointOut> : ConvolvingKernel<PointIn, PointOut> where PointIn : unmanaged where PointOut : unmanaged
    {
        /// <summary>
        /// Sigma (standard deviatiation) parameter of the Gaussian Kernel
        /// </summary>
        public abstract float Sigma { get; set; }
        /// <summary>
        /// Set the distance threshold such as pi, ||pi - q|| > threshold are not considered.
        /// </summary>
        public abstract float Threshold { get; set; }
        /// <summary>
        /// Set the distance threshold relative to a sigma factor i.e. points such as ||pi - q|| > sigma_coefficient^2 * sigma^2 are not considered.
        /// </summary>
        public abstract float ThresholdRelativeToSigma { get; set; }
    }
}
