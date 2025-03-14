using System;

namespace Pcl.NET
{
    public abstract class PointCloud<PointT> : UnmanagedObject where PointT : unmanaged
    {
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

        public abstract Vector<PointT> Points { get; }

        public abstract long Count { get; }

        public abstract bool IsOrganized { get; }

        public abstract ref PointT At(int col, int row);

        public abstract void Add(PointT value);
    }
}
