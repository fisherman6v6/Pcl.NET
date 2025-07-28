#include <pcl/common/common.h>  
#include "export.h"
#include "cstructs.h"
#include "pcl/point_types.h"
#include <pcl/point_cloud.h>

using namespace pcl;

EXPORT(void) common_get_min_max_3d_pointxyz(const PointCloud<PointXYZ>* cloud,
                            PointXYZ* min_pt, PointXYZ* max_pt)
{
    pcl::getMinMax3D(*cloud, *min_pt, *max_pt);
}