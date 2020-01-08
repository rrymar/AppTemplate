using AppTemplate.Database.Migrations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TestsCore;
using TestsCore.Database;
using WebCore.WebClient;

namespace AppTemplate.InterationTesting
{
    public class TestApplicationFactory<TDbContex, TStartup> : WebApplicationFactory<TStartup>
        where TDbContex : DbContext
        where TStartup : class
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

            builder.ConfigureTestServices(s =>
            {
                var provider = s.BuildServiceProvider();
                var db = provider.GetRequiredService<TDbContex>();
                db.InitTestDatabases(typeof(MigrationScripts).Assembly);
                provider.Dispose();
            });
        }
    }
}
