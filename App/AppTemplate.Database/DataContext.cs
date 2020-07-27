using Core.Database;
using Microsoft.EntityFrameworkCore;

namespace AppTemplate.Database
{
    public class DataContext : CoreDataContext
    {
        public DataContext(DbContextOptions<DataContext> options, ICurrentUserLocator currentUserLocator)
         : base(options, currentUserLocator)
        {
        }
    }
}
