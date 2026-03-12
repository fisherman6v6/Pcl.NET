using System.Buffers;
using System.Text;

namespace Pcl.NET
{
    /// <summary>
    /// Allows to access a PCD file as a stream of points
    /// </summary>
    public class PointCloudStreamReader : IDisposable
    {
        private readonly PCDReader _reader;
        private readonly PCDHeader _header;

        private static void ValidateArrayInput<T>(T[] buffer, int index, int count)
        {
            ArgumentNullException.ThrowIfNull(buffer);
            ThrowHelper.ThrowArgumentOutOfRangeIfCondition_IndexMustBeNonNegativeException(index < 0, nameof(index));
            ThrowHelper.ThrowArgumentOutOfRangeIfCondition_IndexMustBeNonNegativeException(count < 0, nameof(count));
            if (buffer.Length - index < count)
            {
                throw new ArgumentException("Invalid index and length.");
            }
        }

        private void ThrowIfDisposed()
        {
#if NET8_0
            ObjectDisposedException.ThrowIf(_disposedValue, this);
#else
            if (_disposedValue)
            {
                throw new ObjectDisposedException(this.ToString());
            }
#endif
        }

        public PointCloudStreamReader(string path, bool leaveOpen = false)
        {
            _header = new PCDHeader();
            IO.ReadPCDHeader(path, out _header);
            if (_header.data_type == DataType.Ascii)
            {
                _reader = new PCDAsciiReader(path, (int)_header.data_idx, leaveOpen);
            }
            else if (_header.data_type == DataType.Binary)
            {
                _reader = new PCDBinaryReader(path, (int)_header.data_idx, leaveOpen);
            }
            else
            {
                throw new NotSupportedException($"Unsupported data type: {_header.data_type}");
            }
        }

        /// <summary>
        /// PCD Header
        /// </summary>
        public PCDHeader Header => _header;
        /// <summary>
        /// Read a single PointXYZ
        /// </summary>
        /// <returns></returns>
        public PointXYZ ReadPointXYZ()
        {
            ThrowIfDisposed();
            return _reader.ReadPointXYZ();
        }
        /// <summary>
        /// Read a single PointXYZI
        /// </summary>
        /// <returns></returns>
        public PointXYZI ReadPointXYZI()
        {
            ThrowIfDisposed();
            return _reader.ReadPointXYZI();
        }
        /// <summary>
        /// Read a single PointXYZRGBA
        /// </summary>
        /// <returns></returns>
        public PointXYZRGBA ReadPointXYZRGBA()
        {
            ThrowIfDisposed();
            return _reader.ReadPointXYZRGBA();
        }
        /// <summary>
        /// Read a block of PointXYZ
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int ReadPointsXYZ(PointXYZ[] buffer, int index, int count)
        {
            ValidateArrayInput(buffer, index, count);
            ThrowIfDisposed();
            return _reader.ReadPointsXYZ(buffer, index, count);
        }
        /// <summary>
        /// Read a block of PointXYZI
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int ReadPointsXYZI(PointXYZI[] buffer, int index, int count)
        {
            ValidateArrayInput(buffer, index, count);
            ThrowIfDisposed();
            return _reader.ReadPointsXYZI(buffer, index, count);
        }
        /// <summary>
        /// Read a block of PointXYZRGBA
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int ReadPointsXYZRGBA(PointXYZRGBA[] buffer, int index, int count)
        {
            ValidateArrayInput(buffer, index, count);
            ThrowIfDisposed();
            return _reader.ReadPointsXYZRGBA(buffer, index, count);
        }

        #region Dispose
        private bool _disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects
                    _reader.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    internal abstract class PCDReader : IDisposable
    {
        public abstract PointXYZ ReadPointXYZ();
        public abstract PointXYZI ReadPointXYZI();
        public abstract PointXYZRGBA ReadPointXYZRGBA();
        public abstract int ReadPointsXYZ(PointXYZ[] buffer, int index, int count);
        public abstract int ReadPointsXYZI(PointXYZI[] buffer, int index, int count);
        public abstract int ReadPointsXYZRGBA(PointXYZRGBA[] buffer, int index, int count);
        public abstract void Dispose();
    }

