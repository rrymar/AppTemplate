using AppTemplate.Database;
using AppTemplate.InterationTesting;
using AppTemplate.Users.TestServices;
using AppTemplate.Web;
using Microsoft.Extensions.DependencyInjection;
using WebCore.DependencyInjection;

namespace AppTemplate.Users.Tests
{
    public class TestApplicationFactory : TestApplicationFactory<DataContext, Startup>
    {
        protected override void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureTestServices(services);
            services.RegisterModule<UserTestServicesModule>();
        }
    }
}
