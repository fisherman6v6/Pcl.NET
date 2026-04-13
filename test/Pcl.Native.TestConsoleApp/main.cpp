// Pcl.Native.TestConsoleApp.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <Eigen/Core>
#include <Eigen/Geometry>
#include <pcl/pcl_macros.h>
#include <pcl/io/pcd_io.h>
#include <pcl/point_cloud.h>
#include <pcl/common/transforms.h>
#include <string>
#include <pcl/search/kdtree.h>
#include <pcl/filters/convolution_3d.h>
#include <cmath>
#include <cstdio>

using namespace Eigen;
using namespace pcl;
using namespace std;

void ApplyGaussianFiler(PointCloud<pcl::PointXYZ>::Ptr& input_cloud, PointCloud<pcl::PointXYZ>::Ptr& output_cloud, float cutoff)
{
    float sigma = (cutoff * sqrt(log(2))) / (3.14f * sqrt(2));
    float threshold = sigma * 3;

    pcl::filters::GaussianKernel<PointXYZ, PointXYZ> gaussian;
    gaussian.setSigma(sigma);                   
    gaussian.setThresholdRelativeToSigma(3.0f);

    pcl::filters::Convolution3D<PointXYZ, PointXYZ, pcl::filters::GaussianKernel<PointXYZ, PointXYZ>> conv;

    conv.setInputCloud(input_cloud);
    conv.setKernel(gaussian);                                         // kernel functor
    conv.setSearchMethod(pcl::search::KdTree<PointXYZ>::Ptr(new pcl::search::KdTree<PointXYZ>)); // neighbor search
    conv.setRadiusSearch(threshold);                                       // absolute neighbor radius

    printf("Applying Gaussian Filter with Sigma: %f, Threshold: %f", sigma, threshold);

    conv.convolve(*output_cloud);
}

int main()
{
    string ifile = "T:\\Special Products\\ale\\huge_BiggoXX___N_N_ScanLaser_full_(08.55.19.266).pcd";
    PointCloud<pcl::PointXYZ>::Ptr cloud(new PointCloud<pcl::PointXYZ>);
    
    PCDReader reader;
    PCLPointCloud2::Ptr header(new PCLPointCloud2);
    reader.readHeader(ifile, *header);
    //io::loadPCDFile(ifile, *cloud);

    cout << "Loaded cloud with " << cloud->size() << " points." << endl;

    //io::savePCDFile(ofile, *out_cloud);
}