    internal class PCDBinaryReader : PCDReader
    {
        private readonly BinaryReader _stream;

        public PCDBinaryReader(string path, int headerOffset, bool leaveOpen = false)
        {
            _stream = new BinaryReader(File.OpenRead(path), Encoding.UTF8, leaveOpen);
            _stream.BaseStream.Seek(headerOffset, SeekOrigin.Begin);
        }

        public override PointXYZ ReadPointXYZ()
        {
            float x = _stream.ReadSingle();
            float y = _stream.ReadSingle();
            float z = _stream.ReadSingle();
            return new PointXYZ(x, y, z);
        }
        public override PointXYZI ReadPointXYZI()
        {
            float x = _stream.ReadSingle();
            float y = _stream.ReadSingle();
            float z = _stream.ReadSingle();
            int intensity = _stream.ReadInt32();
            return new PointXYZI(x, y, z, intensity);
        }
        public override PointXYZRGBA ReadPointXYZRGBA()
        {
            float x = _stream.ReadSingle();
            float y = _stream.ReadSingle();
            float z = _stream.ReadSingle();
            byte b = _stream.ReadByte();
            byte g = _stream.ReadByte();
            byte r = _stream.ReadByte();
            byte a = _stream.ReadByte();
            return new PointXYZRGBA(x, y, z, r, g, b, a);
        }
        public override int ReadPointsXYZ(PointXYZ[] buffer, int index, int count)
        {
            int pointSize = 3 * sizeof(float); // 3 floats per point
            int bytesCount = count * pointSize;
            byte[] ibuf = ArrayPool<byte>.Shared.Rent(bytesCount);

            try
            {
                int numRead = _stream.Read(ibuf, 0, bytesCount);
                for (int i = 0, j = index; i < bytesCount; i += pointSize, j++)
                {
                    float x = BitConverter.ToSingle(ibuf.AsSpan(i, sizeof(float)));
                    float y = BitConverter.ToSingle(ibuf.AsSpan(i + sizeof(float), sizeof(float)));
                    float z = BitConverter.ToSingle(ibuf.AsSpan(i + 2 * sizeof(float), sizeof(float)));
                    buffer[j] = new PointXYZ(x, y, z);
                }

                return numRead / (3 * sizeof(float));
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(ibuf);
            }
        }
        public override int ReadPointsXYZI(PointXYZI[] buffer, int index, int count)
        {
            int pointSize = 3 * sizeof(float) + sizeof(int); // 3 floats + 1 int per point
            int bytesCount = count * pointSize;
            byte[] ibuf = ArrayPool<byte>.Shared.Rent(bytesCount);
            try
            {
                int numRead = _stream.Read(ibuf, 0, bytesCount);
                for (int i = 0, j = index; i < bytesCount; i += pointSize, j++)
                {
                    float x = BitConverter.ToSingle(ibuf.AsSpan(i, sizeof(float)));
                    float y = BitConverter.ToSingle(ibuf.AsSpan(i + sizeof(float), sizeof(float)));
                    float z = BitConverter.ToSingle(ibuf.AsSpan(i + 2 * sizeof(float), sizeof(float)));
                    int intensity = BitConverter.ToInt32(ibuf.AsSpan(i + 3 * sizeof(float), sizeof(int)));
                    buffer[j] = new PointXYZI(x, y, z, intensity);
                }
                return numRead / (3 * sizeof(float) + sizeof(int));
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(ibuf);
            }
        }
        public override int ReadPointsXYZRGBA(PointXYZRGBA[] buffer, int index, int count)
        {
            if (buffer.Length - index < count)
            {
                throw new ArgumentException("Invalid offset and length.");
            }
            int pointSize = 3 * sizeof(float) + 4 * sizeof(byte); // 3 floats + 4 bytes per point
            int bytesCount = count * pointSize;
            byte[] ibuf = ArrayPool<byte>.Shared.Rent(bytesCount);
            try
            {
                int numRead = _stream.Read(ibuf, 0, bytesCount);
                for (int i = 0, j = index; i < bytesCount; i += pointSize, j++)
                {
                    float x = BitConverter.ToSingle(ibuf.AsSpan(i, sizeof(float)));
                    float y = BitConverter.ToSingle(ibuf.AsSpan(i + sizeof(float), sizeof(float)));
                    float z = BitConverter.ToSingle(ibuf.AsSpan(i + 2 * sizeof(float), sizeof(float)));
                    byte b = ibuf[i + 3 * sizeof(float)];
                    byte g = ibuf[i + 3 * sizeof(float) + 1];
                    byte r = ibuf[i + 3 * sizeof(float) + 2];
                    byte a = ibuf[i + 3 * sizeof(float) + 3];
                    buffer[j] = new PointXYZRGBA(x, y, z, r, g, b, a);
                }
                return numRead / (3 * sizeof(float) + 4 * sizeof(byte));
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(ibuf);
            }
        }
        public override void Dispose()
        {
            _stream?.Dispose();
        }
    }

