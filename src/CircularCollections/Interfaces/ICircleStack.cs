using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.Circular
{
    public interface ICircleStack<T> : ICircleContainer<T>
    {
        internal T[] _data { get; set; }

        void Push(T node);
        T Pop();
    }
}
