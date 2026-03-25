#include "cstructs.h"
#include "export.h"
#include "pcl/point_types.h"
#include <pcl/common/common.h>  
#include <pcl/filters/filter.h>
#include <pcl/point_cloud.h>
#include "pcl/types.h"
#include "PointCloud_Common.h"

using namespace pcl;

EXPORT(void) common_get_min_max_3d_pointxyz(const PointCloud<PointXYZ>* cloud,
                            PointXYZ* min_pt, PointXYZ* max_pt)
{
    pcl::getMinMax3D(*cloud, *min_pt, *max_pt);
}

EXPORT(void) common_get_min_max_3d_pointxyzi(const PointCloud<PointXYZI>* cloud,
                            PointXYZI* min_pt, PointXYZI* max_pt)
{
    pcl::getMinMax3D(*cloud, *min_pt, *max_pt);
}

EXPORT(void) common_get_min_max_3d_pointxyzrgba(const PointCloud<PointXYZRGBA>* cloud,
                            PointXYZRGBA* min_pt, PointXYZRGBA* max_pt)
{
    pcl::getMinMax3D(*cloud, *min_pt, *max_pt);
}

EXPORT(int) common_remove_nan_pointxyz(const PointCloud<PointXYZ>* input, PointCloud<PointXYZ>* output, int* indices)
{
    return remove_nan_points(input, output, indices);
}

EXPORT(int) common_remove_nan_pointxyzi(const PointCloud<PointXYZI>* input, PointCloud<PointXYZI>* output, int* indices)
{
    return remove_nan_points(input, output, indices);
}

EXPORT(int) common_remove_nan_pointxyzrgba(const PointCloud<PointXYZRGBA>* input, PointCloud<PointXYZRGBA>* output, int* indices)
{
    return remove_nan_points(input, output, indices);
}