using Fundo.Applications.Domain.Entities;

namespace Fundo.Applications.Domain.Interfaces
{
    public interface ILoanHistoryRepository
    {        
        public Task<List<LoanHistoryDomain>> GetAllByLoanId(int loanId, CancellationToken cancellationToken);
    }
}
