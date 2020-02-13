namespace SIS.HTTP.Contracts
{
    using System.Threading.Tasks;

    public interface IHttpServer
    {
        Task StartAsync();

        void Stop();

        Task ResetAsync();
    }
}
