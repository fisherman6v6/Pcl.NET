#include "CropBoxPointXYZ.h"

CropBox<PointXYZ>* cropbox_pointxyz_ctor()
{
    return new CropBox<PointXYZ>();
}

void cropbox_pointxyz_delete(CropBox<PointXYZ>** ptr) 
{
    delete* ptr;
    *ptr = NULL;
}

void cropbox_pointxyz_set_min(CropBox<PointXYZ>* ptr, eigen_vector4f_t min)
{
    Eigen::Vector4f v;
    v.x() = min.x;
    v.y() = min.y;
    v.z() = min.z;
    v.w() = min.w;
    ptr->setMin(v);
}

eigen_vector4f_t cropbox_pointxyz_get_min(CropBox<PointXYZ>* ptr) 
{
    eigen_vector4f_t cvec{};
    Eigen::Vector4f val = ptr->getMin();
    cvec.x = val.x();
    cvec.y = val.y();
    cvec.z = val.z();
    cvec.w = val.w();
    return cvec;
}

void cropbox_pointxyz_set_max(CropBox<PointXYZ>* ptr, eigen_vector4f_t max)
{
    Eigen::Vector4f val;
    val.x() = max.x;
    val.y() = max.y;
    val.z() = max.z;
    val.w() = max.w;
    ptr->setMax(val);
}

eigen_vector4f_t cropbox_pointxyz_get_max(CropBox<PointXYZ>* ptr)
{
    eigen_vector4f_t cvec{};
    Eigen::Vector4f val = ptr->getMax();
    cvec.x = val.x();
    cvec.y = val.y();
    cvec.z = val.z();
    cvec.w = val.w();
    return cvec;
}

void cropbox_pointxyz_set_translation(CropBox<PointXYZ>* ptr, eigen_vector3f_t translation)
{
    Eigen::Vector3f val;
    val.x() = translation.x;
    val.y() = translation.y;
    val.z() = translation.z;
    ptr->setTranslation(val);
}

eigen_vector3f_t cropbox_pointxyz_get_translation(CropBox<PointXYZ>* ptr)
{
    eigen_vector3f_t cvec{};
    Eigen::Vector3f val = ptr->getTranslation();
    cvec.x = val.x();
    cvec.y = val.y();
    cvec.z = val.z();
    return cvec;
}

void cropbox_pointxyz_set_rotation(CropBox<PointXYZ>* ptr, eigen_vector3f_t rotation)
{
    Eigen::Vector3f val;
    val.x() = rotation.x;
    val.y() = rotation.y;
    val.z() = rotation.z;
    ptr->setRotation(val);
}

eigen_vector3f_t cropbox_pointxyz_get_rotation(CropBox<PointXYZ>* ptr)
{
    eigen_vector3f_t cvec{};
    Eigen::Vector3f val = ptr->getRotation();
    cvec.x = val.x();
    cvec.y = val.y();
    cvec.z = val.z();
    return cvec;
}

void cropbox_pointxyz_set_input_cloud(CropBox<PointXYZ>* ptr, PointCloud<PointXYZ>* cloud)
{
    pcl::PointCloud<pcl::PointXYZ>::Ptr shared(std::make_shared<PointCloud<pcl::PointXYZ>>(*cloud));
    ptr->setInputCloud(shared);
}

const PointCloud<PointXYZ>* cropbox_pointxyz_get_input_cloud(CropBox<PointXYZ>* ptr)
{
    return ptr->getInputCloud().get();
}

void cropbox_pointxyz_filter(CropBox<PointXYZ>* ptr, PointCloud<PointXYZ>* output)
{
    ptr->filter(*output);
}

void cropbox_pointxyz_set_filter_indices(CropBox<PointXYZ>* ptr, std::size_t row_start, std::size_t col_start, std::size_t nb_rows, std::size_t nb_cols)
{
   ptr->setIndices(row_start, col_start, nb_rows, nb_cols);
}

void cropbox_pointxyz_set_filter_indices_vector(CropBox<PointXYZ>* ptr, std::vector<int>* indices)
{
    pcl::PointIndices::Ptr indices_ptr(new pcl::PointIndices());
    indices_ptr->indices = *indices;
    ptr->setIndices(indices_ptr);
}

void cropbox_pointxyz_get_filter_indices_vector(CropBox<PointXYZ>* ptr, std::vector<int>* indices)
{
    pcl::IndicesPtr indices_ptr = ptr->getIndices();
    indices->assign(indices_ptr->begin(), indices_ptr->end());
}

void cropbox_pointxyz_set_keep_organized(CropBox<PointXYZ>* ptr, int keep_organized)
{
    ptr->setKeepOrganized((bool)keep_organized);
    ptr->setKeepOrganized((bool)keep_organized);
}

int cropbox_pointxyz_get_keep_organized(CropBox<PointXYZ>* ptr)
{
    return ptr->getKeepOrganized();
}
