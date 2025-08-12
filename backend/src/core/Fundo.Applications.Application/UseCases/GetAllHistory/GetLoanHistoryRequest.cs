using MediatR;

namespace Fundo.Applications.Application.UseCases.GetAllHistory
{
    public class GetLoanHistoryRequest : IRequest<GetLoanHistoryResponse>
    {
        public int LoanId { get; set; }
    }
}
