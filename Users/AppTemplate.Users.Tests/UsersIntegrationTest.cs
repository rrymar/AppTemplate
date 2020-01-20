using AppTemplate.InterationTesting;
using Xunit;

namespace AppTemplate.Users.Tests
{
    [Collection(FixtureCollection.Name)]
    public abstract class UsersIntegrationTest : IntegrationTest
    {
        public UsersIntegrationTest(TestApplicationFactory factory) : base(factory)
        {
        }
    }
}
