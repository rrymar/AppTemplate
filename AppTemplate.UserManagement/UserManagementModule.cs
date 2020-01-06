using AppTemplate.Database;
using AppTemplate.UserManagement.Authentication;
using AppTemplate.UserManagement.Users;
using Microsoft.Extensions.DependencyInjection;
using WebCore.DependencyInjection;

namespace AppTemplate.UserManagement
{
    public class UserManagementModule : DiModule
    {
        public override void Register(IServiceCollection services)
        {
            services.AddScoped<ICurrentUserLocator, CurrentUserLocator>();
            services.AddTransient<SearchUserQueryHandler>();
        }
    }
}
