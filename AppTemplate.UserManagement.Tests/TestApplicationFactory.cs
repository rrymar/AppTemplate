using AppTemplate.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using TestsCore;
using WebCore.WebClient;

namespace AppTemplate.UserManagement.Tests
{
    public class TestApplicationFactory : WebApplicationFactory<Startup>
    {
        public IHttpClient CreateTestClient()
        {
            return new TestingHttpClient(CreateClient());
        }
    }
}
