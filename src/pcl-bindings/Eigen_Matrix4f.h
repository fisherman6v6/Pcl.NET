#pragma once
#include "export.h"
#include <Eigen/Core>

using namespace Eigen;

EXPORT(Matrix4f*) eigen_matrix4_f_ctor();

EXPORT(void) eigen_matrix4_f_delete(Matrix4f** ptr);

EXPORT(void) eigen_matrix4_f_set_index(Matrix4f* ptr, int row, int col, float value);

EXPORT(float) eigen_matrix4_f_get_index(Matrix4f* ptr, int row, int col);

EXPORT(float*) eigen_matrix4_f_data(Matrix4f* ptr);
