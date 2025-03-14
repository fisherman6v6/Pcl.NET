#pragma once
#include "export.h"
#include "pcl\point_types.h"

using namespace std;
using namespace pcl;
using type = PointXYZI;
using vector_t = vector<type>;

EXPORT(vector_t*) std_vector_xyzi_ctor();

EXPORT(vector_t*) std_vector_xyzi_ctor_count(size_t count);

EXPORT(void) std_vector_xyzi_delete(vector_t** ptr);

EXPORT(void) std_vector_xyzi_at(vector_t* ptr, size_t idx, type* value);

EXPORT(size_t) std_vector_xyzi_size(vector_t* ptr);

EXPORT(void) std_vector_xyzi_clear(vector_t* ptr);

EXPORT(void) std_vector_xyzi_resize(vector_t* ptr, size_t size);

EXPORT(void) std_vector_xyzi_add(vector_t* ptr, type value);

EXPORT(void) std_vector_xyzi_insert(vector_t* ptr, ptrdiff_t index, type value);

EXPORT(type*) std_vector_xyzi_data(vector_t* ptr);
