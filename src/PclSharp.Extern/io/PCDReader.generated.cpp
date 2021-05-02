// Code generated by a template
#pragma once
#include "..\export.h"
#include <pcl/io/pcd_io.h>

using namespace pcl;
using namespace std;

#ifdef __cplusplus
extern "C" {
#endif

EXPORT(PCDReader*) io_pcdreader_ctor()
{
	return new PCDReader();
}

EXPORT(void) io_pcdreader_delete(PCDReader** ptr)
{
	delete *ptr;
	*ptr = NULL;
}

//https://pointclouds.org/documentation/classpcl_1_1_p_c_d_reader.html#ad7f0e72226fcd3b75b98d064ab2c63e2

//int pcl::PCDReader::read(const std::string& file_name,
//	pcl::PointCloud< PointT >& cloud,
//	const int 	offset = 0
//)

EXPORT(int32_t) io_pcdreader_read_xyz(PCDReader* ptr, const std::string& file_name, pcl::PointCloud<PointXYZ>& cloud, const int offset)
{
	return ptr->read(file_name, cloud, offset);
}

EXPORT(int32_t) io_pcdreader_read_xyzrgba(PCDReader* ptr, const char* str, PointCloud<PointXYZRGBA>* cloud, int offset)
{ 
	return ptr->read(string(str), *cloud, offset); 
}


#ifdef __cplusplus  
}
#endif
