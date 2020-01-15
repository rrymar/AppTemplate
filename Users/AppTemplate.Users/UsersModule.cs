using AppTemplate.Database;
using AppTemplate.UserManagement.Authentication;
using AppTemplate.Users.UserManagement;
using Microsoft.Extensions.DependencyInjection;
using WebCore.DependencyInjection;

namespace AppTemplate.Users
{
    public class UsersModule : DiModule
    {
        public override void Register(IServiceCollection services)
        {
            services.AddScoped<ICurrentUserLocator, CurrentUserLocator>();
            services.RegisterModule<UserManagementModule>();
        }
    }
}
