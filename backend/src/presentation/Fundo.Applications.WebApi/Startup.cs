using Fundo.Applications.Application.Services;
using Fundo.Applications.Infrastructure.Persistance.Services;
using Fundo.Applications.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fundo.Applications.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();

            services.ConfigurePersistenceApp(this.Configuration);
            services.ConfigureApplicationApp();
            services.ConfigureCorsPolicy();
            services.AddControllers();
            services.AddEndpointsApiExplorer();            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors();
            app.UseRouting();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
