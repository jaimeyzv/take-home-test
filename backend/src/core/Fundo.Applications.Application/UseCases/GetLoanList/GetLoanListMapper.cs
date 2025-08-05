using AutoMapper;
using Fundo.Applications.Domain.Entities;

namespace Fundo.Applications.Application.UseCases.GetLoanList
{
    public class GetLoanListMapper : Profile
    {
        public GetLoanListMapper()
        {
            //CreateMap<GetLoanListRequest, LoanDomain>();
            CreateMap<LoanDomain, GetLoanListItem>();
            //CreateMap<GetLoanListItem, LoanDomain>();
        }
    }
}
