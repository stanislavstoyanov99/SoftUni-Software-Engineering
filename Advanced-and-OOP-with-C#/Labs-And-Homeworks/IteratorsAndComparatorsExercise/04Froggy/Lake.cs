using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparatorsExercise
{
    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int position = 0; position < stones.Length; position++)
            {
                if (position % 2 == 0)
                {
                    yield return stones[position];
                }
            }

            for (int position = this.stones.Length - 1; position >= 0; position--)
            {
                if (position % 2 != 0)
                {
                    yield return stones[position];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
