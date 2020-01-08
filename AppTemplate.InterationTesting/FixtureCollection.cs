using Xunit;

namespace AppTemplate.InterationTesting
{
    [CollectionDefinition(Name)]
    public class FixtureCollection
        : ICollectionFixture<TestApplicationFactory>
    {
        public const string Name = "FixtureCollection";
    }
}
