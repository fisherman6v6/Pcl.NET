#include "export.h"
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"
#include <pcl/filters/convolution.h>

using namespace pcl;
using namespace std;
using namespace Eigen;
using namespace filters;

using point_t = PointXYZ;
using pointcloud_t = PointCloud<point_t>;
using convolution_t = Convolution<point_t, point_t>;

EXPORT(convolution_t*) convolution_pointxyz_pointxyz_ctor()
{
    return new convolution_t();
}

EXPORT(void) convolution_pointxyz_pointxyz_delete(convolution_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

EXPORT(void) convolution_pointxyz_pointxyz_set_input_cloud(convolution_t* ptr, pointcloud_t* cloud)
{
    pointcloud_t::Ptr shared(std::make_shared<pointcloud_t>(*cloud));
    ptr->setInputCloud(shared);
}

EXPORT(void) convolution_pointxyz_pointxyz_set_kernel(convolution_t* ptr, Eigen::ArrayXf* kernel)
{
    ptr->setKernel(*kernel);
}

EXPORT(void) convolution_pointxyz_pointxyz_set_borders_policy(convolution_t* ptr, int policy)
{
    ptr->setBordersPolicy(policy);
}

EXPORT(int) convolution_pointxyz_pointxyz_get_borders_policy(convolution_t* ptr)
{
    return ptr->getBordersPolicy();
}

EXPORT(void) convolution_pointxyz_pointxyz_set_distance_threshold(convolution_t* ptr, float threshold)
{
    ptr->setDistanceThreshold(threshold);
}

EXPORT(float) convolution_pointxyz_pointxyz_get_distance_threshold(convolution_t* ptr)
{
    return ptr->getDistanceThreshold();
}

EXPORT(void) convolution_pointxyz_pointxyz_convolve_rows(convolution_t* ptr, pointcloud_t* output)
{
    ptr->convolveRows(*output);
}

EXPORT(void) convolution_pointxyz_pointxyz_convolve_cols(convolution_t* ptr, pointcloud_t* output)
{
    ptr->convolveCols(*output);
}

EXPORT(void) convolution_pointxyz_pointxyz_convolve(convolution_t* ptr, pointcloud_t* output)
{
    return ptr->convolve(*output);
}

EXPORT(void) convolution_pointxyz_pointxyz_set_threads(convolution_t* ptr, unsigned int threads)
{
    ptr->setNumberOfThreads(threads);
}

