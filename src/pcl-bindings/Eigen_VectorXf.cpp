#include "Eigen_VectorXf.h"

vector_t* eigen_vectorxf_ctor()
{
    return new vector_t();
}

vector_t* eigen_vectorxf_ctor_size(size_t size)
{
    return new vector_t(size);
}

void eigen_vectorxf_delete(vector_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

void eigen_vectorxf_set_index(vector_t* ptr, size_t index, float value)
{
    ptr->operator()(index) = value;
}

float eigen_vectorxf_get_index(vector_t* ptr, size_t index)
{
    return ptr->operator()(index);
}

float* eigen_vectorxf_data(vector_t* ptr)
{
    return ptr->data();
}

void eigen_vectorxf_normalize(vector_t* ptr)
{
    ptr->normalize();
}
