#pragma once
#include "export.h"
#include <pcl/io/pcd_io.h>

using namespace pcl;

EXPORT(int) io_load_pcd_xyz(const char* path, PointCloud<PointXYZ>* cloud);

EXPORT(int) io_load_pcd_xyzi(const char* path, PointCloud<PointXYZI>* cloud);

EXPORT(int) io_save_pcd_xyz_binary(const char* path, PointCloud<PointXYZ>* cloud, int compressed);

EXPORT(int) io_save_pcd_xyzi_binary(const char* path, PointCloud<PointXYZI>* cloud, int compressed);

EXPORT(int) io_save_pcd_xyz_ascii(const char* path, PointCloud<PointXYZ>* cloud);

EXPORT(int) io_save_pcd_xyzi_ascii(const char* path, PointCloud<PointXYZI>* cloud);

EXPORT(int) io_save_png_xyzrgba(const char* path, PointCloud<PointXYZRGBA>* cloud, const char* field_name);
