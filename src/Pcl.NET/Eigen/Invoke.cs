using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET.Eigen
{
    internal static class Invoke
    {
        private const string DllName = "pcl-bindings";

        #region Matrix4f

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_matrix4_f_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_matrix4_f_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float eigen_matrix4_f_get_index(IntPtr ptr, int row, int col);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_matrix4_f_set_index(IntPtr ptr, int row, int col, float value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern float* eigen_matrix4_f_data(IntPtr ptr); 

        #endregion
    }
}
