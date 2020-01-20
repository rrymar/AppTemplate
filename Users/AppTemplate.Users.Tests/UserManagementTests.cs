using AppTemplate.Database;
using AppTemplate.Database.Users;
using AppTemplate.InterationTesting;
using AppTemplate.Users.TestServices;
using AppTemplate.Users.UserManagement;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AppTemplate.Users.Tests
{
    [Collection(FixtureCollection.Name)]
    public class UserManagementTests : IntegrationTest
    {
        private readonly IUserTestService testService;

        public UserManagementTests(TestApplicationFactory factory) : base(factory)
        {
            testService = Services.GetRequiredService<IUserTestService>();
        }

        [Fact]
        public void ItReturnsSystemUser()
        {
            var actual = testService.Get(KnownUsers.System);
            actual.Should().NotBeNull();
            actual.Id.Should().Be(1);
        }

        [Fact]
        public void ItCreatesUser()
        {
            var user = new UserModel()
            {
                FirstName = "Ruslan",
                LastName = "Rymar",
                Username = "rrmar",
            };

            var actual = testService.Create(user);

            actual.Username.Should().Be(user.Username);
            actual.Roles.Should().BeEmpty();
            actual.FullName.Should().Be(user.FirstName + " " + user.LastName);
        }
    }
}
