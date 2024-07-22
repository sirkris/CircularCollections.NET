using System;

namespace Collections.Generic.Circular
{
    public class CircleStack<T> : ICircleStack<T>
    {
        T[] ICircleStack<T>._data { get; set; }
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

        public CircleStack(int size) { ((ICircleStack<T>)this)._data = new T[size]; }

        public CircleStack(ICircleStack<T> container) { ((ICircleStack<T>)this)._data = (T[])container._data.Clone(); }

        public void Push(T node)
        {
            if (node == null) { throw new NullReferenceException("Value cannot be null."); }

            ((ICircleStack<T>)this).Pointer = (++((ICircleStack<T>)this).Pointer) % ((ICircleStack<T>)this)._data.Length;
            ((ICircleStack<T>)this)._data[((ICircleStack<T>)this).Pointer] = node;
        }

        public T Peek() { return ((ICircleStack<T>)this)._data[((ICircleStack<T>)this).Pointer]; }

        public T Pop()
        {
            T res = ((ICircleStack<T>)this).Peek();
            ((ICircleStack<T>)this)._data[((ICircleStack<T>)this).Pointer] = default;

            Rotate();

            return res;
        }

        public T Rotate()
        {
            if ((--((ICircleStack<T>)this).Pointer) < 0) { ((ICircleStack<T>)this).Pointer = ((ICircleStack<T>)this)._data.Length - 1; }

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
