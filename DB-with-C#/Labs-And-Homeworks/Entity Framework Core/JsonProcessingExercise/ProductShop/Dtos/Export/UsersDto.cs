namespace ProductShop.Dtos.Export
{
    public class UsersDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public SoldProductsInfoDto SoldProducts { get; set; }
    }
}
