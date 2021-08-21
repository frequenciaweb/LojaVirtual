using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Contracts.Services;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Domain.Services.Services
{

    public class ServiceCupomCategoria : ServiceBase<CupomCategoria>, IServiceCupomCategoria
    {
        public ServiceCupomCategoria(IRepositorieCupomCategoria repo, LojaVirtualContext context) : base(repo, context)
        {

        }
    }
}
