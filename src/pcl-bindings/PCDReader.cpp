#include "PCDReader.h"

PCDReader* io_pcdreader_ctor()
{
    return new PCDReader();
}

void io_pcdreader_delete(PCDReader** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

int32_t io_pcdreader_read_xyz(PCDReader* ptr, const char* str, PointCloud<PointXYZ>* cloud, int offset)
{
    return ptr->read(string(str), *cloud, offset);
}
