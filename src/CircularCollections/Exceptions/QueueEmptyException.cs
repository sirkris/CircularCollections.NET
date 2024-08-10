using System;
using System.Runtime.Serialization;

namespace Collections.Generic.Circular.Exceptions
{
    /// <summary>
    /// Exception that is thrown when attempting to access from an empty heap.
    /// </summary>
    [Serializable]
    public class QueueEmptyException : Exception
    {
        public QueueEmptyException(string message, Exception inner)
            : base(message, inner) { }

        public QueueEmptyException(string message)
            : base(message) { }

        public QueueEmptyException()
            : base() { }

        protected QueueEmptyException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context) { }
    }
}
