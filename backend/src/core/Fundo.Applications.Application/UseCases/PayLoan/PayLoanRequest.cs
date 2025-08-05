using MediatR;

namespace Fundo.Applications.Application.UseCases.PayLoan
{
    public class PayLoanRequest : IRequest<PayLoanResponse>
    {
        public int LoanId { get; set; }
        public decimal PaymentAmount { get; set; }        
    }
}
