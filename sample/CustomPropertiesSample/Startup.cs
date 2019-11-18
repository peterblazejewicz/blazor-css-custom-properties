using blazejewicz.CssCustomProperties;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CustomPropertiesSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCssCustomProperties();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
