using Pcl.NET.Eigen;
using System.Runtime.InteropServices;

namespace Pcl.NET
{
    internal static class Invoke
    {
        private const string DllName = "pcl-bindings";

        #region PointCloudXYZ

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyz_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyz_ctor_indices(IntPtr cloud, IntPtr indices);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyz_ctor_wh(long width, long height);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyz_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern PointXYZ* pointcloud_xyz_at_colrow(IntPtr ptr, ulong col, ulong row);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyz_clear(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void pointcloud_xyz_add(IntPtr ptr, PointXYZ* value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyz_downsample(IntPtr ptr, int factor, IntPtr output);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong pointcloud_xyz_size(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyz_data(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint pointcloud_xyz_width(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyz_width_set(IntPtr ptr, uint width);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint pointcloud_xyz_height(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyz_height_set(IntPtr ptr, uint height);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyz_points(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyz_set_is_dense(IntPtr ptr, bool value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool pointcloud_xyz_get_is_dense(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool pointcloud_xyz_is_organized(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyz_concatenate(IntPtr ptr1, IntPtr ptr2, IntPtr out_ptr);

        #endregion

        #region PointCloudXYZI

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyzi_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyzi_ctor_indices(IntPtr cloud, IntPtr indices);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyzi_ctor_wh(long width, long height);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzi_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern PointXYZ* pointcloud_xyzi_at_colrow(IntPtr ptr, ulong col, ulong row);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzi_clear(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void pointcloud_xyzi_add(IntPtr ptr, PointXYZI* value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzi_downsample(IntPtr ptr, int factor, IntPtr output);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong pointcloud_xyzi_size(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyzi_data(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint pointcloud_xyzi_width(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzi_width_set(IntPtr ptr, uint width);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint pointcloud_xyzi_height(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzi_height_set(IntPtr ptr, uint height);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyzi_points(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzi_set_is_dense(IntPtr ptr, bool value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool pointcloud_xyzi_get_is_dense(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool pointcloud_xyzi_is_organized(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzi_concatenate(IntPtr ptr1, IntPtr ptr2, IntPtr out_ptr);

        #endregion

        #region VectorXYZ

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_xyz_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_xyz_ctor_count(ulong count);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyz_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyz_at(IntPtr ptr, ulong idx, ref PointXYZ value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong std_vector_xyz_size(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyz_clear(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyz_resize(IntPtr ptr, ulong size);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyz_add(IntPtr ptr, PointXYZ value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_xyz_data(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyz_insert(IntPtr ptr, ulong idx, PointXYZ value);

        #endregion

        #region VectorXYZI

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_xyzi_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_xyzi_ctor_count(ulong count);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyzi_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyzi_at(IntPtr ptr, ulong idx, ref PointXYZI value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong std_vector_xyzi_size(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyzi_clear(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyzi_resize(IntPtr ptr, ulong size);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyzi_add(IntPtr ptr, PointXYZI value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_xyzi_data(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyzi_insert(IntPtr ptr, ulong idx, PointXYZI value);

        #endregion

        #region VectorByte

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_byte_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_byte_ctor_count(ulong count);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_byte_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_byte_at(IntPtr ptr, ulong idx, ref byte value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong std_vector_byte_size(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_byte_clear(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_byte_resize(IntPtr ptr, ulong size);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_byte_add(IntPtr ptr, byte value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_byte_data(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_byte_insert(IntPtr ptr, ulong idx, byte value);


        #endregion

        #region IO

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int io_load_pcd_xyz(string fileName, IntPtr cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int io_load_pcd_xyzi(string fileName, IntPtr cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int io_save_pcd_xyz_binary(string fileName, IntPtr cloud, int compressed);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int io_save_pcd_xyzi_binary(string fileName, IntPtr cloud, int compressed);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int io_save_pcd_xyz_ascii(string fileName, IntPtr cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int io_save_pcd_xyzi_ascii(string fileName, IntPtr cloud);

        #endregion

        #region CropBox
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pcl_cropbox_pointxyz_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pcl_cropbox_pointxyz_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pcl_cropbox_pointxyz_set_min(IntPtr ptr, Eigen.Vector4f min);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector4f pcl_cropbox_pointxyz_get_min(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pcl_cropbox_pointxyz_set_max(IntPtr ptr, Eigen.Vector4f max);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector4f pcl_cropbox_pointxyz_get_max(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyz_set_translation(IntPtr ptr, Eigen.Vector3f transform);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector3f cropbox_pointxyz_get_translation(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyz_set_rotation(IntPtr ptr, Eigen.Vector3f transform);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector3f cropbox_pointxyz_get_rotation(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyz_set_input_cloud(IntPtr ptr, IntPtr cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cropbox_pointxyz_get_input_cloud(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyz_filter(IntPtr ptr, IntPtr outputCloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyz_set_indices(IntPtr ptr, ulong row_start, ulong col_start, ulong nb_rows, ulong nb_cols);

        #endregion
    }
}
