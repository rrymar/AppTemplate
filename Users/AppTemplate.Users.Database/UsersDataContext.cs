using Core.Database;
using Microsoft.EntityFrameworkCore;

namespace AppTemplate.Users.Database
{
    public class UsersDataContext : CoreDataContext
    {
        public UsersDataContext(DbContextOptions<UsersDataContext> options, ICurrentUserLocator currentUserLocator)
         : base(options, currentUserLocator)
        {
        }
    }
}
