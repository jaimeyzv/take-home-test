using Fundo.Applications.Application.UseCases.CreateLoan;
using Fundo.Applications.Application.UseCases.GetAllHistory;
using Fundo.Applications.Application.UseCases.GetLoanById;
using Fundo.Applications.Application.UseCases.GetLoanList;
using Fundo.Applications.Application.UseCases.PayLoan;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fundo.Applications.Application.Services
{
    public static class ServiceExtesions
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(
                typeof(CreateLoanMapper).Assembly,
                typeof(GetLoanByIdMapper).Assembly,
                typeof(PayLoanMapper).Assembly,
                typeof(GetLoanListMapper).Assembly,
                typeof(GetLoanHistoryMapper).Assembly
                );

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
