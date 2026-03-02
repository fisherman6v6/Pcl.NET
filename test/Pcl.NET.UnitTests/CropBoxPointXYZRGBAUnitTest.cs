using Pcl.NET.Eigen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET.UnitTests
{
    public class CropBoxPointXYZRGBAUnitTest
    {
        [Fact]
        public void CropBoxPointXYZRGBA_Filter_FiltersCorrectly()
        {
            var cloud = new PointCloudXYZRGBA(2, 2);
            cloud.Add(new PointXYZRGBA(0, 0, 0));
            cloud.Add(new PointXYZRGBA(1, 1, 1));
            cloud.Add(new PointXYZRGBA(2, 2, 2));
            cloud.Add(new PointXYZRGBA(3, 3, 3));
            var cropBox = new CropBoxPointXYZRGBA
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
        public void CropBoxPointXYZRGBA_Properties_WorkCorrectly()
        {
            var cropBox = new CropBoxPointXYZRGBA();
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
        public void CropBoxPointXYZRGBA_Indices_SetAndGet()
        {
            var cropBox = new CropBoxPointXYZRGBA();
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
