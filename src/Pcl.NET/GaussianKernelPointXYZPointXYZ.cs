namespace Pcl.NET
{
    public class GaussianKernelPointXYZPointXYZ : GaussianKernel<PointXYZ, PointXYZ>
    {
        private float _sigma;
        private float _threshold;
        private float _thresholdRelativeToSigma;
        private PointCloud<PointXYZ>? _input;

        public override float Sigma
        {
            get
            {
                ThrowIfDisposed();
                return _sigma;
            }
            set
            {
                ThrowIfDisposed();
                Invoke.gaussian_kernel_pointxyz_pointxyz_set_sigma(_ptr, value);
                _sigma = value;
            }
        }
        public override float Threshold
        {
            get
            {
                ThrowIfDisposed();
                return _threshold;
            }
            set
            {
                ThrowIfDisposed();
                Invoke.gaussian_kernel_pointxyz_pointxyz_set_threshold(_ptr, value);
                _threshold = value;
            }
        }
        public override float ThresholdRelativeToSigma
        {
            get
            {
                ThrowIfDisposed();
                return _thresholdRelativeToSigma;
            }
            set
            {
                ThrowIfDisposed();
                Invoke.gaussian_kernel_pointxyz_pointxyz_set_threshold_relative_to_sigma(_ptr, value);
                _thresholdRelativeToSigma = value;
            }
        }
        public override PointCloud<PointXYZ>? Input
        {
            get
            {
                ThrowIfDisposed();
                return _input;
            }
            set
            {
                ThrowIfDisposed();
                Invoke.gaussian_kernel_pointxyz_pointxyz_set_input_cloud(_ptr, value);
                _input = value;
            }
        }

        public GaussianKernelPointXYZPointXYZ()
        {
            _ptr = Invoke.gaussian_kernel_pointxyz_pointxyz_ctor();
        }
        public override void InitCompute()
        {
            Invoke.gaussian_kernel_pointxyz_pointxyz_init_compute(_ptr);
        }

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.gaussian_kernel_pointxyz_pointxyz_delete(ref _ptr);
                _ptr = IntPtr.Zero;
            }
        }
    }
}
