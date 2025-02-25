using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

        protected PclException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
