#include "export.h"
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"
#include <pcl/filters/convolution_3d.h>

using namespace pcl;
using namespace std;
using namespace Eigen;
using namespace pcl::filters;

using point_t = PointXYZ;
using kernel_t = GaussianKernel<point_t, point_t>;

EXPORT(kernel_t*) gaussian_kernel_pointxyz_pointxyz_ctor()
{
    return new kernel_t();
}

EXPORT(void) gaussian_kernel_pointxyz_pointxyz_delete(kernel_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

EXPORT(void) gaussian_kernel_pointxyz_pointxyz_set_sigma(kernel_t* ptr, float sigma)
{
    ptr->setSigma(sigma);
}

EXPORT(void) gaussian_kernel_pointxyz_pointxyz_set_threshold_relative_to_sigma(kernel_t* ptr, float sigma_coefficient)
{
    ptr->setThresholdRelativeToSigma(sigma_coefficient);
}

EXPORT(bool) gaussian_kernel_pointxyz_pointxyz_init_compute(kernel_t* ptr)
{
    return ptr->initCompute();
}

EXPORT(void) gaussian_kernel_pointxyz_pointxyz_set_input_cloud(kernel_t* ptr, PointCloud<point_t>* cloud)
{
    PointCloud<point_t>::Ptr shared(std::make_shared<PointCloud<point_t>>(*cloud));
    ptr->setInputCloud(shared);
}

EXPORT(void) gaussian_kernel_pointxyz_pointxyz_set_threshold(kernel_t* ptr, float threshold)
{
    ptr->setThreshold(threshold);
}