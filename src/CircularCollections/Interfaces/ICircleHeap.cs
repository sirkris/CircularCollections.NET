using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.Circular
{
    public interface ICircleHeap<T> : ICircleContainer<T>
    {
        IHeapEntry<T>[] _data { get; set; }

        ICircleHeap<T> Merge(ICircleHeap<T> heapToMerge);
        void Push(T node, int index);
        T Pop();
        void Reset();
        bool Contains(T target, int index);
        bool Contains(IHeapEntry<T> target);
    }
}
