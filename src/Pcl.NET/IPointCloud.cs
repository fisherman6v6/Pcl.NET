namespace Pcl.NET
{
    public interface IPointCloud
    {
        /// <summary>
        /// Gets or sets the width, in pixels, of the element.
        /// </summary>
        int Width { get; set; }
        /// <summary>
        /// Gets or sets the height dimension.
        /// </summary>
        int Height { get; set; }
        /// <summary>
        /// Gets the total number of elements contained in the collection.
        /// </summary>
        long Count { get; }
        /// <summary>
        /// Pointcloud is dense when it does not contain NaN points
        /// </summary>
        bool IsDense { get; set; }
        /// <summary>
        /// Gets a value indicating whether the collection is organized i.e., whether the height is greater than 1.
        /// </summary>
        bool IsOrganized { get; }
    }
}
