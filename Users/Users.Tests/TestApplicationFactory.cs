using AppTemplate.Web;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Core.Tests.Database;
using Core.Web.DependencyInjection;
using Core.Tests;
using AppTemplate.Database.Migrations;
using Users.Database;
using Users.TestServices.TestMigrations;
using Users.TestServices;

namespace Users.Tests
{
    public class TestApplicationFactory : TestApplicationFactory<UsersDataContext, Startup, MigrationScripts>
    {
        public override List<ITestMigration<UsersDataContext>> TestMigrations 
            => UsersTestMigrations.Migrations;

        protected override void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureTestServices(services);
            services.RegisterModule<UserTestServicesModule>();
        }
    }
}
