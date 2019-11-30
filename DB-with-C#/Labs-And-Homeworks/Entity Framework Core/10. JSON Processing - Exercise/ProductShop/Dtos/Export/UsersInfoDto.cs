namespace ProductShop.Dtos.Export
{
    public class UsersInfoDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public SoldProductsDto[] SoldProducts { get; set; }
    }
}
