﻿namespace _09CollectionHierarchy.Models
{
    public class AddCollection : Collection
    {
        public override int Add(string item)
        {
            base.Add(item);

            return base.Data.Count - 1;
        }
    }
}
