#include "export.h"  
#include <pcl/io/pcd_io.h>  
#include <pcl/io/png_io.h>
#include "cstructs.h"
#include <string.h>

using namespace pcl;  

EXPORT(int) io_load_pcd_xyz(const char* path, PointCloud<PointXYZ>* cloud)  
{  
   return io::loadPCDFile(path, *cloud);  
}  

EXPORT(int) io_load_pcd_xyzi(const char* path, PointCloud<PointXYZI>* cloud)  
{  
   return io::loadPCDFile(path, *cloud);  
}  

EXPORT(int) io_save_pcd_xyz_binary(const char* path, PointCloud<PointXYZ>* cloud, int compressed)  
{  
   if (compressed)  
   {  
       return io::savePCDFileBinaryCompressed(path, *cloud);  
   }  

   return io::savePCDFileBinary(path, *cloud);  
}  

EXPORT(int) io_save_pcd_xyzi_binary(const char* path, PointCloud<PointXYZI>* cloud, int compressed)  
{  
   if (compressed)  
   {  
       return io::savePCDFileBinaryCompressed(path, *cloud);  
   }  

   return io::savePCDFileBinary(path, *cloud);  
}  

EXPORT(int) io_save_pcd_xyz_ascii(const char* path, PointCloud<PointXYZ>* cloud)  
{  
   return io::savePCDFileASCII(path, *cloud);  
}  

EXPORT(int) io_save_pcd_xyzi_ascii(const char* path, PointCloud<PointXYZI>* cloud)  
{  
   return io::savePCDFileASCII(path, *cloud);  
}  

EXPORT(void) io_save_png_xyzrgba(const char* path, PointCloud<PointXYZRGBA>* cloud, const char* field_name)  
{  
   io::savePNGFile(path, *cloud, field_name);
}  

EXPORT(int) io_load_pcd_xyzrgba(const char* path, PointCloud<PointXYZRGBA>* cloud)  
{  
   return io::loadPCDFile(path, *cloud);  
}  

EXPORT(int) io_save_pcd_xyzrgba_binary(const char* path, PointCloud<PointXYZRGBA>* cloud)
{
    return io::savePCDFile(path, *cloud);
}

EXPORT(int) io_save_pcd_xyzrgba_ascii(const char* path, PointCloud<PointXYZRGBA>* cloud)
{
    return io::savePCDFileASCII(path, *cloud);
}

EXPORT(void) io_pointcloud_xyzrgba_image_extractor_from_rgb_field(PointCloud<PointXYZRGBA>* cloud, PCLImage* image, bool setPaintNaNsWithBlack)  
{  
   io::PointCloudImageExtractorFromRGBField<PointXYZRGBA> extractor;  
   extractor.setPaintNaNsWithBlack(setPaintNaNsWithBlack);  
   extractor.extract(*cloud, *image);  
}

EXPORT(int) io_read_pcd_header(const char* path, pcd_header_t* header)
{
    pcl::PCLPointCloud2::Ptr cloud(new pcl::PCLPointCloud2);
    PCDReader reader;
    int err = 0;
    Eigen::Vector4f origin;
    Eigen::Quaternionf orientation;
    int pcd_version;
    int data_type;
    unsigned int data_idx;
    err = reader.readHeader(path, *cloud, origin, orientation, pcd_version, data_type, data_idx);
    if (err != 0)
    {
        // Handle error (e.g., set header fields to zero or return an error code)
        memset(header, 0, sizeof(pcd_header_t));
        return err;
    }
    header->width = cloud->width;
    header->height = cloud->height;
    header->point_step = cloud->point_step;
    header->row_step = cloud->row_step;
    header->is_dense = cloud->is_dense;
    header->data_type = data_type;
    header->data_idx = data_idx;
    for (size_t i = 0; i < cloud->fields.size() && i < MAX_HEADER_FIELDS; i++)
    {
        const auto& field = cloud->fields[i];
        std::strncpy(header->fields[i].name, field.name.c_str(), MAX_FIELD_NAME_LENGTH);
        header->fields[i].offset = field.offset;
        header->fields[i].datatype = field.datatype;
        header->fields[i].count = field.count;
    }
    return err;
}
