#pragma once
#include "export.h"
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"
#include <pcl/filters/crop_box.h>

using namespace pcl;
using namespace std;

EXPORT(CropBox<PointXYZ>*) cropbox_pointxyz_ctor();

EXPORT(void) cropbox_pointxyz_delete(CropBox<PointXYZ>** ptr);

EXPORT(void) cropbox_pointxyz_set_min(CropBox<PointXYZ>* ptr, Eigen::Vector4f min);

EXPORT(Eigen::Vector4f) cropbox_pointxyz_get_min(CropBox<PointXYZ>* ptr);

EXPORT(void) cropbox_pointxyz_set_max(CropBox<PointXYZ>* ptr, Eigen::Vector4f max);

EXPORT(Eigen::Vector4f) cropbox_pointxyz_get_max(CropBox<PointXYZ>* ptr);

EXPORT(void) cropbox_pointxyz_set_translation(CropBox<PointXYZ>* ptr, Eigen::Vector3f translation);

EXPORT(Eigen::Vector3f) cropbox_pointxyz_get_translation(CropBox<PointXYZ>* ptr);

EXPORT(void) cropbox_pointxyz_set_rotation(CropBox<PointXYZ>* ptr, Eigen::Vector3f rotation);

EXPORT(Eigen::Vector3f) cropbox_pointxyz_get_rotation(CropBox<PointXYZ>* ptr);

EXPORT(void) cropbox_pointxyz_set_transform(CropBox<PointXYZ>* ptr, Eigen::Affine3f* transform);

EXPORT(Eigen::Affine3f*) cropbox_pointxyz_get_transform(CropBox<PointXYZ>* ptr);

EXPORT(void) cropbox_pointxyz_set_input_cloud(CropBox<PointXYZ>* ptr, PointCloud<PointXYZ>::Ptr* cloud);

EXPORT(const PointCloud<PointXYZ>*) cropbox_pointxyz_get_input_cloud(CropBox<PointXYZ>* ptr);

EXPORT(void) cropbox_pointxyz_filter(CropBox<PointXYZ>* ptr, PointCloud<PointXYZ>* output);

EXPORT(void) cropbox_pointxyz_filter_indices(CropBox<PointXYZ>* ptr, std::size_t row_start, std::size_t col_start, std::size_t nb_rows, std::size_t nb_cols);