using System.Reflection;
using System.Runtime.InteropServices;

namespace Pcl.NET
{
    internal static class Invoke
    {
        private const string DllName = "pcl-bindings";

        static Invoke() => NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), OnImport);

        static string GetLibraryPath(string libraryName)
        {
            string path = string.Empty;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                path = Path.Combine("runtimes", $"win-{RuntimeInformation.OSArchitecture}", "native", libraryName);
            }
            return path;
        }

        private static nint OnImport(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
#if DEBUG
            // I expect to have libraries under the same folder of the app linking Pcl.NET, so no need to get path depending on arch
            return NativeLibrary.Load(libraryName, assembly, searchPath);
#else
            // Library is linked from nuget, so the path will be runtimes/os-ARCH/native
            var platFormDependantPath = GetLibraryPath(libraryName);
            return NativeLibrary.Load(platFormDependantPath, assembly, searchPath);
#endif
        }

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
        public unsafe static extern PointXYZ* pointcloud_xyz_at_colrow(IntPtr ptr, int col, int row);

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
        public static extern uint pointcloud_xyz_get_width(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyz_set_width(IntPtr ptr, uint width);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint pointcloud_xyz_get_height(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyz_set_height(IntPtr ptr, uint height);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyz_points(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyz_set_is_dense(IntPtr ptr, [MarshalAs(UnmanagedType.Bool)] bool value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
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
        public unsafe static extern PointXYZI* pointcloud_xyzi_at_colrow(IntPtr ptr, int col, int row);

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
        public static extern uint pointcloud_xyzi_get_width(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzi_set_width(IntPtr ptr, uint width);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint pointcloud_xyzi_get_height(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzi_set_height(IntPtr ptr, uint height);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyzi_points(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzi_set_is_dense(IntPtr ptr, [MarshalAs(UnmanagedType.Bool)] bool value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool pointcloud_xyzi_get_is_dense(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool pointcloud_xyzi_is_organized(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzi_concatenate(IntPtr ptr1, IntPtr ptr2, IntPtr out_ptr);

        #endregion

        #region PointCloudXYZRGBA

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyzrgba_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyzrgba_ctor_indices(IntPtr cloud, IntPtr indices);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyzrgba_ctor_wh(long width, long height);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzrgba_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern PointXYZRGBA* pointcloud_xyzrgba_at_colrow(IntPtr ptr, int col, int row);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzrgba_clear(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void pointcloud_xyzrgba_add(IntPtr ptr, PointXYZRGBA* value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzrgba_downsample(IntPtr ptr, int factor, IntPtr output);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong pointcloud_xyzrgba_size(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyzrgba_data(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint pointcloud_xyzrgba_get_width(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzrgba_set_width(IntPtr ptr, uint width);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint pointcloud_xyzrgba_get_height(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzrgba_set_height(IntPtr ptr, uint height);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyzrgba_points(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzrgba_set_is_dense(IntPtr ptr, [MarshalAs(UnmanagedType.Bool)] bool value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool pointcloud_xyzrgba_get_is_dense(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool pointcloud_xyzrgba_is_organized(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pointcloud_xyzrgba_concatenate(IntPtr ptr1, IntPtr ptr2, IntPtr out_ptr);

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

        #region VectorXYZRGBA

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_xyzrgba_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_xyzrgba_ctor_count(ulong count);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyzrgba_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyzrgba_at(IntPtr ptr, ulong idx, ref PointXYZRGBA value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong std_vector_xyzrgba_size(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyzrgba_clear(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyzrgba_resize(IntPtr ptr, ulong size);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyzrgba_add(IntPtr ptr, PointXYZRGBA value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_xyzrgba_data(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_xyzrgba_insert(IntPtr ptr, ulong idx, PointXYZRGBA value);

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

        #region VectorInt

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_int_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_int_ctor_count(ulong count);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_int_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_int_at(IntPtr ptr, ulong idx, ref int value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong std_vector_int_size(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_int_clear(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_int_resize(IntPtr ptr, ulong size);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_int_add(IntPtr ptr, int value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_int_data(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_int_insert(IntPtr ptr, ulong idx, int value);

        #endregion

        #region VectorFloat

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_float_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_float_ctor_count(ulong count);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_float_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_float_at(IntPtr ptr, ulong idx, ref float value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong std_vector_float_size(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_float_clear(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_float_resize(IntPtr ptr, ulong size);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_float_add(IntPtr ptr, float value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr std_vector_float_data(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void std_vector_float_insert(IntPtr ptr, ulong idx, float value);

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

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void io_save_png_xyzrgba(string fileName, IntPtr cloud, string field_name);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int io_load_pcd_xyzrgba(string fileName, IntPtr cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void io_pointcloud_xyzrgba_image_extractor_from_rgb_field(IntPtr cloud, IntPtr image, [MarshalAs(UnmanagedType.Bool)] bool setPaintNaNsWithBlack);

        #endregion

        #region CropBox
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cropbox_pointxyz_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyz_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyz_set_min(IntPtr ptr, Eigen.Vector4f min);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector4f cropbox_pointxyz_get_min(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyz_set_max(IntPtr ptr, Eigen.Vector4f max);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector4f cropbox_pointxyz_get_max(IntPtr ptr);

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
        public static extern void cropbox_pointxyz_set_filter_indices(IntPtr ptr, ulong row_start, ulong col_start, ulong nb_rows, ulong nb_cols);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyz_set_filter_indices_vector(IntPtr ptr, IntPtr indices);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyz_get_filter_indices_vector(IntPtr ptr, IntPtr indices);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cropbox_pointxyz_get_keep_organized(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyz_set_keep_organized(IntPtr ptr, int keep_organized);

        #endregion

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

        #region Vector4f

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_vectorx_f_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_vectorx_f_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float eigen_vectorx_f_get_index(IntPtr ptr, long index);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_vectorx_f_set_index(IntPtr ptr, long index);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern float* eigen_vectorx_f_data(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_vectorx_f_normalize(IntPtr ptr);

        #endregion

        #region Affine3f
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_affine3f_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_affine3f_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_affine3f_ctor_identity();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_affine3f_get_matrix(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_affine3f_set_matrix(IntPtr ptr, IntPtr matrix);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_affine3f_rotate_xyz(IntPtr ptr, float rx, float ry, float rz);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_affine3f_translate_xyz(IntPtr ptr, float tx, float ty, float tz);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_affine3f_scale(IntPtr ptr, float scale);

        #endregion

        #region Transform

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void transform_pointcloud_xyz(IntPtr affineTransform, IntPtr input, IntPtr output);

        #endregion

        #region Quaternionf

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_quaternion_f_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_quaternion_f_delete(ref IntPtr ptr);

        #endregion

        #region PCLImage

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pclimage_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pclimage_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint pclimage_get_width(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pclimage_set_width(IntPtr ptr, uint value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint pclimage_get_height(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pclimage_set_height(IntPtr ptr, uint value);
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pclimage_data(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string pclimage_get_encoding(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pclimage_set_encoding(IntPtr ptr, string encoding);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint pclimage_get_step(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pclimage_set_step(IntPtr ptr, uint value);

        #endregion
    }
}
