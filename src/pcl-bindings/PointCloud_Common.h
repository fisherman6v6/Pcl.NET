#pragma once
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"

using namespace pcl;
using namespace std;

template<typename PointT>
void downsample(PointCloud<PointT>* ptr, int factor, PointCloud<PointT>* output)
{
    if (output->width != ptr->width / factor ||
        output->height != ptr->height / factor)
    {
        output->resize(ptr->width / factor * ptr->height / factor);
        output->width = ptr->width / factor;
        output->height = ptr->height / factor;
        output->is_dense = ptr->is_dense;
    }

    if (factor == 1)
    {
        output->points = ptr->points;
        return;
    }

    auto ow = output->width;
    auto oh = output->height;
    auto iw = ptr->width;

    auto oarr = output->points.data();
    auto iarr = ptr->points.data();

    for (size_t c = 0; c < ow; c++)
    {
        for (size_t r = 0; r < oh; r++)
        {
            oarr[r * ow + c] = iarr[r * factor * iw + c * factor];
        }
    }
}