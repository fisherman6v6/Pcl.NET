namespace Pcl.NET
{
    public abstract class PointCloud<PointT> : UnmanagedObject where PointT : unmanaged
    {
        /// <summary>
        /// Gets or sets the point at the specified column and row in the collection.
        /// </summary>
        /// <param name="col">The zero-based column index of the point to get or set. Must be greater than or equal to 0 and less than the
        /// value of Width.</param>
        /// <param name="row">The zero-based row index of the point to get or set. Must be greater than or equal to 0 and less than the
        /// value of Height.</param>
        /// <returns>The point located at the specified column and row.</returns>
        public virtual PointT this[int col, int row]
        {
            get
            {
                if ((ulong)col >= (ulong)Width)
                {
                    ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException(nameof(col));
                }

                if ((ulong)row >= (ulong)Height)
                {
                    ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException(nameof(row));
                }
                return Points[row * Width + col];
            }
            set
            {
                if ((ulong)col >= (ulong)Width)
                {
                    ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException(nameof(col));
                }

                if ((ulong)row >= (ulong)Height)
                {
                    ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException(nameof(row));
                }
                Points[row * Width + col] = value;
            }
        }
        /// <summary>
        /// Gets or sets the width, in pixels, of the element.
        /// </summary>
        public abstract int Width { get; set; }
        /// <summary>
        /// Gets or sets the height dimension.
        /// </summary>
        public abstract int Height { get; set; }
        public abstract bool IsDense { get; set; }
        /// <summary>
        /// Gets the collection of points defining the point cloud.
        /// </summary>
        public abstract Vector<PointT> Points { get; }
        /// <summary>
        /// Gets the total number of elements contained in the collection.
        /// </summary>
        public abstract long Count { get; }
        /// <summary>
        /// Gets a value indicating whether the collection is organized i.e., whether the height is greater than 1.
        /// </summary>
        public abstract bool IsOrganized { get; }
        /// <summary>
        /// Provides a reference to the element at the specified column and row in the collection.
        /// </summary>
        /// <param name="col">The zero-based column index of the element to access. Must be within the valid range of columns.</param>
        /// <param name="row">The zero-based row index of the element to access. Must be within the valid range of rows.</param>
        /// <returns>A reference to the element of type PointT at the specified column and row.</returns>
        public abstract ref PointT At(int col, int row);
        /// <summary>
        /// Adds the specified point to the collection.
        /// </summary>
        /// <param name="value">The point to add to the collection.</param>
        public abstract void Add(PointT value);
    }
}
