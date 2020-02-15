namespace Andreys.Models
{
    using System;
    using System.Collections.Generic;

    using SIS.MvcFramework;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<Product>();
        }

        public virtual ICollection<Product> Products { get; set; }
    }
}
