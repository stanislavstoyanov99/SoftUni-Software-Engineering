namespace PetStore.Services
{
    public interface ICategoryService
    {
        int Add(string name, string description);

        bool Exists(int categoryId);
    }
}
