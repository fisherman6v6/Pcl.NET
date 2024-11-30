#pragma once
#include "pcl\point_types.h"
#include "export.h"

using namespace std;
using namespace pcl;
using point_t = PointXYZI;
using vector_t = vector<point_t>;

#ifdef __cplusplus  
extern "C" {
#endif

    EXPORT(vector_t*) std_vector_xyzi_ctor();

    EXPORT(vector_t*) std_vector_xyzi_ctor_count(size_t count);

    EXPORT(void) std_vector_xyzi_delete(vector_t** ptr);

    EXPORT(void) std_vector_xyzi_at(vector_t* ptr, size_t idx, point_t* value);

    EXPORT(size_t) std_vector_xyzi_size(vector_t* ptr);

    EXPORT(void) std_vector_xyzi_clear(vector_t* ptr);

    EXPORT(void) std_vector_xyzi_resize(vector_t* ptr, size_t size);

    EXPORT(void) std_vector_xyzi_add(vector_t* ptr, point_t value);

    EXPORT(void) std_vector_xyzi_insert(vector_t* ptr, ptrdiff_t index, point_t value);

    EXPORT(point_t*) std_vector_xyzi_data(vector_t* ptr);

#ifdef __cplusplus  
}
#endif