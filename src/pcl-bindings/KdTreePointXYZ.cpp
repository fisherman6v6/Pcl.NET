#include "export.h"
#include "pcl/point_types.h"
#include "pcl/kdtree/kdtree_flann.h"
#include "PointCloud_Common.h"

using namespace pcl;
using namespace std;

using point_t = PointXYZ;
using pointcloud_t = PointCloud<point_t>;
using kdtree_t = KdTreeFLANN<point_t>;

EXPORT(kdtree_t*) kdtree_pointxyz_ctor(int sorted)
{
    return new kdtree_t(sorted);
}

EXPORT(void) kdtree_pointxyz_delete(kdtree_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

EXPORT(void) kdtree_pointxyz_set_input_cloud(kdtree_t* ptr, pointcloud_t* cloud)
{
    ptr->setInputCloud(pointcloud_t::ConstPtr(cloud));
}

EXPORT(void) kdtree_pointxyz_set_epsilon(kdtree_t* ptr, float eps)
{
    ptr->setEpsilon(eps);
}

EXPORT(int) kdtree_pointxyz_nearest_k_search(kdtree_t* ptr, point_t* point, int k, vector<int>* indices, vector<float>* distances)
{
    indices->resize(k);
    distances->resize(k);
    
    int found = ptr->nearestKSearch(*point, k, *indices, *distances);
    
    return found;
}

EXPORT(int) kdtree_pointxyz_radius_search(kdtree_t* ptr, point_t* point, double radius, int max_nn, vector<int>* indices, vector<float>* distances)
{
    int found = ptr->radiusSearch(*point, radius, *indices, *distances, max_nn);
    
    return found;
}

EXPORT(void) kdtree_pointxyz_set_sorted_results(kdtree_t* ptr, int sorted)
{
    ptr->setSortedResults(sorted);
}

EXPORT(int) kdtree_pointxyz_get_sorted_results(kdtree_t* ptr)
{
    return ptr->getSortedResults() ? 1 : 0;
}

EXPORT(float) kdtree_pointxyz_get_epsilon(kdtree_t* ptr)
{
    return ptr->getEpsilon();
}