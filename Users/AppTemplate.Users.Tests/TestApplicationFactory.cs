using AppTemplate.Database;
using AppTemplate.InterationTesting;
using AppTemplate.Users.TestServices;
using AppTemplate.Web;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using AppTemplate.Users.TestServices.TestMigrations;
using Core.Tests.Database;
using Core.Web.DependencyInjection;

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
