#include "export.h"
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"
#include <pcl/filters/convolution_3d.h>
#include <memory>

using namespace pcl;
using namespace std;
using namespace Eigen;
using namespace filters;

using point_t = PointXYZ;
using pointcloud_t = PointCloud<point_t>;
using kernel_t = GaussianKernel<point_t, point_t>;
using convolution_t = Convolution3D<point_t, point_t, kernel_t>;

EXPORT(convolution_t*) convolution_3d_gaussian_kernel_pointxyz_pointxyz_ctor()
{
    return new convolution_t();
}

EXPORT(void) convolution_3d_gaussian_kernel_pointxyz_pointxyz_delete(convolution_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

EXPORT(void) convolution_3d_gaussian_kernel_pointxyz_pointxyz_set_input_cloud(convolution_t* ptr, pointcloud_t* cloud)
{
    pointcloud_t::Ptr shared = std::make_shared<pointcloud_t>(*cloud);
    ptr->setInputCloud(shared);
}

EXPORT(void) convolution_3d_gaussian_kernel_pointxyz_pointxyz_set_kernel(convolution_t* ptr, kernel_t* kernel)
{
    ptr->setKernel(*kernel);
}

EXPORT(void) convolution_3d_gaussian_kernel_pointxyz_pointxyz_set_radius_search(convolution_t* ptr, double radius)
{
    ptr->setRadiusSearch(radius);
}

EXPORT(double) convolution_3d_gaussian_kernel_pointxyz_pointxyz_get_radius_search(convolution_t* ptr, double radius)
{
    return ptr->getRadiusSearch();
}

EXPORT(void) convolution_3d_gaussian_kernel_pointxyz_pointxyz_convolve(convolution_t* ptr, pointcloud_t* output)
{
    ptr->convolve(*output);
}

EXPORT(void) convolution_3d_gaussian_kernel_pointxyz_pointxyz_set_indices_vector(convolution_t* ptr, std::vector<int>* indices)
{
    pcl::PointIndices::Ptr indices_ptr(new pcl::PointIndices());
    indices_ptr->indices = *indices;
    ptr->setIndices(indices_ptr);
}

EXPORT(void) convolution_3d_gaussian_kernel_pointxyz_pointxyz_get_indices_vector(convolution_t* ptr, std::vector<int>* indices)
{
    pcl::IndicesPtr indices_ptr = ptr->getIndices();
    indices->assign(indices_ptr->begin(), indices_ptr->end());
}

EXPORT(void) convolution_3d_gaussian_kernel_pointxyz_pointxyz_set_indices(convolution_t* ptr, std::size_t row_start, std::size_t col_start, std::size_t nb_rows, std::size_t nb_cols)
{
    ptr->setIndices(row_start, col_start, nb_rows, nb_cols);
}