    internal class PCDAsciiReader : PCDReader
    {
        private readonly StreamReader _stream;

        public PCDAsciiReader(string path, int headerOffset, bool leaveOpen = false)
        {
            _stream = new StreamReader(File.OpenRead(path), Encoding.UTF8, leaveOpen);
            _stream.BaseStream.Seek(headerOffset, SeekOrigin.Begin);
        }

        private int ReadLines(int count, string[] lines)
        {
            int linesRead = 0;
            for (int i = 0; i < count && !_stream.EndOfStream; i++)
            {
                string line = _stream.ReadLine()!;
                lines[i] = line;
                linesRead++;
            }

            return linesRead;
        }
        private static PointXYZ ParsePointXYZ(string line)
        {
            string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 3)
            {
                throw new FormatException($"Invalid point data format: '{line}'");
            }
            if (!float.TryParse(parts[0], out float x) ||
                !float.TryParse(parts[1], out float y) ||
                !float.TryParse(parts[2], out float z))
            {
                throw new FormatException($"Invalid point data format: '{line}'");
            }
            return new PointXYZ(x, y, z);
        }
        private static PointXYZI ParsePointXYZI(string line)
        {
            string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 4)
            {
                throw new FormatException($"Invalid point data format: '{line}'");
            }
            if (!float.TryParse(parts[0], out float x) ||
                !float.TryParse(parts[1], out float y) ||
                !float.TryParse(parts[2], out float z) ||
                !int.TryParse(parts[3], out int intensity))
            {
                throw new FormatException($"Invalid point data format: '{line}'");
            }
            return new PointXYZI(x, y, z, intensity);
        }
        private static PointXYZRGBA ParsePointXYZRGBA(string line)
        {
            string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 8)
            {
                throw new FormatException($"Invalid point data format: '{line}'");
            }
            if (!float.TryParse(parts[0], out float x) ||
                !float.TryParse(parts[1], out float y) ||
                !float.TryParse(parts[2], out float z) ||
                !byte.TryParse(parts[3], out byte r) ||
                !byte.TryParse(parts[4], out byte g) ||
                !byte.TryParse(parts[5], out byte b) ||
                !byte.TryParse(parts[6], out byte a))
            {
                throw new FormatException($"Invalid point data format: '{line}'");
            }
            return new PointXYZRGBA(x, y, z, r, g, b, a);
        }

        public override PointXYZ ReadPointXYZ()
        {
            string? line = _stream.ReadLine() ?? throw new EndOfStreamException("Unexpected end of stream while reading point data.");
            return ParsePointXYZ(line);
        }
        public override PointXYZI ReadPointXYZI()
        {
            string line = _stream.ReadLine() ?? throw new EndOfStreamException("Unexpected end of stream while reading point data.");

            return ParsePointXYZI(line);
        }
        public override PointXYZRGBA ReadPointXYZRGBA()
        {
            string line = _stream.ReadLine() ?? throw new EndOfStreamException("Unexpected end of stream while reading point data.");

            return ParsePointXYZRGBA(line);
        }
        public override int ReadPointsXYZ(PointXYZ[] buffer, int index, int count)
        {
            string[] lines = ArrayPool<string>.Shared.Rent(count);
            try
            {
                int linesRead = ReadLines(count, lines);

                for (int i = 0, j = index; i < linesRead; i++, j++)
                {
                    buffer[j] = ParsePointXYZ(lines[i]);
                }

                // a line is a point, so the number of lines read is the number of points read
                return linesRead;
            }
            finally
            {
                ArrayPool<string>.Shared.Return(lines);
            }
        }
        public override int ReadPointsXYZI(PointXYZI[] buffer, int index, int count)
        {
            string[] lines = ArrayPool<string>.Shared.Rent(count);
            try
            {
                int linesRead = ReadLines(count, lines);

                for (int i = 0, j = index; i < linesRead; i++, j++)
                {
                    buffer[j] = ParsePointXYZI(lines[i]);
                }

                // a line is a point, so the number of lines read is the number of points read
                return linesRead;
            }
            finally
            {
                ArrayPool<string>.Shared.Return(lines);
            }
        }
        public override int ReadPointsXYZRGBA(PointXYZRGBA[] buffer, int index, int count)
        {
            string[] lines = ArrayPool<string>.Shared.Rent(count);
            try
            {
                int linesRead = ReadLines(count, lines);
                for (int i = 0, j = index; i < linesRead; i++, j++)
                {
                    buffer[j] = ParsePointXYZRGBA(lines[i]);
                }
                // a line is a point, so the number of lines read is the number of points read
                return linesRead;
            }
            finally
            {
                ArrayPool<string>.Shared.Return(lines);
            }
        }
        public override void Dispose()
        {
            _stream?.Dispose();
        }
    }

    public static class PointCloudStreamReaderExtensions
    {
        /// <summary>
        /// Read a block of PointXYZ in a Span
        /// </summary>
        /// <param name="this"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static int ReadPointsXYZ(this PointCloudStreamReader @this, Span<PointXYZ> buffer)
        {
            PointXYZ[] sharedBuffer = ArrayPool<PointXYZ>.Shared.Rent(buffer.Length);
            try
            {
                int pointsRead = @this.ReadPointsXYZ(sharedBuffer, 0, buffer.Length);
                sharedBuffer.AsSpan(0, pointsRead).CopyTo(buffer);
                return pointsRead;
            }
            finally
            {
                ArrayPool<PointXYZ>.Shared.Return(sharedBuffer);
            }
        }
        /// <summary>
        /// Read a block of PointXYZI in a Span
        /// </summary>
        /// <param name="this"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static int ReadPointsXYZI(this PointCloudStreamReader @this, Span<PointXYZI> buffer)
        {
            PointXYZI[] sharedBuffer = ArrayPool<PointXYZI>.Shared.Rent(buffer.Length);
            try
            {
                int pointsRead = @this.ReadPointsXYZI(sharedBuffer, 0, buffer.Length);
                sharedBuffer.AsSpan(0, pointsRead).CopyTo(buffer);
                return pointsRead;
            }
            finally
            {
                ArrayPool<PointXYZI>.Shared.Return(sharedBuffer);
            }
        }
        /// <summary>
        /// Read a block of PointXYZRGBA in a Span
        /// </summary>
        /// <param name="this"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static int ReadPointsXYZRGBA(this PointCloudStreamReader @this, Span<PointXYZRGBA> buffer)
        {
            PointXYZRGBA[] sharedBuffer = ArrayPool<PointXYZRGBA>.Shared.Rent(buffer.Length);
            try
            {
                int pointsRead = @this.ReadPointsXYZRGBA(sharedBuffer, 0, buffer.Length);
                sharedBuffer.AsSpan(0, pointsRead).CopyTo(buffer);
                return pointsRead;
            }
            finally
            {
                ArrayPool<PointXYZRGBA>.Shared.Return(sharedBuffer);
            }
        }
    }
}
