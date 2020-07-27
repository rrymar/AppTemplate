using AppTemplate.Database.Migrations;
using AppTemplate.Web;
using Core.Tests;
using Users.Database;
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
