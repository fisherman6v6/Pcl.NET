#pragma once

#include <pcl/io/pcd_io.h>
#include "export.h"

using namespace pcl;
using namespace std;

#ifdef __cplusplus
extern "C" {
#endif

  EXPORT(PCDWriter*) io_pcdwriter_ctor();

  EXPORT(void) io_pcdwriter_delete(PCDWriter** ptr);

  EXPORT(int32_t) io_pcdwriter_write_xyz(PCDWriter* ptr, const char* str, PointCloud<PointXYZ>* cloud, int binary);

#ifdef __cplusplus  
}
#endif