using System;
using System.Collections.Generic;
using System.Text;

namespace CircularCollections
{
    public interface ICircleQueue<T> : ICircleContainer<T>
    {
        void Enqueue(T node);
        internal T[] _data { get; set; }
    }
}
