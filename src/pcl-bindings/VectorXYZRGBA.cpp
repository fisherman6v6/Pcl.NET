#include "export.h"
#include "pcl\point_types.h"

using namespace std;
using namespace pcl;
using point_t = PointXYZRGBA;
using vector_t = vector<point_t>;

EXPORT(vector_t*) std_vector_xyzrgba_ctor()
{
    return new vector_t();
}

EXPORT(vector_t*) std_vector_xyzrgba_ctor_count(size_t count)
{
    return new vector_t(count);
}

EXPORT(void) std_vector_xyzrgba_delete(vector_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

EXPORT(void) std_vector_xyzrgba_at(vector_t* ptr, size_t idx, point_t* value)
{
    *value = ptr->at(idx);
}

EXPORT(size_t) std_vector_xyzrgba_size(vector_t* ptr)
{
    return ptr->size();
}

EXPORT(void) std_vector_xyzrgba_clear(vector_t* ptr)
{
    ptr->clear();
}

EXPORT(void) std_vector_xyzrgba_resize(vector_t* ptr, size_t size)
{
    ptr->resize(size);
}

EXPORT(void) std_vector_xyzrgba_add(vector_t* ptr, point_t value)
{
    //the value needs to be aligned to be pushed into the cloud, so do that.
    point_t deref;
    memcpy(&deref, &value, sizeof(point_t));
    ptr->push_back(deref);
}

EXPORT(void) std_vector_xyzrgba_insert(vector_t* ptr, ptrdiff_t index, point_t value)
{
    //the value needs to be aligned to be pushed into the cloud, so do that.
    point_t deref;
    memcpy(&deref, &value, sizeof(point_t));
    ptr->insert(ptr->begin() + index, deref);
}

EXPORT(point_t*) std_vector_xyzrgba_data(vector_t* ptr)
{
    return ptr->data();
}
