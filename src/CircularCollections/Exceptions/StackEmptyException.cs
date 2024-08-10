using System;
using System.Runtime.Serialization;

namespace Collections.Generic.Circular.Exceptions
{
    /// <summary>
    /// Exception that is thrown when attempting to access from an empty heap.
    /// </summary>
    [Serializable]
    public class StackEmptyException : Exception
    {
        public StackEmptyException(string message, Exception inner)
            : base(message, inner) { }

        public StackEmptyException(string message)
            : base(message) { }

        public StackEmptyException()
            : base() { }

        protected StackEmptyException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context) { }
    }
}
