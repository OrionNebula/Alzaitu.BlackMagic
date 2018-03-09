using System;
using System.Runtime.Serialization;

namespace Alzaitu.BlackMagic.Core
{
    [Serializable]
    public unsafe class ObjectPlacement<T> : ISerializable
    {
        private FakeTypedReference _typedReference;

        public IntPtr Address { get; }

        public T Value
        {
            get => _typedReference.GetValue<T>();
            set => _typedReference.SetValue(value);
        }

        /// <summary>
        /// Construct a reference to an existing field.
        /// </summary>
        /// <param name="field">The field to reference.</param>
        public ObjectPlacement(ref T field)
        {
            var r = __makeref(field);
            Address = *(IntPtr*) &r;
            _typedReference = new FakeTypedReference(Address, typeof(T));
        }

        /// <summary>
        /// Construct a reference to a fixed address.
        /// </summary>
        /// <param name="address"></param>
        public ObjectPlacement(IntPtr address)
        {
            Address = address;
            _typedReference = new FakeTypedReference(address, typeof(T));
        }

        protected ObjectPlacement(SerializationInfo info, StreamingContext context) : this(
            new IntPtr(info.GetInt64(nameof(Address))))
        {
            
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(ObjectPlacement<T>));
            info.AddValue(nameof(Address), Address.ToInt64());
        }

        public static implicit operator T(ObjectPlacement<T> obj) => obj.Value;

        public static implicit operator ObjectPlacement<T>(IntPtr ptr) => new ObjectPlacement<T>(ptr);
    }
}
