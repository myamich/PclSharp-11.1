﻿using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PclSharp.Features;
using PclSharp.IO;
using PclSharp.Std;
using static PclSharp.Test.TestData;

namespace PclSharp.Test.Tutorials
{
    [TestClass]
    public class SupervoxelClustering
    {
        //http://pointclouds.org/documentation/tutorials/statistical_outlier.php#statistical-outlier-removal
        [TestMethod]
        public unsafe void SupervoxelClusteringTutorialTest()
        {
            var voxelResolution = 0.008f;
            var seedResolution = 0.1f;
            var colorImportance = 0.2f;
            var spatialImportance = 0.4f;
            var normalImportance = 1f;

            using (var cloud = new PointCloudOfXYZRGBA())
            {
                using (var reader = new PCDReader())
                    //Assert.AreEqual(0, reader.Read(DataPath("tutorials/correspondence_grouping/milk_cartoon_all_small_clorox.pcd"), cloud));
                    Assert.AreEqual(0, reader.Read(DataPath("tutorials/table_scene_mug_stereo_textured.pcd"), cloud));

                var min = new Vector3(float.MaxValue);
                var max = new Vector3(float.MinValue);
                foreach(var p in cloud.Points)
                {
                    min = Vector3.Min(min, p.V);
                    max = Vector3.Max(max, p.V);
                }

                using (var normals = new PointCloudOfNormal(cloud.Width, cloud.Height))
                using (var super = new Segmentation.SupervoxelClusteringOfXYZRGBA(voxelResolution, seedResolution))
                using (var clusters = new Segmentation.SupervoxelClustersOfXYZRGBA())
                {
                    using (var ne = new IntegralImageNormalEstimationPointXYZAndNormal())
                    using (var noColor = new PointCloudOfXYZ(cloud.Width, cloud.Height))
                    {
                        var count = cloud.Count;
                        var cptr = cloud.Data;
                        var nptr = noColor.Data;
                        for (var i = 0; i < count; i++)
                            (nptr + i)->V = (cptr + i)->V;

                        ne.SetNormalEstimationMethod(IntegralImageNormalEstimation.NormalEstimationMethod.Average3DGradient);
                        ne.SetMaxDepthChangeFactor(0.02f);
                        ne.SetNormalSmoothingSize(10f);

                        ne.SetInputCloud(noColor);
                        ne.Compute(normals);
                    }

                    super.SetInputCloud(cloud);
                    super.SetNormalCloud(normals);

                    super.SetColorImportance(colorImportance);
                    super.SetSpatialImportance(spatialImportance);
                    super.SetNormalImportance(normalImportance);

                    super.Extract(clusters);
                    Assert.IsTrue(clusters.Count > 0);
                }
            }
        }
    }
}