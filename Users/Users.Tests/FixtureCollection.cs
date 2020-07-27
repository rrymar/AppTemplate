using Xunit;

namespace Users.Tests
{
    [CollectionDefinition(Name)]
    public class FixtureCollection
        : ICollectionFixture<TestApplicationFactory>
    {
        public const string Name = "FixtureCollection";
    }
}
