using Fundo.Applications.Domain.ValueObjects;

namespace Fundo.Applications.Application.UseCases.CreateLoan
{
    public sealed class CreateLoanResponse
    {        
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }
        public string ApplicantName { get; set; }
        public LoanStatus Status { get; set; }
    }
}
