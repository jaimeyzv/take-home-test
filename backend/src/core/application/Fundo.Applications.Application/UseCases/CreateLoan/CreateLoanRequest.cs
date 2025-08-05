using Fundo.Applications.Domain.ValueObjects;
using MediatR;

namespace Fundo.Applications.Application.UseCases.CreateLoan
{
    public class CreateLoanRequest : IRequest<CreateLoanResponse>
    {        
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }
        public string ApplicantName { get; set; }
        public LoanStatus Status { get; set; }

    }
}
