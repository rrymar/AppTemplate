using AppTemplate.Users.UserManagement.Handlers;
using Microsoft.Extensions.DependencyInjection;
using WebCore.DependencyInjection;

namespace AppTemplate.Users.UserManagement
{
    public class UserManagementModule : DiModule
    {
        public override void Register(IServiceCollection services)
        {
            services.AddTransient<SearchUsersQueryHandler>();
            services.AddTransient<CreateUserHandler>();
            services.AddTransient<UpdateUserHandler>();
            services.AddTransient<DeleteUserHandler>();
            services.AddTransient<GetUserHandler>();
        }
    }
}
