using System;
using System.Runtime.Serialization;

namespace Alzaitu.BlackMagic
{
    public abstract class ObjectPlacement
    {
        public abstract Type Type { get; }

        public abstract object UntypedValue { get; set; }

    }

    [Serializable]
    public class ObjectPlacement<T> : ObjectPlacement, ISerializable
    {
        private FakeTypedReference _typedReference;

        public IntPtr Address { get; }

        public override Type Type => typeof(T);

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
            //info.AddValue(nameof(RuntimeTypeHandle), _typedReference.Type.ToInt64());
        }

        public static implicit operator T(ObjectPlacement<T> obj) => obj.Value;

        public static implicit operator ObjectPlacement<T>(IntPtr ptr) => new ObjectPlacement<T>(ptr);
    }
}

