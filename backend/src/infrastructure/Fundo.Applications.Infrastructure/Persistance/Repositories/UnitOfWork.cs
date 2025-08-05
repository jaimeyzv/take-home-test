using Fundo.Applications.Domain.Interfaces;
using Fundo.Applications.Infrastructure.Persistance.Context;

namespace Fundo.Applications.Infrastructure.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
