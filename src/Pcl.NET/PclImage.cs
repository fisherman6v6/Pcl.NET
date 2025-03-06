using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public class PclImage : UnmanagedObject
    {
        private readonly Vector<byte> _data;

        /// <summary>
        /// Width in pixel
        /// </summary>
        public uint Width
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.pclimage_get_width(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.pclimage_set_width(_ptr, value);
            }
        }
        /// <summary>
        /// Height in pixel
        /// </summary>
        public uint Height
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.pclimage_get_height(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.pclimage_set_height(_ptr, value);
            }
        }
        /// <summary>
        /// A string that specifies the encoding of the image data (e.g., "rgb8", "bgr8", "mono8").
        /// </summary>
        public string Encoding
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.pclimage_get_encoding(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.pclimage_set_encoding(_ptr, value);
            }
        }
        /// <summary>
        /// The number of bytes per row of the image. This is useful for accessing pixel data in a row-major order.
        /// </summary>
        public uint Step
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.pclimage_get_step(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.pclimage_set_step(_ptr, value);
            }
        }
        /// <summary>
        ///  The raw image data. The size of this vector is typically width * height * number_of_channels.
        /// </summary>
        public Vector<byte> Data => _data;

        public PclImage()
        {
            _ptr = Invoke.pclimage_ctor();
            _data = new VectorByte(Invoke.pclimage_data(_ptr));
        }

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.pclimage_delete(ref _ptr);
            }
        }
    }

    public static class PclImageEncodings
    {
        public static readonly string Rgb8 = "rgb8";
        public static readonly string Mono8 = "mono8";
        public static readonly string Mono16 = "mono16";
    }
}
