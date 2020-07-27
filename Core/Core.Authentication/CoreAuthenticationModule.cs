using Core.Database;
using Core.Web.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Authentication
{
    public class CoreAuthenticationModule : IModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<ICurrentUserLocator, UserContext>();
        }
    }
}
