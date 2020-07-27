using Core.Web.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Users.TestServices.UserManagement;

namespace Users.TestServices
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
