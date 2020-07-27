using Core.Database;
using Microsoft.EntityFrameworkCore;
using Users.Database;

namespace AppTemplate.Database
{
    public class DataContext : CoreDataContext
    {
        public DbSet<UserPreferense> UserPreferenses { get; set; }

        public DataContext(DbContextOptions<DataContext> options, ICurrentUserLocator currentUserLocator)
         : base(options, currentUserLocator)
        {
        }

        public DataContext()
        {

        }
    }
}
