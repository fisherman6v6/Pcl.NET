using System.Runtime.CompilerServices;

namespace Pcl.NET
{
    internal class VectorXYZ : Vector<PointXYZ>
    {
        public unsafe override PointXYZ this[long index]
        {
            get
            {
                return DataU[index];
            }
            set
            {
                Unsafe.Write(DataU + index, value);
            }
        }

        public override long Count => (long)Invoke.std_vector_xyz_size(_ptr);

        public IntPtr Data => Invoke.std_vector_xyz_data(_ptr);

        public unsafe PointXYZ* DataU => (PointXYZ*)(void*)Data;

        public VectorXYZ()
        {
            _ptr = Invoke.std_vector_xyz_ctor();
        }

        public VectorXYZ(long count)
        {
            _ptr = Invoke.std_vector_xyz_ctor_count((ulong)count);
        }

        /// <summary>
        /// construct as a copy of the list
        /// </summary>
        /// <param name="list"></param>
        public unsafe VectorXYZ(PointXYZ[] arr)
        {
            _ptr = Invoke.std_vector_xyz_ctor_count((ulong)arr.Length);
            PointXYZ* dptr = (PointXYZ*)(void*)Data;
            for (int i = 0; i < arr.Length; i++)
            {
                System.Runtime.CompilerServices.Unsafe.Write(dptr + i, arr[i]);
            }
        }

        internal VectorXYZ(IntPtr ptr)
        {
            _suppressDispose = true;
            _ptr = ptr;
        }

        public override void Add(PointXYZ item)
        {
            Invoke.std_vector_xyz_add(_ptr, item);
        }

        public override void At(long idx, ref PointXYZ value)
        {
            Invoke.std_vector_xyz_at(_ptr, (ulong)idx, ref value);
        }

        public unsafe override PointXYZ[] ToArray()
        {
            if (Count > Array.MaxLength)
            {
                throw new IndexOutOfRangeException($"{nameof(Array.MaxLength)} is {Array.MaxLength}");
            }
            PointXYZ[] arr = new PointXYZ[Count];
            fixed (PointXYZ* aptr = arr)
            {
                Unsafe.CopyBlockUnaligned((void*)aptr, (void*)DataU, (uint)(Unsafe.SizeOf<PointXYZ>() * arr.Length));
            }
            return arr;
        }

        public unsafe override void CopyTo(PointXYZ[] arr, int idx)
        {
            if (Count > Array.MaxLength)
            {
                throw new IndexOutOfRangeException($"{nameof(Array.MaxLength)} is {Array.MaxLength}");
            }
            fixed (PointXYZ* aptr = arr)
            {
                System.Runtime.CompilerServices.Unsafe.CopyBlockUnaligned((void*)aptr, (void*)DataU, (uint)(System.Runtime.CompilerServices.Unsafe.SizeOf<PointXYZ>() * (uint)Count));
            }
        }

        public override void Clear()
        {
            Invoke.std_vector_xyz_clear(_ptr);
        }

        public override void Insert(long index, PointXYZ item)
        {
            Invoke.std_vector_xyz_insert(_ptr, (ulong)index, item);
        }

        public override void Resize(long size)
        {
            Invoke.std_vector_xyz_resize(_ptr, (ulong)size);
        }

        public override IEnumerator<PointXYZ> GetEnumerator()
        {
            long count = Count;
            for (var i = 0; i < count; i++)
            {
                yield return this[i];
            }
        }

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.std_vector_xyz_delete(ref _ptr);
            }
        }
    }
}
