using System;
using System.Collections.Generic;
using System.Text;

namespace CircularCollections
{
    public interface ICircleQueue<T> : ICircleContainer<T>
    {
        internal T[] _data { get; set; }

        void Enqueue(T node);
        T Dequeue();
    }
}
