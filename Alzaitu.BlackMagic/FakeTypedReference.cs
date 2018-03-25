using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Alzaitu.BlackMagic
{
    /// <summary>
    /// Mimics the structure of a TypedReference so we can alter private properties.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct FakeTypedReference
    {
        /// <summary>
        /// The address of the reference.
        /// </summary>
        public readonly IntPtr Value;
        /// <summary>
        /// The type handle representing the type of this reference.
        /// </summary>
        public readonly IntPtr Type;

        /// <summary>
        /// Construct a FakeTypedReference from an existing TypedReference.
        /// </summary>
        /// <param name="reference">The TypedReference to copy.</param>
        public FakeTypedReference(TypedReference reference)
        {
            var fake = *(FakeTypedReference*) &reference;
            Value = fake.Value;
            Type = fake.Type;
        }

        /// <summary>
        /// Construct a FakeTypedReference with the specified address and type.
        /// </summary>
        /// <param name="value">The address to point to.</param>
        /// <param name="type">The type of this reference.</param>
        /// <inheritdoc />
        public FakeTypedReference(IntPtr value, Type type) : this(value, type.TypeHandle.Value)
        {
        }

        /// <summary>
        /// Construct a FakeTypedReference with the specified address and type handle.
        /// </summary>
        /// <param name="value">The address to point to.</param>
        /// <param name="type">The type handle representing the type of this reference.</param>
        public FakeTypedReference(IntPtr value, IntPtr type)
        {
            Value = value;
            Type = type;
        }

        /// <summary>
        /// Treat this as a TypedReference and get its value.
        /// </summary>
        /// <typeparam name="T">The type of the value to get.</typeparam>
        /// <returns>The value as retrieved from the address specified.</returns>
        public T GetValue<T>()
        {
            fixed (FakeTypedReference* ptr = &this)
                return __refvalue(*(TypedReference*)ptr, T);
        }

        /// <summary>
        /// Treat this as a TypedReference and set its value.
        /// </summary>
        /// <typeparam name="T">The type of the value to set.</typeparam>
        /// <param name="value">The value to set.</param>
        public void SetValue<T>(T value)
        {
            fixed (FakeTypedReference* ptr = &this)
                __refvalue(*(TypedReference*) ptr, T) = value;
        }

        /// <summary>
        /// Create a FakeTypedReference with a given type and address.
        /// </summary>
        /// <typeparam name="T">The type of the FakeTypedReference to construct.</typeparam>
        /// <param name="value">The address of the reference to construct.</param>
        /// <returns>The specified FakeTypedReference object.</returns>
        public static FakeTypedReference Create<T>(IntPtr value) => new FakeTypedReference(value, typeof(T));
    }
}
