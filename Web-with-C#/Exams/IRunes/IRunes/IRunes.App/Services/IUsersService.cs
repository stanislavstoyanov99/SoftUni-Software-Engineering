namespace IRunes.App.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        bool IsUserNameUsed(string username);

        bool IsEmailUsed(string email);
    }
}
