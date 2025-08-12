using AutoMapper;
using Fundo.Applications.Domain.Entities;
using Fundo.Applications.Infrastructure.Persistance.Entities;

namespace Fundo.Applications.Infrastructure.Persistance.Mappers
{
    internal class LoanHistoryEntityMapper : Profile
    {
        public LoanHistoryEntityMapper()
        {
            CreateMap<LoanHistoryEntity, LoanHistoryDomain>();
            CreateMap<LoanHistoryDomain, LoanHistoryEntity>();
        }
    }
}
