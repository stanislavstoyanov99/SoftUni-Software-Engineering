using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TupleExercise
{
    public class CustomTuple<T1Item, T2Item>
    {
        public CustomTuple(T1Item firstItem, T2Item secondItem)
        {
            this.firstItem = firstItem;
            this.secondItem = secondItem;
        }

        private T1Item firstItem;
        private T2Item secondItem;

        public override string ToString()
        {
            return $"{firstItem} -> {secondItem}";
        }
    }
}
