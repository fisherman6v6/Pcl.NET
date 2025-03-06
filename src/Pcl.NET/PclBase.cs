using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public abstract class PclBase<PointT> : UnmanagedObject where PointT : unmanaged
    {
        public abstract PointCloud<PointT>? Input { get; set; }

        public abstract VectorInt Indices { get; set; }

        public abstract void SetIndices(long row_start, long col_start, long nb_rows, long nb_cols);
    }
}
