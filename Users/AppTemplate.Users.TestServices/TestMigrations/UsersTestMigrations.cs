using AppTemplate.Database;
using Core.Tests.Database;
using System.Collections.Generic;

namespace AppTemplate.Users.TestServices.TestMigrations
{
    public static class UsersTestMigrations
    {
        public static readonly List<ITestMigration<DataContext>> Migrations = new List<ITestMigration<DataContext>>
        {
            new AddTestUsers()
        };
    }
}
