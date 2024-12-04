#pragma once
#include "export.h"
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"

using namespace pcl;
using namespace std;

using point_vector = vector<PointXYZI, Eigen::aligned_allocator<PointXYZI>>;


EXPORT(PointCloud<PointXYZI>*) pointcloud_xyzi_ctor();

EXPORT(PointCloud<PointXYZI>*) pointcloud_xyzi_ctor_wh(uint32_t width, uint32_t height);

EXPORT(PointCloud<PointXYZI>*) pointcloud_xyzi_ctor_indices(PointCloud<PointXYZI>* cloud, vector<int>* indices);

EXPORT(void) pointcloud_xyzi_delete(PointCloud<PointXYZI>** ptr);

EXPORT(PointXYZI*) pointcloud_xyzi_at_colrow(PointCloud<PointXYZI>* ptr, size_t col, size_t row);

EXPORT(void) pointcloud_xyzi_add(PointCloud<PointXYZI>* ptr, PointXYZI* value);

EXPORT(size_t) pointcloud_xyzi_size(PointCloud<PointXYZI>* ptr);

EXPORT(void) pointcloud_xyzi_clear(PointCloud<PointXYZI>* ptr);

EXPORT(uint32_t) pointcloud_xyzi_width(PointCloud<PointXYZI>* ptr);

EXPORT(void) pointcloud_xyzi_width_set(PointCloud<PointXYZI>* ptr, uint32_t width);

EXPORT(uint32_t) pointcloud_xyzi_height(PointCloud<PointXYZI>* ptr);

EXPORT(void) pointcloud_xyzi_height_set(PointCloud<PointXYZI>* ptr, uint32_t height);

EXPORT(int32_t) pointcloud_xyzi_is_organized(PointCloud<PointXYZI>* ptr);

EXPORT(point_vector*) pointcloud_xyzi_points(PointCloud<PointXYZI>* ptr);

EXPORT(PointXYZI*) pointcloud_xyzi_data(PointCloud<PointXYZI>* ptr);

EXPORT(void) pointcloud_xyzi_downsample(PointCloud<PointXYZI>* ptr, int factor, PointCloud<PointXYZI>* output);

EXPORT(void) pointcloud_xyzi_set_is_dense(PointCloud<PointXYZI>* ptr, int value);

EXPORT(int) pointcloud_xyzi_get_is_dense(PointCloud<PointXYZI>* ptr);

EXPORT(void) pointcloud_xyzi_concatenate(PointCloud<PointXYZI>* ptr1, PointCloud<PointXYZI>* ptr2, PointCloud<PointXYZI>* ptr_out);
