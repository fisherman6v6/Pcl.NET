namespace Pcl.NET
{
    /// <summary>
    /// KdTree represents the base spatial locator class for kd-tree implementations.
    /// </summary>
    public class KdTreePointXYZ : UnmanagedObject
    {
        private PointCloud<PointXYZ>? _input;

        /// <summary>
        /// Empty constructor for KdTree. Sets some internal values to their defaults.
        /// </summary>
        public KdTreePointXYZ() : this(true)
        {
        }
        /// <summary>
        /// sorted set to true if the application that the tree will be used for requires sorted nearest neighbor indices (default). False otherwise.
        /// </summary>
        /// <param name="sorted"></param>
        public KdTreePointXYZ(bool sorted)
        {
            _ptr = Invoke.kdtree_pointxyz_ctor(sorted ? 1 : 0);
        }
        /// <summary>
        /// Provide a pointer to the input dataset.
        /// </summary>
        public PointCloud<PointXYZ>? Input
        {
            get => _input;
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));

                Invoke.kdtree_pointxyz_set_input_cloud(this, value);
                _input = value;
            }
        }
        /// <summary>
        /// Search epsilon precision (error bound) for nearest neighbors searches.
        /// </summary>
        public float Epsilon
        {
            get
            {
                return Invoke.kdtree_pointxyz_get_epsilon(this);
            }

            set
            {
                Invoke.kdtree_pointxyz_set_epsilon(this, value);
            }
        }
        /// <summary>
        /// Search for k-nearest neighbors for the given query point.
        /// </summary>
        /// <param name="searchPoint">the given query point</param>
        /// <param name="k">the number of neighbors to search for</param>
        /// <param name="indices">the resultant indices of the neighboring points</param>
        /// <param name="distances">the resultant squared distances to the neighboring points</param>
        /// <returns></returns>
        public int NearestKSearch(PointXYZ searchPoint, int k, VectorInt indices, VectorFloat distances)
        {
            ArgumentNullException.ThrowIfNull(indices, nameof(indices));
            ArgumentNullException.ThrowIfNull(distances, nameof(distances));

            return Invoke.kdtree_pointxyz_nearest_k_search(this, ref searchPoint, k, indices, distances);
        }
        /// <summary>
        /// Search for all the nearest neighbors of the query point in a given radius.
        /// </summary>
        /// <param name="searchPoint">the given query point</param>
        /// <param name="radius">the radius of the sphere bounding all of p_q's neighbors</param>
        /// <param name="max_nn">the resultant indices of the neighboring points</param>
        /// <param name="indices">the resultant squared distances to the neighboring points</param>
        /// <param name="distances">f given, bounds the maximum returned neighbors to this value. If \a max_nn is set to 0 or to a number higher than the number of points in the input cloud, all neighbors in \a radius will bereturned.</param>
        /// <returns></returns>
        public int RadiusSearch(PointXYZ searchPoint, float radius, int max_nn, VectorInt indices, VectorFloat distances)
        {
            ArgumentNullException.ThrowIfNull(indices, nameof(indices));
            ArgumentNullException.ThrowIfNull(distances, nameof(distances));

            return Invoke.kdtree_pointxyz_radius_search(this, ref searchPoint, radius, max_nn, indices, distances);
        }

        #region Dispose
        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.kdtree_pointxyz_delete(ref _ptr);
            }
        } 
        #endregion
    }
}
