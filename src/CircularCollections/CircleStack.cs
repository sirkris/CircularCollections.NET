using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Collections.Generic.Circular
{
    public class CircleStack<T> : ICircleStack<T>
    {
        T[] ICircleStack<T>._data { get; set; }
        bool ICircleStack<T>._indexerIsReadOnly { get; set; }
        int ICircleContainer<T>.Pointer { get; set; }

        T ICircleContainer<T>.Top
        {
            get { return ((ICircleStack<T>)this)._data[((ICircleStack<T>)this).Pointer]; }
            set { }
        }

        T ICircleContainer<T>.Bottom
        {
            get
            {
                int index = ((ICircleStack<T>)this).Pointer - 1;
                if (index < 0) { index = (Size - 1); }

                return ((ICircleStack<T>)this)._data[index];
            }
            set { }
        }

        public int Size
        {
            get
            {
                return ((ICircleStack<T>)this)._data.Length;
            }
            set { }
        }

        public int Count
        {
            get { return _count; }
            set { }
        }
        private int _count;

        public CircleStack(int size, bool indexerIsReadOnly = true)
        {
            ((ICircleStack<T>)this)._data = new T[size];
            ((ICircleStack<T>)this)._indexerIsReadOnly = indexerIsReadOnly;
        }

        public CircleStack(ICircleStack<T> container, bool indexerIsReadOnly = true)
        {
            ((ICircleStack<T>)this)._data = (T[])container._data.Clone();
            _count = container.Count;
            ((ICircleStack<T>)this)._indexerIsReadOnly = indexerIsReadOnly;
        }

        // It is not recommended that you use this constructor on inputs that are partially unfilled AND have valid null entries.
        // It will not be possible to obtain a valid count in that case since we don't know how to interpret the nulls.
        public CircleStack(T[] data, bool countNulls = false, bool indexerIsReadOnly = true)
        {
            ((ICircleStack<T>)this)._data = (T[])data.Clone();
            if (countNulls) { _count = data.Length; } // Assumes any null values are valid entries; O(1) time
            else
            {
                // Assumes any null values represent empty space so break at the first null; O(n) time
                for (int i = 1; i < data.Length && !EqualityComparer<T>.Default.Equals(data[i], default); i++) { _count++; }

                // Queues/stacks start at index 1, 0 is last index
                if (!EqualityComparer<T>.Default.Equals(data[0], default)) { _count++; }
                if (!Count.Equals(0)) { ((ICircleStack<T>)this).Pointer = (Count % Size); }
            }

            ((ICircleStack<T>)this)._indexerIsReadOnly = indexerIsReadOnly;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int pos = ((ICircleStack<T>)this).Pointer;
            for (int i = 1; i <= Count; i++)
            {
                yield return ((ICircleStack<T>)this)._data[pos];
                if ((--pos).Equals(-1)) { pos = (Size - 1); }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        public T this[int key]
        {
            get
            {
                return ((ICircleStack<T>)this)._data[key];
            }
            set
            {
                if (((ICircleStack<T>)this)._indexerIsReadOnly) { throw new ReadOnlyException("Indexer is set to read-only."); }
                else { ((ICircleStack<T>)this)._data[key] = value; }
            }
        }

        public void Push(T node)
        {
            if (node == null) { throw new NullReferenceException("Value cannot be null."); }

            ((ICircleStack<T>)this).Pointer = (++((ICircleStack<T>)this).Pointer) % ((ICircleStack<T>)this)._data.Length;
            ((ICircleStack<T>)this)._data[((ICircleStack<T>)this).Pointer] = node;

            if (!Count.Equals(Size)) { _count++; };
        }

        public T Peek() { return ((ICircleStack<T>)this)._data[((ICircleStack<T>)this).Pointer]; }

        public T Pop()
        {
            if (Count.Equals(0)) { throw new InvalidOperationException("Stack empty."); }

            T res = ((ICircleStack<T>)this).Peek();
            ((ICircleStack<T>)this)._data[((ICircleStack<T>)this).Pointer] = default;

            _count--;

            Rotate();

            return res;
        }

        public T Rotate(int factor = -1)
        {
            ((ICircleStack<T>)this).Pointer = (((ICircleStack<T>)this).Pointer + factor) % ((ICircleStack<T>)this)._data.Length;
            while (((ICircleStack<T>)this).Pointer < 0)
            {
                ((ICircleStack<T>)this).Pointer = ((ICircleStack<T>)this)._data.Length + ((ICircleStack<T>)this).Pointer;
            }

            return ((ICircleStack<T>)this).Peek();
        }

        public bool Contains(T target)
        {
            if (target == null) { throw new NullReferenceException("Target cannot be null."); }

            int i = 0, pointer = ((ICircleStack<T>)this).Pointer;
            while (!target.Equals(((ICircleStack<T>)this).Peek())
                && !(++i).Equals(((ICircleStack<T>)this)._data.Length)) { Rotate(); }

            ((ICircleStack<T>)this).Pointer = pointer; // Reset the pointer back to its original position

            return !i.Equals(((ICircleStack<T>)this)._data.Length);
        }
    }
}
