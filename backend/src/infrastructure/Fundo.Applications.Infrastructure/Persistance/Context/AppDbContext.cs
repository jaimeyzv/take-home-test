using Fundo.Applications.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fundo.Applications.Infrastructure.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly);
        }

        public DbSet<LoanEntity> Loans { get; set; }
    }
}
