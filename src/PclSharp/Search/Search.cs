using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PclSharp.Std;

namespace PclSharp.Search
{
    public abstract class Search<PointT> : UnmanagedObject
    {
        public abstract bool SortedResults { get; set; }

        public abstract void SetInputCloud(PointCloud<PointT> cloud);

        public abstract int NearestKSearch(PointT point, int k, VectorOfInt k_indices, VectorOfFloat k_sqr_distances);
    }
}
