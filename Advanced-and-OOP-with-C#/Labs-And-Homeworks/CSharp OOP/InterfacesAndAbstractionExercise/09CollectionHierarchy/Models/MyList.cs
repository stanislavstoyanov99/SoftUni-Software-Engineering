using _09CollectionHierarchy.Interfaces;

namespace _09CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, IMylist
    {
        public override string Remove()
        {
            string item = base.Data[0];
            base.Data.RemoveAt(0);

            return item;
        }

        public string Used()
        {
            return string.Join(" ", base.Data);
        }
    }
}
