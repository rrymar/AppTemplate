using Core.Tests.Database;
using System.Collections.Generic;
using Users.Database;

namespace Users.TestServices.TestMigrations
{
    public static class UsersTestMigrations
    {
        public static readonly List<ITestMigration<UsersDataContext>> Migrations = new List<ITestMigration<UsersDataContext>>
        {
            new AddTestUsers()
        };
    }
}
