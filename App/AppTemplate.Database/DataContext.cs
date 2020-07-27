using AppTemplate.Users.Database;
using Core.Database;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppTemplate.Database
{
    public class DataContext : CoreDataContext
    {
        public DbSet<UserPreferense> UserPreferenses { get; set; }

        public DataContext(DbContextOptions<DataContext> options, ICurrentUserLocator currentUserLocator)
         : base(options, currentUserLocator)
        {
            //throw new NotImplementedException("DataContext should be used only for migrations generations.");
        }

        public DataContext()
        {

        }
    }
}
