using System.Collections.Generic;

namespace _09CollectionHierarchy.Models
{
    public abstract class Collection
    {
        private const int MAX_CAPACITY = 100;

        public Collection()
        {
            this.Data = new List<string>(MAX_CAPACITY);
        }

        public List<string> Data { get; }

        public virtual int Add(string item)
        {
            this.Data.Insert(0, item);

            return 0;
        }
    }
}
