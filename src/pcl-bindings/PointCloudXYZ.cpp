#include "PointCloudXYZ.h"

using namespace pcl;
using namespace std;
using point_vector = vector<PointXYZ, Eigen::aligned_allocator<PointXYZ>>;

PointCloud<PointXYZ>* pointcloud_xyz_ctor()
{
    return new PointCloud<PointXYZ>();
}

PointCloud<PointXYZ>* pointcloud_xyz_ctor_wh(uint32_t width, uint32_t height)
{
	return new PointCloud<PointXYZ>(width, height);
}

PointCloud<PointXYZ>* pointcloud_xyz_ctor_indices(PointCloud<PointXYZ>* cloud, vector<int>* indices)
{
	if (indices == NULL)
		return new PointCloud<PointXYZ>(*cloud);
	else
		return new PointCloud<PointXYZ>(*cloud, *indices);
}

void pointcloud_xyz_delete(PointCloud<PointXYZ>** ptr)
{
	delete* ptr;
	*ptr = NULL;
}

PointXYZ* pointcloud_xyz_at_colrow(PointCloud<PointXYZ>* ptr, size_t col, size_t row)
{
	return &(*ptr)(col, row);
}

void pointcloud_xyz_add(PointCloud<PointXYZ>* ptr, PointXYZ* value)
{
	//the value needs to be aligned to be pushed into the cloud, so do that.
	PointXYZ deref;
	memcpy(&deref, value, sizeof(PointXYZ));
	ptr->push_back(deref);
}

size_t pointcloud_xyz_size(PointCloud<PointXYZ>* ptr)
{
	return ptr->size();
}

void pointcloud_xyz_clear(PointCloud<PointXYZ>* ptr)
{
	ptr->clear();
}

uint32_t pointcloud_xyz_width(PointCloud<PointXYZ>* ptr)
{
	return ptr->width;
}

void pointcloud_xyz_width_set(PointCloud<PointXYZ>* ptr, uint32_t width)
{
	ptr->width = width;
}

uint32_t pointcloud_xyz_height(PointCloud<PointXYZ>* ptr)
{
	return ptr->height;
}

void pointcloud_xyz_height_set(PointCloud<PointXYZ>* ptr, uint32_t height)
{
	ptr->height = height;
}

int32_t pointcloud_xyz_is_organized(PointCloud<PointXYZ>* ptr)
{
	return ptr->isOrganized();
}

point_vector* pointcloud_xyz_points(PointCloud<PointXYZ>* ptr)
{
	return &ptr->points;
}

PointXYZ* pointcloud_xyz_data(PointCloud<PointXYZ>* ptr)
{
	return ptr->points.data();
}

void pointcloud_xyz_downsample(PointCloud<PointXYZ>* ptr, int factor, PointCloud<PointXYZ>* output)
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

void pointcloud_xyz_set_is_dense(PointCloud<PointXYZ>* ptr, int value)
{
	ptr->is_dense = value;
}

int pointcloud_xyz_get_is_dense(PointCloud<PointXYZ>* ptr)
{
	return ptr->is_dense;
}

void pointcloud_xyz_concatenate(PointCloud<PointXYZ>* ptr1, PointCloud<PointXYZ>* ptr2, PointCloud<PointXYZ>* ptr_out)
{
	PointCloud<PointXYZ>::concatenate(*ptr1, *ptr2, *ptr_out);
}

Eigen::Vector4f* pointcloud_xyz_get_sensor_origin(PointCloud<PointXYZ>* ptr)
{
    return &ptr->sensor_origin_;
}

void pointcloud_xyz_set_sensor_origin(PointCloud<PointXYZ>* ptr, Eigen::Vector4f* value)
{
    ptr->sensor_origin_ = *value;
}
