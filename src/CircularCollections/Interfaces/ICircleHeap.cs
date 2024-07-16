using System;
using System.Collections.Generic;
using System.Text;

namespace CircularCollections
{
    public interface ICircleHeap<T> : ICircleContainer<T>
    {
        internal IHeapEntry<T>[] _data { get; set; }

        ICircleHeap<T> Merge(ICircleHeap<T> heapToMerge);
        void Push(T node, int index);
        void Reset();
    }
}
