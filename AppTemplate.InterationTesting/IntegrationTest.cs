using AppTemplate.Database;
using AppTemplate.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TestsCore.Database;
using WebCore.WebClient;

namespace AppTemplate.InterationTesting
{
    public abstract class IntegrationTest : IntegrationTest<DataContext, Startup>
    {
        protected IntegrationTest(TestApplicationFactory factory) : base(factory)
        {
        }
    }

    public class TestApplicationFactory : TestApplicationFactory<DataContext, Startup>
    {
    }

    [AutoRollback]
    public abstract class IntegrationTest<TDbContex, TStartup>
    where TDbContex : DbContext
    where TStartup : class
    {
        private readonly TestApplicationFactory<TDbContex, TStartup> factory;

        protected virtual bool CreateTransaction => false;

        protected readonly TDbContex DataContext;

        protected readonly IServiceProvider Services;

        private readonly IServiceScope scope;

        protected RestClient Client;


        protected IntegrationTest(TestApplicationFactory<TDbContex, TStartup> factory)
        {
            this.factory = factory;
            factory.Server.PreserveExecutionContext = true;

            Client = new RestClient(factory.CreateTestClient());
            scope = factory.Services.CreateScope();
            Services = scope.ServiceProvider;

            DataContext = scope.ServiceProvider.GetRequiredService<TDbContex>();

        }

        public virtual void Dispose()
        {
            Client?.Dispose();
            scope?.Dispose();
        }
    }
}
