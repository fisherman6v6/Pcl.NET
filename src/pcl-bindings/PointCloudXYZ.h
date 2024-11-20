#pragma once

#include "export.h"
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"

using namespace pcl;
using namespace std;

using point_vector = vector<PointXYZ, Eigen::aligned_allocator<PointXYZ>>;

#ifdef __cplusplus  
extern "C" {  
#endif  

    EXPORT(PointCloud<PointXYZ>*) pointcloud_xyz_ctor();

    EXPORT(PointCloud<PointXYZ>*) pointcloud_xyz_ctor_wh(uint32_t width, uint32_t height);

    EXPORT(PointCloud<PointXYZ>*) pointcloud_xyz_ctor_indices(PointCloud<PointXYZ>* cloud, vector<int>* indices);

    EXPORT(void) pointcloud_xyz_delete(PointCloud<PointXYZ>** ptr);

    EXPORT(PointXYZ*) pointcloud_xyz_at_colrow(PointCloud<PointXYZ>* ptr, size_t col, size_t row);

    EXPORT(void) pointcloud_xyz_add(PointCloud<PointXYZ>* ptr, PointXYZ* value);

    EXPORT(size_t) pointcloud_xyz_size(PointCloud<PointXYZ>* ptr);

    EXPORT(void) pointcloud_xyz_clear(PointCloud<PointXYZ>* ptr);

    EXPORT(uint32_t) pointcloud_xyz_width(PointCloud<PointXYZ>* ptr);

    EXPORT(void) pointcloud_xyz_width_set(PointCloud<PointXYZ>* ptr, uint32_t width);

    EXPORT(uint32_t) pointcloud_xyz_height(PointCloud<PointXYZ>* ptr);

    EXPORT(void) pointcloud_xyz_height_set(PointCloud<PointXYZ>* ptr, uint32_t height);

    EXPORT(int32_t) pointcloud_xyz_is_organized(PointCloud<PointXYZ>* ptr);

    EXPORT(point_vector*) pointcloud_xyz_points(PointCloud<PointXYZ>* ptr);

    EXPORT(PointXYZ*) pointcloud_xyz_data(PointCloud<PointXYZ>* ptr);

    EXPORT(void) pointcloud_xyz_downsample(PointCloud<PointXYZ>* ptr, int factor, PointCloud<PointXYZ>* output);

    EXPORT(void) pointcloud_xyz_set_is_dense(PointCloud<PointXYZ>* ptr, int value);

    EXPORT(int) pointcloud_xyz_get_is_dense(PointCloud<PointXYZ>* ptr);

    EXPORT(void) pointcloud_xyz_concatenate(PointCloud<PointXYZ>* ptr1, PointCloud<PointXYZ>* ptr2, PointCloud<PointXYZ>* ptr_out);

    EXPORT(Eigen::Vector4f) pointcloud_xyz_get_sensor_origin(PointCloud<PointXYZ>* ptr);

    EXPORT(void) pointcloud_xyz_set_sensor_origin(PointCloud<PointXYZ>* ptr, Eigen::Vector4f value);

    EXPORT(Eigen::Quaternionf) pointcloud_xyz_get_sensor_orientation(PointCloud<PointXYZ>* ptr);

    EXPORT(void) pointcloud_xyz_set_sensor_orientation(PointCloud<PointXYZ>* ptr, Eigen::Quaternionf value);

#ifdef __cplusplus  
}
#endif  