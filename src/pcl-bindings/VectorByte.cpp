#include "VectorByte.h"

vector_t* std_vector_byte_ctor()
{
    return new vector_t();
}

vector_t* std_vector_byte_ctor_count(size_t count)
{
    return new vector_t(count);
}

void std_vector_byte_delete(vector_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

void std_vector_byte_at(vector_t* ptr, size_t idx, byte* value)
{
    *value = ptr->at(idx);
}

size_t std_vector_byte_size(vector_t* ptr)
{
    return ptr->size();
}

void std_vector_byte_clear(vector_t* ptr)
{
    ptr->clear();
}

void std_vector_byte_resize(vector_t* ptr, size_t size)
{
    ptr->resize(size);
}

void std_vector_byte_add(vector_t* ptr, byte value)
{
    ptr->push_back(value);
}

void std_vector_byte_insert(vector_t* ptr, ptrdiff_t index, byte value)
{
    ptr->insert(ptr->begin() + index, value);
}

byte* std_vector_byte_data(vector_t* ptr)
{
    return ptr->data();
}
