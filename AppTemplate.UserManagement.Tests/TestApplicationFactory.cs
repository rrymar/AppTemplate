using AppTemplate.Database;
using AppTemplate.Database.Migrations;
using AppTemplate.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TestsCore;
using TestsCore.Database;
using WebCore.WebClient;
using Xunit;

namespace AppTemplate.UserManagement.Tests
{
    public class TestApplicationFactory : WebApplicationFactory<Startup>
    {
        public IHttpClient CreateTestClient()
        {
            return new TestingHttpClient(CreateClient());
        }
        
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.json");

            builder.ConfigureAppConfiguration((_, c) => c.AddJsonFile(configPath));

            builder.Configure((context,app) =>
            {
                // as this method overrides actual Configure
                Startup.ConfigureApp(app, context.HostingEnvironment);

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                    db.InitTestDatabases(typeof(MigrationScripts).Assembly);
                }
            });
        }
    }

    [CollectionDefinition(Name)]
    public class FixtureCollection : ICollectionFixture<TestApplicationFactory>
    {
        public const string Name = "FixtureCollection";
    }
}
