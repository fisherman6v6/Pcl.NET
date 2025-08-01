#include "export.h"
#include <Eigen/Geometry>
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"
#include <pcl/common/transforms.h>

using namespace Eigen;
using namespace pcl;

EXPORT(Affine3f*) eigen_affine3f_ctor()
{
    return new Affine3f();
}

EXPORT(void) eigen_affine3f_delete(Affine3f** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

EXPORT(Affine3f*) eigen_affine3f_ctor_identity()
{
    Affine3f* t = new Affine3f();
    t->setIdentity();
    return t;
}

EXPORT(Matrix4f*) eigen_affine3f_get_matrix(Affine3f* ptr)
{
    return &ptr->matrix();
}

EXPORT(void) eigen_affine3f_set_matrix(Affine3f* ptr, Matrix4f* matrix)
{
    ptr->matrix() = *matrix;
}

EXPORT(void) eigen_affine3f_rotate_xyz(Affine3f* ptr, float rx, float ry, float rz)
{
    ptr->rotate(Eigen::AngleAxisf(rx, Eigen::Vector3f::UnitX()));
    ptr->rotate(Eigen::AngleAxisf(ry, Eigen::Vector3f::UnitY()));
    ptr->rotate(Eigen::AngleAxisf(rz, Eigen::Vector3f::UnitZ()));
}

EXPORT(void) eigen_affine3f_translate_xyz(Affine3f* ptr, float tx, float ty, float tz)
{
    ptr->translate(Vector3f(tx, ty, tz));
}

EXPORT(void) transform_pointcloud_xyz(Affine3f* ptr, PointCloud<PointXYZ>* input, PointCloud<PointXYZ>* output)
{
    pcl::transformPointCloud(*input, *output, *ptr);
}

EXPORT(void) eigen_affine3f_scale(Affine3f* ptr, float scale)
{
    ptr->scale(scale);
}


