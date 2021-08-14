using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Contracts.Services;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Domain.Services.Services
{

    public class ServiceCliente : ServiceBase<Cliente>, IServiceCliente
    {
        public ServiceCliente(IRepositorieCliente repo, LojaVirtualContext context) : base(repo, context)
        {

        }
    }
}
