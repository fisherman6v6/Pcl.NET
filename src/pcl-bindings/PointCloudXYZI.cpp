#include "PointCloudXYZI.h"

PointCloud<PointXYZI>* pointcloud_xyzi_ctor()
{
    return new PointCloud<PointXYZI>();
}

PointCloud<PointXYZI>* pointcloud_xyzi_ctor_wh(uint32_t width, uint32_t height)
{
    return new PointCloud<PointXYZI>(width, height);
}

PointCloud<PointXYZI>* pointcloud_xyzi_ctor_indices(PointCloud<PointXYZI>* cloud, vector<int>* indices)
{
    if (indices == NULL)
        return new PointCloud<PointXYZI>(*cloud);
    else
        return new PointCloud<PointXYZI>(*cloud, *indices);
}

void pointcloud_xyzi_delete(PointCloud<PointXYZI>** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

PointXYZI* pointcloud_xyzi_at_colrow(PointCloud<PointXYZI>* ptr, size_t col, size_t row)
{
    return &(*ptr)(col, row);
}

void pointcloud_xyzi_add(PointCloud<PointXYZI>* ptr, PointXYZI* value)
{
    //the value needs to be aligned to be pushed into the cloud, so do that.
    PointXYZI deref;
    memcpy(&deref, value, sizeof(PointXYZ));
    ptr->push_back(deref);
}

size_t pointcloud_xyzi_size(PointCloud<PointXYZI>* ptr)
{
    return ptr->size();
}

void pointcloud_xyzi_clear(PointCloud<PointXYZI>* ptr)
{
    ptr->clear();
}

uint32_t pointcloud_xyzi_width(PointCloud<PointXYZI>* ptr)
{
    return ptr->width;
}

void pointcloud_xyzi_width_set(PointCloud<PointXYZI>* ptr, uint32_t width)
{
    ptr->width = width;
}

uint32_t pointcloud_xyzi_height(PointCloud<PointXYZI>* ptr)
{
    return ptr->height;
}

void pointcloud_xyzi_height_set(PointCloud<PointXYZI>* ptr, uint32_t height)
{
    ptr->height = height;
}

int32_t pointcloud_xyzi_is_organized(PointCloud<PointXYZI>* ptr)
{
    return ptr->isOrganized();
}

point_vector* pointcloud_xyzi_points(PointCloud<PointXYZI>* ptr)
{
    return &ptr->points;
}

PointXYZI* pointcloud_xyzi_data(PointCloud<PointXYZI>* ptr)
{
    return ptr->points.data();
}

void pointcloud_xyzi_downsample(PointCloud<PointXYZI>* ptr, int factor, PointCloud<PointXYZI>* output)
{
    if (output->width != ptr->width / factor ||
        output->height != ptr->height / factor)
    {
        output->resize(ptr->width / factor * ptr->height / factor);
        output->width = ptr->width / factor;
        output->height = ptr->height / factor;
        output->is_dense = ptr->is_dense;
    }

    if (factor == 1)
    {
        output->points = ptr->points;
        return;
    }

    auto ow = output->width;
    auto oh = output->height;
    auto iw = ptr->width;

    auto oarr = output->points.data();
    auto iarr = ptr->points.data();

    for (size_t c = 0; c < ow; c++)
    {
        for (size_t r = 0; r < oh; r++)
        {
            oarr[r * ow + c] = iarr[r * factor * iw + c * factor];
        }
    }
}

void pointcloud_xyzi_set_is_dense(PointCloud<PointXYZI>* ptr, int value)
{
    ptr->is_dense = value;
}

int pointcloud_xyzi_get_is_dense(PointCloud<PointXYZI>* ptr)
{
    return ptr->is_dense;
}

void pointcloud_xyzi_concatenate(PointCloud<PointXYZI>* ptr1, PointCloud<PointXYZI>* ptr2, PointCloud<PointXYZI>* ptr_out)
{
    PointCloud<PointXYZI>::concatenate(*ptr1, *ptr2, *ptr_out);
}
