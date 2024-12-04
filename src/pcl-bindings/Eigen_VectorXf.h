#pragma once
#include "export.h"
#include <Eigen/Core>

using namespace Eigen;

EXPORT(VectorXf*) eigen_vectorx_f_ctor();

EXPORT(void) eigen_vectorx_f_delete(VectorXf** ptr);

EXPORT(void) eigen_vectorx_f_set_index(VectorXf* ptr, size_t index, float value);

EXPORT(float) eigen_vectorx_f_get_index(VectorXf* ptr, size_t index);

EXPORT(float*) eigen_vectorx_f_data(VectorXf* ptr);

EXPORT(void) eigen_vectorx_f_normalize(VectorXf* ptr);
