#include "PointCloudXYZ.h"
#include "PointCloud_Common.h"

pointcloud_t* pointcloud_xyz_ctor()
{
    return new pointcloud_t();
}

pointcloud_t* pointcloud_xyz_ctor_wh(uint32_t width, uint32_t height)
{
	return new pointcloud_t(width, height);
}

pointcloud_t* pointcloud_xyz_ctor_indices(pointcloud_t* cloud, vector<int>* indices)
{
	if (indices == NULL)
		return new pointcloud_t(*cloud);
	else
		return new pointcloud_t(*cloud, *indices);
}

void pointcloud_xyz_delete(pointcloud_t** ptr)
{
	delete* ptr;
	*ptr = NULL;
}

type* pointcloud_xyz_at_colrow(pointcloud_t* ptr, int col, int row)
{
	return &(ptr->at(col, row));
}

void pointcloud_xyz_add(pointcloud_t* ptr, type* value)
{
	//the value needs to be aligned to be pushed into the cloud, so do that.
	PointXYZ deref;
	memcpy(&deref, value, sizeof(PointXYZ));
	ptr->push_back(deref);
}

size_t pointcloud_xyz_size(pointcloud_t* ptr)
{
	return ptr->size();
}

void pointcloud_xyz_clear(pointcloud_t* ptr)
{
	ptr->clear();
}

uint32_t pointcloud_xyz_get_width(pointcloud_t* ptr)
{
	return ptr->width;
}

void pointcloud_xyz_set_width(pointcloud_t* ptr, uint32_t width)
{
	ptr->width = width;
}

uint32_t pointcloud_xyz_get_height(pointcloud_t* ptr)
{
	return ptr->height;
}

void pointcloud_xyz_set_height(pointcloud_t* ptr, uint32_t height)
{
	ptr->height = height;
}

int32_t pointcloud_xyz_is_organized(pointcloud_t* ptr)
{
	return ptr->isOrganized();
}

point_vector* pointcloud_xyz_points(pointcloud_t* ptr)
{
	return &ptr->points;
}

type* pointcloud_xyz_data(pointcloud_t* ptr)
{
	return ptr->points.data();
}

void pointcloud_xyz_downsample(pointcloud_t* ptr, int factor, pointcloud_t* output)
{
    downsample<type>(ptr, factor, output);
}

void pointcloud_xyz_set_is_dense(pointcloud_t* ptr, int value)
{
	ptr->is_dense = value;
}

int pointcloud_xyz_get_is_dense(pointcloud_t* ptr)
{
	return ptr->is_dense;
}

void pointcloud_xyz_concatenate(pointcloud_t* ptr1, pointcloud_t* ptr2, pointcloud_t* ptr_out)
{
	pointcloud_t::concatenate(*ptr1, *ptr2, *ptr_out);
}
