using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

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
            // Library is linked from nuget, so the path will be runtimes/os-ARCH/native
            var platFormDependantPath = GetLibraryPath(libraryName);
            if (NativeLibrary.TryLoad(platFormDependantPath, out nint handle))
            {
                return handle;
            }
            // in debug the library will be under the native folder
            string path = Path.Combine("native", libraryName);
            if (NativeLibrary.TryLoad(path, out handle))
            {
                return handle;
            }
            // fallback to app directory - last chance otherwise boom
            handle = NativeLibrary.Load(libraryName, assembly, searchPath);
            return handle;
        }

        #region Common

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void common_get_min_max_3d_pointxyz(IntPtr cloud, ref PointXYZ min, ref PointXYZ max);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void common_get_min_max_3d_pointxyzi(IntPtr cloud, ref PointXYZI min, ref PointXYZI max);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void common_get_min_max_3d_pointxyzrgba(IntPtr cloud, ref PointXYZRGBA min, ref PointXYZRGBA max);

        #endregion

        #region PointCloudXYZ

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyz_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyz_ctor_indices(IntPtr cloud, IntPtr indices);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr pointcloud_xyz_ctor_wh(uint width, uint height);

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
        public static extern IntPtr pointcloud_xyzi_ctor_wh(uint width, uint height);

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
        public static extern IntPtr pointcloud_xyzrgba_ctor_wh(uint width, uint height);

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
        public static extern int io_save_pcd_xyzrgba_binary(string filename, IntPtr cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int io_save_pcd_xyzrgba_ascii(string filename, IntPtr cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void io_pointcloud_xyzrgba_image_extractor_from_rgb_field(IntPtr cloud, IntPtr image, [MarshalAs(UnmanagedType.Bool)] bool setPaintNaNsWithBlack);

        #endregion

        #region CropBoxXYZ

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

        #region CropBoxXYZ

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cropbox_pointxyzi_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyzi_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyzi_set_min(IntPtr ptr, Eigen.Vector4f min);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector4f cropbox_pointxyzi_get_min(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyzi_set_max(IntPtr ptr, Eigen.Vector4f max);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector4f cropbox_pointxyzi_get_max(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyzi_set_translation(IntPtr ptr, Eigen.Vector3f transform);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector3f cropbox_pointxyzi_get_translation(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyzi_set_rotation(IntPtr ptr, Eigen.Vector3f transform);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector3f cropbox_pointxyzi_get_rotation(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyzi_set_input_cloud(IntPtr ptr, IntPtr cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cropbox_pointxyzi_get_input_cloud(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyzi_filter(IntPtr ptr, IntPtr outputCloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyzi_set_filter_indices(IntPtr ptr, ulong row_start, ulong col_start, ulong nb_rows, ulong nb_cols);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyzi_set_filter_indices_vector(IntPtr ptr, IntPtr indices);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyzi_get_filter_indices_vector(IntPtr ptr, IntPtr indices);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cropbox_pointxyzi_get_keep_organized(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cropbox_pointxyzi_set_keep_organized(IntPtr ptr, int keep_organized);

        #endregion

        #region Matrix4f

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_matrix4f_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_matrix4f_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float eigen_matrix4f_get_index(IntPtr ptr, int row, int col);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_matrix4f_set_index(IntPtr ptr, int row, int col, float value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern float* eigen_matrix4f_data(IntPtr ptr);

        #endregion

        #region VectorXf

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_vectorxf_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_vectorxf_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float eigen_vectorxf_get_index(IntPtr ptr, long index);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_vectorxf_set_index(IntPtr ptr, long index, float value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern IntPtr eigen_vectorxf_data(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_vectorxf_normalize(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long eigen_vectorxf_size(IntPtr ptr);

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


        #region ArrayXf

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_arrayxf_ctor_size(long size);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float eigen_arrayxf_get_index(IntPtr ptr, long index);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long eigen_arrayxf_size(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_arrayxf_set_index(IntPtr ptr, long index, float value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void eigen_arrayxf_delete(ref IntPtr ptr);

        #endregion

        #region ConvolutionPointXYZPointXYZ

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr convolution_pointxyz_pointxyz_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution_pointxyz_pointxyz_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution_pointxyz_pointxyz_set_input_cloud(IntPtr ptr, IntPtr cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution_pointxyz_pointxyz_set_kernel(IntPtr ptr, IntPtr kernel);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution_pointxyz_pointxyz_set_borders_policy(IntPtr ptr, int policy);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int convolution_pointxyz_pointxyz_get_borders_policy(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution_pointxyz_pointxyz_set_distance_threshold(IntPtr ptr, float threshold);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float convolution_pointxyz_pointxyz_get_distance_threshold(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution_pointxyz_pointxyz_convolve_rows(IntPtr ptr, IntPtr output);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution_pointxyz_pointxyz_convolve_cols(IntPtr ptr, IntPtr output);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution_pointxyz_pointxyz_convolve(IntPtr ptr, IntPtr output);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution_pointxyz_pointxyz_set_threads(IntPtr ptr, int threads);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_vectorxf_ctor_size(long size);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_arrayxf_sin(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_arrayxf_cos(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_arrayxf_tan(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_arrayxf_exp(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_arrayxf_log(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_arrayxf_sqrt(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_arrayxf_abs(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr eigen_arrayxf_data(IntPtr ptr);

        #endregion

        #region GaussianKernelPointXYZPointXYZ

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gaussiankernel_pointxyz_pointxyz_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gaussiankernel_pointxyz_pointxyz_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gaussiankernel_pointxyz_pointxyz_set_sigma(IntPtr ptr, float sigma);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gaussiankernel_pointxyz_pointxyz_set_threshold_relative_to_sigma(IntPtr ptr, float sigma_coeff);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gaussiankernel_pointxyz_pointxyz_set_threshold(IntPtr ptr, float threshold);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gaussiankernel_pointxyz_pointxyz_set_input_cloud(IntPtr ptr, IntPtr cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool gaussiankernel_pointxyz_pointxyz_init_compute(IntPtr ptr);

        #endregion

        #region Convolution3DGaussianKernelPointXYZPointXYZ

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr convolution3d_gaussiankernel_pointxyz_pointxyz_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution3d_gaussiankernel_pointxyz_pointxyz_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution3d_gaussiankernel_pointxyz_pointxyz_set_input_cloud(IntPtr ptr, IntPtr cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution3d_gaussiankernel_pointxyz_pointxyz_set_kernel(IntPtr ptr, IntPtr kernel);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution3d_gaussiankernel_pointxyz_pointxyz_set_search_surface(IntPtr ptr, IntPtr cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution3d_gaussiankernel_pointxyz_pointxyz_set_threads(IntPtr ptr, int threads);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution3d_gaussiankernel_pointxyz_pointxyz_set_radius_search(IntPtr ptr, float radius);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution3d_gaussiankernel_pointxyz_pointxyz_convolve(IntPtr ptr, IntPtr output_cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution_3d_gaussian_kernel_pointxyz_pointxyz_set_indices_vector(IntPtr ptr, IntPtr indices);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution_3d_gaussian_kernel_pointxyz_pointxyz_get_indices_vector(IntPtr ptr, IntPtr indices);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void convolution_3d_gaussian_kernel_pointxyz_pointxyz_set_indices(IntPtr ptr, long row_start, long col_start, long nb_rows, long nb_cols);

        #endregion

        #region VoxelGridPointXYZ

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr voxel_grid_pointxyz_ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_set_leaf_size(IntPtr ptr, float lx, float ly, float lz);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_set_filter_field_name(IntPtr ptr, string field_name);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_set_filter_limits(IntPtr ptr, float min_limit, float max_limit);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_set_filter_limits_negative(IntPtr ptr, [MarshalAs(UnmanagedType.Bool)] bool negative);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_set_min_points_per_voxel(IntPtr ptr, uint min_points);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_set_save_leaf_layout(IntPtr ptr, [MarshalAs(UnmanagedType.Bool)] bool save_leaf_layout);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_set_downsample_all_data(IntPtr ptr, [MarshalAs(UnmanagedType.Bool)] bool downsample_all_data);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_set_input_cloud(IntPtr ptr, IntPtr cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr voxel_grid_pointxyz_get_input_cloud(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_filter(IntPtr ptr, IntPtr output);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector3f voxel_grid_pointxyz_get_leaf_size(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_get_filter_field_name(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] StringBuilder field_name, int max_length);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_get_filter_limits(IntPtr ptr, out double min_limit, out double max_limit);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_get_filter_limits_negative(IntPtr ptr, [MarshalAs(UnmanagedType.Bool)] out bool limit_negative);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector3i voxel_grid_pointxyz_get_nr_divisions(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector3i voxel_grid_pointxyz_get_min_box_coordinates(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector3i voxel_grid_pointxyz_get_max_box_coordinates(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int voxel_grid_pointxyz_get_centroid_index(IntPtr ptr, ref PointXYZ point);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector3i voxel_grid_pointxyz_get_grid_coordinates(IntPtr ptr, float x, float y, float z);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int voxel_grid_pointxyz_get_centroid_index_at(IntPtr ptr, int i, int j, int k);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool voxel_grid_pointxyz_get_downsample_all_data(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint voxel_grid_pointxyz_get_min_points_per_voxel(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool voxel_grid_pointxyz_get_save_leaf_layout(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_set_indices(IntPtr ptr, long row_start, long col_start, long nb_rows, long nb_cols);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_set_indices_vector(IntPtr ptr, IntPtr indices);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void voxel_grid_pointxyz_get_indices_vector(IntPtr ptr, IntPtr indices);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Eigen.Vector3i voxel_grid_pointxyz_get_division_multiplier(IntPtr ptr);

        #endregion

        #region KdTreePointXYZ

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr kdtree_pointxyz_ctor(int sorted);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void kdtree_pointxyz_delete(ref IntPtr ptr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void kdtree_pointxyz_set_input_cloud(IntPtr kdtree, IntPtr cloud);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void kdtree_pointxyz_set_epsilon(IntPtr kdtree, float eps);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int kdtree_pointxyz_nearest_k_search(
            IntPtr kdtree,
            ref PointXYZ point,
            int k,
            IntPtr indices, // std::vector<int>*
            IntPtr distances // std::vector<float>*
        );

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int kdtree_pointxyz_radius_search(
            IntPtr kdtree,
            ref PointXYZ point,
            double radius,
            int max_nn,
            IntPtr indices, // std::vector<int>*
            IntPtr distances // std::vector<float>*
        );

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void kdtree_pointxyz_set_sorted_results(IntPtr kdtree, int sorted);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int kdtree_pointxyz_get_sorted_results(IntPtr kdtree);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float kdtree_pointxyz_get_epsilon(KdTreePointXYZ kdTreePointXYZ);

        #endregion
    }
}
