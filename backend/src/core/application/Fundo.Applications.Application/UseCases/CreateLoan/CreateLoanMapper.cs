using AutoMapper;
using Fundo.Applications.Domain.Entities;

namespace Fundo.Applications.Application.UseCases.CreateLoan
{
    public class CreateLoanMapper : Profile
    {
        public CreateLoanMapper()
        {
            CreateMap<CreateLoanRequest, LoanDomain>();
            CreateMap<LoanDomain, CreateLoanResponse>();
        }
    }
}
