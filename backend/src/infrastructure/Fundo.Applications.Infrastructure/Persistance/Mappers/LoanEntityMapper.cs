using AutoMapper;
using Fundo.Applications.Domain.Entities;
using Fundo.Applications.Infrastructure.Persistance.Entities;

namespace Fundo.Applications.Infrastructure.Persistance.Mappers
{
    public sealed class LoanEntityMapper : Profile
    {
        public LoanEntityMapper()
        {
            CreateMap<LoanEntity, LoanDomain>();
            CreateMap<LoanDomain, LoanEntity>();
        }
    }
}
