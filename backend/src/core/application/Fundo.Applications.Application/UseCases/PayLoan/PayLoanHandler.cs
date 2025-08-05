using AutoMapper;
using Fundo.Applications.Domain.Entities;
using Fundo.Applications.Domain.Interfaces;
using MediatR;

namespace Fundo.Applications.Application.UseCases.PayLoan
{
    public class PayLoanHandler : IRequestHandler<PayLoanRequest, PayLoanResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoanRepository _repository;
        private readonly IMapper _mapper;

        public PayLoanHandler(IUnitOfWork unitOfWork,
            ILoanRepository loanRepository,
            IMapper mapper) 
        {
            this._unitOfWork = unitOfWork;
            this._repository = loanRepository;
            this._mapper = mapper;
        }

        public async Task<PayLoanResponse> Handle(PayLoanRequest request, CancellationToken cancellationToken)
        {
            var currectLoanEntity = await this._repository.GetById(request.LoanId, cancellationToken);
            var currecntLoanDomain = _mapper.Map<LoanDomain>(currectLoanEntity);

            currecntLoanDomain.MakePayment(request.PaymentAmount);
            
            await _repository.Update(currecntLoanDomain, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<PayLoanResponse>(currecntLoanDomain);
        }
    }
}
