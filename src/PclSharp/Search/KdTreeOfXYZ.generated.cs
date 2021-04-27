using System;
using System.Runtime.InteropServices;
using PclSharp.Struct;
using PclSharp.Std;
using System.Collections.Generic;

namespace PclSharp.Search
{
	public static partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr search_kdtree_xyz_ctor(bool sorted);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void search_kdtree_xyz_delete(ref IntPtr ptr);

		//methods
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void search_kdtree_xyz_setInputCloud(IntPtr ptr, IntPtr cloud);

		//properties
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void search_kdtree_xyz_setSortedResults(IntPtr ptr, bool value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern bool search_kdtree_xyz_getSortedResults(IntPtr ptr);

		[DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
		public static extern int search_kdtree_xyz_nearestKSearch(IntPtr ptr, PointXYZ point, int k, PointIndices k_indices, List<VectorOfFloat> k_sqr_distances);
	}

    public class KdTreeOfXYZ : KdTree<PointXYZ>
    {
		public override bool SortedResults
		{
			get { return Invoke.search_kdtree_xyz_getSortedResults(_ptr); }
            set { Invoke.search_kdtree_xyz_setSortedResults(_ptr, value); }
		}

		public KdTreeOfXYZ(bool sorted = true)
		{
			_ptr = Invoke.search_kdtree_xyz_ctor(sorted);
		}

        public override void SetInputCloud(PointCloud<PointXYZ> cloud)
		{
			Invoke.search_kdtree_xyz_setInputCloud(_ptr, cloud);
		}

		protected override void DisposeObject()
		{
			Invoke.search_kdtree_xyz_delete(ref _ptr);
		}

        public override int NearestKSearch(PointXYZ point, int k, PointIndices k_indices, List<VectorOfFloat> k_sqr_distances)
        {
			return Invoke.search_kdtree_xyz_nearestKSearch(_ptr, point, k, k_indices, k_sqr_distances);

		}
    }
}
