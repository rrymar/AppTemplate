using Core.Database;
using Core.Web.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Database;
using Users.UserManagement;

namespace Users
{
    public class UsersModule : ITopLevelModule
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            services.AddDbContext<UsersDataContext>(o => o.UseSqlServer(connectionString));

            services.RegisterModule<UserManagementModule>();
        }
    }
}
