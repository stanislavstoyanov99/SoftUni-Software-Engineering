namespace IRunes.App.Services
{
    using ViewModels.Home;

    public interface IHomeService
    {
        LoggedInViewModel GetUsername();
    }
}
