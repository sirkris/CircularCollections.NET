using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.Circular
{
    public interface ICircleStack<T> : ICircleContainer<T>
    {
        public T[] _data { get; set; }
        internal bool _indexerIsReadOnly { get; set; }

        void Push(T node);
        T Pop();
    }
}
