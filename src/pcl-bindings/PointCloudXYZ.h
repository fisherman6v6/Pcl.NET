#pragma once

#include "export.h"
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"

using namespace pcl;
using namespace std;

using point_t = PointXYZ;
using pointcloud_t = PointCloud<point_t>;
using point_vector = vector<point_t, Eigen::aligned_allocator<point_t>>;

EXPORT(pointcloud_t*) pointcloud_xyz_ctor();

EXPORT(pointcloud_t*) pointcloud_xyz_ctor_wh(uint32_t width, uint32_t height);

EXPORT(pointcloud_t*) pointcloud_xyz_ctor_indices(pointcloud_t* cloud, vector<int>* indices);

EXPORT(void) pointcloud_xyz_delete(pointcloud_t** ptr);

EXPORT(point_t*) pointcloud_xyz_at_colrow(pointcloud_t* ptr, size_t col, size_t row);

EXPORT(void) pointcloud_xyz_add(pointcloud_t* ptr, point_t* value);

EXPORT(size_t) pointcloud_xyz_size(pointcloud_t* ptr);

EXPORT(void) pointcloud_xyz_clear(pointcloud_t* ptr);

EXPORT(uint32_t) pointcloud_xyz_get_width(pointcloud_t* ptr);

EXPORT(void) pointcloud_xyz_set_width(pointcloud_t* ptr, uint32_t width);

EXPORT(uint32_t) pointcloud_xyz_get_height(pointcloud_t* ptr);

EXPORT(void) pointcloud_xyz_set_height(pointcloud_t* ptr, uint32_t height);

EXPORT(int32_t) pointcloud_xyz_is_organized(pointcloud_t* ptr);

EXPORT(point_vector*) pointcloud_xyz_points(pointcloud_t* ptr);

EXPORT(point_t*) pointcloud_xyz_data(pointcloud_t* ptr);

EXPORT(void) pointcloud_xyz_downsample(pointcloud_t* ptr, int factor, pointcloud_t* output);

EXPORT(void) pointcloud_xyz_set_is_dense(pointcloud_t* ptr, int value);

EXPORT(int) pointcloud_xyz_get_is_dense(pointcloud_t* ptr);

EXPORT(void) pointcloud_xyz_concatenate(pointcloud_t* ptr1, pointcloud_t* ptr2, pointcloud_t* ptr_out);
