#pragma once
#include "export.h"
#include "pcl\point_types.h"

using namespace std;
using namespace pcl;
using point_t = PointXYZ;
using vector_t = vector<point_t>;


EXPORT(vector_t*) std_vector_xyz_ctor();

EXPORT(vector_t*) std_vector_xyz_ctor_count(size_t count);

EXPORT(void) std_vector_xyz_delete(vector_t** ptr);

EXPORT(void) std_vector_xyz_at(vector_t* ptr, size_t idx, point_t* value);

EXPORT(size_t) std_vector_xyz_size(vector_t* ptr);

EXPORT(void) std_vector_xyz_clear(vector_t* ptr);

EXPORT(void) std_vector_xyz_resize(vector_t* ptr, size_t size);

EXPORT(void) std_vector_xyz_add(vector_t* ptr, point_t value);

EXPORT(void) std_vector_xyz_insert(vector_t* ptr, ptrdiff_t index, point_t value);

EXPORT(PointXYZ*) std_vector_xyz_data(vector_t* ptr);
