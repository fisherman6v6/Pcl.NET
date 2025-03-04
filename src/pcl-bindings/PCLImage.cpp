#include "PCLImage.h"
#include <string>

PCLImage* pclimage_ctor()
{
    return new PCLImage();
}

void pclimage_delete(PCLImage** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

std::uint32_t pclimage_get_width(PCLImage* ptr)
{
    return ptr->width;
}

void pclimage_set_width(PCLImage* ptr, std::uint32_t value)
{
    ptr->height = value;
}

std::uint32_t pclimage_get_height(PCLImage* ptr)
{
    return ptr->height;
}

void pclimage_set_height(PCLImage* ptr, uint32_t value)
{
    ptr->height = value;
}

std::vector<uint8_t>* pclimage_data(PCLImage* ptr)
{
    return &(ptr->data);
}

const char* pclimage_get_encoding(PCLImage* ptr)
{
    return (const char*)ptr->encoding.c_str();
}

void pclimage_set_encoding(PCLImage* ptr, const char* encoding)
{
    ptr->encoding = encoding;
}

void pcimage_set_step(PCLImage* ptr, uint32_t value)
{
    ptr->step = value;
}

uint32_t pclimage_get_step(PCLImage* ptr)
{
    return ptr->step;
}