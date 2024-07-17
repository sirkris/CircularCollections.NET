﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CircularCollections
{
    class CircleMinHeap<T> : ICircleHeap<T>
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
            get { return ((ICircleHeap<T>)this)._data[Size - 1].Value; }
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

        public CircleMinHeap(int size) { ((ICircleHeap<T>)this)._data = new IHeapEntry<T>[size]; }

        public CircleMinHeap(ICircleHeap<T> container)
        {
            ((ICircleHeap<T>)this)._data
= (IHeapEntry<T>[])container._data.Clone();
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
            for (int i = 0; i < ((ICircleHeap<T>)this).Size; i++)
            {
                if (swap == null)
                {
                    if (((ICircleHeap<T>)this)._data[i] == null || heapEntry.Index < ((ICircleHeap<T>)this)._data[i].Index)
                    {
                        swap = ((ICircleHeap<T>)this)._data[i];
                        ((ICircleHeap<T>)this)._data[i] = heapEntry;
                    }
                }
                else
                {
                    IHeapEntry<T> tmp = swap;
                    swap = ((ICircleHeap<T>)this)._data[i];
                    ((ICircleHeap<T>)this)._data[i] = tmp;
                }
            }
        }

        public T Peek()
        {
            return ((ICircleHeap<T>)this)._data[((ICircleHeap<T>)this).Pointer].Value;
        }

        public T Pop()
        {
            T res = ((ICircleHeap<T>)this).Peek();
            ((ICircleHeap<T>)this)._data[((ICircleHeap<T>)this).Pointer] = default;

            Rotate();

            return res;
        }

        public T Rotate()
        {
            if ((--((ICircleHeap<T>)this).Pointer) < 0)
            {
                ((ICircleHeap<T>)this).Pointer = ((ICircleHeap<T>)this)._data.Length - 1;
            }

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
    }
}
