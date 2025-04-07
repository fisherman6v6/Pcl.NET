#include "VectorXYZ.h"

vector_t* std_vector_xyz_ctor()
{
	return new vector_t();
}

vector_t* std_vector_xyz_ctor_count(size_t count)
{
    return new vector_t(count);
}

void std_vector_xyz_delete(vector_t** ptr)
{
	delete* ptr;
	*ptr = NULL;
}

void std_vector_xyz_at(vector_t* ptr, size_t idx, point_t* value)
{
	*value = ptr->at(idx);
}

size_t std_vector_xyz_size(vector_t* ptr)
{
	return ptr->size();
}

void std_vector_xyz_clear(vector_t* ptr)
{
	ptr->clear();
}

void std_vector_xyz_resize(vector_t* ptr, size_t size)
{
	ptr->resize(size);
}

void std_vector_xyz_add(vector_t* ptr, point_t value)
{
	//the value needs to be aligned to be pushed into the cloud, so do that.
    point_t deref;
	memcpy(&deref, &value, sizeof(point_t));
	ptr->push_back(deref);
}

void std_vector_xyz_insert(vector_t* ptr, ptrdiff_t index, point_t value)
{
	//the value needs to be aligned to be pushed into the cloud, so do that.
    point_t deref;
	memcpy(&deref, &value, sizeof(point_t));
	ptr->insert(ptr->begin() + index, deref);
}

point_t* std_vector_xyz_data(vector_t* ptr)
{
	return ptr->data();
}