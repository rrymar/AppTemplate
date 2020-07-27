using Microsoft.Extensions.DependencyInjection;

namespace Core.Web.DependencyInjection
{
    public interface IModule
    {
        void Register(IServiceCollection services);
    }
}
