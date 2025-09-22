#include "export.h"
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"
#include <pcl/filters/crop_box.h>
#include "cstructs.h"

using namespace pcl;
using namespace std;

using point_t = PointXYZI;
using pointcloud_t = PointCloud<point_t>;
using cropbox_t = CropBox<point_t>;

EXPORT(cropbox_t*) cropbox_pointxyzi_ctor()
{
    return new cropbox_t();
}

EXPORT(void) cropbox_pointxyzi_delete(cropbox_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

EXPORT(void) cropbox_pointxyzi_set_min(cropbox_t* ptr, eigen_vector4f_t min)
{
    Eigen::Vector4f v;
    v.x() = min.x;
    v.y() = min.y;
    v.z() = min.z;
    v.w() = min.w;
    ptr->setMin(v);
}

EXPORT(eigen_vector4f_t) cropbox_pointxyzi_get_min(cropbox_t* ptr)
{
    eigen_vector4f_t cvec{};
    Eigen::Vector4f val = ptr->getMin();
    cvec.x = val.x();
    cvec.y = val.y();
    cvec.z = val.z();
    cvec.w = val.w();
    return cvec;
}

EXPORT(void) cropbox_pointxyzi_set_max(cropbox_t* ptr, eigen_vector4f_t max)
{
    Eigen::Vector4f val;
    val.x() = max.x;
    val.y() = max.y;
    val.z() = max.z;
    val.w() = max.w;
    ptr->setMax(val);
}

EXPORT(eigen_vector4f_t) cropbox_pointxyzi_get_max(cropbox_t* ptr)
{
    eigen_vector4f_t cvec{};
    Eigen::Vector4f val = ptr->getMax();
    cvec.x = val.x();
    cvec.y = val.y();
    cvec.z = val.z();
    cvec.w = val.w();
    return cvec;
}

EXPORT(void) cropbox_pointxyzi_set_translation(cropbox_t* ptr, eigen_vector3f_t translation)
{
    Eigen::Vector3f val;
    val.x() = translation.x;
    val.y() = translation.y;
    val.z() = translation.z;
    ptr->setTranslation(val);
}

EXPORT(eigen_vector3f_t) cropbox_pointxyzi_get_translation(cropbox_t* ptr)
{
    eigen_vector3f_t cvec{};
    Eigen::Vector3f val = ptr->getTranslation();
    cvec.x = val.x();
    cvec.y = val.y();
    cvec.z = val.z();
    return cvec;
}

EXPORT(void) cropbox_pointxyzi_set_rotation(cropbox_t* ptr, eigen_vector3f_t rotation)
{
    Eigen::Vector3f val;
    val.x() = rotation.x;
    val.y() = rotation.y;
    val.z() = rotation.z;
    ptr->setRotation(val);
}

EXPORT(eigen_vector3f_t) cropbox_pointxyzi_get_rotation(cropbox_t* ptr)
{
    eigen_vector3f_t cvec{};
    Eigen::Vector3f val = ptr->getRotation();
    cvec.x = val.x();
    cvec.y = val.y();
    cvec.z = val.z();
    return cvec;
}

EXPORT(void) cropbox_pointxyzi_set_input_cloud(cropbox_t* ptr, pointcloud_t* cloud)
{
    pointcloud_t::Ptr shared(std::make_shared<pointcloud_t>(*cloud));
    ptr->setInputCloud(shared);
}

EXPORT(const pointcloud_t*) cropbox_pointxyzi_get_input_cloud(cropbox_t* ptr)
{
    return ptr->getInputCloud().get();
}

EXPORT(void) cropbox_pointxyzi_filter(cropbox_t* ptr, pointcloud_t* output)
{
    ptr->filter(*output);
}

EXPORT(void) cropbox_pointxyzi_set_filter_indices(cropbox_t* ptr, std::size_t row_start, std::size_t col_start, std::size_t nb_rows, std::size_t nb_cols)
{
    ptr->setIndices(row_start, col_start, nb_rows, nb_cols);
}

EXPORT(void) cropbox_pointxyzi_set_filter_indices_vector(cropbox_t* ptr, std::vector<int>* indices)
{
    pcl::PointIndices::Ptr indices_ptr(new pcl::PointIndices());
    indices_ptr->indices = *indices;
    ptr->setIndices(indices_ptr);
}

EXPORT(void) cropbox_pointxyzi_get_filter_indices_vector(cropbox_t* ptr, std::vector<int>* indices)
{
    pcl::IndicesPtr indices_ptr = ptr->getIndices();
    indices->assign(indices_ptr->begin(), indices_ptr->end());
}

EXPORT(void) cropbox_pointxyzi_set_keep_organized(cropbox_t* ptr, int keep_organized)
{
    ptr->setKeepOrganized((bool)keep_organized);
    ptr->setKeepOrganized((bool)keep_organized);
}

EXPORT(int) cropbox_pointxyzi_get_keep_organized(cropbox_t* ptr)
{
    return ptr->getKeepOrganized();
}
