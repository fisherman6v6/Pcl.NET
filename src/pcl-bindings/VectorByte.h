#pragma once
#include "export.h"
#include <vector>

using byte = unsigned char;
using vector_t = std::vector<byte>;

EXPORT(vector_t*) std_vector_byte_ctor();

EXPORT(vector_t*) std_vector_byte_ctor_count(size_t count);

EXPORT(void) std_vector_byte_delete(vector_t** ptr);

EXPORT(void) std_vector_byte_at(vector_t* ptr, size_t idx, byte* value);

EXPORT(size_t) std_vector_byte_size(vector_t* ptr);

EXPORT(void) std_vector_byte_clear(vector_t* ptr);

EXPORT(void) std_vector_byte_resize(vector_t* ptr, size_t size);

EXPORT(void) std_vector_byte_add(vector_t* ptr, byte value);

EXPORT(void) std_vector_byte_insert(vector_t* ptr, ptrdiff_t index, byte value);

EXPORT(byte*) std_vector_byte_data(vector_t* ptr);