using AppTemplate.Users.TestServices;
using AppTemplate.Web;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using AppTemplate.Users.TestServices.TestMigrations;
using Core.Tests.Database;
using Core.Web.DependencyInjection;
using AppTemplate.Users.Database;
using Core.Tests;
using AppTemplate.Database.Migrations;

namespace AppTemplate.Users.Tests
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
