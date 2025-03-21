#pragma once
#include "export.h"
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"
#include <pcl/filters/crop_box.h>
#include "cstructs.h"

using namespace pcl;
using namespace std;

EXPORT(CropBox<PointXYZ>*) cropbox_pointxyz_ctor();

EXPORT(void) cropbox_pointxyz_delete(CropBox<PointXYZ>** ptr);

EXPORT(void) cropbox_pointxyz_set_min(CropBox<PointXYZ>* ptr, eigen_vector4f_t min);

EXPORT(eigen_vector4f_t) cropbox_pointxyz_get_min(CropBox<PointXYZ>* ptr);

EXPORT(void) cropbox_pointxyz_set_max(CropBox<PointXYZ>* ptr, eigen_vector4f_t max);

EXPORT(eigen_vector4f_t) cropbox_pointxyz_get_max(CropBox<PointXYZ>* ptr);

EXPORT(void) cropbox_pointxyz_set_translation(CropBox<PointXYZ>* ptr, eigen_vector3f_t translation);

EXPORT(eigen_vector3f_t) cropbox_pointxyz_get_translation(CropBox<PointXYZ>* ptr);

EXPORT(void) cropbox_pointxyz_set_rotation(CropBox<PointXYZ>* ptr, eigen_vector3f_t rotation);

EXPORT(eigen_vector3f_t) cropbox_pointxyz_get_rotation(CropBox<PointXYZ>* ptr);

EXPORT(void) cropbox_pointxyz_set_transform(CropBox<PointXYZ>* ptr, Eigen::Affine3f* transform);

EXPORT(Eigen::Affine3f*) cropbox_pointxyz_get_transform(CropBox<PointXYZ>* ptr);

EXPORT(void) cropbox_pointxyz_set_input_cloud(CropBox<PointXYZ>* ptr, PointCloud<PointXYZ>* cloud);

EXPORT(const PointCloud<PointXYZ>*) cropbox_pointxyz_get_input_cloud(CropBox<PointXYZ>* ptr);

EXPORT(void) cropbox_pointxyz_filter(CropBox<PointXYZ>* ptr, PointCloud<PointXYZ>* output);

EXPORT(void) cropbox_pointxyz_set_filter_indices(CropBox<PointXYZ>* ptr, std::size_t row_start, std::size_t col_start, std::size_t nb_rows, std::size_t nb_cols);

EXPORT(void)cropbox_pointxyz_set_filter_indices_vector(CropBox<PointXYZ>* ptr, std::vector<int>* indices);

EXPORT(void)cropbox_pointxyz_get_filter_indices_vector(CropBox<PointXYZ>* ptr, std::vector<int>* indices);

EXPORT(void) cropbox_pointxyz_set_keep_organized(CropBox<PointXYZ>* ptr, int keep_organized);

EXPORT(int) cropbox_pointxyz_get_keep_organized(CropBox<PointXYZ>* ptr);
