using AppTemplate.Database.Migrations;
using AppTemplate.Users.Database;
using AppTemplate.Web;
using Core.Tests;
using Xunit;

namespace Users.Tests
{
    [Collection(FixtureCollection.Name)]
    public abstract class UsersIntegrationTest : IntegrationTest<UsersDataContext, Startup, MigrationScripts>
    {
        public UsersIntegrationTest(TestApplicationFactory factory) : base(factory)
        {
        }
    }
}
