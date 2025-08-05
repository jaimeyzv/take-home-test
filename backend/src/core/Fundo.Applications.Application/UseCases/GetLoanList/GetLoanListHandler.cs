using AutoMapper;
using Fundo.Applications.Domain.Interfaces;
using MediatR;

namespace Fundo.Applications.Application.UseCases.GetLoanList
{
    public class GetLoanListHandler : IRequestHandler<GetLoanListRequest, GetLoanListResponse>
    {        
        private readonly ILoanRepository _repository;
        private readonly IMapper _mapper;

        public GetLoanListHandler(ILoanRepository loanRepository,
            IMapper mapper) 
        {
            this._repository = loanRepository;
            this._mapper = mapper;
        }

        public async Task<GetLoanListResponse> Handle(GetLoanListRequest request, CancellationToken cancellationToken)
        {
            var entityList = await this._repository.GetAll(cancellationToken);
            var loanItems = _mapper.Map<List<GetLoanListItem>>(entityList);

            return new GetLoanListResponse
            {
                Loans = loanItems
            };
        }
    }
}
