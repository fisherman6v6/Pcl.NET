#pragma once
#include "export.h"
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"
#include <pcl/filters/crop_box.h>
#include "cstructs.h"

using namespace pcl;
using namespace std;

using point_t = PointXYZ;
using pointcloud_t = PointCloud<point_t>;
using cropbox_t = CropBox<point_t>;

EXPORT(cropbox_t*) cropbox_pointxyz_ctor();

EXPORT(void) cropbox_pointxyz_delete(cropbox_t** ptr);

EXPORT(void) cropbox_pointxyz_set_min(cropbox_t* ptr, eigen_vector4f_t min);

EXPORT(eigen_vector4f_t) cropbox_pointxyz_get_min(cropbox_t* ptr);

EXPORT(void) cropbox_pointxyz_set_max(cropbox_t* ptr, eigen_vector4f_t max);

EXPORT(eigen_vector4f_t) cropbox_pointxyz_get_max(cropbox_t* ptr);

EXPORT(void) cropbox_pointxyz_set_translation(cropbox_t* ptr, eigen_vector3f_t translation);

EXPORT(eigen_vector3f_t) cropbox_pointxyz_get_translation(cropbox_t* ptr);

EXPORT(void) cropbox_pointxyz_set_rotation(cropbox_t* ptr, eigen_vector3f_t rotation);

EXPORT(eigen_vector3f_t) cropbox_pointxyz_get_rotation(cropbox_t* ptr);

EXPORT(void) cropbox_pointxyz_set_transform(cropbox_t* ptr, Eigen::Affine3f* transform);

EXPORT(Eigen::Affine3f*) cropbox_pointxyz_get_transform(cropbox_t* ptr);

EXPORT(void) cropbox_pointxyz_set_input_cloud(cropbox_t* ptr, pointcloud_t* cloud);

EXPORT(const pointcloud_t*) cropbox_pointxyz_get_input_cloud(cropbox_t* ptr);

EXPORT(void) cropbox_pointxyz_filter(cropbox_t* ptr, pointcloud_t* output);

EXPORT(void) cropbox_pointxyz_set_filter_indices(cropbox_t* ptr, std::size_t row_start, std::size_t col_start, std::size_t nb_rows, std::size_t nb_cols);

EXPORT(void)cropbox_pointxyz_set_filter_indices_vector(cropbox_t* ptr, std::vector<int>* indices);

EXPORT(void)cropbox_pointxyz_get_filter_indices_vector(cropbox_t* ptr, std::vector<int>* indices);

EXPORT(void) cropbox_pointxyz_set_keep_organized(cropbox_t* ptr, int keep_organized);

EXPORT(int) cropbox_pointxyz_get_keep_organized(cropbox_t* ptr);
