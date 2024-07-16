﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CircularCollections
{
    public interface ICircleContainer<T>
    {
        public int Pointer { get; set; }
        public int Size { get; set; }

        public T Top { get; set; }
        public T Bottom { get; set; }

        T Peek();
        T Rotate();
        bool Contains(T target);
    }
}
