using System;
using Xunit;

namespace Pcl.NET.UnitTests
{
    public class PointCloudXYZTests : IDisposable
    {
        private readonly PointCloudXYZ _cloud;
        private const string TestFile = "simpleXYZ.pcd";

        public PointCloudXYZTests()
        {
            _cloud = PointCloudXYZ.Load(TestFile);
        }

        [Fact]
        public void Load_ValidFile_ShouldLoadSuccessfully()
        {
            Assert.NotNull(_cloud);
            Assert.True(_cloud.Count > 0);
        }

        [Fact]
        public void Properties_ShouldHaveValidValues()
        {
            Assert.True(_cloud.Width > 0);
            Assert.True(_cloud.Height > 0);
            Assert.NotNull(_cloud.Points);
            Assert.Equal(_cloud.Width * _cloud.Height, _cloud.Count);
        }

        [Fact]
        public void Points_ShouldBeAccessible()
        {
            var points = _cloud.Points;
            Assert.NotNull(points);
            Assert.Equal(_cloud.Count, points.Count);

            // Access first point to verify XYZ coordinates are readable
            var firstPoint = points[0];
            Assert.True(float.IsFinite(firstPoint.X));
            Assert.True(float.IsFinite(firstPoint.Y));
            Assert.True(float.IsFinite(firstPoint.Z));
        }

        [Fact]
        public void At_ValidIndices_ShouldReturnPoint()
        {
            var point = _cloud.At(0, 0);
            Assert.True(float.IsFinite(point.X));
            Assert.True(float.IsFinite(point.Y));
            Assert.True(float.IsFinite(point.Z));
        }

        [Fact]
        public void Concatenate_TwoPointClouds_ShouldCombineCounts()
        {
            var cloud1 = new PointCloudXYZ(2, 2);
            var cloud2 = new PointCloudXYZ(2, 2);

            cloud1.Add(new PointXYZ(1, 1, 1));
            cloud1.Add(new PointXYZ(2, 2, 2));
            cloud2.Add(new PointXYZ(3, 3, 3));
            cloud2.Add(new PointXYZ(4, 4, 4));

            var combined = PointCloudXYZ.Concatenate(cloud1, cloud2);
            Assert.Equal(cloud1.Count + cloud2.Count, combined.Count);
        }

        [Fact]
        public void Add_Point_ShouldIncreaseCount()
        {
            var cloud = new PointCloudXYZ();
            var initialCount = cloud.Count;
            cloud.Add(new PointXYZ(1, 2, 3));
            Assert.Equal(initialCount + 1, cloud.Count);
        }

        [Fact]
        public void Downsample_ValidFactor_ShouldReduceSize()
        {
            var factor = 2;
            var downsampled = _cloud.Downsample(factor);
            
            Assert.NotNull(downsampled);
            Assert.True(downsampled.Count <= _cloud.Count);
            Assert.Equal(_cloud.Width / factor, downsampled.Width);
            Assert.Equal(_cloud.Height / factor, downsampled.Height);
        }

        [Fact]
        public void Constructor_WithDimensions_ShouldCreateEmptyCloud()
        {
            var width = 10;
            var height = 5;
            var cloud = new PointCloudXYZ(width, height);

            Assert.Equal(width, cloud.Width);
            Assert.Equal(height, cloud.Height);
            Assert.Equal(width * height, cloud.Count);
        }

        [Fact]
        public void CopyConstructor_ShouldCreateIndependentCopy()
        {
            var copy = new PointCloudXYZ(_cloud);

            Assert.Equal(_cloud.Count, copy.Count);
            Assert.Equal(_cloud.Width, copy.Width);
            Assert.Equal(_cloud.Height, copy.Height);
            Assert.Equal(_cloud.IsDense, copy.IsDense);

            // Verify points are copied
            for (int i = 0; i < Math.Min(5, _cloud.Count); i++)
            {
                Assert.Equal(_cloud.Points[i].X, copy.Points[i].X);
                Assert.Equal(_cloud.Points[i].Y, copy.Points[i].Y);
                Assert.Equal(_cloud.Points[i].Z, copy.Points[i].Z);
            }
        }

        [Fact]
        public void OperatorPlus_ShouldConcatenateClouds()
        {
            var cloud1 = new PointCloudXYZ(2, 1);
            var cloud2 = new PointCloudXYZ(2, 1);

            cloud1.Add(new PointXYZ(1, 1, 1));
            cloud2.Add(new PointXYZ(2, 2, 2));

            var combined = cloud1 + cloud2;
            Assert.Equal(cloud1.Count + cloud2.Count, combined.Count);
        }

        public void Dispose()
        {
            _cloud?.Dispose();
        }
    }
}