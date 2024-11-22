#include "VectorXYZ.h"

vector_t* std_vector_xyz_ctor()
{
	return new vector<PointXYZ>();
}

vector_t* std_vector_xyz_ctor_count(size_t count)
{
    return new vector<PointXYZ>(count);
}

void std_vector_xyz_delete(vector<PointXYZ>** ptr)
{
	delete* ptr;
	*ptr = NULL;
}

void std_vector_xyz_at(vector<PointXYZ>* ptr, size_t idx, PointXYZ* value)
{
	*value = ptr->at(idx);
}

size_t std_vector_xyz_size(vector<PointXYZ>* ptr)
{
	return ptr->size();
}

void std_vector_xyz_clear(vector<PointXYZ>* ptr)
{
	ptr->clear();
}

void std_vector_xyz_resize(vector<PointXYZ>* ptr, size_t size)
{
	ptr->resize(size);
}

void std_vector_xyz_add(vector<PointXYZ>* ptr, PointXYZ value)
{
	//the value needs to be aligned to be pushed into the cloud, so do that.
	PointXYZ deref;
	memcpy(&deref, &value, sizeof(PointXYZ));
	ptr->push_back(deref);
}

void std_vector_xyz_insert(vector<PointXYZ>* ptr, ptrdiff_t index, PointXYZ value)
{
	//the value needs to be aligned to be pushed into the cloud, so do that.
	PointXYZ deref;
	memcpy(&deref, &value, sizeof(PointXYZ));
	ptr->insert(ptr->begin() + index, deref);
}

PointXYZ* std_vector_xyz_data(vector<PointXYZ>* ptr)
{
	return ptr->data();
}