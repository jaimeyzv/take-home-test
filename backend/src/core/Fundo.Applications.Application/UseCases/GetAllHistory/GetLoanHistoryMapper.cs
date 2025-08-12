using AutoMapper;
using Fundo.Applications.Domain.Entities;

namespace Fundo.Applications.Application.UseCases.GetAllHistory
{
    internal class GetLoanHistoryMapper : Profile
    {
        public GetLoanHistoryMapper()
        {
            CreateMap<LoanHistoryDomain, GetLoanHistoryItem>();
        }
    }
}
