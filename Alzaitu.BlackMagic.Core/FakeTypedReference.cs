using System;
using System.Runtime.InteropServices;

namespace Alzaitu.BlackMagic.Core
{
    /// <summary>
    /// Mimics the structure of a TypedReference so we can alter private properties.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct FakeTypedReference
    {
        public readonly IntPtr Value;
        public readonly IntPtr Type;

        public FakeTypedReference(TypedReference reference)
        {
            var fake = *(FakeTypedReference*) &reference;
            Value = fake.Value;
            Type = fake.Type;
        }

        public FakeTypedReference(IntPtr value, Type type) : this(value, type.TypeHandle.Value)
        {
            
        }

        public FakeTypedReference(IntPtr value, IntPtr type)
        {
            Value = value;
            Type = type;
        }

        public T GetValue<T>()
        {
            fixed (FakeTypedReference* ptr = &this)
                return __refvalue(*(TypedReference*) ptr, T);
        }

        public void SetValue<T>(T value)
        {
            fixed (FakeTypedReference* ptr = &this)
                __refvalue(*(TypedReference*) ptr, T) = value;
        }
    }
}
