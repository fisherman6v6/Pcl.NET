#pragma once

#include <pcl/io/pcd_io.h>
#include "export.h"

using namespace pcl;
using namespace std;

#ifdef __cplusplus
extern "C" {
#endif

    EXPORT(PCDReader*) io_pcdreader_ctor();

    EXPORT(void) io_pcdreader_delete(PCDReader** ptr);

    EXPORT(int32_t) io_pcdreader_read_xyz(PCDReader* ptr, const char* str, PointCloud<PointXYZ>* cloud, int offset);

#ifdef __cplusplus  
}
#endif