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
        public unsafe float* DataU => Invoke.eigen_matrix4f_data(_ptr);

        public float this[int row, int col]
        {
            get
            {
                if (row < 0 || col < 0 || row >= 4 || col >= 4)
                {
                    ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
                }
                return Invoke.eigen_matrix4f_get_index(_ptr, row, col);
            }
            set
            {
                if (row < 0 || col < 0 || row >= 4 || col >= 4)
                {
                    ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
                }
                Invoke.eigen_matrix4f_set_index(_ptr, row, col, value);
            }
        }

        public Matrix4f()
        {
            _ptr = Invoke.eigen_matrix4f_ctor();
        }

        internal Matrix4f(IntPtr ptr, bool suppressDispose)
        {
            _ptr = ptr;
            _suppressDispose = suppressDispose;
        }

        public float M11
        {
            get
            {
                return this[0, 0];
            }

            set
            {
                this[0, 0] = value;
            }
        }

        public float M12
        {
            get
            {
                return this[0, 1];
            }
            set
            {
                this[0, 1] = value;
            }
        }

        public float M13
        {
            get
            {
                return this[0, 2];
            }
            set
            {
                this[0,2] = value;
            }
        }

        public float M14
        {
            get
            {
                return this[0, 3];
            }
            set
            {
                this[0, 3] = value;
            }
        }

        public float M21
        {
            get
            {
                return this[1, 0];
            }
            set
            {
                this[1, 0] = value;
            }
        }

        public float M22
        {
            get
            {
                return this[1, 1];
            }
            set
            {
                this[1, 1] = value;
            }
        }

        public float M23
        {
            get
            {
                return this[1, 2];
            }
            set
            {
                this[0, 2] = value;
            }
        }

        public float M24
        {
            get
            {
                return this[1, 3];
            }
            set
            {
                this[1, 3] = value;
            }
        }

        public float M31
        {
            get
            {
                return this[2, 0];
            }
            set
            {
                this[2, 0] = value;
            }
        }

        public float M32
        {
            get
            {
                return this[2, 1];
            }
            set
            {
                this[2, 1] = value;
            }
        }

        public float M33
        {
            get
            {
                return this[2, 2];
            }
            set
            {
                this[2, 2] = value;
            }
        }

        public float M34
        {
            get
            {
                return this[2, 3];
            }
            set
            {
                this[2, 3] = value;
            }
        }

        public float M41
        {
            get
            {
                return this[3, 0];
            }
            set
            {
                this[3, 0] = value;
            }
        }

        public float M42
        {
            get
            {
                return this[3, 1];
            }
            set
            {
                this[3, 1] = value;
            }
        }

        public float M43
        {
            get
            {
                return this[3, 2];
            }
            set
            {
                this[3, 2] = value;
            }
        }

        public float M44
        {
            get
            {
                return this[3, 3];
            }
            set
            {
                this[3, 3] = value;
            }
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
                Invoke.eigen_matrix4f_delete(ref _ptr);
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
