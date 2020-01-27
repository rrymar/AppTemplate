﻿using AppTemplate.Database.Users;
using AppTemplate.Users.TestServices.TestMigrations;
using AppTemplate.Users.TestServices.UserManagement;
using AppTemplate.Users.UserManagement;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using TestsCore.Assertion;
using Xunit;

namespace AppTemplate.Users.Tests.UserManagement
{
    public class UserManagementTests : UsersIntegrationTest
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
            var expected = new UserModel()
            {
                FirstName = "Ruslan",
                LastName = "Rymar",
                Username = "rrmar",
            };

            var actual = testService.Create(expected);

            actual.Username.Should().Be(expected.Username);
            actual.Roles.Should().BeEmpty();
            actual.FullName.Should().Be(expected.FirstName + " " + expected.LastName);
        }

        [Fact]
        public void ItUpdatesUser()
        {
            var expected = new UserModel()
            {
                FirstName = "Changed",
                IsSystemUser = true,
                Email = "Email Changed"
            };

            var actual = testService.Update(UsersTestConstants.User.Id, expected);
            actual.FirstName.Should().Be(expected.FirstName);
            actual.Email.Should().Be(expected.Email);
            actual.IsSystemUser.Should().BeFalse();
            actual.Id.Should().Be(UsersTestConstants.User.Id);
        }

        [Fact]
        public void ItDeletesUser()
        {
            testService.Delete(UsersTestConstants.User.Id);

            testService.Invoking(s => s.Get(UsersTestConstants.User.Id))
                .ShouldThrowHttpError(System.Net.HttpStatusCode.NotFound);
        }
    }
}