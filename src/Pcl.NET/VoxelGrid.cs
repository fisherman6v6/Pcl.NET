using Pcl.NET.Eigen;

namespace Pcl.NET
{
    /// <summary>
    /// VoxelGrid assembles a local 3D grid over a given PointCloud, and downsamples + filters the data.
    /// The VoxelGrid class creates a *3D voxel grid* (think about a voxel
    /// grid as a set of tiny 3D boxes in space) over the input point cloud data.
    /// Then, in each *voxel* (i.e., 3D box), all the points present will be
    /// approximated (i.e., *downsampled*) with their centroid. This approach is
    /// a bit slower than approximating them with the center of the voxel, but it
    /// represents the underlying surface more accurately.
    /// </summary>
    /// <typeparam name="PointT"></typeparam>
    public abstract class VoxelGrid<PointT> : Filter<PointT> where PointT : unmanaged
    {
        public abstract string FilterFieldName { get; set; }
        /// <summary>
        /// Voxel grid leaf size
        /// </summary>
        public abstract Vector3f LeafSize { get; set; }
        public abstract void SetLeafSize(float sizeX, float sizeY, float sizeZ);
        /// <summary>
        /// Set to true if all fields need to be downsampled, or false if just XYZ.
        /// </summary>
        public abstract bool DownSampleAllData { get; set; }
        /// <summary>
        /// Set the minimum number of points required for a voxel to be used.
        /// </summary>
        public abstract uint MinimumPointsNumberPerVoxel { get; set; }
        /// <summary>
        /// Set to true if leaf layout information needs to be saved for later access.
        /// </summary>
        public abstract bool SaveLeafLayout { get; set; }
        /// <summary>
        /// Get the maximum coordinates of the bounding box (after filtering is performed).
        /// </summary>
        public abstract Vector3i MaxBoxCoordinates { get; }
        /// <summary>
        /// Get the minimum coordinates of the bounding box (after filtering is performed).
        /// </summary>
        public abstract Vector3i MinBoxCoordinates { get; }
        /// <summary>
        /// Get the number of divisions along all 3 axes (after filtering is performed).
        /// </summary>
        public abstract Vector3i NrDivisions { get; }
        /// <summary>
        /// Get the multipliers to be applied to the grid coordinates in order to find the centroid index(after filtering is performed).
        /// </summary>
        public abstract Vector3i DivisionMultiplier { get; }
        /// <summary>
        /// Returns the index in the resulting downsampled cloud of the specified point.
        /// note for efficiency, user must make sure that the saving of the leaf layout is enabled and filtering
        /// performed, and that the point is inside the grid, to avoid invalid access(or use
        /// getGridCoordinates+getCentroidIndexAt)
        /// </summary>
        /// <param name="p">p the point to get the index at</param>
        /// <returns></returns>
        public abstract int GetCentroidIndex(PointXYZ p);
        /// <summary>
        /// Returns the corresponding (i,j,k) coordinates in the grid of point (x,y,z).
        /// </summary>
        /// <param name="x">x the X point coordinate to get the (i, j, k) index at</param>
        /// <param name="y">y the Y point coordinate to get the (i, j, k) index at</param>
        /// <param name="z">z the Z point coordinate to get the (i, j, k) index at</param>
        /// <returns></returns>
        public abstract Vector3i GetGridCoordinates(float x, float y, float z);
        /// <summary>
        /// Returns the index in the downsampled cloud corresponding to a given set of coordinates.
        /// </summary>
        /// <param name="v">ijk the coordinates (i,j,k) in the grid (-1 if empty)</param>
        /// <returns></returns>
        public abstract int GetCentroidIndexAt(Vector3i v);
        /// <summary>
        /// Set the field filter limits. All points having field values outside this interval will be discarded.
        /// </summary>
        /// <param name="limitMin">limit_min the minimum allowed field value</param>
        /// <param name="limitMax">limit_max the maximum allowed field value</param>
        public abstract void SetFilterLimits(float limitMin, float limitMax);
        /// <summary>
        /// Get whether the data outside the interval (min/max) is to be returned (true) or inside (false).
        /// </summary>
        public abstract bool FilterLimitsNegative { get; set; }
    }
}
