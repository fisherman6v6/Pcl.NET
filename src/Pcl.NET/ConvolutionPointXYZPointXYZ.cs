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
                return (BordersPolicy)Invoke.convolution_pointxyz_pointxyz_get_borders_policy(_ptr);
            }
            set
            {
                Invoke.convolution_pointxyz_pointxyz_set_borders_policy(_ptr, (int)value);
            }
        }
        public override float DistanceThreshold
        {
            get
            {
                return Invoke.convolution_pointxyz_pointxyz_get_distance_threshold(_ptr);
            }
            set
            {
                Invoke.convolution_pointxyz_pointxyz_set_distance_threshold(_ptr, value);
            }
        }
        public override int NumberOfThreads
        {
            get
            {
                return _numberOfThreads;
            }
            set

            {
                _numberOfThreads = value;
                Invoke.convolution_pointxyz_pointxyz_set_threads(_ptr, value);
            }
        }
        public override PointCloud<PointXYZ>? Input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
                Invoke.convolution_pointxyz_pointxyz_set_input_cloud(_ptr, value);
            }
        }
        public override ArrayXf? Kernel
        {
            get
            {
                return _kernel;
            }
            set
            {
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
            PointCloudXYZ ouput = new();
            Invoke.convolution_pointxyz_pointxyz_convolve_rows(_ptr, ouput);
            return ouput;
        }

        public override PointCloud<PointXYZ> ConvolveColumns()
        {
            PointCloudXYZ ouput = new();
            Invoke.convolution_pointxyz_pointxyz_convolve_cols(_ptr, ouput);
            return ouput;
        }

        public override PointCloud<PointXYZ> ConvolveRows()
        {
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
