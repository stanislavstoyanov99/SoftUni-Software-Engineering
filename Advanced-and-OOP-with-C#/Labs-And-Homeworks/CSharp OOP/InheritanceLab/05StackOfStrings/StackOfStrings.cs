using System.Collections.Generic;

namespace CustomStack
{
    // Generic version
    public class StackOfStrings<T> : Stack<T>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                this.Push(element);
            }
        }
    }
}
