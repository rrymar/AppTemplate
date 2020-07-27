using Core.Web.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Users.UserManagement.Search;
using Users.UserManagement.Users;

namespace Users.UserManagement
{
    public class UserManagementModule : IModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<UserMapper>();

            services.AddTransient<UsersService>();
            services.AddTransient<SearchUsersService>();
        }
    }
}
