#include "export.h"
#include "pcl/point_types.h"
#include <pcl/filters/voxel_grid.h>
#include "cstructs.h"

using point_t = pcl::PointXYZ;
using voxelgrid_t = pcl::VoxelGrid<point_t>;
using pointcloud_t = pcl::PointCloud<point_t>;

EXPORT(voxelgrid_t*) voxelgrid_pointxyz_ctor()
{
    return new voxelgrid_t();
}

EXPORT(void) voxelgrid_pointxyz_delete(voxelgrid_t** ptr)
{
    delete *ptr;
    *ptr = nullptr;
}

EXPORT(void) voxelgrid_pointxyz_set_leaf_size(voxelgrid_t* ptr, float lx, float ly, float lz)
{
    ptr->setLeafSize(lx, ly, lz);
}

EXPORT(void) voxelgrid_pointxyz_set_filter_field_name(voxelgrid_t* ptr, const char* field_name)
{
    ptr->setFilterFieldName(field_name);
}

EXPORT(void) voxelgrid_pointxyz_set_filter_limits(voxelgrid_t* ptr, float min_limit, float max_limit)
{
    ptr->setFilterLimits(min_limit, max_limit);
}

EXPORT(void) voxelgrid_pointxyz_set_filter_limits_negative(voxelgrid_t* ptr, bool negative)
{
    ptr->setFilterLimitsNegative(negative);
}

EXPORT(void) voxelgrid_pointxyz_set_min_points_per_voxel(voxelgrid_t* ptr, unsigned int min_points)
{
    ptr->setMinimumPointsNumberPerVoxel(min_points);
}

EXPORT(void) voxelgrid_pointxyz_set_save_leaf_layout(voxelgrid_t* ptr, bool save_leaf_layout)
{
    ptr->setSaveLeafLayout(save_leaf_layout);
}

EXPORT(void) voxelgrid_pointxyz_set_downsample_all_data(voxelgrid_t* ptr, bool downsample_all_data)
{
    ptr->setDownsampleAllData(downsample_all_data);
}

EXPORT(void) voxelgrid_pointxyz_set_input_cloud(voxelgrid_t* ptr, pointcloud_t* cloud)
{
    pointcloud_t::Ptr shared(std::make_shared<pointcloud_t>(*cloud));
    ptr->setInputCloud(shared);
}

EXPORT(void) voxelgrid_pointxyz_set_indices_vector(voxelgrid_t* ptr, std::vector<int>* indices)
{
    pcl::IndicesPtr indices_ptr(new pcl::Indices(*indices));
    ptr->setIndices(indices_ptr);
}

EXPORT(const pointcloud_t*) voxelgrid_pointxyz_get_input_cloud(voxelgrid_t* ptr)
{
    return ptr->getInputCloud().get();
}

EXPORT(void) voxelgrid_pointxyz_filter(voxelgrid_t* ptr, pointcloud_t* output)
{
    ptr->filter(*output);
}

EXPORT(eigen_vector3f_t) voxelgrid_pointxyz_get_leaf_size(voxelgrid_t* ptr)
{
    Eigen::Vector3f leaf_size = ptr->getLeafSize();
    eigen_vector3f_t ret = {};
    ret.x = leaf_size.x();
    ret.y = leaf_size.y();
    ret.z = leaf_size.z();
    return ret;
}

EXPORT(void) voxelgrid_pointxyz_get_filter_field_name(voxelgrid_t* ptr, char* field_name, size_t max_length)
{
    std::string name = ptr->getFilterFieldName();
    strncpy(field_name, name.c_str(), max_length);
    field_name[max_length - 1] = '\0'; // Ensure null termination
}

EXPORT(void) voxelgrid_pointxyz_get_filter_limits(voxelgrid_t* ptr, double* min_limit, double* max_limit)
{
    ptr->getFilterLimits(*min_limit, *max_limit);
}

EXPORT(void) voxelgrid_pointxyz_get_filter_limits_negative(voxelgrid_t* ptr, bool* limit_negative)
{
    *limit_negative = ptr->getFilterLimitsNegative();
}

EXPORT(eigen_vector3i_t) voxelgrid_pointxyz_get_nr_divisions(voxelgrid_t* ptr)
{
    Eigen::Vector3i div = ptr->getNrDivisions();
    eigen_vector3i_t ret = {};
    ret.x = div.x();
    ret.y = div.y();
    ret.z = div.z();
    return ret;
}

EXPORT(eigen_vector3i_t) voxelgrid_pointxyz_get_min_box_coordinates(voxelgrid_t* ptr)
{
    Eigen::Vector3i min = ptr->getMinBoxCoordinates();
    eigen_vector3i_t ret = {};
    ret.x = min.x();
    ret.y = min.y();
    ret.z = min.z();
    return ret;
}

EXPORT(eigen_vector3i_t) voxelgrid_pointxyz_get_max_box_coordinates(voxelgrid_t* ptr)
{
    Eigen::Vector3i max = ptr->getMaxBoxCoordinates();
    eigen_vector3i_t ret = {};
    ret.x = max.x();
    ret.y = max.y();
    ret.z = max.z();
    return ret;
}

EXPORT(int) voxelgrid_pointxyz_get_centroid_index(voxelgrid_t* ptr, const point_t* point)
{
    return ptr->getCentroidIndex(*point);
}

EXPORT(eigen_vector3i_t) voxelgrid_pointxyz_get_grid_coordinates(voxelgrid_t* ptr, float x, float y, float z)
{
    Eigen::Vector3i coords = ptr->getGridCoordinates(x, y, z);
    eigen_vector3i_t ret = {};
    ret.x = coords.x();
    ret.y = coords.y();
    ret.z = coords.z();
    return ret;
}

EXPORT(int) voxelgrid_pointxyz_get_centroid_index_at(voxelgrid_t* ptr, int i, int j, int k)
{
    return ptr->getCentroidIndexAt(Eigen::Vector3i(i, j, k));
}

EXPORT(bool) voxelgrid_pointxyz_get_downsample_all_data(voxelgrid_t* ptr)
{
    return ptr->getDownsampleAllData();
}

EXPORT(unsigned int) voxelgrid_pointxyz_get_min_points_per_voxel(voxelgrid_t* ptr)
{
    return ptr->getMinimumPointsNumberPerVoxel();
}

EXPORT(void) voxelgrid_pointxyz_get_indices_vector(voxelgrid_t* ptr, std::vector<int>* indices)
{
    pcl::IndicesPtr indices_ptr = ptr->getIndices();
    indices->assign(indices_ptr->begin(), indices_ptr->end());
}

EXPORT(eigen_vector3i_t) voxelgrid_pointxyz_get_division_multiplier(voxelgrid_t* ptr)
{
    Eigen::Vector3i div_mul = ptr->getDivisionMultiplier();
    eigen_vector3i_t ret = {};
    ret.x = div_mul.x();
    ret.y = div_mul.y();
    ret.z = div_mul.z();
    return ret;
}












