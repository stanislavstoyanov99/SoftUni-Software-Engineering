using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int defaultSize = 2;

        private T[] innerArray;

        public CustomStack()
        {
            this.innerArray = new T[defaultSize];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.innerArray.Length == Count)
            {
                this.Grow();
            }

            this.innerArray[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            this.CheckIfEmpty();
            this.Count--;

            T tempElement = this.innerArray[this.Count];
            this.innerArray[this.Count] = default(T);

            return tempElement;
        }

        public T Peek()
        {
            this.CheckIfEmpty();

            return this.innerArray[this.Count - 1];
        }

        private void CheckIfEmpty()
        {
            if (this.Count == 0)
            {
                Console.WriteLine("No elements");
                Environment.Exit(0);
            }
        }

        private void Grow()
        {
            T[] tempArray = new T[defaultSize * 2];

            this.innerArray.CopyTo(tempArray, 0);
            this.innerArray = tempArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int number = innerArray.Length - 1; number >= 0; number--)
            {
                yield return innerArray[number];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
