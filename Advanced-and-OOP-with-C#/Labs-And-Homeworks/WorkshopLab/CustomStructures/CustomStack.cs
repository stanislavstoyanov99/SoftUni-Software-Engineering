using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStructures
{
    /// <summary>
    /// Integer stack
    /// </summary>
    public class CustomStack<T>
    {
        /// <summary>
        /// Default size of internal array
        /// </summary>
        private const int defaultSize = 2;

        /// <summary>
        /// Internal array
        /// </summary>
        private T[] innerArr;

        /// <summary>
        /// Number of elements in the list
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Creates custom integer list with default size
        /// </summary>
        public CustomStack()
        {
            innerArr = new T[defaultSize];
        }

        /// <summary>
        /// Pushes element to the stack
        /// </summary>
        /// <param name="element">element to push</param>
        public void Push(T element)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            innerArr[Count] = element;
            Count++;
        }

        /// <summary>
        /// Shows the last added element
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            CheckIfEmpty();

            return innerArr[Count - 1];
        }

        private void CheckIfEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }

        /// <summary>
        /// Pops element from the stack
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            CheckIfEmpty();
            Count--;
            T tempElement = innerArr[Count];
            innerArr[Count] = default(T);

            return tempElement;
        }

        /// <summary>
        /// Method that loop all the elements in the stack
        /// </summary>
        /// <param name="action">action to do</param>
        public void ForEach(Action<T> action)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                action(innerArr[i]);
            }
        }

        private void Grow()
        {
            T[] tempArr = new T[innerArr.Length * 2];

            innerArr.CopyTo(tempArr, 0);
            innerArr = tempArr;
        }
    }
}
