#include "export.h"
#include "Eigen_Matrix4f.h"

Matrix4f* eigen_matrix4f_ctor()
{
    return new Matrix4f();
}

void eigen_matrix4f_delete(Matrix4f** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

void eigen_matrix4f_set_index(Matrix4f* ptr, int row, int col, float value)
{
    ptr->operator()(row, col) = value;
}

float eigen_matrix4f_get_index(Matrix4f* ptr, int row, int col)
{
    return ptr->operator()(row, col);
}

float* eigen_matrix4f_data(Matrix4f* ptr)
{
    return ptr->data();
}
