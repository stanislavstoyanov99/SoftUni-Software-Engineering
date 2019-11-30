namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidations.Store;

    public class Store
    {
        public int StoreId { get; set; }

        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }
            = new HashSet<Sale>();
    }
}
