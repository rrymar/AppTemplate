using AppTemplate.Database;
using AppTemplate.InterationTesting;
using AppTemplate.Users.TestServices;
using AppTemplate.Web;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TestsCore.Database;
using WebCore.DependencyInjection;
using AppTemplate.Users.TestServices.TestMigrations;

namespace AppTemplate.Users.Tests
{
    public class TestApplicationFactory : TestApplicationFactory<DataContext, Startup>
    {
        public override List<ITestMigration<DataContext>> TestMigrations 
            => UsersTestMigrations.Migrations;

        protected override void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureTestServices(services);
            services.RegisterModule<UserTestServicesModule>();
        }
    }
}
