using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Collections.Generic.Circular
{
    public class CircleQueue<T> : ICircleQueue<T>
    {
        T[] ICircleQueue<T>._data { get; set; }
        bool ICircleQueue<T>._indexerIsReadOnly { get; set; }
        int ICircleContainer<T>.Pointer { get; set; }

        T ICircleContainer<T>.Top
        {
            get { return ((ICircleQueue<T>)this)._data[((ICircleQueue<T>)this).Pointer]; }
            set { }
        }

        T ICircleContainer<T>.Bottom
        {
            get { return ((ICircleQueue<T>)this)._data[_bottomPos]; }
            set { }
        }
        private int _bottomPos { get; set; }

        public int Size
        {
            get
            {
                return ((ICircleQueue<T>)this)._data.Length;
            }
            set { }
        }

        public int Count
        {
            get { return _count; }
            set { }
        }
        private int _count;

        public CircleQueue(int size, bool indexerIsReadOnly = true)
        {
            ((ICircleQueue<T>)this)._data = new T[size];
            ((ICircleQueue<T>)this)._indexerIsReadOnly = indexerIsReadOnly;
        }

        public CircleQueue(ICircleQueue<T> container, bool indexerIsReadOnly = true)
        {
            ((ICircleQueue<T>)this)._data = (T[])container._data.Clone();
            _count = container.Count;
            ((ICircleQueue<T>)this)._indexerIsReadOnly = indexerIsReadOnly;
        }

        // It is not recommended that you use this constructor on inputs that are partially unfilled AND have valid null entries.
        // It will not be possible to obtain a valid count in that case since we don't know how to interpret the nulls.
        public CircleQueue(T[] data, bool countNulls = false, bool indexerIsReadOnly = true)
        {
            ((ICircleQueue<T>)this)._data = (T[])data.Clone();
            if (countNulls) { _count = data.Length; } // Assumes any null values are valid entries; O(1) time
            else
            {
                // Assumes any null values represent empty space so break at the first null; O(n) time
                for (int i = 1; i < data.Length && !EqualityComparer<T>.Default.Equals(data[i], default); i++) { _count++; }

                // Queues/stacks start at index 1, 0 is last index
                if (!EqualityComparer<T>.Default.Equals(data[0], default)) { _count++; }
                if (!Count.Equals(0))
                {
                    ((ICircleQueue<T>)this).Pointer = 1;
                    _bottomPos = (!Count.Equals(Size) ? Count : 0);  // We don't subtract 1 because entries start at index 1
                }
            }

            ((ICircleQueue<T>)this)._indexerIsReadOnly = indexerIsReadOnly;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int pos = ((ICircleQueue<T>)this).Pointer, remaining = Count;
            while (!(remaining--).Equals(0))
            {
                yield return ((ICircleQueue<T>)this)._data[pos];
                pos = (++pos) % ((ICircleQueue<T>)this)._data.Length;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        public T this[int key]
        {
            get
            {
                return ((ICircleQueue<T>)this)._data[key];
            }
            set
            {
                if (((ICircleQueue<T>)this)._indexerIsReadOnly) { throw new ReadOnlyException("Indexer is set to read-only."); }
                else { ((ICircleQueue<T>)this)._data[key] = value; }
            }
        }

        public void Enqueue(T node)
        {
            if (node == null) { throw new NullReferenceException("Value cannot be null."); }

            if (((ICircleQueue<T>)this)._data[_bottomPos] != null)
            {
                _bottomPos = (++_bottomPos) % ((ICircleQueue<T>)this)._data.Length;
            }

            if (!Count.Equals(0) && _bottomPos.Equals(((ICircleQueue<T>)this).Pointer))
            {
                ((ICircleQueue<T>)this).Pointer = (++((ICircleQueue<T>)this).Pointer) % ((ICircleQueue<T>)this)._data.Length;
            }

            ((ICircleQueue<T>)this)._data[_bottomPos] = node;

            if (!Count.Equals(Size)) { _count++; }
        }

        public T Peek() { return ((ICircleQueue<T>)this)._data[((ICircleQueue<T>)this).Pointer]; }

        public T Dequeue()
        {
            if (Count.Equals(0)) { throw new InvalidOperationException("Queue empty."); }

            T res = ((ICircleQueue<T>)this).Peek();
            ((ICircleQueue<T>)this)._data[((ICircleQueue<T>)this).Pointer] = default;

            _count--;

            Rotate();
            
            return res;
        }

        public T Rotate()
        {
            ((ICircleQueue<T>)this).Pointer = (++((ICircleQueue<T>)this).Pointer) % ((ICircleQueue<T>)this)._data.Length;

            return ((ICircleQueue<T>)this).Peek();
        }

        public bool Contains(T target)
        {
            if (target == null) { throw new NullReferenceException("Target cannot be null."); }

            int i = 0, pointer = ((ICircleQueue<T>)this).Pointer;
            while (!target.Equals(((ICircleQueue<T>)this).Peek())
                && !(++i).Equals(((ICircleQueue<T>)this)._data.Length)) { Rotate(); }

            ((ICircleQueue<T>)this).Pointer = pointer; // Reset the pointer back to its original position

            return !i.Equals(((ICircleQueue<T>)this)._data.Length);
        }
    }
}
