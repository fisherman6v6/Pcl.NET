#include "export.h"
#include <vector>

using point_t = unsigned char;
using vector_t = std::vector<point_t>;

EXPORT(vector_t*) std_vector_byte_ctor()
{
    return new vector_t();
}

EXPORT(vector_t*) std_vector_byte_ctor_count(size_t count)
{
    return new vector_t(count);
}

EXPORT(void) std_vector_byte_delete(vector_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

EXPORT(void) std_vector_byte_at(vector_t* ptr, size_t idx, point_t* value)
{
    *value = ptr->at(idx);
}

EXPORT(size_t) std_vector_byte_size(vector_t* ptr)
{
    return ptr->size();
}

EXPORT(void) std_vector_byte_clear(vector_t* ptr)
{
    ptr->clear();
}

EXPORT(void) std_vector_byte_resize(vector_t* ptr, size_t size)
{
    ptr->resize(size);
}

EXPORT(void) std_vector_byte_add(vector_t* ptr, point_t value)
{
    ptr->push_back(value);
}

EXPORT(void) std_vector_byte_insert(vector_t* ptr, ptrdiff_t index, point_t value)
{
    ptr->insert(ptr->begin() + index, value);
}

EXPORT(point_t*) std_vector_byte_data(vector_t* ptr)
{
    return ptr->data();
}
