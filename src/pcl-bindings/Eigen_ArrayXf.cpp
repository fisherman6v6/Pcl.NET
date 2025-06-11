#include "export.h"
#include <Eigen/Core>

using namespace Eigen;

#define EIGEN_ARRAYXF_MATH_WRAPPER(FUNC) \
    EXPORT(ArrayXf*) eigen_arrayxf_##FUNC(const ArrayXf* ptr) { \
        if (!ptr) return nullptr; \
        return new ArrayXf(ptr->array().FUNC()); \
    }

EXPORT(ArrayXf*) eigen_arrayxf_ctor_size(int size)
{
    return new ArrayXf(size);
}

EXPORT(void) eigen_arrayxf_delete(ArrayXf** ptr)
{
    delete* ptr;
    *ptr = nullptr;
}

EXPORT(void) eigen_arrayxf_set_index(ArrayXf* ptr, int index, float value)
{
    (*ptr)[index] = value;
}

EXPORT(float) eigen_arrayxf_get_index(ArrayXf* ptr, int index)
{
    return (*ptr)[index];
}

EXPORT(size_t) eigen_arrayxf_size(ArrayXf* ptr)
{
    return ptr->size();
}

EXPORT(float*) eigen_arrayxf_data(ArrayXf* ptr)
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
