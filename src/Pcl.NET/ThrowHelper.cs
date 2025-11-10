using System.Diagnostics.CodeAnalysis;

namespace Pcl.NET
{
    internal static class ThrowHelper
    {
        [DoesNotReturn]
        public static void ThrowArgumentOutOfRange_IndexMustBeLessException()
        {
            throw new ArgumentOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')");
        }
        [DoesNotReturn]
        public static void ThrowArgumentOutOfRange_IndexMustBeLessException(string name)
        {
            throw new ArgumentOutOfRangeException($"Index was out of range. Must be non-negative and less than the size of the collection. (Parameter '{name}')");
        }
        public static void ThrowArgumentOutOfRangeIfCondition_IndexMustBeLessException(bool condition, string name)
        {
            if (condition)
            {
                throw new ArgumentOutOfRangeException($"Index was out of range. Must be non-negative and less than the size of the collection. (Parameter '{name}')");
            }
        }
        [DoesNotReturn]
        public static void ThrowIOException_CannotWriteFile(string filename)
        {
            throw new IOException($"Cannot write file. Check filename: {filename}");
        }
        [DoesNotReturn]
        public static void ThrowIOException_CannotReadFile(string filename)
        {
            throw new IOException($"Cannot read file. Check filename (Parameter {filename})");
        }
        [DoesNotReturn]
        public static void ThrowPclException(string message)
        {
            throw new PclException(message);
        }
        [DoesNotReturn]
        public static void ThrowInvalidOperation_PointCloudNotSetException()
        {
            throw new InvalidOperationException("Input cloud is not set");
        }
        [DoesNotReturn]
        public static void ThrowUnorganizedPointCloudfCondition_CantUse2DIndexing(bool condition)
        {
            if (condition)
            {
                throw new InvalidOperationException("Can't use 2D indexing with an unorganized point cloud");
            }
        }
    }
}
