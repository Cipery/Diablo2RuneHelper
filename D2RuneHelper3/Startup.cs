using Blazor.Extensions.Storage;
using Blazor.Fluxor;
using D2RuneHelper3.Model;
using D2RuneHelper3.Services;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace D2RuneHelper3
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<DataTable>();
            services.AddSingleton<AppState>();
            services.AddStorage();
            services.AddFluxor(options => options
                .UseDependencyInjection(typeof(Startup).Assembly)
                .AddMiddleware<Blazor.Fluxor.ReduxDevTools.ReduxDevToolsMiddleware>()
                .AddMiddleware<Blazor.Fluxor.Routing.RoutingMiddleware>()
            );
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
