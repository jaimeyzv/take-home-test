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
            if (!context.LoanStatus.Any())
            {
                context.LoanStatus.AddRange(
                    new LoanStatusEntity { Name = "Active"},
                    new LoanStatusEntity { Name = "Paid"} 
                );

                context.Loans.AddRange(
                    new LoanEntity { Amount = 100, CurrentBalance = 5000, ApplicantName = "Jaime Zamora", StatusId = 1 },
                    new LoanEntity { Amount = 200, CurrentBalance = 4900, ApplicantName = "Jaime Zamora", StatusId = 2 },
                    new LoanEntity { Amount = 300, CurrentBalance = 4700, ApplicantName = "Jaime Zamora", StatusId = 1 },
                    new LoanEntity { Amount = 400, CurrentBalance = 4400, ApplicantName = "Jaime Zamora", StatusId = 2 }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}
