﻿using Core.Database;
using Core.Tests.Database;
using Users.Database;

namespace Users.TestServices.TestMigrations
{
    public class AddTestUsers : ITestMigration<UsersDataContext>
    {
        public string Name => "202001201015_AddTestUsers";

        public void Execute(UsersDataContext context)
        {
            var user = new User()
            {
                Username = UsersTestConstants.User.Username,
            };

            var inactiveUser = new User()
            {
                Username = UsersTestConstants.InactiveUser.Username,
                IsActive = false
            };

            context.Users.Add(user);
            context.SaveChanges();

            context.Users.Add(inactiveUser);
            context.SaveChanges();
        }
    }
}
