#include "export.h"
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"
#include "pcl/segmentation/sac_segmentation.h"

using namespace pcl;
using namespace std;

using point_t = PointXYZI;
using pointcloud_t = PointCloud<point_t>;
using sacsegmentation_t = SACSegmentation <point_t>;

EXPORT(sacsegmentation_t*) sacsegmentation_pointxyzi_ctor()
{
    return new sacsegmentation_t();
}

EXPORT(void) sacsegmentation_pointxyzi_delete(sacsegmentation_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

EXPORT(void) sacsegmentation_pointxyzi_set_model_type(sacsegmentation_t* ptr, int model)
{
    ptr->setModelType(model);
}

EXPORT(int) sacsegmentation_pointxyzi_get_model_type(sacsegmentation_t* ptr)
{
    return ptr->getModelType();
}

EXPORT(void) sacsegmentation_pointxyzi_set_method_type(sacsegmentation_t* ptr, int method)
{
    ptr->setMethodType(method);
}

EXPORT(int) sacsegmentation_pointxyzi_get_method_type(sacsegmentation_t* ptr)
{
    return ptr->getMethodType();
}

EXPORT(void) sacsegmentation_pointxyzi_set_distance_threshold(sacsegmentation_t* ptr, double threshold)
{
    ptr->setDistanceThreshold(threshold);
}

EXPORT(double) sacsegmentation_pointxyzi_get_distance_threshold(sacsegmentation_t* ptr)
{
    return ptr->getDistanceThreshold();
}

EXPORT(void) sacsegmentation_pointxyzi_set_max_iterations(sacsegmentation_t* ptr, int max_iterations)
{
    ptr->setMaxIterations(max_iterations);
}

EXPORT(int) sacsegmentation_pointxyzi_get_max_iterations(sacsegmentation_t* ptr)
{
    return ptr->getMaxIterations();
}

EXPORT(void) sacsegmentation_pointxyzi_set_optimize_coefficients(sacsegmentation_t* ptr, bool optimize)
{
    ptr->setOptimizeCoefficients(optimize);
}

EXPORT(bool) sacsegmentation_pointxyzi_get_optimize_coefficients(sacsegmentation_t* ptr)
{
    return ptr->getOptimizeCoefficients();
}

EXPORT(void) sacsegmentation_pointxyzi_set_radius_limits(sacsegmentation_t* ptr, double min_radius, double max_radius)
{
    ptr->setRadiusLimits(min_radius, max_radius);
}

EXPORT(void) sacsegmentation_pointxyzi_get_radius_limits(sacsegmentation_t* ptr, double* min_radius, double* max_radius)
{
    return ptr->getRadiusLimits(*min_radius, *max_radius);
}

EXPORT(void) sacsegmentation_pointxyzi_set_input_cloud(sacsegmentation_t* ptr, pointcloud_t* cloud)
{
    pointcloud_t::Ptr shared(std::make_shared<pointcloud_t>(*cloud));
    ptr->setInputCloud(shared);
}

EXPORT(const pointcloud_t*) sacsegmentation_pointxyzi_get_input_cloud(sacsegmentation_t* ptr)
{
    return ptr->getInputCloud().get();
}

EXPORT(void) sacsegmentation_pointxyzi_segment(sacsegmentation_t* ptr, std::vector<int>* inliers, std::vector<float>* coefficients)
{
    pcl::PointIndices pcl_inliers;
    pcl::ModelCoefficients pcl_coefficients;

    ptr->segment(pcl_inliers, pcl_coefficients);

    if (inliers != nullptr) {
        *inliers = pcl_inliers.indices;
    }

    if (coefficients != nullptr) {
        *coefficients = pcl_coefficients.values;
    }
}

EXPORT(void) sacsegmentation_pointxyzi_set_indices(sacsegmentation_t* ptr, std::size_t row_start, std::size_t col_start, std::size_t nb_rows, std::size_t nb_cols)
{
    ptr->setIndices(row_start, col_start, nb_rows, nb_cols);
}

EXPORT(void) sacsegmentation_pointxyzi_set_indices_vector(sacsegmentation_t* ptr, std::vector<int>* indices)
{
    pcl::PointIndices::Ptr indices_ptr(new pcl::PointIndices());
    indices_ptr->indices = *indices;
    ptr->setIndices(indices_ptr);
}

EXPORT(void) sacsegmentation_pointxyzi_get_filter_indices_vector(sacsegmentation_t* ptr, std::vector<int>* indices)
{
    pcl::IndicesPtr indices_ptr = ptr->getIndices();
    indices->assign(indices_ptr->begin(), indices_ptr->end());
}