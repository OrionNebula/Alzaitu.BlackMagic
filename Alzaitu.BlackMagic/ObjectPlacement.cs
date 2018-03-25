using System;
using System.Runtime.Serialization;

namespace Alzaitu.BlackMagic
{
    /// <summary>
    /// Abstract parent class for <see cref="ObjectPlacement{T}"/>.
    /// </summary>
    public abstract class ObjectPlacement
    {
        /// <summary>
        /// The type of this ObjectPlacement.
        /// </summary>
        public abstract Type Type { get; }

        /// <summary>
        /// The untyped value of this ObjectPlacement.
        /// </summary>
        public abstract object UntypedValue { get; set; }

    }

    /// <summary>
    /// Holds a reference to an object of a specified type.
    /// </summary>
    /// <typeparam name="T">The type of the referenced object.</typeparam>
    /// <inheritdoc cref="ObjectPlacement"/>
    [Serializable]
    public class ObjectPlacement<T> : ObjectPlacement, ISerializable
    {
        private FakeTypedReference _typedReference;
        
        /// <summary>
        /// The address of the reference in memory.
        /// </summary>
        public IntPtr Address { get; }

        public override Type Type => typeof(T);

        /// <summary>
        /// The value referenced.
        /// </summary>
        public T Value
        {
            get => _typedReference.GetValue<T>();
            set => _typedReference.SetValue(value);
        }

        public override object UntypedValue
        {
            get => Value;
            set
            {
                if(!(value is T tValue))
                    throw new ArgumentException("Argument was the wrong type.");

                Value = tValue;
            }
        }

        /// <summary>
        /// Construct a reference to an existing field.
        /// </summary>
        /// <param name="field">The field to reference.</param>
        public ObjectPlacement(ref T field)
        {
            _typedReference = new FakeTypedReference(__makeref(field));
            Address = _typedReference.Value;
        }

        /// <summary>
        /// Construct a reference to a fixed address.
        /// </summary>
        /// <param name="address"></param>
        public ObjectPlacement(IntPtr address) : this(address, typeof(T).TypeHandle.Value)
        {
        }

        private ObjectPlacement(IntPtr address, IntPtr typeToken)
        {
            Address = address;
            _typedReference = new FakeTypedReference(address, typeToken);
        }

        protected ObjectPlacement(SerializationInfo info, StreamingContext context) : this(
            new IntPtr(info.GetInt64(nameof(Address))))//, new IntPtr(info.GetInt64(nameof(RuntimeTypeHandle))))
        {
            
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(ObjectPlacement<T>));
            info.AddValue(nameof(Address), Address.ToInt64());
        }

        public static implicit operator T(ObjectPlacement<T> obj) => obj.Value;
    }
}

