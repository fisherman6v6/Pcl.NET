#pragma once
#include "export.h"
#include <vector>

using type = unsigned char;
using vector_t = std::vector<type>;

EXPORT(vector_t*) std_vector_byte_ctor();

EXPORT(vector_t*) std_vector_byte_ctor_count(size_t count);

EXPORT(void) std_vector_byte_delete(vector_t** ptr);

EXPORT(void) std_vector_byte_at(vector_t* ptr, size_t idx, type* value);

EXPORT(size_t) std_vector_byte_size(vector_t* ptr);

EXPORT(void) std_vector_byte_clear(vector_t* ptr);

EXPORT(void) std_vector_byte_resize(vector_t* ptr, size_t size);

EXPORT(void) std_vector_byte_add(vector_t* ptr, type value);

EXPORT(void) std_vector_byte_insert(vector_t* ptr, ptrdiff_t index, type value);

EXPORT(type*) std_vector_byte_data(vector_t* ptr);