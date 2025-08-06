using Fundo.Applications.Domain.Interfaces;
using Fundo.Applications.Infrastructure.Persistance.Context;
using Fundo.Applications.Infrastructure.Persistance.Entities;
using Fundo.Applications.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fundo.Applications.Infrastructure.Persistance.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var connectionString = configuration.GetConnectionString("Database");
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILoanRepository, LoanRepository>();            
        }

        public static async Task SeedAsync(AppDbContext context)
        {
            if (!context.Loans.Any())
            {
                context.Loans.AddRange(
                    new LoanEntity { Amount = 4000, CurrentBalance = 4000, ApplicantName = "Jaime Zamora", Status = "Active" },
                    new LoanEntity { Amount = 5000, CurrentBalance = 5000, ApplicantName = "Yampiere Vasquez", Status = "Active" },
                    new LoanEntity { Amount = 6000, CurrentBalance = 6000, ApplicantName = "Piero Zamvas", Status = "Active" },
                    new LoanEntity { Amount = 10000, CurrentBalance = 0, ApplicantName = "Cristiano Ronaldo", Status = "Paid" }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}
