using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.Circular
{
    public class CircleQueue<T> : ICircleQueue<T>
    {
        T[] ICircleQueue<T>._data { get; set; }
        int ICircleContainer<T>.Pointer { get; set; }

        T ICircleContainer<T>.Top
        {
            get { return ((ICircleQueue<T>)this)._data[((ICircleQueue<T>)this).Pointer]; }
            set { }
        }

        T ICircleContainer<T>.Bottom
        {
            get
            {
                int index = ((ICircleQueue<T>)this).Pointer - 1;
                if (index < 0) { index = (Size - 1); }

                return ((ICircleQueue<T>)this)._data[index];
            }
            set { }
        }

        public int Size
        {
            get
            {
                return ((ICircleQueue<T>)this)._data.Length;
            }
            set { }
        }

        public CircleQueue(int size) { ((ICircleQueue<T>)this)._data = new T[size]; }

        public CircleQueue(ICircleQueue<T> container) { ((ICircleQueue<T>)this)._data = (T[])container._data.Clone(); }

        public void Enqueue(T node)
        {
            if (node == null) { throw new NullReferenceException("Value cannot be null."); }

            ((ICircleQueue<T>)this)._data[((ICircleQueue<T>)this).Pointer] = node;
        }

        public T Peek() { return ((ICircleQueue<T>)this)._data[((ICircleQueue<T>)this).Pointer]; }

        public T Dequeue()
        {
            T res = ((ICircleQueue<T>)this).Peek();
            ((ICircleQueue<T>)this)._data[((ICircleQueue<T>)this).Pointer] = default;

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
