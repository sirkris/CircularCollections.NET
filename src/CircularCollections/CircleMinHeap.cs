using Collections.Generic.Circular.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Collections.Generic.Circular
{
    public class CircleMinHeap<T> : ICircleHeap<T>
    {
        IHeapEntry<T>[] ICircleHeap<T>._data { get; set; }
        int ICircleContainer<T>.Pointer { get; set; }

        T ICircleContainer<T>.Top
        {
            get { return ((ICircleHeap<T>)this)._data[0].Value; }
            set { }
        }

        T ICircleContainer<T>.Bottom
        {
            get { return (!Count.Equals(0) ? ((ICircleHeap<T>)this)._data[Count - 1].Value : default); }
            set { }
        }

        public int Size
        {
            get
            {
                return ((ICircleHeap<T>)this)._data.Length;
            }
            set { }
        }

        public int Count
        {
            get { return _count; }
            set { }
        }
        private int _count;

        public CircleMinHeap(int size) { ((ICircleHeap<T>)this)._data = new IHeapEntry<T>[size]; }

        public CircleMinHeap(ICircleHeap<T> container)
        {
            ((ICircleHeap<T>)this)._data
= (IHeapEntry<T>[])container._data.Clone();
            _count = container.Count;
        }

        // It is not recommended that you use this constructor on inputs that are partially unfilled AND have valid null entries.
        // It will not be possible to obtain a valid count in that case since we don't know how to interpret the nulls.
        public CircleMinHeap(IHeapEntry<T>[] data, bool countNulls = false)
        {
            ((ICircleHeap<T>)this)._data = (IHeapEntry<T>[])data.Clone();
            if (countNulls) { _count = data.Length; } // Assumes any null values are valid entries; O(1) time
            else
            {
                // Assumes any null values represent empty space so break at the first null; O(n) time
                for (int i = 0; i < data.Length && data[i] != null; i++) { _count++; }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (IHeapEntry<T> entry in ((ICircleHeap<T>)this)._data) { yield return entry.Value; }
        }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        public T this[int key]
        {
            get
            {
                return ((ICircleHeap<T>)this)._data[key].Value;
            }
            set
            {
                throw new ReadOnlyException("Attempting to set data array directly could violate heap property.");
            }
        }

        public ICircleHeap<T> Merge(ICircleHeap<T> heapToMerge)
        {
            for (int i = 0; i < heapToMerge._data.Length && heapToMerge._data[i] != null; i++)
            {
                Push(heapToMerge._data[i].Value, heapToMerge._data[i].Index);
            }

            return this;
        }

        public void Reset() { ((ICircleHeap<T>)this).Pointer = 0; } // Reset our pointer back to the top of the heap

        public void Push(T node, int index)
        {
            // If we're rotated, reset the pointer
            Reset();

            // Note - If we're pushing onto a full circular minheap, the highest element will be discarded
            IHeapEntry<T> heapEntry = new HeapEntry<T>(index, node);
            IHeapEntry<T> swap = null;
            bool swapped = false;  // Use this since swap can go back to null when traversing empty space
            for (int i = 0; i < ((ICircleHeap<T>)this).Size; i++)
            {
                if (!swapped)
                {
                    if (((ICircleHeap<T>)this)._data[i] == null || heapEntry.Index < ((ICircleHeap<T>)this)._data[i].Index)
                    {
                        swap = ((ICircleHeap<T>)this)._data[i];
                        ((ICircleHeap<T>)this)._data[i] = heapEntry;
                        swapped = true;
                    }
                }
                else
                {
                    IHeapEntry<T> tmp = swap;
                    swap = ((ICircleHeap<T>)this)._data[i];
                    ((ICircleHeap<T>)this)._data[i] = tmp;
                }
            }

            if (!Count.Equals(Size)) { _count++; }
        }

        public T Peek()
        {
            return ((ICircleHeap<T>)this)._data[((ICircleHeap<T>)this).Pointer].Value;
        }

        public T Pop()
        {
            if (Count.Equals(0)) { throw new HeapEmptyException("Heap empty."); }
            else if (((ICircleHeap<T>)this).Pointer >= Count) { throw new InvalidOperationException("Pointer past end."); }

            T res = ((ICircleHeap<T>)this).Peek();
            ((ICircleHeap<T>)this)._data[((ICircleHeap<T>)this).Pointer] = default;
            _count--;

            // Sift up
            for (int i = ((ICircleHeap<T>)this).Pointer + 1; i < Size; i++)
            {
                ((ICircleHeap<T>)this)._data[i - 1] = ((ICircleHeap<T>)this)._data[i];
                ((ICircleHeap<T>)this)._data[i] = default;
            }

            // If pointer no longer points to an entry (i.e. we popped at the bottom), decrement up to the previous entry
            if (((ICircleHeap<T>)this).Pointer.Equals(Count) && !Count.Equals(0)) { ((ICircleHeap<T>)this).Pointer--; }

            return res;
        }

        public T Rotate()
        {
            ((ICircleHeap<T>)this).Pointer = (++((ICircleHeap<T>)this).Pointer) % ((ICircleHeap<T>)this)._data.Length;

            return ((ICircleHeap<T>)this).Peek();
        }

        public bool Contains(T target)
        {
            if (target == null) { throw new NullReferenceException("Target cannot be null."); }

            int i = 0, pointer = ((ICircleHeap<T>)this).Pointer;
            while (!target.Equals(((ICircleHeap<T>)this).Peek())
                && !(++i).Equals(((ICircleHeap<T>)this)._data.Length)) { Rotate(); }

            ((ICircleHeap<T>)this).Pointer = pointer; // Reset the pointer back to its original position

            return !i.Equals(((ICircleHeap<T>)this)._data.Length);
        }

        public bool Contains(T target, int index) { return Contains(new HeapEntry<T>(index, target)); }

        public bool Contains(IHeapEntry<T> target)
        {
            if (target == null) { throw new NullReferenceException("Target cannot be null."); }

            int left = 0, right = ((ICircleHeap<T>)this)._data.Length - 1;
            while (!left.Equals(right))
            {
                int m = left + ((right - left) / 2);

                if (target.Value.Equals(((ICircleHeap<T>)this)._data[m].Value)) { return true; }
                else if (target.Index < ((ICircleHeap<T>)this)._data[m].Index) { right = m; }
                else { left = ++m; }
            }

            return false;
        }
    }
}
