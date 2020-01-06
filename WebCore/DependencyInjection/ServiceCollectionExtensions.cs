using Microsoft.Extensions.DependencyInjection;

namespace WebCore.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterModule<T>(this IServiceCollection services)
            where T : DiModule, new()
        {
            var module = new T();
            module.Register(services);
        }
    }
}
