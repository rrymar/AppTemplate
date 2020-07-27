using AppTemplate.Users.TestServices.UserManagement;
using Core.Web.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace AppTemplate.Users.TestServices
{
    public class UserTestServicesModule : IModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<IUserTestService, UserTestService>();
            services.AddTransient<SearchUsersTestService>();
        }
    }
}
