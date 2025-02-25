#include "CropBoxPointXYZ.h"

EXPORT(CropBox<PointXYZ>*) cropbox_pointxyz_ctor()
{
    return new CropBox<PointXYZ>();
}

EXPORT(void) cropbox_pointxyz_delete(CropBox<PointXYZ>** ptr) 
{
    delete* ptr;
    *ptr = NULL;
}

EXPORT(void) cropbox_pointxyz_set_min(CropBox<PointXYZ>* ptr, Eigen::Vector4f min) 
{
    ptr->setMin(min);
}

EXPORT(Eigen::Vector4f) cropbox_pointxyz_get_min(CropBox<PointXYZ>* ptr) 
{
    return ptr->getMin();
}

EXPORT(void) cropbox_pointxyz_set_max(CropBox<PointXYZ>* ptr, Eigen::Vector4f max) 
{
    ptr->setMax(max);
}

EXPORT(Eigen::Vector4f) cropbox_pointxyz_get_max(CropBox<PointXYZ>* ptr) 
{
    return ptr->getMax();
}

EXPORT(void) cropbox_pointxyz_set_translation(CropBox<PointXYZ>* ptr, Eigen::Vector3f translation) 
{
    ptr->setTranslation(translation);
}

EXPORT(Eigen::Vector3f) cropbox_pointxyz_get_translation(CropBox<PointXYZ>* ptr) 
{
    return ptr->getTranslation();
}

EXPORT(void) cropbox_pointxyz_set_rotation(CropBox<PointXYZ>* ptr, Eigen::Vector3f rotation) 
{
    ptr->setRotation(rotation);
}

EXPORT(Eigen::Vector3f) cropbox_pointxyz_get_rotation(CropBox<PointXYZ>* ptr) 
{
    return ptr->getRotation();
}

EXPORT(void) cropbox_pointxyz_set_input_cloud(CropBox<PointXYZ>* ptr, PointCloud<PointXYZ>* cloud)
{
    ptr->setInputCloud(std::shared_ptr<PointCloud<PointXYZ>>(cloud));
}

EXPORT(const PointCloud<PointXYZ>*) cropbox_pointxyz_get_input_cloud(CropBox<PointXYZ>* ptr)
{
    return ptr->getInputCloud().get();
}

EXPORT(void) cropbox_pointxyz_filter(CropBox<PointXYZ>* ptr, PointCloud<PointXYZ>* output)
{
    ptr->filter(*output);
}

EXPORT(void) cropbox_pointxyz_set_filter_indices(CropBox<PointXYZ>* ptr, std::size_t row_start, std::size_t col_start, std::size_t nb_rows, std::size_t nb_cols)
{
   ptr->setIndices(row_start, col_start, nb_rows, nb_cols);
}

EXPORT(void) cropbox_pointxyz_set_filter_indices_vector(CropBox<PointXYZ>* ptr, std::vector<int>* indices)
{
    pcl::PointIndices::Ptr indices_ptr(new pcl::PointIndices());
    indices_ptr->indices = *indices;
    ptr->setIndices(indices_ptr);
}


EXPORT(void) cropbox_pointxyz_get_filter_indices_vector(CropBox<PointXYZ>* ptr, std::vector<int>* indices)
{
    pcl::IndicesPtr indices_ptr = ptr->getIndices();
    indices->assign(indices_ptr->begin(), indices_ptr->end());
}
