using Fundo.Applications.Domain.Entities;

namespace Fundo.Applications.Domain.Interfaces
{
    public interface ILoanRepository
    {
        public Task<LoanDomain?> GetById(int loanId, CancellationToken cancellationToken);        
        Task Create(LoanDomain domain, CancellationToken cancellationToken);
        Task Update(LoanDomain domain, CancellationToken cancellationToken);
    }
}
