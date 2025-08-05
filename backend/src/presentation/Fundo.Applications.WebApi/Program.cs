using Fundo.Applications.Infrastructure.Persistance.Context;
using Fundo.Applications.Infrastructure.Persistance.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fundo.Applications.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // Use Startup.cs pattern
                var startup = new Startup(builder.Configuration);
                startup.ConfigureServices(builder.Services);

                var app = builder.Build();

                using (var scope = app.Services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    dbContext.Database.Migrate();

                    ServiceExtensions.SeedAsync(dbContext).GetAwaiter().GetResult();
                }

                // Run app pipeline
                startup.Configure(app, app.Environment);
                app.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unhandled WebApi exception: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Application shutting down.");
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }
    }
}
