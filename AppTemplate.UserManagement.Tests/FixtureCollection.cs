using AppTemplate.Database;
using AppTemplate.InterationTesting;
using AppTemplate.Web;
using Xunit;

namespace AppTemplate.UserManagement.Tests
{
    [CollectionDefinition(Name)]
    public class FixtureCollection 
        : ICollectionFixture<TestApplicationFactory>
    {
        public const string Name = "FixtureCollection";
    }

    public class TestApplicationFactory : TestApplicationFactory<DataContext, Startup>
    {

    }
}
