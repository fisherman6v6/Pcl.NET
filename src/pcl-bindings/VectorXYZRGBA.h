#pragma once
#include "export.h"
#include "pcl\point_types.h"

using namespace std;
using namespace pcl;
using point_t = PointXYZRGBA;
using vector_t = vector<point_t>;


EXPORT(vector_t*) std_vector_xyzrgba_ctor();

EXPORT(vector_t*) std_vector_xyzrgba_ctor_count(size_t count);

EXPORT(void) std_vector_xyzrgba_delete(vector_t** ptr);

EXPORT(void) std_vector_xyzrgba_at(vector_t* ptr, size_t idx, point_t* value);

EXPORT(size_t) std_vector_xyzrgba_size(vector_t* ptr);

EXPORT(void) std_vector_xyzrgba_clear(vector_t* ptr);

EXPORT(void) std_vector_xyzrgba_resize(vector_t* ptr, size_t size);

EXPORT(void) std_vector_xyzrgba_add(vector_t* ptr, point_t value);

EXPORT(void) std_vector_xyzrgba_insert(vector_t* ptr, ptrdiff_t index, point_t value);

EXPORT(point_t*) std_vector_xyzrgba_data(vector_t* ptr);