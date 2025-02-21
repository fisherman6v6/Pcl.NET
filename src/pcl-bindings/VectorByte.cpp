#include "VectorByte.h"

EXPORT(vector_t*)std_vector_byte_ctor()
{
    return new vector_t();
}

EXPORT(vector_t*)std_vector_ctor_count(size_t count)
{
    return new vector_t(count);
}

EXPORT(void)std_vector_delete(vector_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

EXPORT(void)std_vector_at(vector_t* ptr, size_t idx, byte* value)
{
    *value = ptr->at(idx);
}

EXPORT(size_t)std_vector_size(vector_t* ptr)
{
    return ptr->size();
}

EXPORT(void)std_vector_clear(vector_t* ptr)
{
    ptr->clear();
}

EXPORT(void)std_vector_resize(vector_t* ptr, size_t size)
{
    ptr->resize(size);
}

EXPORT(void)std_vector_add(vector_t* ptr, byte value)
{
    ptr->push_back(value);
}

EXPORT(void)std_vector_insert(vector_t* ptr, ptrdiff_t index, byte value)
{
    ptr->insert(ptr->begin() + index, value);
}

EXPORT(byte*)std_vector_data(vector_t* ptr)
{
    return ptr->data();
}
