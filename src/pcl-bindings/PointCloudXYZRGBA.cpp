#include "PointCloud_Common.h"
#include "export.h"
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"

using namespace pcl;
using namespace std;

using point_t = PointXYZRGBA;
using pointcloud_t = PointCloud<point_t>;
using point_vector = vector<point_t, Eigen::aligned_allocator<point_t>>;

EXPORT(pointcloud_t*) pointcloud_xyzrgba_ctor()
{
    return new pointcloud_t();
}

EXPORT(pointcloud_t*) pointcloud_xyzrgba_ctor_wh(uint32_t width, uint32_t height)
{
    return new pointcloud_t(width, height);
}

EXPORT(pointcloud_t*) pointcloud_xyzrgba_ctor_indices(pointcloud_t* cloud, vector<int>* indices)
{
    if (indices == NULL)
        return new pointcloud_t(*cloud);
    else
        return new pointcloud_t(*cloud, *indices);
}

EXPORT(void) pointcloud_xyzrgba_delete(pointcloud_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

EXPORT(point_t*) pointcloud_xyzrgba_at_colrow(pointcloud_t* ptr, int col, int row)
{
    return &(ptr->at(col, row));
}

EXPORT(void) pointcloud_xyzrgba_add(pointcloud_t* ptr, point_t* value)
{
    //the value needs to be aligned to be pushed into the cloud, so do that.
    point_t deref;
    memcpy(&deref, value, sizeof(point_t));
    ptr->push_back(deref);
}

EXPORT(size_t) pointcloud_xyzrgba_size(pointcloud_t* ptr)
{
    return ptr->size();
}

EXPORT(void) pointcloud_xyzrgba_clear(pointcloud_t* ptr)
{
    ptr->clear();
}

EXPORT(uint32_t) pointcloud_xyzrgba_get_width(pointcloud_t* ptr)
{
    return ptr->width;
}

EXPORT(void) pointcloud_xyzrgba_set_width(pointcloud_t* ptr, uint32_t width)
{
    ptr->width = width;
}

EXPORT(uint32_t) pointcloud_xyzrgba_get_height(pointcloud_t* ptr)
{
    return ptr->height;
}

EXPORT(void) pointcloud_xyzrgba_set_height(pointcloud_t* ptr, uint32_t height)
{
    ptr->height = height;
}

EXPORT(int32_t) pointcloud_xyzrgba_is_organized(pointcloud_t* ptr)
{
    return ptr->isOrganized();
}

EXPORT(point_vector*) pointcloud_xyzrgba_points(pointcloud_t* ptr)
{
    return &ptr->points;
}

EXPORT(point_t*) pointcloud_xyzrgba_data(pointcloud_t* ptr)
{
    return ptr->points.data();
}

EXPORT(void) pointcloud_xyzrgba_downsample(pointcloud_t* ptr, int factor, pointcloud_t* output)
{
    downsample<point_t>(ptr, factor, output);
}

EXPORT(void) pointcloud_xyzrgba_set_is_dense(pointcloud_t* ptr, int value)
{
    ptr->is_dense = value;
}

EXPORT(int) pointcloud_xyzrgba_get_is_dense(pointcloud_t* ptr)
{
    return ptr->is_dense;
}

EXPORT(void) pointcloud_xyzrgba_concatenate(pointcloud_t* ptr1, pointcloud_t* ptr2, pointcloud_t* ptr_out)
{
    pointcloud_t::concatenate(*ptr1, *ptr2, *ptr_out);
}
