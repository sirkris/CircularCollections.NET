using System;
using System.Runtime.Serialization;

namespace Collections.Generic.Circular.Exceptions
{
    [Serializable]
    public class HeapEmptyException : Exception
    {
        public HeapEmptyException(string message, Exception inner)
            : base(message, inner) { }

        public HeapEmptyException(string message)
            : base(message) { }

        public HeapEmptyException()
            : base() { }

        protected HeapEmptyException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context) { }
    }
}
