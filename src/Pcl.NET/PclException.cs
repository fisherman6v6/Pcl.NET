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
}
