namespace SIS.HTTP
{
    public interface IHttpServer
    {
        void StartAsync();

        void StopAsync();

        void Reset();
    }
}
