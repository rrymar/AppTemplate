using AppTemplate.Database;
using System.Collections.Generic;
using TestsCore.Database;

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
