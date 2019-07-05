using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rand;

        public RandomList()
        {
            this.rand = new Random();
        }

        public string RandomString()
        {
            int index = rand.Next(0, this.Count);
            string elementToRemove = this[index];
            this.RemoveAt(index);

            return elementToRemove;
        }
    }
}
