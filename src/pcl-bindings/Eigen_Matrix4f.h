#pragma once
#include <Eigen/Core>
#include "export.h"

using namespace Eigen;

#ifdef __cplusplus
extern "C" {
#endif

    EXPORT(Matrix4f*) eigen_matrix4_f_ctor();

    EXPORT(void) eigen_matrix4_f_delete(Matrix4f** ptr);

    EXPORT(void) eigen_matrix4_f_set_index(Matrix4f* ptr, int row, int col, float value);

    EXPORT(float) eigen_matrix4_f_get_index(Matrix4f* ptr, int row, int col);

    EXPORT(float*) eigen_matrix4_f_data(Matrix4f* ptr);

#ifdef __cplusplus  
}
#endif