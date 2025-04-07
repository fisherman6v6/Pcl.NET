#include "PointCloudXYZI.h"
#include "PointCloud_Common.h"

pointcloud_t* pointcloud_xyzi_ctor()
{
    return new pointcloud_t();
}

pointcloud_t* pointcloud_xyzi_ctor_wh(uint32_t width, uint32_t height)
{
    return new pointcloud_t(width, height);
}

pointcloud_t* pointcloud_xyzi_ctor_indices(pointcloud_t* cloud, vector<int>* indices)
{
    if (indices == NULL)
        return new pointcloud_t(*cloud);
    else
        return new pointcloud_t(*cloud, *indices);
}

void pointcloud_xyzi_delete(pointcloud_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

point_t* pointcloud_xyzi_at_colrow(pointcloud_t* ptr, int col, int row)
{
    return &(ptr->at(col, row));
}

void pointcloud_xyzi_add(pointcloud_t* ptr, point_t* value)
{
    //the value needs to be aligned to be pushed into the cloud, so do that.
    point_t deref;
    memcpy(&deref, value, sizeof(PointXYZ));
    ptr->push_back(deref);
}

size_t pointcloud_xyzi_size(pointcloud_t* ptr)
{
    return ptr->size();
}

void pointcloud_xyzi_clear(pointcloud_t* ptr)
{
    ptr->clear();
}

uint32_t pointcloud_xyzi_get_width(pointcloud_t* ptr)
{
    return ptr->width;
}

void pointcloud_xyzi_set_width(pointcloud_t* ptr, uint32_t width)
{
    ptr->width = width;
}

uint32_t pointcloud_xyzi_get_height(pointcloud_t* ptr)
{
    return ptr->height;
}

void pointcloud_xyzi_set_height(pointcloud_t* ptr, uint32_t height)
{
    ptr->height = height;
}

int32_t pointcloud_xyzi_is_organized(pointcloud_t* ptr)
{
    return ptr->isOrganized();
}

point_vector* pointcloud_xyzi_points(pointcloud_t* ptr)
{
    return &ptr->points;
}

point_t* pointcloud_xyzi_data(pointcloud_t* ptr)
{
    return ptr->points.data();
}

void pointcloud_xyzi_downsample(pointcloud_t* ptr, int factor, pointcloud_t* output)
{
    downsample<point_t>(ptr, factor, output);
}

void pointcloud_xyzi_set_is_dense(pointcloud_t* ptr, int value)
{
    ptr->is_dense = value;
}

int pointcloud_xyzi_get_is_dense(pointcloud_t* ptr)
{
    return ptr->is_dense;
}

void pointcloud_xyzi_concatenate(pointcloud_t* ptr1, pointcloud_t* ptr2, pointcloud_t* ptr_out)
{
    pointcloud_t::concatenate(*ptr1, *ptr2, *ptr_out);
}
