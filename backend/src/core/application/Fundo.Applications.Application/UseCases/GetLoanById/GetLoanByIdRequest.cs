using MediatR;

namespace Fundo.Applications.Application.UseCases.GetLoanById
{
    public class GetLoanByIdRequest : IRequest<GetLoanByIdResponse>
    {
        public int LoanId { get; set; }
    }
}
