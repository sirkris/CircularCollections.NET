using System;
using System.Collections.Generic;
using System.Text;

namespace CircularCollections
{
    public interface ICircleStack<T> : ICircleContainer<T>
    {
        internal T[] _data { get; set; }

        void Push(T node);
        T Pop();
    }
}
