using System;
using Xunit;

namespace Pcl.NET.UnitTests
{
    public class PointCloudXYZRGBATests : IDisposable
    {
        private readonly PointCloudXYZRGBA _cloud;
        private const string TestFile = "simpleXYZRGBA.pcd";

        public PointCloudXYZRGBATests()
        {
            _cloud = PointCloudXYZRGBA.Load(TestFile);
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

            // Access first point to verify XYZ and color components are readable
            var firstPoint = points[0];
            Assert.True(float.IsFinite(firstPoint.X));
            Assert.True(float.IsFinite(firstPoint.Y));
            Assert.True(float.IsFinite(firstPoint.Z));
            Assert.InRange(firstPoint.R, 0, 255);
            Assert.InRange(firstPoint.G, 0, 255);
            Assert.InRange(firstPoint.B, 0, 255);
            Assert.InRange(firstPoint.A, 0, 255);
        }

        [Fact]
        public void At_ValidIndices_ShouldReturnPoint()
        {
            var point = _cloud.At(0, 0);
            Assert.True(float.IsFinite(point.X));
            Assert.True(float.IsFinite(point.Y));
            Assert.True(float.IsFinite(point.Z));
            Assert.InRange(point.R, 0, 255);
            Assert.InRange(point.G, 0, 255);
            Assert.InRange(point.B, 0, 255);
            Assert.InRange(point.A, 0, 255);
        }

        [Fact]
        public void Concatenate_TwoPointClouds_ShouldCombineCounts()
        {
            var cloud1 = new PointCloudXYZRGBA(2, 2);
            var cloud2 = new PointCloudXYZRGBA(2, 2);

            cloud1.Add(new PointXYZRGBA { X = 1, Y = 1, Z = 1, R = 255, G = 0, B = 0, A = 255 });
            cloud1.Add(new PointXYZRGBA { X = 2, Y = 2, Z = 2, R = 0, G = 255, B = 0, A = 255 });
            cloud2.Add(new PointXYZRGBA { X = 3, Y = 3, Z = 3, R = 0, G = 0, B = 255, A = 255 });
            cloud2.Add(new PointXYZRGBA { X = 4, Y = 4, Z = 4, R = 255, G = 255, B = 255, A = 255 });

            var combined = PointCloudXYZRGBA.Concatenate(cloud1, cloud2);
            Assert.Equal(cloud1.Count + cloud2.Count, combined.Count);
        }

        [Fact]
        public void Add_Point_ShouldIncreaseCount()
        {
            var cloud = new PointCloudXYZRGBA();
            var initialCount = cloud.Count;
            cloud.Add(new PointXYZRGBA { X = 1, Y = 2, Z = 3, R = 255, G = 128, B = 64, A = 255 });
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
            var cloud = new PointCloudXYZRGBA(width, height);

            Assert.Equal(width, cloud.Width);
            Assert.Equal(height, cloud.Height);
            Assert.Equal(width * height, cloud.Count);
        }

        [Fact]
        public void CopyConstructor_ShouldCreateIndependentCopy()
        {
            var copy = new PointCloudXYZRGBA(_cloud);

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
                Assert.Equal(_cloud.Points[i].R, copy.Points[i].R);
                Assert.Equal(_cloud.Points[i].G, copy.Points[i].G);
                Assert.Equal(_cloud.Points[i].B, copy.Points[i].B);
                Assert.Equal(_cloud.Points[i].A, copy.Points[i].A);
            }
        }

        [Fact]
        public void OperatorPlus_ShouldConcatenateClouds()
        {
            var cloud1 = new PointCloudXYZRGBA(2, 1);
            var cloud2 = new PointCloudXYZRGBA(2, 1);

            cloud1.Add(new PointXYZRGBA { X = 1, Y = 1, Z = 1, R = 255, G = 0, B = 0, A = 255 });
            cloud2.Add(new PointXYZRGBA { X = 2, Y = 2, Z = 2, R = 0, G = 255, B = 0, A = 255 });

            var combined = cloud1 + cloud2;
            Assert.Equal(cloud1.Count + cloud2.Count, combined.Count);
        }

        public void Dispose()
        {
            _cloud?.Dispose();
        }
    }
}