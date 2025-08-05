using AutoMapper;
using Fundo.Applications.Domain.Entities;
using Fundo.Applications.Domain.Interfaces;
using Fundo.Applications.Infrastructure.Persistance.Context;
using Fundo.Applications.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fundo.Applications.Infrastructure.Persistance.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LoanRepository(AppDbContext context,
            IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task Create(LoanDomain domain, CancellationToken cancellationToken)
        {
            var loanEntity = _mapper.Map<LoanEntity>(domain);

            _context.Loans.Add(loanEntity);
        }

        public async Task<LoanDomain?> GetById(int loanId, CancellationToken cancellationToken)
        {
            var entity = await _context
                    .Loans
                    .FirstOrDefaultAsync(x => x.LoanId == loanId, cancellationToken);

            if (entity == null) return null;

            var loanDomain = _mapper.Map<LoanDomain>(entity);

            return loanDomain;
        }

        public async Task Update(LoanDomain domain, CancellationToken cancellationToken)
        {
            var entity = await _context
                    .Loans
                    .SingleAsync(x => x.LoanId == domain.LoanId, cancellationToken);
            _context.Entry(entity).State = EntityState.Detached;
            var newEntity = _mapper.Map<LoanEntity>(domain);
            _context.Loans.Update(newEntity);
        }
    }
}
