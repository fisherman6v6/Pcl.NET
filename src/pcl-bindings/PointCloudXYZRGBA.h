#pragma once
#pragma once
#include "export.h"
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"

using namespace pcl;
using namespace std;

using point_t = PointXYZRGBA;
using pointcloud_t = PointCloud<point_t>;
using point_vector = vector<point_t, Eigen::aligned_allocator<point_t>>;


EXPORT(pointcloud_t*) pointcloud_xyzrgba_ctor();

EXPORT(pointcloud_t*) pointcloud_xyzrgba_ctor_wh(uint32_t width, uint32_t height);

EXPORT(pointcloud_t*) pointcloud_xyzrgba_ctor_indices(pointcloud_t* cloud, vector<int>* indices);

EXPORT(void) pointcloud_xyzrgba_delete(pointcloud_t** ptr);

EXPORT(point_t*) pointcloud_xyzrgba_at_colrow(pointcloud_t* ptr, int col, int row);

EXPORT(void) pointcloud_xyzrgba_add(pointcloud_t* ptr, point_t* value);

EXPORT(size_t) pointcloud_xyzrgba_size(pointcloud_t* ptr);

EXPORT(void) pointcloud_xyzrgba_clear(pointcloud_t* ptr);

EXPORT(uint32_t) pointcloud_xyzrgba_get_width(pointcloud_t* ptr);

EXPORT(void) pointcloud_xyzrgba_set_width(pointcloud_t* ptr, uint32_t width);

EXPORT(uint32_t) pointcloud_xyzrgba_get_height(pointcloud_t* ptr);

EXPORT(void) pointcloud_xyzrgba_set_height(pointcloud_t* ptr, uint32_t height);

EXPORT(int32_t) pointcloud_xyzrgba_is_organized(pointcloud_t* ptr);

EXPORT(point_vector*) pointcloud_xyzrgba_points(pointcloud_t* ptr);

EXPORT(point_t*) pointcloud_xyzrgba_data(pointcloud_t* ptr);

EXPORT(void) pointcloud_xyzrgba_downsample(pointcloud_t* ptr, int factor, pointcloud_t* output);

EXPORT(void) pointcloud_xyzrgba_set_is_dense(pointcloud_t* ptr, int value);

EXPORT(int) pointcloud_xyzrgba_get_is_dense(pointcloud_t* ptr);

EXPORT(void) pointcloud_xyzrgba_concatenate(pointcloud_t* ptr1, pointcloud_t* ptr2, pointcloud_t* ptr_out);
