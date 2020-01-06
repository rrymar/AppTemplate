using FluentAssertions;
using System.Collections.Generic;
using WebCore.WebClient;
using Xunit;

namespace AppTemplate.UserManagement.Tests
{
    public class UsersTests : IClassFixture<TestApplicationFactory>
    {
        private readonly RestClient client;

        private readonly RestRequest request = "weatherforecast".ToRestRequest();

        public UsersTests(TestApplicationFactory factory)
        {
            client = new RestClient(factory.CreateTestClient());
        }
        
        [Fact]
        public void ItReturnsUsers()
        {
            var actual = client.Get<List<User>>(request);
            actual.Should().NotBeNull();
        }
    }
}
