using Microsoft.Extensions.DependencyInjection;

namespace Core.Web.DependencyInjection
{
    public abstract class DiModule
    {
        public abstract void Register(IServiceCollection services);
    }
}
