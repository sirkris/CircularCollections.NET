using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.Circular
{
    public interface ICircleContainer<T>
    {
        public int Pointer { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }

        public T Top { get; set; }
        public T Bottom { get; set; }

        T Peek();
        T Rotate();
        bool Contains(T target);
    }
}
