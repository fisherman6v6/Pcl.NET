#include "ConvolutionPointXYZPointXYZ.h"

convolution_t* convolution_pointxyz_pointxyz_ctor()
{
    return new convolution_t();
}

void convolution_pointxyz_pointxyz_delete(convolution_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

void convolution_pointxyz_pointxyz_set_input_cloud(convolution_t* ptr, pointcloud_t* cloud)
{
    pointcloud_t::Ptr shared(std::make_shared<pointcloud_t>(*cloud));
    ptr->setInputCloud(shared);
}

void convolution_pointxyz_pointxyz_set_kernel(convolution_t* ptr, Eigen::ArrayXf* kernel)
{
    ptr->setKernel(*kernel);
}

void convolution_pointxyz_pointxyz_set_borders_policy(convolution_t* ptr, int policy)
{
    ptr->setBordersPolicy(policy);
}

int convolution_pointxyz_pointxyz_get_borders_policy(convolution_t* ptr)
{
    return ptr->getBordersPolicy();
}

void convolution_pointxyz_pointxyz_set_distance_threshold(convolution_t* ptr, float threshold)
{
    ptr->setDistanceThreshold(threshold);
}

float convolution_pointxyz_pointxyz_get_distance_threshold(convolution_t* ptr)
{
    return ptr->getDistanceThreshold();
}

void convolution_pointxyz_pointxyz_convolve_rows(convolution_t* ptr, pointcloud_t* output)
{
    ptr->convolveRows(*output);
}

void convolution_pointxyz_pointxyz_convolve_cols(convolution_t* ptr, pointcloud_t* output)
{
    ptr->convolveCols(*output);
}

void convolution_pointxyz_pointxyz_convolve(convolution_t* ptr, pointcloud_t* output)
{
    return ptr->convolve(*output);
}

void convolution_pointxyz_pointxyz_set_threads(convolution_t* ptr, unsigned int threads)
{
    ptr->setNumberOfThreads(threads);
}

