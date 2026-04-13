using Pcl.NET.Eigen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public class ConvolutionPointXYZPointXYZ : Convolution<PointXYZ, PointXYZ>
    {
        private int _numberOfThreads;
        private PointCloud<PointXYZ>? _input;
        private ArrayXf? _kernel;

        public override BordersPolicy BordersPolicy
        {
            get
            {
                ThrowIfDisposed();
                return (BordersPolicy)Invoke.convolution_pointxyz_pointxyz_get_borders_policy(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.convolution_pointxyz_pointxyz_set_borders_policy(_ptr, (int)value);
            }
        }
        public override float DistanceThreshold
        {
            get
            {   ThrowIfDisposed();
                return Invoke.convolution_pointxyz_pointxyz_get_distance_threshold(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.convolution_pointxyz_pointxyz_set_distance_threshold(_ptr, value);
            }
        }
        public override int NumberOfThreads
        {
            get
            {
                ThrowIfDisposed();
                return _numberOfThreads;
            }
            set
            {
                ThrowIfDisposed();
                _numberOfThreads = value;
                Invoke.convolution_pointxyz_pointxyz_set_threads(_ptr, value);
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
                _input = value;
                Invoke.convolution_pointxyz_pointxyz_set_input_cloud(_ptr, value);
            }
        }
        public override ArrayXf? Kernel
        {
            get
            {
                ThrowIfDisposed();
                return _kernel;
            }
            set
            {
                ThrowIfDisposed();
                _kernel = value;
                Invoke.convolution_pointxyz_pointxyz_set_kernel(_ptr, value);
            }
        }

        public ConvolutionPointXYZPointXYZ()
        {
            _ptr = Invoke.convolution_pointxyz_pointxyz_ctor();
        }

        public override PointCloud<PointXYZ> Convolve()
        {
            ThrowIfDisposed();
            ThrowIfInputNotSet();
            PointCloudXYZ ouput = new();
            Invoke.convolution_pointxyz_pointxyz_convolve_rows(_ptr, ouput);
            return ouput;
        }

        public override PointCloud<PointXYZ> ConvolveColumns()
        {
            ThrowIfDisposed();
            ThrowIfInputNotSet();
            PointCloudXYZ ouput = new();
            Invoke.convolution_pointxyz_pointxyz_convolve_cols(_ptr, ouput);
            return ouput;
        }

        public override PointCloud<PointXYZ> ConvolveRows()
        {
            ThrowIfDisposed();
            ThrowIfInputNotSet();
            PointCloudXYZ ouput = new();
            Invoke.convolution_pointxyz_pointxyz_convolve(_ptr, ouput);
            return ouput;
        }

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.convolution_pointxyz_pointxyz_delete(ref _ptr);
                _ptr = IntPtr.Zero;
            }
        }
    }
}
