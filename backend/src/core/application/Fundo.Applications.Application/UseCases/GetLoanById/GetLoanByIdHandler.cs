using AutoMapper;
using Fundo.Applications.Domain.Interfaces;
using MediatR;

namespace Fundo.Applications.Application.UseCases.GetLoanById
{
    public class GetLoanByIdHandler : IRequestHandler<GetLoanByIdRequest, GetLoanByIdResponse>
    {        
        private readonly ILoanRepository _repository;
        private readonly IMapper _mapper;

        public GetLoanByIdHandler(ILoanRepository loanRepository,
            IMapper mapper) 
        {
            this._repository = loanRepository;
            this._mapper = mapper;
        }

        public async Task<GetLoanByIdResponse> Handle(GetLoanByIdRequest request, CancellationToken cancellationToken)
        {
            var loanEntity = await this._repository.GetById(request.LoanId, cancellationToken);
            var response = _mapper.Map<GetLoanByIdResponse>(loanEntity);
            return response;
        }
    }
}
