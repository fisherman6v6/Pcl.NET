namespace Pcl.NET
{
    public class PclException : Exception
    {
        public PclException()
        {
        }

        public PclException(string? message) : base(message)
        {
        }

        public PclException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }

    public class UnorganizedPointCloudException : PclException
    {
        public UnorganizedPointCloudException()
        {
        }
        public UnorganizedPointCloudException(string? message) : base(message)
        {
        }
        public UnorganizedPointCloudException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
