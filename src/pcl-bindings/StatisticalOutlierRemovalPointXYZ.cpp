#include <pcl/filters/statistical_outlier_removal.h>
#include "pcl/impl/point_types.hpp"
#include "pcl/point_cloud.h"
#include "export.h"

using namespace pcl;
using point_t = PointXYZ;
using pointcloud_t = PointCloud<point_t>;

EXPORT(StatisticalOutlierRemoval<point_t>*) statistical_outlier_removal_pointxyz_ctor()
{
    return new StatisticalOutlierRemoval<point_t>();
}

EXPORT(void) statistical_outlier_removal_pointxyz_delete(StatisticalOutlierRemoval<point_t>** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

EXPORT(void) statistical_outlier_removal_pointxyz_set_input_cloud(StatisticalOutlierRemoval<point_t>* ptr, pointcloud_t* cloud)
{
    pointcloud_t::Ptr shared(std::make_shared<pointcloud_t>(*cloud));
    ptr->setInputCloud(shared);
}

EXPORT(void) statistical_outlier_removal_pointxyz_set_mean_k(StatisticalOutlierRemoval<point_t>* ptr, int mean_k)
{
    ptr->setMeanK(mean_k);
}

EXPORT(int) statistical_outlier_removal_pointxyz_get_mean_k(StatisticalOutlierRemoval<point_t>* ptr)
{
    return ptr->getMeanK();
}

EXPORT(void) statistical_outlier_removal_pointxyz_set_stddev_mul_thresh(StatisticalOutlierRemoval<point_t>* ptr, double stddev_mul_thresh)
{
    ptr->setStddevMulThresh(stddev_mul_thresh);
}

EXPORT(double) statistical_outlier_removal_pointxyz_get_stddev_mul_thresh(StatisticalOutlierRemoval<point_t>* ptr)
{
    return ptr->getStddevMulThresh();
}

EXPORT(void) statistical_outlier_removal_pointxyz_filter(StatisticalOutlierRemoval<point_t>* ptr, pointcloud_t* output)
{
    ptr->filter(*output);
}

EXPORT(void) statistical_outlier_removal_pointxyz_set_filter_indices_vector(StatisticalOutlierRemoval<point_t>* ptr, std::vector<int>* indices)
{
    pcl::PointIndices::Ptr indices_ptr(new pcl::PointIndices());
    indices_ptr->indices = *indices;
    ptr->setIndices(indices_ptr);
}

EXPORT(void) statistical_outlier_removal_pointxyz_get_filter_indices_vector(StatisticalOutlierRemoval<point_t>* ptr, std::vector<int>* indices)
{
    pcl::IndicesPtr indices_ptr = ptr->getIndices();
    indices->assign(indices_ptr->begin(), indices_ptr->end());
}

EXPORT(void) statistical_outlier_removal_pointxyz_set_indices(StatisticalOutlierRemoval<point_t>* ptr, std::size_t row_start, std::size_t col_start, std::size_t nb_rows, std::size_t nb_cols)
{
    ptr->setIndices(row_start, col_start, nb_rows, nb_cols);
}
