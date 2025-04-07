#pragma once
#include "export.h"
#include <vector>

using point_t = float;
using vector_t = std::vector<point_t>; 

EXPORT(vector_t*) std_vector_float_ctor();

EXPORT(vector_t*) std_vector_float_ctor_count(size_t count);

EXPORT(void) std_vector_float_delete(vector_t** ptr);

EXPORT(void) std_vector_float_at(vector_t* ptr, size_t idx, point_t* value);

EXPORT(size_t) std_vector_float_size(vector_t* ptr);

EXPORT(void) std_vector_float_clear(vector_t* ptr);

EXPORT(void) std_vector_float_resize(vector_t* ptr, size_t size);

EXPORT(void) std_vector_float_add(vector_t* ptr, point_t value);

EXPORT(void) std_vector_float_insert(vector_t* ptr, ptrdiff_t index, point_t value);

EXPORT(point_t*) std_vector_float_data(vector_t* ptr);