﻿using _09CollectionHierarchy.Interfaces;

namespace _09CollectionHierarchy.Models
{
    public class AddRemoveCollection : Collection, IAddRemoveCollection
    {
        public virtual string Remove()
        {
            string item = base.Data[base.Data.Count - 1];
            base.Data.RemoveAt(base.Data.Count - 1);

            return item;
        }
    }
}
