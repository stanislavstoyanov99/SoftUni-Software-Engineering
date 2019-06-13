using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class CustomThreeuple<T1Item, T2Item, T3Item>
    {
        public CustomThreeuple(T1Item firstItem, T2Item secondItem, T3Item thirdItem)
        {
            this.firstItem = firstItem;
            this.secondItem = secondItem;
            this.thirdItem = thirdItem;
        }

        private T1Item firstItem;
        private T2Item secondItem;
        private T3Item thirdItem;

        public override string ToString()
        {
            return $"{firstItem} -> {secondItem} -> {thirdItem}";
        }
    }
}
