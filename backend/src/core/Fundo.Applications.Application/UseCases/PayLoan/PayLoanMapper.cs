using AutoMapper;
using Fundo.Applications.Domain.Entities;

namespace Fundo.Applications.Application.UseCases.PayLoan
{
    public class PayLoanMapper : Profile
    {
        public PayLoanMapper()
        {            
            CreateMap<LoanDomain, PayLoanResponse>();
            CreateMap<PayLoanRequest, LoanDomain>().ForMember(dest => dest.Amount,
            opt => opt.MapFrom(src => src.PaymentAmount));
        }
    }
}
