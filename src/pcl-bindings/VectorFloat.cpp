#include "VectorFloat.h"

vector_t* std_vector_float_ctor()
{
    return new vector_t();
}

vector_t* std_vector_float_ctor_count(size_t count)
{
    return new vector_t(count);
}

void std_vector_float_delete(vector_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

void std_vector_float_at(vector_t* ptr, size_t idx, type* value)
{
    *value = ptr->at(idx);
}

size_t std_vector_float_size(vector_t* ptr)
{
    return ptr->size();
}

void std_vector_float_clear(vector_t* ptr)
{
    ptr->clear();
}

void std_vector_float_resize(vector_t* ptr, size_t size)
{
    ptr->resize(size);
}

void std_vector_float_add(vector_t* ptr, type value)
{
    ptr->push_back(value);
}

void std_vector_float_insert(vector_t* ptr, ptrdiff_t index, type value)
{
    ptr->insert(ptr->begin() + index, value);
}

type* std_vector_float_data(vector_t* ptr)
{
    return ptr->data();
}
