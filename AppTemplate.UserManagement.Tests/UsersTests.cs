using AppTemplate.Database;
using AppTemplate.InterationTesting;
using AppTemplate.UserManagement.Users;
using FluentAssertions;
using System.Collections.Generic;
using WebCore.WebClient;
using Xunit;

namespace AppTemplate.UserManagement.Tests
{
    public class UsersTests : IntegrationTest
    {
        private readonly RestRequest request = UserManagementRoutes.Users.ToRestRequest();

        public UsersTests(TestApplicationFactory factory) : base(factory)
        {
        }

        //public UsersTests(TestApplicationFactory factory) : base(factory)
        //{
        //}

        [Fact]
        public void ItReturnsUsers()
        {
            DataContext.Users.Add(new Database.Users.User()
            {
                Username = "AAAAA",
            });
            DataContext.SaveChanges();

            var actual = Client.Get<List<UserModel>>(request);
            actual.Should().NotBeNull();
            actual.Should().HaveCount(2);
            actual.ForEach(a => a.Username.Should().NotBeNullOrWhiteSpace());
        }

        [Fact]
        public void ItReturnsUsers2()
        {
            var actual = Client.Get<List<UserModel>>(request);
            actual.Should().NotBeNull();
            actual.ForEach(a => a.Username.Should().NotBeNullOrWhiteSpace());
        }
    }
}
