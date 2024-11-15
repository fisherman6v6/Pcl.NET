namespace Pcl.NET
{
    public abstract class UnmanagedObject : DisposableObject
    {
        protected IntPtr _ptr;

        public IntPtr Ptr => _ptr;

        public static implicit operator IntPtr(UnmanagedObject obj)
        {
            return obj?._ptr ?? IntPtr.Zero;
        }
    }
}
