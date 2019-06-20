using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private class LinkNode
        {
            public T Value { get; private set; }

            public LinkNode NextNode { get; set; }

            public LinkNode PreviousNode { get; set; }

            public LinkNode(T value)
            {
                this.Value = value;
            }
        }

        public int Count { get; private set; }

        private LinkNode head;
        private LinkNode tail;

        public void AddFirst(T value)
        {
            LinkNode newHead = new LinkNode(value);

            if (this.Count == 0)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T value)
        {
            LinkNode newTail = new LinkNode(value);

            if (this.Count == 0)
            {
                this.head = this.tail = newTail;
            }
            else
            {
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            CheckIfEmpty();

            T firstElement = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head == null)
            {
                this.tail = null;
            }
            else
            {
                this.head.PreviousNode = null;
            }

            this.Count--;

            return firstElement;
        }

        public T RemoveLast()
        {
            CheckIfEmpty();

            T lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;

            if (this.tail == null)
            {
                this.head = null;
            }
            else
            {
                this.tail.NextNode = null;
            }

            this.Count--;

            return lastElement;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            var currentNode = this.head;
            int counter = 0;

            while (currentNode != null)
            {
                array[counter++] = currentNode.Value;

                currentNode = currentNode.NextNode;
            }

            return array;
        }

        public List<T> ToList()
        {
            List<T> list = new List<T>(this.Count);

            var currentNode = this.head;
            while (currentNode != null)
            {
                list.Add(currentNode.Value);

                currentNode = currentNode.NextNode;
            }

            return list;
        }

        public bool Contains(T value)
        {
            LinkNode currentNode = this.head;

            bool isFound = false;

            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    isFound = true;
                }

                currentNode = currentNode.NextNode;
            }

            return isFound;
        }

        public void Print(Action<T> action)
        {
            LinkNode currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);

                currentNode = currentNode.NextNode;
            }
        }

        private void CheckIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Double linked list is empty!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkNode currentNode = this.head;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
