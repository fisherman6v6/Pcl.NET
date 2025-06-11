#pragma once
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

EXPORT(convolution_t*) convolution_pointxyz_pointxyz_ctor();

EXPORT(void) convolution_pointxyz_pointxyz_delete(convolution_t** ptr);

EXPORT(void) convolution_pointxyz_pointxyz_set_input_cloud(convolution_t* ptr, pointcloud_t* cloud);

EXPORT(void) convolution_pointxyz_pointxyz_set_kernel(convolution_t* ptr, Eigen::ArrayXf* kernel);

EXPORT(void) convolution_pointxyz_pointxyz_set_borders_policy(convolution_t* ptr, int policy);

EXPORT(int) convolution_pointxyz_pointxyz_get_borders_policy(convolution_t* ptr);

EXPORT(void) convolution_pointxyz_pointxyz_set_distance_threshold(convolution_t* ptr, float threshold);

EXPORT(float) convolution_pointxyz_pointxyz_get_distance_threshold(convolution_t* ptr);

EXPORT(void) convolution_pointxyz_pointxyz_convolve_rows(convolution_t* ptr, pointcloud_t* output);

EXPORT(void) convolution_pointxyz_pointxyz_convolve_cols(convolution_t* ptr, pointcloud_t* output);

EXPORT(void) convolution_pointxyz_pointxyz_convolve(convolution_t* ptr, pointcloud_t* output);

EXPORT(void) convolution_pointxyz_pointxyz_set_threads(convolution_t* ptr, unsigned int threads);
