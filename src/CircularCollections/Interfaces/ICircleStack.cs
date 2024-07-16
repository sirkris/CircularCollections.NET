using System;
using System.Collections.Generic;
using System.Text;

namespace CircularCollections
{
    public interface ICircleStack<T> : ICircleContainer<T>
    {
        void Push(T node);
        internal T[] _data { get; set; }
    }
}
