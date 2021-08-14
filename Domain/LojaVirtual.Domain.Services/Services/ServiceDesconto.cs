using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Contracts.Services;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Domain.Services.Services
{

    public class ServiceDesconto : ServiceBase<Desconto>, IServiceDesconto
    {
        public ServiceDesconto(IRepositorieDesconto repo, LojaVirtualContext context) : base(repo, context)
        {

        }
    }
}
