using AppTemplate.Users.Database;
using Core.Tests.Database;
using System.Collections.Generic;

namespace AppTemplate.Users.TestServices.TestMigrations
{
    public static class UsersTestMigrations
    {
        public static readonly List<ITestMigration<UsersDataContext>> Migrations = new List<ITestMigration<UsersDataContext>>
        {
            new AddTestUsers()
        };
    }
}
