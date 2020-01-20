using Microsoft.EntityFrameworkCore;

namespace TestsCore.Database
{
    public interface ITestMigration<T>
         where T : DbContext
    {
        string Name { get; }

        void Execute(T context);
    }
}
