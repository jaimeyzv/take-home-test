using Fundo.Applications.Domain.Entities;

namespace Fundo.Applications.Domain.Interfaces
{
    public interface ILoanRepository
    {
        public Task<LoanDomain?> GetById(int loanId, CancellationToken cancellationToken);
        public Task<List<LoanDomain>> GetAllByPaymentId(int paymentId, CancellationToken cancellationToken);
        Task Create(LoanDomain domain, CancellationToken cancellationToken);
    }
}
