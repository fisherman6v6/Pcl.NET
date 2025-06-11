#pragma once
#include "export.h"
#include <Eigen/Core>

using namespace Eigen;
using vector_t = VectorXf;

EXPORT(vector_t*) eigen_vectorxf_ctor();

EXPORT(vector_t*) eigen_vectorxf_ctor_size(size_t size);

EXPORT(void) eigen_vectorxf_delete(vector_t** ptr);

EXPORT(void) eigen_vectorxf_set_index(vector_t* ptr, size_t index, float value);

EXPORT(float) eigen_vectorxf_get_index(vector_t* ptr, size_t index);

EXPORT(float*) eigen_vectorxf_data(vector_t* ptr);

EXPORT(void) eigen_vectorxf_normalize(vector_t* ptr);
