using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public class Convolution3DGaussianKernelPointXYZPointXYZ : Convolution3D<PointXYZ, PointXYZ, GaussianKernel<PointXYZ, PointXYZ>>
    {
        private readonly VectorInt _indices;
        private PointCloud<PointXYZ>? _input = null;
        private GaussianKernel<PointXYZ, PointXYZ>? _kernel = null;
        private int _numberOfThreads;

        public override int NumberOfThreads
        {
            get
            {
                return _numberOfThreads;
            }
            set
            {
                _numberOfThreads = value;
                Invoke.convolution_3d_gaussian_kernel_pointxyz_pointxyz_set_threads(_ptr, value);
            }
        }
        public override GaussianKernel<PointXYZ, PointXYZ>? Kernel
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
                Invoke.convolution_3d_gaussian_kernel_pointxyz_pointxyz_set_kernel(_ptr, _kernel);
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
                Invoke.convolution_3d_gaussian_kernel_pointxyz_pointxyz_set_input_cloud(_ptr, _input);
            }
        }
        public override VectorInt Indices
        {
            get
            {
                ThrowIfDisposed();
                Invoke.convolution_3d_gaussian_kernel_pointxyz_pointxyz_get_indices_vector(_ptr, _indices);
                return _indices;
            }
            set
            {
                ThrowIfDisposed();
                Invoke.convolution_3d_gaussian_kernel_pointxyz_pointxyz_set_indices_vector(_ptr, value);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Convolution3DGaussianKernelPointXYZPointXYZ"/> class.
        /// </summary>
        public Convolution3DGaussianKernelPointXYZPointXYZ()
        {
            _indices = new VectorInt();
            _ptr = Invoke.convolution_3d_gaussian_kernel_pointxyz_pointxyz_ctor();
        }
        
        public override PointCloud<PointXYZ> Convolve()
        {
            PointCloudXYZ output = new PointCloudXYZ();
            Invoke.convolution_3d_gaussian_kernel_pointxyz_pointxyz_convolve(_ptr, output);
            return output;
        }

        public override void SetIndices(long row_start, long col_start, long nb_rows, long nb_cols)
        {
            Invoke.convolution_3d_gaussian_kernel_pointxyz_pointxyz_set_indices(_ptr, row_start, col_start, nb_rows, nb_cols);
        }

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.convolution_3d_gaussian_kernel_pointxyz_pointxyz_delete(ref _ptr);
                _ptr = IntPtr.Zero;
            }
        }
    }
}
