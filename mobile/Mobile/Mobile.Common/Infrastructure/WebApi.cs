using RestSharp;

namespace Mobile.Common.Infrastructure
{
    public class WebApi
    {
        public static RestClient GetClient()
        {
            return new RestClient("http://localhost:2887");
        }
    }
}