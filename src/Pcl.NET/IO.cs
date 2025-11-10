namespace Pcl.NET
{
    public static class IO
    {
        public static PointCloudXYZ LoadPointCloudXYZ(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException($"'{nameof(filename)}' cannot be null or empty.", nameof(filename));
            }

            PointCloudXYZ cloud = new PointCloudXYZ();
            int ret = Invoke.io_load_pcd_xyz(filename, cloud);

            if (ret != 0)
            {
                ThrowHelper.ThrowIOException_CannotReadFile(filename);
            }
            return cloud;
        }

        public static PointCloudXYZI LoadPointCloudXYZI(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException($"'{nameof(filename)}' cannot be null or empty.", nameof(filename));
            }

            PointCloudXYZI cloud = new PointCloudXYZI();
            int ret = Invoke.io_load_pcd_xyzi(filename, cloud);
            if (ret != 0)
            {
                ThrowHelper.ThrowIOException_CannotReadFile(filename);
            }
            return cloud;
        }

        public static void SavePointCloudXYZBinary(string filename, PointCloudXYZ cloud, bool compressed = false)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException($"'{nameof(filename)}' cannot be null or empty.", nameof(filename));
            }

            ArgumentNullException.ThrowIfNull(cloud, nameof(cloud));

            int ret = Invoke.io_save_pcd_xyz_binary(filename, cloud, compressed ? 1 : 0);

            if (ret != 0)
            {
                ThrowHelper.ThrowIOException_CannotWriteFile(filename);
            }
        }

        public static void SavePointCloudXYZAscii(string filename, PointCloudXYZ cloud)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException($"'{nameof(filename)}' cannot be null or empty.", nameof(filename));
            }

            ArgumentNullException.ThrowIfNull(cloud, nameof(cloud));

            int ret = Invoke.io_save_pcd_xyz_ascii(filename, cloud);
            if (ret != 0)
            {
                ThrowHelper.ThrowIOException_CannotWriteFile(filename);
            }
        }

        public static void SavePointCloudXYZIBinary(string filename, PointCloudXYZI cloud, bool compressed = false)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException($"'{nameof(filename)}' cannot be null or empty.", nameof(filename));
            }

            ArgumentNullException.ThrowIfNull(cloud, nameof(cloud));

            int ret = Invoke.io_save_pcd_xyzi_binary(filename, cloud, compressed ? 1 : 0);
            if (ret != 0)
            {
                ThrowHelper.ThrowIOException_CannotWriteFile(filename);
            }
        }

        public static void SavePointCloudXYZIAscii(string filename, PointCloudXYZI cloud)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException($"'{nameof(filename)}' cannot be null or empty.", nameof(filename));
            }

            ArgumentNullException.ThrowIfNull(cloud, nameof(cloud));

            int ret = Invoke.io_save_pcd_xyzi_ascii(filename, cloud);
            if (ret != 0)
            {
                ThrowHelper.ThrowIOException_CannotWriteFile(filename);
            }
        }

        public static void SavePNGFilePointCloudXYZRGBA(string filename, PointCloudXYZRGBA cloud, string fieldName)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException($"'{nameof(filename)}' cannot be null or empty.", nameof(filename));
            }

            ArgumentNullException.ThrowIfNull(cloud, nameof(cloud));

            Invoke.io_save_png_xyzrgba(filename, cloud, fieldName);
        }

        public static PointCloudXYZRGBA LoadPointCloudXYZRGBA(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException($"'{nameof(filename)}' cannot be null or empty.", nameof(filename));
            }

            PointCloudXYZRGBA cloud = new();
            int ret = Invoke.io_load_pcd_xyzrgba(filename, cloud);
            if (ret != 0)
            {
                ThrowHelper.ThrowIOException_CannotWriteFile(filename);
            }
            return cloud;
        }

        public static PclImage ExtractImageFromRGBField(PointCloudXYZRGBA pointCloud, string encoding, bool setPaintNaNsWithBlack)
        {
            PclImage image = new PclImage();
            image.Encoding = encoding;

            Invoke.io_pointcloud_xyzrgba_image_extractor_from_rgb_field(pointCloud, image, setPaintNaNsWithBlack);

            return image;
        }
    }
}
