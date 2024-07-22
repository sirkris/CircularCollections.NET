using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.Circular
{
    public interface IHeapEntry<T>
    {
        public int Index { get; set; }
        public T Value { get; set; }
    }
}
