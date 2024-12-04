namespace Pcl.NET
{
    internal static class ThrowHelper
    {
        public static void ThrowArgumentOutOfRange_IndexMustBeLessException()
        {
            throw new ArgumentOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')");
        }

        public static void ThrowIOException_CannotWriteFile(string filename)
        {
            throw new IOException($"Cannot write file. Check filename: {filename}");
        }

        public static void ThrowIOException_CannotReadFile(string filename)
        {
            throw new IOException($"Cannot read file. Check filename (Parameter {filename})");
        }
    }
}
