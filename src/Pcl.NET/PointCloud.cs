namespace Pcl.NET
{
    public abstract class PointCloud<PointT> : UnmanagedObject, IPointCloud where PointT : unmanaged
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
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }
        public abstract bool IsDense { get; set; }
        /// <summary>
        /// Gets the collection of points defining the point cloud.
        /// </summary>
        public abstract Vector<PointT> Points { get; }
        public abstract long Count { get; }
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
