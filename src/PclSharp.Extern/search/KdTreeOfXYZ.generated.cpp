// Code generated by a template
#pragma once
#include "..\export.h"

#include "pcl\pcl_base.h"
#include "pcl\point_types.h"
#include <pcl/search/kdtree.h>

using namespace pcl::search;
using namespace std;

typedef pcl::PointXYZ PointXYZ;
typedef KdTree<PointXYZ> search_t;
typedef shared_ptr<pcl::PointCloud<PointXYZ>> boost_cloud;
typedef std::vector<float> vectorOfFloat;

#ifdef __cplusplus
extern "C" {
#endif 

EXPORT(search_t*) search_kdtree_xyz_ctor(int sorted)
{
	return new search_t(sorted);
}

EXPORT(void) search_kdtree_xyz_delete(search_t** ptr)
{
	delete *ptr;
	*ptr = NULL;
}

EXPORT(void) search_kdtree_xyz_setInputCloud(KdTree<PointXYZ>* ptr, pcl::PointCloud<PointXYZ>* cloud)
{
	ptr->setInputCloud(boost_cloud(boost_cloud(), cloud));
}

EXPORT(int) search_kdtree_xyz_nearestKSearch(KdTree<PointXYZ>* ptr, const PointXYZ& point, int k, std::vector<int> k_indices, std::vector< float > k_sqr_distances)
{
	return ptr->nearestKSearch(point, k, k_indices, k_sqr_distances);
}

EXPORT(void) search_kdtree_xyz_setSortedResults(KdTree<PointXYZ>* ptr, int value)
{ 
	ptr->setSortedResults(value); 
}

EXPORT(int) search_kdtree_xyz_getSortedResults(KdTree<PointXYZ>* ptr)
{ 
	return ptr->getSortedResults(); 
}

#ifdef __cplusplus  
}
#endif  