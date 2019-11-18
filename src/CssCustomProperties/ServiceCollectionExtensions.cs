using blazejewicz.CssCustomProperties.Services;
using Microsoft.Extensions.DependencyInjection;

namespace blazejewicz.CssCustomProperties
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddCssCustomProperties(this IServiceCollection services)
        {
            return services.AddTransient<ICustomProperties, CustomProperties>();
        }
    }
}
