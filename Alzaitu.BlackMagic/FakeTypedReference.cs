using System;
using System.Runtime.InteropServices;
// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable

namespace Alzaitu.BlackMagic
{
    /// <summary>
    /// Mimics the structure of a TypedReference so we can alter private properties.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct FakeTypedReference
    {
        private readonly IntPtr _value;
        private readonly IntPtr _type;

        public FakeTypedReference(IntPtr value, Type type) : this(value, type.TypeHandle.Value)
        {
            
        }

        public FakeTypedReference(IntPtr value, IntPtr type)
        {
            _value = value;
            _type = type;
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
