namespace Pcl.NET.TestConsoleApp
{
  internal class Program
  {
    static void Main(string[] args)
    {
      using PCDReader reader = new PCDReader();
      PointCloudXYZ pointCloud = new();
      reader.Read(@"C:\Users\alessandro.fici\Desktop\PointClouds\123_Default_FULL_19.02.09.pcd", pointCloud);
    }
  }
}
