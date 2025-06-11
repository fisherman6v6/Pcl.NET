#pragma once
#include "export.h"
#include <Eigen/Core>

using namespace Eigen;

EXPORT(ArrayXf*) eigen_arrayxf_ctor_size(int size);

EXPORT(void) eigen_arrayxf_delete(ArrayXf** ptr);

EXPORT(void) eigen_arrayxf_set_index(ArrayXf* ptr, int index, float value);

EXPORT(float) eigen_arrayxf_get_index(ArrayXf* ptr, int index);

EXPORT(size_t) eigen_arrayxf_size(ArrayXf* ptr);

EXPORT(float*) eigen_arrayxf_data(ArrayXf* ptr);

EXPORT(ArrayXf*) eigen_arrayxf_sin(const ArrayXf* ptr);

EXPORT(ArrayXf*) eigen_arrayxf_cos(const ArrayXf* ptr);

EXPORT(ArrayXf*) eigen_arrayxf_tan(const ArrayXf* ptr);

EXPORT(ArrayXf*) eigen_arrayxf_exp(const ArrayXf* ptr);

EXPORT(ArrayXf*) eigen_arrayxf_log(const ArrayXf* ptr);

EXPORT(ArrayXf*) eigen_arrayxf_sqrt(const ArrayXf* ptr);

EXPORT(ArrayXf*) eigen_arrayxf_abs(const ArrayXf* ptr);
