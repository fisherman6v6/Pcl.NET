#include "Eigen_VectorXf.h"

VectorXf* eigen_vectorx_f_ctor()
{
    return new VectorXf();
}

void eigen_vectorx_f_delete(VectorXf** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

void eigen_vectorx_f_set_index(VectorXf* ptr, size_t index, float value)
{
    ptr->operator()(index) = value;
}

float eigen_vectorx_f_get_index(VectorXf* ptr, size_t index)
{
    return ptr->operator()(index);
}

float* eigen_vectorx_f_data(VectorXf* ptr)
{
    return ptr->data();
}

void eigen_vectorx_f_normalize(VectorXf* ptr)
{
    ptr->normalize();
}
