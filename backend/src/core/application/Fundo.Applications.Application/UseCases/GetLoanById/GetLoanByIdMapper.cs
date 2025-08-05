using AutoMapper;
using Fundo.Applications.Domain.Entities;

namespace Fundo.Applications.Application.UseCases.GetLoanById
{
    public class GetLoanByIdMapper : Profile
    {
        public GetLoanByIdMapper()
        {
            CreateMap<GetLoanByIdRequest, LoanDomain>();
            CreateMap<LoanDomain, GetLoanByIdResponse>();
        }
    }
}
