#pragma once
#include "export.h"
#include <vector>

using type = int;
using vector_t = std::vector<int>;

EXPORT(vector_t*) std_vector_int_ctor();

EXPORT(vector_t*) std_vector_int_ctor_count(size_t count);

EXPORT(void) std_vector_int_delete(vector_t** ptr);

EXPORT(void) std_vector_int_at(vector_t* ptr, size_t idx, type* value);

EXPORT(size_t) std_vector_int_size(vector_t* ptr);

EXPORT(void) std_vector_int_clear(vector_t* ptr);

EXPORT(void) std_vector_int_resize(vector_t* ptr, size_t size);

EXPORT(void) std_vector_int_add(vector_t* ptr, type value);

EXPORT(void) std_vector_int_insert(vector_t* ptr, ptrdiff_t index, type value);

EXPORT(int*) std_vector_int_data(vector_t* ptr);