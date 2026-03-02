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

        public static PointCloudXYZI TransformPointCloudXYZI(Eigen.Affine3f transform, PointCloudXYZI input)
        {
            PointCloudXYZI output = new PointCloudXYZI();
            Invoke.transform_pointcloud_xyzi(transform, input, output);
            return output;
        }
    }
}
