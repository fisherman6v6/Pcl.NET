#include "export.h"  
#include <pcl/io/pcd_io.h>  
#include <pcl/io/png_io.h>

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
   io::savePNGFile(path, *cloud, field_name); // Ensure the correct header is included for this function  
}  

EXPORT(int) io_load_pcd_xyzrgba(const char* path, PointCloud<PointXYZRGBA>* cloud)  
{  
   return io::loadPCDFile(path, *cloud);  
}  

EXPORT(void) io_pointcloud_xyzrgba_image_extractor_from_rgb_field(PointCloud<PointXYZRGBA>* cloud, PCLImage* image, bool setPaintNaNsWithBlack)  
{  
   io::PointCloudImageExtractorFromRGBField<PointXYZRGBA> extractor;  
   extractor.setPaintNaNsWithBlack(setPaintNaNsWithBlack);  
   extractor.extract(*cloud, *image);  
}
