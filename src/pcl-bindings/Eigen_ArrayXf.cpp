#include "Eigen_ArrayXf.h"

#define EIGEN_ARRAYXF_MATH_WRAPPER(FUNC) \
    ArrayXf* eigen_arrayxf_##FUNC(const ArrayXf* ptr) { \
        if (!ptr) return nullptr; \
        return new ArrayXf(ptr->array().FUNC()); \
    }

ArrayXf* eigen_arrayxf_ctor_size(int size)
{
    return new ArrayXf(size);
}

void eigen_arrayxf_delete(ArrayXf** ptr)
{
    delete* ptr;
    *ptr = nullptr;
}

void eigen_arrayxf_set_index(ArrayXf* ptr, int index, float value)
{
    (*ptr)[index] = value;
}

float eigen_arrayxf_get_index(ArrayXf* ptr, int index)
{
    return (*ptr)[index];
}

size_t eigen_arrayxf_size(ArrayXf* ptr)
{
    return ptr->size();
}

float* eigen_arrayxf_data(ArrayXf* ptr)
{
    return ptr->data();
}


EIGEN_ARRAYXF_MATH_WRAPPER(sin)
EIGEN_ARRAYXF_MATH_WRAPPER(cos)
EIGEN_ARRAYXF_MATH_WRAPPER(tan)
EIGEN_ARRAYXF_MATH_WRAPPER(exp)
EIGEN_ARRAYXF_MATH_WRAPPER(log)
EIGEN_ARRAYXF_MATH_WRAPPER(sqrt)
EIGEN_ARRAYXF_MATH_WRAPPER(abs)
