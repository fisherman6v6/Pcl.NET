#pragma once
#include "export.h"
#include <pcl/PCLImage.h>

using namespace pcl;
using namespace std;

EXPORT(PCLImage*) pclimage_ctor();

EXPORT(void) pclimage_delete(PCLImage** ptr);

EXPORT(std::uint32_t) pclimage_get_width(PCLImage* ptr);

EXPORT(void) pclimage_set_width(PCLImage* ptr, std::uint32_t value);

EXPORT(std::uint32_t) pclimage_get_height(PCLImage* ptr);

EXPORT(void) pclimage_set_height(PCLImage* ptr, std::uint32_t value);

EXPORT(std::vector<uint8_t>*) pclimage_data(PCLImage* ptr);

EXPORT(const char*) pclimage_get_encoding(PCLImage* ptr);

EXPORT(void) pclimage_set_encoding(PCLImage* ptr, const char* encoding);

EXPORT(void) pcimage_set_step(PCLImage* ptr, uint32_t value);

EXPORT(std::uint32_t) pclimage_get_step(PCLImage* ptr);
