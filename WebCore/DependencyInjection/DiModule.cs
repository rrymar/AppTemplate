using Microsoft.Extensions.DependencyInjection;

namespace WebCore.DependencyInjection
{
    public abstract class DiModule
    {
        public abstract void Register(IServiceCollection services);
    }
}
