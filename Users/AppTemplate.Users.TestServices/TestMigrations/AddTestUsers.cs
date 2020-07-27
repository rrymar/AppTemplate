using AppTemplate.Database;
using AppTemplate.Users.Database;
using Core.Tests.Database;

namespace AppTemplate.Users.TestServices.TestMigrations
{
    public class AddTestUsers : ITestMigration<DataContext>
    {
        public string Name => "202001201015_AddTestUsers";

        public void Execute(DataContext context)
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
