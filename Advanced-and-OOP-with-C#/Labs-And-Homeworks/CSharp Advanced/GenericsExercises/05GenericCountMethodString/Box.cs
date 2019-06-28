using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodString
{
    public class Box<T>
        where T : IComparable<T>
    {
        public Box()
        {
            this.boxItems = new List<T>();
        }

        private List<T> boxItems;

        public void Add(T element)
        {
            this.boxItems.Add(element);
        }

        public int Count(T elementToCompare)
        {
            int counter = 0;

            foreach (var item in boxItems)
            {
                int value = item.CompareTo(elementToCompare);

                if (value == 1)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
