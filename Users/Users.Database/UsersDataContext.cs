using Core.Database;
using Microsoft.EntityFrameworkCore;

namespace Users.Database
{
    public class UsersDataContext : CoreDataContext
    {
        public DbSet<UserPreferense> UserPreferenses { get; set; }

        public UsersDataContext(DbContextOptions<UsersDataContext> options, ICurrentUserLocator currentUserLocator)
         : base(options, currentUserLocator)
        {
        }
    }
}
