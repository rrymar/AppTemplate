using AppTemplate.Database;
using AppTemplate.UserManagement.Authentication;
using Microsoft.Extensions.DependencyInjection;
using WebCore.DependencyInjection;

namespace AppTemplate.UserManagement
{
    public class UserManagementModule : DiModule
    {
        public override void Register(IServiceCollection services)
        {
            services.AddScoped<ICurrentUserLocator, CurrentUserLocator>();
        }
    }
}
