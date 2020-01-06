using AppTemplate.UserManagement.Users;
using FluentAssertions;
using System.Collections.Generic;
using WebCore.WebClient;
using Xunit;

namespace AppTemplate.UserManagement.Tests
{
    [Collection(FixtureCollection.Name)]
    public class UsersTests
    {
        private readonly RestClient client;

        private readonly TestApplicationFactory factory;

        private readonly RestRequest request = UserManagementRoutes.Users.ToRestRequest();

        public UsersTests(TestApplicationFactory factory)
        { 
            this.factory = factory;
            client = new RestClient(factory.CreateTestClient());
        }
        
        [Fact]
        public void ItReturnsUsers()
        {
            var actual = client.Get<List<UserModel>>(request);
            actual.Should().NotBeNull();
            actual.ForEach(a => a.Username.Should().NotBeNullOrWhiteSpace());
        }

        [Fact]
        public void ItReturnsUsers2()
        {
            var actual = client.Get<List<UserModel>>(request);
            actual.Should().NotBeNull();
            actual.ForEach(a => a.Username.Should().NotBeNullOrWhiteSpace());
        }
    }
}
