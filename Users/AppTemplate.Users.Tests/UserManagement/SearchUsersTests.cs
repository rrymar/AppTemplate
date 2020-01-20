using AppTemplate.Users.TestServices.UserManagement;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using WebCore.Crud;
using Xunit;

namespace AppTemplate.Users.Tests.UserManagement
{
    public class SearchUsersTests : UsersIntegrationTest
    {
        private readonly SearchUsersTestService testService;

        public SearchUsersTests(TestApplicationFactory factory) : base(factory)
        {
            testService = Services.GetRequiredService<SearchUsersTestService>();
        }

        [Fact]
        public void ItSearchUsers()
        {
            var query = new SearchQuery();
            var actual = testService.Search(query);
            actual.TotalCount.Should().Be(2);
            actual.Items.Should().HaveCount(2);
        }
    }
}
