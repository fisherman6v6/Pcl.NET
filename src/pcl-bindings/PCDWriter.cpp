#include "PCDWriter.h"

PCDWriter* io_pcdwriter_ctor()
{
	return new PCDWriter();
}

void io_pcdwriter_delete(PCDWriter** ptr)
{
	delete* ptr;
	*ptr = NULL;
}

int32_t io_pcdwriter_write_xyz(PCDWriter* ptr, const char* str, PointCloud<PointXYZ>* cloud, int binary)
{
	return ptr->write(string(str), *cloud, binary);
}