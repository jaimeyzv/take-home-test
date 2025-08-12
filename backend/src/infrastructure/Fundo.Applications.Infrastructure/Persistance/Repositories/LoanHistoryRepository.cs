using AutoMapper;
using Fundo.Applications.Domain.Entities;
using Fundo.Applications.Domain.Interfaces;
using Fundo.Applications.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Fundo.Applications.Infrastructure.Persistance.Repositories
{
    public class LoanHistoryRepository : ILoanHistoryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LoanHistoryRepository(AppDbContext context,
            IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<LoanHistoryDomain>> GetAllByLoanId(int loanId, CancellationToken cancellationToken)
        {
            var entity = await _context
                   .LoanHistory
                   .Where(x => x.LoanId == loanId)
                   .ToListAsync();

            if (entity == null) return null;

            var loanDomain = _mapper.Map<List<LoanHistoryDomain>>(entity);

            return loanDomain;
        }
    }
}
