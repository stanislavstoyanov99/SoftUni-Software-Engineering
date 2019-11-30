namespace BookShop.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public ICollection<BookCategory> CategoryBooks { get; set; }
            = new HashSet<BookCategory>();
    }
}
