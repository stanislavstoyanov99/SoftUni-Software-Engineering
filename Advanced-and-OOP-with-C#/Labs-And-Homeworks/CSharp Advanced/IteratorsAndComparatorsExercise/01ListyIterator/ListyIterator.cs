using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparatorsExercise
{
    public class ListyIterator<T>
    {
        private List<T> items;
        private int currentIndex;

        public ListyIterator(List<T> items)
        {
            this.items = items;
            this.currentIndex = 0;
        }

        public ListyIterator()
        {
            this.items = new List<T>();
            this.currentIndex = 0;
        }

        public void Add(List<T> elements)
        {
            this.items.AddRange(elements);
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.currentIndex < this.items.Count - 1)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.items[currentIndex]);
        }
    }
}
