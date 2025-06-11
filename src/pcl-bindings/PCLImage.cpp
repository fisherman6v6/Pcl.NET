#include "export.h"
#include <pcl/PCLImage.h>

using namespace pcl;
using namespace std;
#include <string>

EXPORT(PCLImage*) pclimage_ctor()
{
    return new PCLImage();
}

EXPORT(void) pclimage_delete(PCLImage** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

std::uint32_t pclimage_get_width(PCLImage* ptr)
{
    return ptr->width;
}

EXPORT(void) pclimage_set_width(PCLImage* ptr, std::uint32_t value)
{
    ptr->height = value;
}

EXPORT(std::uint32_t) pclimage_get_height(PCLImage* ptr)
{
    return ptr->height;
}

EXPORT(void) pclimage_set_height(PCLImage* ptr, uint32_t value)
{
    ptr->height = value;
}

EXPORT(std::vector<uint8_t>*) pclimage_data(PCLImage* ptr)
{
    return &(ptr->data);
}

EXPORT(const char*) pclimage_get_encoding(PCLImage* ptr)
{
    return (const char*)ptr->encoding.c_str();
}

EXPORT(void) pclimage_set_encoding(PCLImage* ptr, const char* encoding)
{
    ptr->encoding = encoding;
}

EXPORT(void) pcimage_set_step(PCLImage* ptr, uint32_t value)
{
    ptr->step = value;
}

EXPORT(uint32_t) pclimage_get_step(PCLImage* ptr)
{
    return ptr->step;
}