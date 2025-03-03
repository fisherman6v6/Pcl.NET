#include "IO.h"
#include <pcl/io/png_io.h>

int io_load_pcd_xyz(const char* path, PointCloud<PointXYZ>* cloud)
{
    return io::loadPCDFile(path, *cloud);
}

int io_load_pcd_xyzi(const char* path, PointCloud<PointXYZI>* cloud)
{
    return io::loadPCDFile(path, *cloud);
}

int io_save_pcd_xyz_binary(const char* path, PointCloud<PointXYZ>* cloud, int compressed)
{
    if (compressed)
    {
        return io::savePCDFileBinaryCompressed(path, *cloud);
    }

    return io::savePCDFileBinary(path, *cloud);
}

int io_save_pcd_xyzi_binary(const char* path, PointCloud<PointXYZI>* cloud, int compressed)
{
    if (compressed)
    {
        return io::savePCDFileBinaryCompressed(path, *cloud);
    }

    return io::savePCDFileBinary(path, *cloud);
}

int io_save_pcd_xyz_ascii(const char* path, PointCloud<PointXYZ>* cloud)
{
    return io::savePCDFileASCII(path, *cloud);
}

int io_save_pcd_xyzi_ascii(const char* path, PointCloud<PointXYZI>* cloud)
{
    return io::savePCDFileASCII(path, *cloud);
}

int io_save_png_xyzrgba(const char* path, PointCloud<PointXYZRGBA>* cloud, const char* field_name)
{
    io::savePNGFile(path, *cloud, field_name);
}
