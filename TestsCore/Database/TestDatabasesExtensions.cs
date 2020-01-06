using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TestsCore.Database
{
    public static class TestDatabasesExtensions
    {
        private static readonly object locker = new object();

        private static bool dbInitialized;

        public static void InitTestDatabases(this DbContext dbContext, params Assembly[] migrationAsssemblies)
        {
            lock (locker)
            {
                if (dbInitialized) return;

                var db = new TestDatabaseMigrator(dbContext);
                db.Create();

                foreach (var assembly in migrationAsssemblies)
                {
                    db.RunMigrations(assembly);
                }

                dbInitialized = true;
            }
        }
    }
}
