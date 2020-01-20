using AppTemplate.Database;
using AppTemplate.InterationTesting;
using AppTemplate.Users.TestServices;
using AppTemplate.Users.UserManagement;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using WebCore.WebClient;
using Xunit;

namespace AppTemplate.Users.Tests
{
    [Collection(FixtureCollection.Name)]
    public class UserManagementTests : IntegrationTest
    {
        // private readonly RestRequest request = UsersRoutes.Users.ToRestRequest();

        private readonly IUserTestService testService;

        public UserManagementTests(TestApplicationFactory factory) : base(factory)
        {
            testService = Services.GetRequiredService<IUserTestService>();
        }

        [Fact]
        public void ItReturnUser()
        {
            var expected = new Database.Users.User()
            {
                Username = "AAAAA",
            };
            DataContext.Users.Add(expected);
            DataContext.SaveChanges();


            var actual = testService.Get(expected.Id);
            actual.Should().NotBeNull();
            actual.Username.Should().Be(expected.Username);
        }

        //[Fact]
        //public void ItReturnsUsers2()
        //{
        //    var actual = Client.Get<List<UserModel>>(request);
        //    actual.Should().NotBeNull();
        //    actual.ForEach(a => a.Username.Should().NotBeNullOrWhiteSpace());
        //}
    }
}
