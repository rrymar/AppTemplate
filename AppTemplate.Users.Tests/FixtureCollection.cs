using AppTemplate.InterationTesting;
using Xunit;

namespace AppTemplate.UserManagement.Tests
{
    [CollectionDefinition(Name)]
    public class FixtureCollection
        : ICollectionFixture<TestApplicationFactory>
    {
        public const string Name = "FixtureCollection";
    }
}
