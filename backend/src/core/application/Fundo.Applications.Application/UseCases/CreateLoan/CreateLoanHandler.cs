using AutoMapper;
using Fundo.Applications.Domain.Entities;
using Fundo.Applications.Domain.Interfaces;
using MediatR;

namespace Fundo.Applications.Application.UseCases.CreateLoan
{
    public class CreateLoanHandler : IRequestHandler<CreateLoanRequest, CreateLoanResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoanRepository _repository;
        private readonly IMapper _mapper;

        public CreateLoanHandler(IUnitOfWork unitOfWork,
            ILoanRepository loanRepository,
            IMapper mapper) 
        {
            this._unitOfWork = unitOfWork;
            this._repository = loanRepository;
            this._mapper = mapper;
        }

        public async Task<CreateLoanResponse> Handle(CreateLoanRequest request, CancellationToken cancellationToken)
        {
            var loanDomain = _mapper.Map<LoanDomain>(request);
            loanDomain.NewLoanCreation();
            await _repository.Create(loanDomain, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);
            return new CreateLoanResponse { LoanId = loanDomain.LoanId };            
        }
    }
}
