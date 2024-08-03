using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.Circular
{
    public class HeapEntry<T> : IHeapEntry<T>
    {
        int IHeapEntry<T>.Index { get; set; }
        T IHeapEntry<T>.Value { get; set; }

        public HeapEntry(int index, T value)
        {
            ((IHeapEntry<T>)this).Index = index;
            ((IHeapEntry<T>)this).Value = value;
        }
    }
}
