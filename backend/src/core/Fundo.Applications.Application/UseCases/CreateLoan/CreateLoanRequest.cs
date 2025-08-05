using MediatR;

namespace Fundo.Applications.Application.UseCases.CreateLoan
{
    public class CreateLoanRequest : IRequest<CreateLoanResponse>
    {        
        public decimal Amount { get; set; }        
        public string ApplicantName { get; set; }
    }
}
