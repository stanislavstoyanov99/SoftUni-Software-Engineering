namespace SIS.HTTP.Response
{
    using Enumerations;

    public class StatusCodeResponse : HttpResponse
    {
        public StatusCodeResponse(HttpResponseCode code)
        {
            this.StatusCode = code;
        }
    }
}
