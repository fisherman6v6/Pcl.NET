using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET.Eigen
{
    public class Affine3f : UnmanagedObject
    {
        private Matrix4f _matrix;

        public Affine3f()
        {
            _ptr = Invoke.eigen_affine3f_ctor_identity();
            _matrix = new Matrix4f(Invoke.eigen_affine3f_get_matrix(_ptr), true);
        }

        public Matrix4f Matrix
        {
            get
            {
                ThrowIfDisposed();
                return _matrix;
            }
            set
            {
                ThrowIfDisposed();
                Invoke.eigen_affine3f_set_matrix(_ptr, value);
                _matrix = value;
            }
        }

        public void Rotate(double rx,  double ry, double rz)
        {
            ThrowIfDisposed();
            Invoke.eigen_affine3f_rotate_xyz(_ptr, (float)rx, (float)ry, (float)rz);
        }

        public void Translate(double tx, double ty, double tz)
        {
            ThrowIfDisposed();
            Invoke.eigen_affine3f_translate_xyz(_ptr, (float)tx, (float)ty, (float)tz);
        }

        public void Scale(double scale)
        {
            ThrowIfDisposed();
            Invoke.eigen_affine3f_scale(_ptr, (float)scale);
        }

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.eigen_affine3f_delete(ref _ptr);
            }
        }
    }
}
