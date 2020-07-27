using Core.Web.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Users.UserManagement.Handlers;

namespace Users.UserManagement
{
    public class UserManagementModule : IModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<SearchUsersQueryHandler>();
            services.AddTransient<CreateUserHandler>();
            services.AddTransient<UpdateUserHandler>();
            services.AddTransient<DeleteUserHandler>();
            services.AddTransient<GetUserHandler>();
            services.AddTransient<UserMapper>();
        }
    }
}
