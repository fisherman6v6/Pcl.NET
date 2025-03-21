#pragma once
#include "export.h"
#include "Eigen_Matrix4f.h"
#include <Eigen/Geometry>
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"

using namespace Eigen;
using namespace pcl;

EXPORT(Affine3f*) eigen_affine3f_ctor();

EXPORT(void) eigen_affine3f_delete(Affine3f** ptr);

EXPORT(Affine3f*) eigen_affine3f_ctor_identity();

EXPORT(Matrix4f*) eigen_affine3f_get_matrix(Affine3f* ptr);

EXPORT(void) eigen_affine3f_set_matrix(Affine3f* ptr, Matrix4f* matrix);

EXPORT(void) eigen_affine3f_rotate_xyz(Affine3f* ptr, float rx, float ry, float rz);

EXPORT(void) eigen_affine3f_translate_xyz(Affine3f* ptr, float tx, float ty, float tz);

EXPORT(void) transform_pointcloud_xyz(Affine3f* ptr, PointCloud<PointXYZ>* input, PointCloud<PointXYZ>* output);

EXPORT(void) eigen_affine3f_scale(Affine3f* ptr, float scale);
