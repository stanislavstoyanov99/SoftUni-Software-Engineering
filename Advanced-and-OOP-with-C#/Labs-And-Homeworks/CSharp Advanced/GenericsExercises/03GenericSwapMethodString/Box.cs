using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodString
{
    public class Box<T>
    {
        private List<T> boxItems;

        public Box()
        {
            this.boxItems = new List<T>();
        }

        public void Add(T element)
        {
            this.boxItems.Add(element);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            T temp = boxItems[firstIndex];
            boxItems[firstIndex] = boxItems[secondIndex];
            boxItems[secondIndex] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in boxItems)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
