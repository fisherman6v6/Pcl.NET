using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET.Eigen
{
    public class Matrix4f : UnmanagedObject
    {
        public unsafe float* DataU => Invoke.eigen_matrix4_f_data(_ptr);

        public float this[int row, int col]
        {
            get
            {
                return Invoke.eigen_matrix4_f_get_index(_ptr, row, col);
            }
            set
            {
                Invoke.eigen_matrix4_f_set_index(_ptr, row, col, value);
            }
        }

        public Matrix4f()
        {
            _ptr = Invoke.eigen_matrix4_f_ctor();
        }

        internal Matrix4f(IntPtr ptr, bool suppressDispose)
        {
            _ptr = ptr;
            _suppressDispose = suppressDispose;
        }

        /// <summary>
        /// Copy from an existing Matrix4x4
        /// </summary>
        /// <param name="m">matrix to copy</param>
        public unsafe Matrix4f(Matrix4x4 m)
            : this()
        {
            float* start = &m.M11;
            int row = 0;
            int i = 0;
            for (; row < 4; row++)
            {
                int col = 0;
                while (col < 4)
                {
                    this[row, col] = start[i];
                    col++;
                    i++;
                }
            }
        }

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.eigen_matrix4_f_delete(ref _ptr);
            }
        }

        public static Matrix4f Identity()
        {
            Matrix4f m = new Matrix4f();
            m[0, 0] = 1;
            m[0, 1] = 0;
            m[0, 2] = 0;
            m[0, 3] = 0;
            m[1, 0] = 0;
            m[1, 1] = 1;
            m[1, 2] = 0;
            m[1, 3] = 0;
            m[2, 0] = 0;
            m[2, 1] = 0;
            m[2, 2] = 1;
            m[2, 3] = 0;
            m[3, 0] = 0;
            m[3, 1] = 0;
            m[3, 2] = 0;
            m[3, 3] = 1;

            return m;
        }
    }
}
