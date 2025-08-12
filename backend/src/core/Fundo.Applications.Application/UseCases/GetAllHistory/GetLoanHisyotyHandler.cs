using AutoMapper;
using Fundo.Applications.Domain.Interfaces;
using MediatR;

namespace Fundo.Applications.Application.UseCases.GetAllHistory
{
    public class GetLoanHisyotyHandler : IRequestHandler<GetLoanHistoryRequest, GetLoanHistoryResponse>
    {
        private readonly ILoanHistoryRepository _repository;
        private readonly IMapper _mapper;

        public GetLoanHisyotyHandler(ILoanHistoryRepository loanHistoryRepository,
        IMapper mapper)
        {
            this._repository = loanHistoryRepository;
            this._mapper = mapper;
        }

        public async Task<GetLoanHistoryResponse> Handle(GetLoanHistoryRequest request, CancellationToken cancellationToken)
        {
            var loanEntity = await this._repository.GetAllByLoanId(request.LoanId, cancellationToken);
            var response = _mapper.Map<List<GetLoanHistoryItem>>(loanEntity);
            return new GetLoanHistoryResponse
            {
                History = response
            };
        }
    }
}
