using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStructures
{
    /// <summary>
    /// Integer List
    /// </summary>
    public class CustomList<T> where T : IComparable
    {
        /// <summary>
        /// Default size of internal array
        /// </summary>
        private const int defaultSize = 4;

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
        public CustomList()
        {
            innerArr = new T[defaultSize];
        }

        /// <summary>
        /// Creates custom integer list with initial size
        /// </summary>
        /// <param name="initialSize">Initial size of the list</param>
        public CustomList(int initialSize)
        {
            innerArr = new T[initialSize];
        }

        public T this[int index]
        {
            get
            {
                CheckIndexRange(index);

                return innerArr[index];
            }
            set
            {
                CheckIndexRange(index);

                innerArr[index] = value;
            }
        }

        /// <summary>
        /// Method that adds element to the list
        /// </summary>
        /// <param name="element">Element to add</param>
        public void Add(T element)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            innerArr[Count] = element;
            Count++;
        }

        /// <summary>
        /// Method that adds collection to the list
        /// </summary>
        /// <param name="list">Collection to add</param>
        public void AddRange(T[] list)
        {
            if (list.Length + Count >= innerArr.Length)
            {
                if (list.Length + Count > innerArr.Length * 2)
                {
                    Grow((list.Length + Count) * 2);
                }
                else
                {
                    Grow();
                }
            }

            for (int i = 0; i < list.Length; i++)
            {
                innerArr[Count] = list[i];
                Count++;
            }
        }

        /// <summary>
        /// Removes element at current position from the list
        /// </summary>
        /// <param name="index">Index of the element to remove</param>
        /// <exception cref="IndexOutOfRangeException">The position is out of range</exception>
        public void RemoveAt(int index)
        {
            CheckIndexRange(index);
            ShiftLeft(index);
            Shrink();
            Count--;
        }

        /// <summary>
        /// Insert element at given index
        /// </summary>
        /// <param name="index">position of the element</param>
        /// <param name="element">element to insert at index</param>
        public void InsertAt(int index, T element)
        {
            CheckIndexRange(index);
            ShiftRight(index);
            innerArr[index] = element;
            Count++;
        }

        /// <summary>
        /// Check whether element exists in the list
        /// </summary>
        /// <param name="element">element to search in the list</param>
        /// <returns></returns>
        public bool Contains(T element) 
        {
            bool result = false;

            for (int i = 0; i < Count; i++)
            {
                if (innerArr[i].Equals(element))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Swap two elements in the list
        /// </summary>
        /// <param name="firstIndex">first element index</param>
        /// <param name="secondIndex">second element index</param>
        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIndexRange(firstIndex);
            CheckIndexRange(secondIndex);

            T tempElement = innerArr[firstIndex];
            innerArr[firstIndex] = innerArr[secondIndex];
            innerArr[secondIndex] = tempElement;
        }

        public void Shrink()
        {
            if (innerArr.Length / 4 > Count)
            {
                T[] tempArr = new T[innerArr.Length / 2];

                for (int i = 0; i < Count; i++)
                {
                    tempArr[i] = innerArr[i];
                }

                innerArr = tempArr;
            }
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(innerArr[i]);
            }
        }

        #region private

        private void CheckIndexRange(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Grow()
        {
            Grow(innerArr.Length * 2);
        }

        private void Grow(int newSize)
        {
            T[] tempArr = new T[newSize];

            innerArr.CopyTo(tempArr, 0);
            innerArr = tempArr;
        }

        private void ShiftLeft(int position)
        {
            if (position < Count - 1)
            {
                for (int i = position; i < Count - 1; i++)
                {
                    innerArr[i] = innerArr[i + 1];
                }
            }

            innerArr[Count - 1] = default(T);
        }

        private void ShiftRight(int position)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            if (position < Count - 1)
            {
                for (int i = Count - 1; i >= position; i--)
                {
                    innerArr[i] = innerArr[i + 1];
                }
            }
            else if (position == Count - 1)
            {
                innerArr[position] = default(T);
            }
        }

        #endregion

    }
}
