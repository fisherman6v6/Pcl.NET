using System;
using Xunit;
using Pcl.NET;
using Pcl.NET.Eigen;

namespace Pcl.NET.UnitTests
{
    public class CropBoxPointXYZUnitTest
    {
        [Fact]
        public void CropBoxPointXYZ_Filter_FiltersCorrectly()
        {
            var cloud = new PointCloudXYZ(2, 2);
            cloud.Add(new PointXYZ(0, 0, 0));
            cloud.Add(new PointXYZ(1, 1, 1));
            cloud.Add(new PointXYZ(2, 2, 2));
            cloud.Add(new PointXYZ(3, 3, 3));
            var cropBox = new CropBoxPointXYZ
            {
                Min = new Vector4f(1, 1, 1, 1),
                Max = new Vector4f(3, 3, 3, 1),
                Input = cloud
            };
            var filtered = cropBox.ApplyFilter();
            Assert.NotNull(filtered);
            Assert.All(filtered.Points, p => Assert.InRange(p.X, 1, 3));
        }

        [Fact]
        public void CropBoxPointXYZ_Properties_WorkCorrectly()
        {
            var cropBox = new CropBoxPointXYZ();
            cropBox.Min = new Vector4f(1, 2, 3, 1);
            cropBox.Max = new Vector4f(4, 5, 6, 1);
            cropBox.Translation = new Vector3f(1, 1, 1);
            cropBox.Rotation = new Vector3f(0, 0, 0);
            cropBox.KeepOrganized = true;
            Assert.Equal(new Vector4f(1, 2, 3, 1), cropBox.Min);
            Assert.Equal(new Vector4f(4, 5, 6, 1), cropBox.Max);
            Assert.Equal(new Vector3f(1, 1, 1), cropBox.Translation);
            Assert.Equal(new Vector3f(0, 0, 0), cropBox.Rotation);
            Assert.True(cropBox.KeepOrganized);
        }

        [Fact]
        public void CropBoxPointXYZ_Indices_SetAndGet()
        {
            var cropBox = new CropBoxPointXYZ();
            var indices = new VectorInt();
            indices.Add(0);
            indices.Add(1);
            cropBox.Indices = indices;
            var result = cropBox.Indices;
            Assert.Equal(indices.Count, result.Count);
            Assert.Equal(indices[0], result[0]);
        }
    }
}
