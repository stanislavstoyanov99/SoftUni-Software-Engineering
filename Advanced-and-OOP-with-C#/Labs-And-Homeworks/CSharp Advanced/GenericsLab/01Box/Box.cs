using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> boxItems;

        public int Count => this.boxItems.Count;

        public Box()
        {
            boxItems = new List<T>();
        }

        public void Add(T element)
        {
            this.boxItems.Add(element);
        }

        public T Remove()
        {
            T lastElement = this.boxItems.Last();
            this.boxItems.RemoveAt(Count - 1);

            return lastElement;
        }
    }
}
