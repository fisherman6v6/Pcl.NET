namespace Pcl.NET
{
    public static class Transforms
    {
        public static PointCloudXYZ TransformPointCloudXYZ(Eigen.Affine3f transform, PointCloudXYZ input)
        {
            PointCloudXYZ output = new PointCloudXYZ();
            Invoke.transform_pointcloud_xyz(transform, input, output);
            return output;
        }
    }
}
