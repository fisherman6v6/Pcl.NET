#include "export.h"
#include "pcl/impl/point_types.hpp"
#include "pcl/pcl_base.h"
#include "pcl/point_cloud.h"
#include "pcl/point_types.h"
#include <Eigen/Core>
#include <pcl/registration/icp.h>

using namespace pcl;
using namespace Eigen;
using point_source_t = PointXYZ;
using point_target_t = PointXYZ;
using point_cloud_t = PointCloud<PointXYZ>;
using icp_t = IterativeClosestPoint<point_source_t, point_target_t>;

EXPORT(icp_t*) iterative_closest_point_xyz_xyz_ctor()
{
    return new icp_t();
}

EXPORT(void) iterative_closest_point_xyz_xyz_delete(icp_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}


EXPORT(void) iterative_closest_point_xyz_xyz_set_input_source(icp_t* ptr, point_cloud_t* cloud)
{
    point_cloud_t::Ptr shared(std::make_shared<point_cloud_t>(*cloud));
    ptr->setInputSource(shared);
}

EXPORT(void) iterative_closest_point_xyz_xyz_set_input_target(icp_t* ptr, point_cloud_t* cloud)
{
    point_cloud_t::Ptr shared(std::make_shared<point_cloud_t>(*cloud));
    ptr->setInputTarget(shared);
}

EXPORT(void) iterative_closest_point_xyz_xyz_set_use_reciprocal_correspondences(icp_t* ptr, bool use_reciprocal_correspondences)
{
    ptr->setUseReciprocalCorrespondences(use_reciprocal_correspondences);
}

EXPORT(int) iterative_closest_point_xyz_xyz_get_use_reciprocal_correspondences(icp_t* ptr)
{
    return ptr->getUseReciprocalCorrespondences();
}

EXPORT(void) iterative_closest_point_xyz_xyz_set_max_correspondence_distance(icp_t* ptr, double distance)
{
    ptr->setMaxCorrespondenceDistance(distance);
}

EXPORT(double) iterative_closest_point_xyz_xyz_get_max_correspondence_distance(icp_t* ptr)
{
    return ptr->getMaxCorrespondenceDistance();
}

EXPORT(void) iterative_closest_point_xyz_xyz_set_maximum_iterations(icp_t* ptr, int nr_iterations)
{
    ptr->setMaximumIterations(nr_iterations);
}

EXPORT(int) iterative_closest_point_xyz_xyz_get_maximum_iterations(icp_t* ptr)
{
    return ptr->getMaximumIterations();
}

EXPORT(void) iterative_closest_point_xyz_xyz_set_transformation_epsilon(icp_t* ptr, double epsilon)
{
    ptr->setTransformationEpsilon(epsilon);
}

EXPORT(double) iterative_closest_point_xyz_xyz_get_transformation_epsilon(icp_t* ptr)
{
    return ptr->getTransformationEpsilon();
}

EXPORT(void) iterative_closest_point_xyz_xyz_set_euclidean_fitness_epsilon(icp_t* ptr, double epsilon)
{
    ptr->setEuclideanFitnessEpsilon(epsilon);
}

EXPORT(double) iterative_closest_point_xyz_xyz_get_euclidean_fitness_epsilon(icp_t* ptr)
{
    return ptr->getEuclideanFitnessEpsilon();
}

EXPORT(void) iterative_closest_point_xyz_xyz_align(icp_t* ptr, point_cloud_t* output)
{
    ptr->align(*output);
}

EXPORT(void) iterative_closest_point_xyz_xyz_align_guess(icp_t* ptr, point_cloud_t* output, Matrix4f* guess)
{
    ptr->align(*output, *guess);

}

EXPORT(int) iterative_closest_point_xyz_xyz_has_converged(icp_t* ptr)
{
    return ptr->hasConverged();
}

EXPORT(double) iterative_closest_point_xyz_xyz_get_fitness_score(icp_t* ptr, double max_range)
{
    return ptr->getFitnessScore(max_range);
}

EXPORT(Matrix4f*) iterative_closest_point_xyz_xyz_get_final_transformation(icp_t* ptr)
{
    // getFinalTransformation() returns an Eigen::Matrix4f by value;
    // allocate a new Matrix4f on the heap and copy the contents so the managed side can own/delete it.
    Matrix4f* m = new Matrix4f(ptr->getFinalTransformation());
    return m;
}

EXPORT(void) iterative_closest_point_xyz_xyz_set_indices_vector(icp_t* ptr, const std::vector<int>& indices)
{
    pcl::PointIndices::Ptr indices_ptr(new pcl::PointIndices());
    indices_ptr->indices = indices;
    ptr->setIndices(indices_ptr);
}


EXPORT(void) iterative_closest_point_xyz_xyz_set_indices(icp_t* ptr, std::size_t row_start, std::size_t col_start, std::size_t nb_rows, std::size_t nb_cols)
{
    ptr->setIndices(row_start, col_start, nb_rows, nb_cols);
}

EXPORT(void) iterative_closest_point_xyz_xyz_set_ransac_outlier_rejection_threshold(icp_t* ptr, double threshold)
{
    ptr->setRANSACOutlierRejectionThreshold(threshold);
}

EXPORT(double) iterative_closest_point_xyz_xyz_get_ransac_outlier_rejection_threshold(icp_t* ptr)
{
    return ptr->getRANSACOutlierRejectionThreshold();
}

EXPORT(void) iterative_closest_point_xyz_xyz_set_transformation_rotation_epsilon(icp_t* ptr, double epsilon)
{
    ptr->setTransformationRotationEpsilon(epsilon);
}

EXPORT(double) iterative_closest_point_xyz_xyz_get_transformation_rotation_epsilon(icp_t* ptr)
{
    return ptr->getTransformationRotationEpsilon();
}