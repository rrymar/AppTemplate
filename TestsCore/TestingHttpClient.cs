using WebCore.WebClient;

namespace TestsCore
{
    public class TestingHttpClient : DefaultHttpClient
    {
        public TestingHttpClient(System.Net.Http.HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
