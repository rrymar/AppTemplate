using AppTemplate.Users.TestServices.UserManagement;
using Microsoft.Extensions.DependencyInjection;
using WebCore.DependencyInjection;

namespace AppTemplate.Users.TestServices
{
    public class UserTestServicesModule : DiModule
    {
        public override void Register(IServiceCollection services)
        {
            services.AddTransient<IUserTestService, UserTestService>();
            services.AddTransient<SearchUsersTestService>();
        }
    }
}
