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

void cropbox_pointxyz_set_min(CropBox<PointXYZ>* ptr, Eigen::Vector4f min) 
{
    ptr->setMin(min);
}

Eigen::Vector4f cropbox_pointxyz_get_min(CropBox<PointXYZ>* ptr) 
{
    return ptr->getMin();
}

void cropbox_pointxyz_set_max(CropBox<PointXYZ>* ptr, Eigen::Vector4f max) 
{
    ptr->setMax(max);
}

Eigen::Vector4f cropbox_pointxyz_get_max(CropBox<PointXYZ>* ptr) 
{
    return ptr->getMax();
}

void cropbox_pointxyz_set_translation(CropBox<PointXYZ>* ptr, Eigen::Vector3f translation) 
{
    ptr->setTranslation(translation);
}

Eigen::Vector3f cropbox_pointxyz_get_translation(CropBox<PointXYZ>* ptr) 
{
    return ptr->getTranslation();
}

void cropbox_pointxyz_set_rotation(CropBox<PointXYZ>* ptr, Eigen::Vector3f rotation) 
{
    ptr->setRotation(rotation);
}

Eigen::Vector3f cropbox_pointxyz_get_rotation(CropBox<PointXYZ>* ptr) 
{
    return ptr->getRotation();
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
