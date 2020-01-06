using AppTemplate.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using TestsCore.Database;
using WebCore.WebClient;

namespace AppTemplate.UserManagement.Tests
{
    [AutoRollback]
    public abstract class IntegrationTest
    {
        private readonly TestApplicationFactory factory;

        protected virtual bool CreateTransaction => false;

        protected readonly DataContext DataContext;

        protected readonly IServiceProvider Services;

        private readonly IServiceScope scope;

        protected RestClient Client;


        protected IntegrationTest(TestApplicationFactory factory)
        {
            this.factory = factory;
            factory.Server.PreserveExecutionContext = true;

            Client = new RestClient(factory.CreateTestClient());
            scope = factory.Services.CreateScope();
            Services = scope.ServiceProvider;

            DataContext = scope.ServiceProvider.GetRequiredService<DataContext>();

        }

        public virtual void Dispose()
        {
            Client?.Dispose();
            scope?.Dispose();
        }
    }
}
