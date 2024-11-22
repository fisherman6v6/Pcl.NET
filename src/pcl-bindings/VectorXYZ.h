#pragma once
#include "pcl\point_types.h"
#include "export.h"

using namespace std;
using namespace pcl;
using vector_t = vector<PointXYZ>;

#ifdef __cplusplus  
extern "C" {
#endif

    EXPORT(vector_t*) std_vector_xyz_ctor();

    EXPORT(vector_t*) std_vector_xyz_ctor_count(size_t count);

    EXPORT(void) std_vector_xyz_delete(vector<PointXYZ>** ptr);

    EXPORT(void) std_vector_xyz_at(vector<PointXYZ>* ptr, size_t idx, PointXYZ* value);

    EXPORT(size_t) std_vector_xyz_size(vector<PointXYZ>* ptr);

    EXPORT(void) std_vector_xyz_clear(vector<PointXYZ>* ptr);

    EXPORT(void) std_vector_xyz_resize(vector<PointXYZ>* ptr, size_t size);

    EXPORT(void) std_vector_xyz_add(vector<PointXYZ>* ptr, PointXYZ value);

    EXPORT(void) std_vector_xyz_insert(vector<PointXYZ>* ptr, ptrdiff_t index, PointXYZ value);

    EXPORT(PointXYZ*) std_vector_xyz_data(vector<PointXYZ>* ptr);

#ifdef __cplusplus  
}
#endif