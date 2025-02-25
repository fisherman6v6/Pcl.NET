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
    }
}
